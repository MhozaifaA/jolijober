using JolijoberProject.Shared.SharedKernal.EnumClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Main.Repository.DataTransferObjects
{
    public class FilterDto
    {
        public string Title { get; set; }
        public Availabilties Availabilty { get; set; }
        public string Specification { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public string Tag { get; set; }
        public string Region { get; set; }
    }
}
