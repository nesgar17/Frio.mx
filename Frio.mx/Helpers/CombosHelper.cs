namespace Frio.mx.Helpers
{
    using Frio.mx.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class CombosHelper : IDisposable
    {
        public static DataContext db = new DataContext();

        public static List<Torneo> GetTorneos()
        {
            var torneo = db.Torneos.ToList();
            torneo.Add(new Torneo
            {
                TorneoId = 0,
                Nombre = "[--Selecciona un Torno--]"
            });

            return torneo.OrderBy(t => t.Nombre).ToList();
        }



        public void Dispose()
        {
            db.Dispose();
        }
    }
}