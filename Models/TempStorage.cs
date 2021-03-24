using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public static class TempStorage
    {
        private static List<Response> applications = new List<Response>();

        public static IEnumerable<Response> Applications => applications;

        public static void AddApplication(Response application)
        {
           
                applications.Add(application);
            
        }
    }
}
