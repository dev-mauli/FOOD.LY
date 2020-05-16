﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FOOD.LY
{
    /// <summary>
    /// Summary description for fileUploader
    /// </summary>
    public class fileUploader : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                string dirFullPath = HttpContext.Current.Server.MapPath("~/Upload/");
                string[] files;
                int numFiles;
                files = System.IO.Directory.GetFiles(dirFullPath);
                numFiles = files.Length;
                numFiles = numFiles + 1;
                string str_image = "";
                string FilePath = "";

                foreach (string s in context.Request.Files)
                {
                    HttpPostedFile file = context.Request.Files[s];
                    string fileName = file.FileName;
                    string fileExtension = file.ContentType;

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        fileExtension = Path.GetExtension(fileName);
                        str_image = fileName + numFiles.ToString() + fileExtension;
                        string pathToSave_100 = HttpContext.Current.Server.MapPath("~/Upload/") + str_image;
                        file.SaveAs(pathToSave_100);
                        FilePath = "../Upload/" + str_image;

                    }
                }
                context.Response.Write(FilePath);
            }
            catch (Exception ac)
            {
                ac.ToString();
            }
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}