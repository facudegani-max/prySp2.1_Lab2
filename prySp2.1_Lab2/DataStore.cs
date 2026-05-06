using System;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace prySp2._1_Lab2
{
    static class DataStore
    {
        public static DataTable Cantantes { get; private set; }
        public static DataTable Temas { get; private set; }
        private static string _connectionString;
        private static bool _useDb = false;
        public static string CantantesIdColumnName { get; private set; } = "IdCantante";
        public static string TemasIdColumnName { get; private set; } = "IdTema";

        static DataStore()
        {
            Initialize();
        }

        public static void Initialize()
        {
            // Inicializa estructuras en memoria
            Cantantes = new DataTable("Cantantes");
            Temas = new DataTable("Temas");

            // Buscar archivo de Access en la carpeta de la aplicación o en una carpeta llamada "Base Datos"
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string dbFile = null;

            // Buscar carpeta "Base Datos" en el directorio actual y en padres (hasta 5 niveles)
            var current = baseDir;
            for (int i = 0; i < 6 && !string.IsNullOrEmpty(current); i++)
            {
                var candidateDir = Path.Combine(current, "Base Datos");
                if (Directory.Exists(candidateDir))
                {
                    dbFile = Directory.GetFiles(candidateDir, "*.accdb").FirstOrDefault() ?? Directory.GetFiles(candidateDir, "*.mdb").FirstOrDefault();
                    if (!string.IsNullOrEmpty(dbFile)) break;
                }
                var parent = Directory.GetParent(current);
                current = parent?.FullName;
            }

            // Si no se encontró, buscar en todos los subdirectorios del bin
            if (string.IsNullOrEmpty(dbFile))
            {
                var accdb = Directory.GetFiles(baseDir, "*.accdb", SearchOption.AllDirectories).FirstOrDefault();
                var mdb = Directory.GetFiles(baseDir, "*.mdb", SearchOption.AllDirectories).FirstOrDefault();
                dbFile = accdb ?? mdb;
            }

            if (!string.IsNullOrEmpty(dbFile))
            {
                // Intentar usar provider ACE, si falla se usa modo en memoria
                _connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbFile};Persist Security Info=False;";
                try
                {
                    LoadFromDatabase();
                    _useDb = true;
                    return;
                }
                catch
                {
                    // fallback a DataTable en memoria
                    _useDb = false;
                }
            }

            // Estructura mínima en memoria si no hay DB disponible
            var idCant = new DataColumn("IdCantante", typeof(int)) { AutoIncrement = true, AutoIncrementSeed = 1 };
            Cantantes.Columns.Add(idCant);
            Cantantes.Columns.Add("Numero", typeof(int));
            Cantantes.Columns.Add("Nombre", typeof(string));
            Cantantes.PrimaryKey = new[] { idCant };

            var idTema = new DataColumn("IdTema", typeof(int)) { AutoIncrement = true, AutoIncrementSeed = 1 };
            Temas.Columns.Add(idTema);
            Temas.Columns.Add("Numero", typeof(int));
            Temas.Columns.Add("Nombre", typeof(string));
            Temas.Columns.Add("UrlVideo", typeof(string));
            Temas.Columns.Add("IdCantante", typeof(int));
            Temas.PrimaryKey = new[] { idTema };
        }

        private static void LoadFromDatabase()
        {
            using var conn = new OleDbConnection(_connectionString);
            conn.Open();

            // Cargar Cantantes
            using (var da = new OleDbDataAdapter("SELECT * FROM Cantantes", conn))
            {
                Cantantes.Clear();
                da.Fill(Cantantes);
            }
            var cantIdCol = FindColumnName(Cantantes, "IdCantante") ?? FindColumnName(Cantantes, "idCantante");
            if (!string.IsNullOrEmpty(cantIdCol))
            {
                Cantantes.PrimaryKey = new[] { Cantantes.Columns[cantIdCol] };
                CantantesIdColumnName = cantIdCol;
            }

            // Cargar Temas
            using (var da = new OleDbDataAdapter("SELECT * FROM Temas", conn))
            {
                Temas.Clear();
                da.Fill(Temas);
            }
            var temaIdCol = FindColumnName(Temas, "IdTema") ?? FindColumnName(Temas, "idTema");
            if (!string.IsNullOrEmpty(temaIdCol))
            {
                Temas.PrimaryKey = new[] { Temas.Columns[temaIdCol] };
                TemasIdColumnName = temaIdCol;
            }
        }

        private static string FindColumnName(DataTable dt, string name)
        {
            if (dt == null) return null;
            foreach (DataColumn c in dt.Columns)
            {
                if (string.Equals(c.ColumnName, name, StringComparison.OrdinalIgnoreCase)) return c.ColumnName;
            }
            return null;
        }

        public static bool CantanteNumeroExists(int numero)
        {
            // Buscar en la tabla cargada en memoria
            foreach (DataRow r in Cantantes.Rows)
            {
                if (r.IsNull("Numero")) continue;
                if (Convert.ToInt32(r["Numero"]) == numero) return true;
            }
            return false;
        }

        public static void AddCantante(int numero, string nombre)
        {
            if (_useDb)
            {
                try
                {
                    using var conn = new OleDbConnection(_connectionString);
                    conn.Open();
                    using var cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Cantantes (Numero, Nombre) VALUES (?, ?);";
                    cmd.Parameters.AddWithValue("?", numero);
                    cmd.Parameters.AddWithValue("?", nombre);
                    cmd.ExecuteNonQuery();
                    // Obtener identity
                    cmd.CommandText = "SELECT @@IDENTITY";
                    var idObj = cmd.ExecuteScalar();
                    int id = Convert.ToInt32(idObj);

                var row = Cantantes.NewRow();
                if (!string.IsNullOrEmpty(CantantesIdColumnName) && Cantantes.Columns.Contains(CantantesIdColumnName)) row[CantantesIdColumnName] = id;
                row["Numero"] = numero;
                row["Nombre"] = nombre;
                Cantantes.Rows.Add(row);
                    return;
                }
                catch (Exception ex)
                {
                    // Si falla la escritura en la DB, desactivar el modo DB y agregar en memoria
                    _useDb = false;
                    MessageBox.Show($"No se pudo guardar en la base de datos. Se guardará temporalmente en memoria.\nDetalles: {ex.Message}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            var r = Cantantes.NewRow();
            r["Numero"] = numero;
            r["Nombre"] = nombre;
            Cantantes.Rows.Add(r);
        }

        public static bool TemaNumeroExists(int numero)
        {
            foreach (DataRow r in Temas.Rows)
            {
                if (r.IsNull("Numero")) continue;
                if (Convert.ToInt32(r["Numero"]) == numero) return true;
            }
            return false;
        }

        public static void AddTema(int numero, string nombre, string urlVideo, int idCantante)
        {
            if (_useDb)
            {
                try
                {
                    using var conn = new OleDbConnection(_connectionString);
                    conn.Open();
                    using var cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Temas (Numero, Nombre, UrlVideo, IdCantante) VALUES (?, ?, ?, ?);";
                    cmd.Parameters.AddWithValue("?", numero);
                    cmd.Parameters.AddWithValue("?", nombre);
                    cmd.Parameters.AddWithValue("?", urlVideo);
                    cmd.Parameters.AddWithValue("?", idCantante);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT @@IDENTITY";
                    var idObj = cmd.ExecuteScalar();
                    int id = Convert.ToInt32(idObj);

                var row = Temas.NewRow();
                if (!string.IsNullOrEmpty(TemasIdColumnName) && Temas.Columns.Contains(TemasIdColumnName)) row[TemasIdColumnName] = id;
                row["Numero"] = numero;
                row["Nombre"] = nombre;
                row["UrlVideo"] = urlVideo;
                row["IdCantante"] = idCantante;
                Temas.Rows.Add(row);
                    return;
                }
                catch (Exception ex)
                {
                    _useDb = false;
                    MessageBox.Show($"No se pudo guardar el tema en la base de datos. Se guardará temporalmente en memoria.\nDetalles: {ex.Message}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            var r = Temas.NewRow();
            r["Numero"] = numero;
            r["Nombre"] = nombre;
            r["UrlVideo"] = urlVideo;
            r["IdCantante"] = idCantante;
            Temas.Rows.Add(r);
        }

        public static DataRow[] GetTemasByCantante(int idCantante)
        {
            return Temas.Select($"IdCantante = {idCantante}");
        }
    }
}
