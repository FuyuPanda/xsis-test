using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsis.Api.Model.Movies
{
    public class InsertMovieModel
    {
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public decimal rating { get; set; }
        public string image { get; set; } = string.Empty;
    }
}
