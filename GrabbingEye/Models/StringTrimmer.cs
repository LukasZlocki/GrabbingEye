using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabbingEye.Models
{
    class StringTrimmer
    {
        private static string TRIM_STRING_1 = "&nbsp;";
        private static string TRIM_STRING_2 = ",";


        public string StringTrimm(string stringToTrimm)
        {
            string _trimmedString = "";
            _trimmedString = stringToTrimm.Replace(TRIM_STRING_1, "");
            _trimmedString = _trimmedString.Replace(TRIM_STRING_2, "");

            return (_trimmedString);
        }

    }
}
