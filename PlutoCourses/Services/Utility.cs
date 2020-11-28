using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PlutoCourses.Services
{
    public static class Utility
    {
        public static string SaveImage(HttpPostedFileBase img, HttpContextBase context)
        {
            string imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(img.FileName);
            string serverPath = context.Server.MapPath("~/Content/Images");
            img.SaveAs(Path.Combine(serverPath, imageName));
            return imageName;
        }
    }
}