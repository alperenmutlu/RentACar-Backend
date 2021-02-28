using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        private static string sourcepath = Environment.CurrentDirectory + "\\wwwroot";
        private static string path = "\\images\\";
        private static string guidName = null;
        private static string type = null;
        public static IResult Add(IFormFile file)
        {
            if (file.Length > 0)
            {

                guidName = Guid.NewGuid().ToString();
                type = Path.GetExtension(file.FileName);


                using (FileStream fs = File.Create(sourcepath + path + guidName + type))
                {
                    file.CopyTo(fs);
                    fs.Flush();

                }
                return new SuccessResult((guidName + type));
            }
            return new ErrorResult();

        }
        public static IResult Delete(string imagePath)
        {
            File.Delete(sourcepath + path + imagePath);
            return new SuccessResult();
        }
        public static IResult Update(IFormFile file, string sourcePath)
        {
            if (file.Length > 0)
            {
                guidName = Guid.NewGuid().ToString();
                type = Path.GetExtension(file.FileName);
                File.Delete(sourcepath + path + sourcePath);
                using (FileStream fs = File.Create(sourcepath + path + guidName + type))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                return new SuccessResult((guidName + type));
            }
            return new ErrorResult();
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
            string result = $@"{newPath}";
            return result;
        }
    }
}
