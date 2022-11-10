using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFCoreNullReferenceException
{
    public class Call
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }

        public ICollection<User> FollowUpUsers { get; set; }
        public ICollection<User> CCUsers { get; set; }
        public virtual ICollection<CCUserCallJoin> CCUserCallJoins { get; set; }
        public virtual ICollection<FollowUpUserCallJoin> FollowUpUserCallJoins { get; set; }
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public virtual ICollection<Call> Calls { get; set; } //we don't really need this property but it makes the many-to-many mapping happy
        public virtual ICollection<CCUserCallJoin> CCUserCallJoins { get; set; }
        public virtual ICollection<FollowUpUserCallJoin> FollowUpUserCallJoins { get; set; }
    }

    public class CCUserCallJoin
    {
        public User User { get; set; }
        public Call Call { get; set; }
    }

    public class FollowUpUserCallJoin
    {
        public User User { get; set; }
        public Call Call { get; set; }
    }
}
