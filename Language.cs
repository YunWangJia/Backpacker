using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Backpacker
{
    [Serializable]
    public class Language
    {
        public string LanguageType;
        public string Author;
        public string Version;
        public int fontSize;
        public Language() { }

        public Dictionary<string, string> Lib = new Dictionary<string, string>()
        {
           
        };
        
    }

}
