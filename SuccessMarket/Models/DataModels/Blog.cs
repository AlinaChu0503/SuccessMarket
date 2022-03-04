using System;
using System.Collections.Generic;

#nullable disable

namespace SuccessMarket.Models.DataModels
{
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string Url { get; set; }
        public int UserUserId { get; set; }

        public virtual User UserUser { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
