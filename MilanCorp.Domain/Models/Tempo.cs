using System;
using System.Collections.Generic;
using System.Text;

namespace MilanCorp.Domain.Models
{
    public class Tempo
    {
        public int temperature { get; set; }
        public string wind_direction { get; set; }
        public int wind_velocity { get; set; }
        public int humidity { get; set; }
        public string condition { get; set; }
        public int pressure { get; set; }
        public string icon { get; set; }
        public int sensation { get; set; }
        public string date { get; set; }
    }

}
