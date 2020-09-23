using JolijoberProject.Shared.SharedKernal.EnumClass;
using JolijoberProject.Shared.SharedKernal.SharedModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JolijoberProject.Shared.SharedKernal.ExtensionMethod;
namespace Jolijober.ViewModel
{
    public class PostViewModel
    {
        public DateTime Date { get; set; }///used
        [Required(ErrorMessage ="لايمكن للعنوان ان يكون فارغا")]
        public string Title { get; set; } ///used
      //  public MinMax Sallaries { get; set; } = new MinMax(); ///used //object max min

        [Range(0,double.MaxValue,ErrorMessage ="لايمكن ادخال راتب سالب")]
        public double MinSallary { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "لايمكن ادخال راتب سالب")]

        public double MaxSallary { get;  set; }

        public Availabilties Availabilty { get; set; }
        public string Descreption { get; set; } ///used

        public List<TagsSelect> Tags = JolijoberExtensions.NewTagsSelect();
        public string Specification { get; set; } ///used  //Epic Coder
        public string Region { get; set; }///used 


        public PostTypes PostType { get; set; } ///used




        //public MinMax Hours { get; set; }//max min
        //public string KindPay { get; set; } //object max min
        //public string[] Skills { get; set; } = new string[] { };

        //public string[] Categories { get; set; } = new string[] { }; // collection  like sofware en

    }
}
