using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class UserInfo
    {
        [Key] //主键 
        public int Id { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>

        public string Username { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Realname { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 电话号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 座机
        /// </summary>
        public string Line_phone { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
       
        public string Remark { get; set; }

        /// <summary>
        /// 状态 0 正常 -1删除
        /// </summary>
        public int Status { get; set; }

        public DateTime UpdateTime { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        

    }
}
