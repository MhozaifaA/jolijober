using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jolijober.Util.Translate
{
    public interface IAppTranslate
    {
        IReadOnlyDictionary<string, string> Translate { get; }
        string Language { get; set; }
        string this[string i] { get; }
        //public string this[string i,bool isi=true]
        //{
        //    get {  return isi?i:Translate.GetValueOrDefault(i) ?? i; }
        //}
    }
}
