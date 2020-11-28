using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlutoCourses.Services
{
    public interface IHashingService
    {
        string Hash(string plainTxt);
    }
}