using System;
using System.Data;

namespace prySp2._1_Lab2
{
    static class DataStore
    {
        public static DataTable Cantantes { get; private set; }
        public static DataTable Temas { get; private set; }

        static DataStore()
        {
            Initialize();
        }

        public static void Initialize()
        {
            Cantantes = new DataTable("Cantantes");
            var idCant = new DataColumn("IdCantante", typeof(int)) { AutoIncrement = true, AutoIncrementSeed = 1 };
            Cantantes.Columns.Add(idCant);
            Cantantes.Columns.Add("Numero", typeof(int));
            Cantantes.Columns.Add("Nombre", typeof(string));
            Cantantes.PrimaryKey = new[] { idCant };

            Temas = new DataTable("Temas");
            var idTema = new DataColumn("IdTema", typeof(int)) { AutoIncrement = true, AutoIncrementSeed = 1 };
            Temas.Columns.Add(idTema);
            Temas.Columns.Add("Numero", typeof(int));
            Temas.Columns.Add("Nombre", typeof(string));
            Temas.Columns.Add("UrlVideo", typeof(string));
            Temas.Columns.Add("IdCantante", typeof(int));
            Temas.PrimaryKey = new[] { idTema };
        }

        public static bool CantanteNumeroExists(int numero)
        {
            foreach (DataRow r in Cantantes.Rows)
            {
                if (r.Field<int>("Numero") == numero) return true;
            }
            return false;
        }

        public static void AddCantante(int numero, string nombre)
        {
            var row = Cantantes.NewRow();
            row["Numero"] = numero;
            row["Nombre"] = nombre;
            Cantantes.Rows.Add(row);
        }

        public static bool TemaNumeroExists(int numero)
        {
            foreach (DataRow r in Temas.Rows)
            {
                if (r.Field<int>("Numero") == numero) return true;
            }
            return false;
        }

        public static void AddTema(int numero, string nombre, string urlVideo, int idCantante)
        {
            var row = Temas.NewRow();
            row["Numero"] = numero;
            row["Nombre"] = nombre;
            row["UrlVideo"] = urlVideo;
            row["IdCantante"] = idCantante;
            Temas.Rows.Add(row);
        }

        public static DataRow[] GetTemasByCantante(int idCantante)
        {
            return Temas.Select($"IdCantante = {idCantante}");
        }
    }
}
