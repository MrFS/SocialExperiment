using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Administration.Olympus
{
    public static class About
    {
        /// <summary>
        /// Setter tittelen til Administrasjon/Olympus prosjektet
        /// Legg dette til i databasen, slik at tittelen blir hentet derfra.
        /// </summary>
        /// <returns>Tittelen til Olympus(Administrasjon) (TODO: Hent fra database)</returns>
        public static string olympusTitle()
        {
            return "SocialExperiment - Olympus";
        }
    }
}
