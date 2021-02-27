using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Core.Utilitis.Results;

namespace Core.Utilitis.Business
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var result = newPath(file);
            try
            {
                var copyFiletoTempFolder = Path.GetTempFileName();
                if (file.Length > 0)
                    using (var stream = new FileStream(copyFiletoTempFolder, FileMode.Create))
                        file.CopyTo(stream);

                File.Move(copyFiletoTempFolder, result);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result;
        }

        public static string Update(IFormFile file, string sourcePath)
        {
            var result = newPath(file);
            try
            {

                if (sourcePath.Length > 0)
                    using (var stream = new FileStream(result, FileMode.Create))
                        file.CopyTo(stream);

                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result;
        }

        public static IResult Delete(string sourcePath)
        {
            try
            {
                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();

        }
        public static string DefaultPath()
        {
            string defaultPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\defaultImage.jpg");
            return defaultPath;
        }

        public static string newPath(IFormFile file)
        {

            System.IO.FileInfo fileInfo = new System.IO.FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            var newUniqueFilename = Guid.NewGuid().ToString("N") + "_"
                + DateTime.Now.Year + "-"
                + DateTime.Now.Month + "-"
                + DateTime.Now.Day + "-"
                + DateTime.Now.Hour + "-"
                + DateTime.Now.Minute + "-"
                + DateTime.Now.Second + "-"
                + DateTime.Now.Millisecond
                + fileExtension;

            string savedPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            string savedFullPath = $@"{savedPath}\{newUniqueFilename}";

            return savedFullPath;
        }



    }
}
