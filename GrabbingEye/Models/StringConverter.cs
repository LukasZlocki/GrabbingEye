using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabbingEye.Models
{
    class StringConverter
    {

/// <summary>
/// String converter
/// </summary>
/// <param name="toRepleace">string with signs to repleace</param>
/// <param name="stringToCut">sign which need to be repleaced</param>
/// <returns></returns>
        public string RepleaceString(string toRepleace, string stringToCut)
        {
            string _newString = "";
            _newString = toRepleace.Replace(stringToCut, "");
            return (_newString);
        }


    }
}
