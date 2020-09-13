using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jolijober.Util.Translate
{
    public interface IAppTranslate
    {
        IReadOnlyDictionary<string, string> Translate { get; }

        public string this[string i]
        {
            get { return Translate[i]; }
        }
    }
}
