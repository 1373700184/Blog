using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{

    /// <summary>
    /// 评论
    /// </summary>
    public class Comment
    {
        [Key] //主键 
        public int PKid { get; set; }

        /// <summary>
        /// 谁的（UserInfo）
        /// </summary>
        public int Uid { get; set; }
        public int Bid { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 星级（推荐度1-10）
        /// </summary>
        public int Star { get; set; }

        /// <summary>
        /// 状态 0 正常 -1删除
        /// </summary>
        public int Status { get; set; }

        public DateTime UpdateTime { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}
