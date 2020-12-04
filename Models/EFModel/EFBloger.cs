using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class EFBloger:Bloger
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Uname { get; set; }

        /// <summary>
        /// 类型名
        /// </summary>
        public string Mname { get; set; }


        public string Datestr { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public string Commentcount { get; set; }


    }
}
