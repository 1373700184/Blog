using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Mix
    {
        [Key] //主键
        public int PKID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string MixNo { get; set; }


        /// <summary>
        /// 名称
        /// </summary>
        public string MixName { get; set; }

        /// <summary>
        /// 上一级的Id
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 上一级的名称
        /// </summary>
        public string ParentName { get; set; }
        
        /// <summary>
        /// 等级
        /// </summary>
        public int MixLevel { get; set; }

        /// <summary>
        /// 允许添加下一级
        /// </summary>
        public bool Allowadd { get; set; }

        /// <summary>
        /// 允许被编辑
        /// </summary>
        public bool Allowedit { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreatorId { get; set; }


        /// <summary>
        /// 状态 0 正常 -1删除
        /// </summary>
        public int Status { get; set; }

        public DateTime UpdateTime { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime? DeleteTime { get; set; }

    }
}
