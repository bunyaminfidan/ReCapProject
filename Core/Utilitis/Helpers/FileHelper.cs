using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Core.Utilitis.Results;

namespace Core.Utilitis.Business.Helpers
{
    public class FileHelper
    {
        //public static string Add(IFormFile file)
        //{
        //    var result = newPath(file);
        //    try
        //    {
        //        var copyFiletoTempFolder = Path.GetTempFileName();
        //        if (file.Length > 0)
        //            using (var stream = new FileStream(copyFiletoTempFolder, FileMode.Create))
        //                file.CopyTo(stream);

        //        File.Move(copyFiletoTempFolder, result);
        //    }
        //    catch (Exception exception)
        //    {
        //        return exception.Message;
        //    }
        //    return result;
        //}

        //public static string Update(IFormFile file, string sourcePath)
        //{
        //    var result = newPath(file);
        //    try
        //    {

        //        if (sourcePath.Length > 0)
        //            using (var stream = new FileStream(result, FileMode.Create))
        //                file.CopyTo(stream);

        //        File.Delete(sourcePath);
        //    }
        //    catch (Exception exception)
        //    {
        //        return exception.Message;
        //    }
        //    return result;
        //}

        //public static IResult Delete(string sourcePath)
        //{
        //    try
        //    {
        //        File.Delete(sourcePath);
        //    }
        //    catch (Exception exception)
        //    {
        //        return new ErrorResult(exception.Message);
        //    }
        //    return new SuccessResult();

        //}
        //public static string DefaultPath()
        //{
        //    string defaultPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\defaultImage.jpg");
        //    return defaultPath;
        //}
        //public static string newPath(IFormFile file)
        //{

        //    FileInfo ff = new FileInfo(file.FileName);
        //    string fileExtension = ff.Extension;


        //    string path = Environment.CurrentDirectory + @"\wwwroot\Images";
        //    //var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;

        //    var newUniqueFilename = Guid.NewGuid().ToString("N") + "_"
        //        + DateTime.Now.Year + "-"
        //        + DateTime.Now.Month + "-"
        //        + DateTime.Now.Day + "-"
        //        + DateTime.Now.Hour + "-"
        //        + DateTime.Now.Minute + "-"
        //        + DateTime.Now.Second + "-"
        //        + DateTime.Now.Millisecond
        //        + fileExtension;


        //    string result = $@"{newUniqueFilename}";
        //    return result;

        //    string result = $@"{path}\{newPath}";

        //    return result;


        //}
        ////public static string newPath(IFormFile file)
        ////{

        ////    System.IO.FileInfo fileInfo = new System.IO.FileInfo(file.FileName);
        ////    string fileExtension = fileInfo.Extension;

        ////    var newUniqueFilename = Guid.NewGuid().ToString("N") + "_"
        ////        + DateTime.Now.Year + "-"
        ////        + DateTime.Now.Month + "-"
        ////        + DateTime.Now.Day + "-"
        ////        + DateTime.Now.Hour + "-"
        ////        + DateTime.Now.Minute + "-"
        ////        + DateTime.Now.Second + "-"
        ////        + DateTime.Now.Millisecond
        ////        + fileExtension;

        ////    string savedPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

        ////    string savedFullPath = $@"{savedPath}\{newUniqueFilename}";

        ////    return savedFullPath;
        ////}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
            public static string Add(IFormFile file)
            {
                var result = newPath(file);
                try
                {
                    var sourcePath = Path.GetTempFileName();
                    if (file.Length > 0)
                        using (var stream = new FileStream(sourcePath, FileMode.Create))
                            file.CopyTo(stream);
                    File.Move(sourcePath, result.newPath);
                }
                catch (Exception exception)
                {
                    return exception.Message;
                }
                return result.Path2;
            }

            public static string Update(string sourcePath, IFormFile file)
            {
                var result = newPath(file);
                try
                {
                    if (sourcePath.Length > 0)
                    {
                        using (var stream = new FileStream(result.newPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                    File.Delete(sourcePath);
                }
                catch (Exception exception)
                {
                    return exception.Message;
                }
                return result.Path2;
            }

            public static IResult Delete(string path)
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception exception)
                {
                    return new ErrorResult(exception.Message);
                }

                return new SuccessResult();
            }

            public static (string newPath, string Path2) newPath(IFormFile file)
            {
                FileInfo ff = new FileInfo(file.FileName);
                string fileExtension = ff.Extension;

                var newPath = Guid.NewGuid() + fileExtension;


                string path = Environment.CurrentDirectory + @"\wwwroot\Images";

                string result = $@"{path}\{newPath}";

                return (result, $"\\Images\\{newPath}");
            }
        }
    }





