using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    /// <summary>
    /// Blog 内容细节
    /// </summary>
    public class Bloger
    {
        [Key] //主键 
        public int PKid { get; set; }

        /// <summary>
        /// 谁的（UserInfo）
        /// </summary>
        public int Uid { get; set; }

        /// <summary>
        /// 背景大图
        /// </summary>
        public string Backpic { get; set; }

        /// <summary>
        /// 小标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 概叙
        /// </summary>
        public string Briefly { get; set; }

        /// <summary>
        /// 内容（包含图片文字）
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 内容类别（Mix）
        /// </summary>
        public string Mid { get; set; }

        /// <summary>
        /// 状态 0 正常 -1删除
        /// </summary>
        public int Status { get; set; }

        public DateTime UpdateTime { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime? DeleteTime { get; set; }

    }
}
