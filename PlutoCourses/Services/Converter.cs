using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PlutoCourses.Services
{
    public static class Converter
    {
        public static string ConvertToHexa(string txt)
        {
            StringBuilder result = new StringBuilder();
            foreach(byte c in txt)
            {
                result.Append(c.ToString("x2"));
            }
            return result.ToString();
        }
    }
}