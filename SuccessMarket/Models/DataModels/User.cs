using System;
using System.Collections.Generic;

#nullable disable

namespace SuccessMarket.Models.DataModels
{
    public partial class User
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
