using JolijoberProject.Shared.SharedKernal.EnumClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jolijober.ViewModel
{
    public class FilterViewModel
    {
        public string Title { get; set; }

        private Availabilties _Availabilty;
        public Availabilties Availabilty
        {
            get { return _Availabilty; }
            set { _Availabilty = value; }
        }

        public string Specification { get; set; }
        public  double Min { get; set; }
        public  double Max { get; set; }
        public string Tag { get; set; }
        public string Region { get; set; }
    }
}
