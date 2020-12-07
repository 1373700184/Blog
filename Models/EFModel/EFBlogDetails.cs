using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.EFModel
{
    public class EFBlogDetails
    {
        public Bloger Blog { get; set; }
        public List<Comment> BlogComments { get; set; }
    }
}
