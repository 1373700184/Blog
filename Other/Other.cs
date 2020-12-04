using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Other
{
    public class Other
    {
        public static string UpFile(IFormFile file)
        {
            if (System.IO.Directory.Exists("/upload/bgpic") == false)//如果不存在就创建images文件夹
            {
                System.IO.Directory.CreateDirectory("./upload/bgpic");
            }
            string extName = Path.GetExtension(file.FileName).ToLower();

            string path = "./upload/bgpic";

            string fileNewName = Guid.NewGuid().ToString();
            string ImageUrl = path + fileNewName + extName;

            using (var stream = new FileStream(ImageUrl, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            return ImageUrl;
        }
    }
}
