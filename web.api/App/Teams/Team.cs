using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using web.api.App.Users;

namespace web.api.App.Teams
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int OwnerUserId { get; set; }

        [ForeignKey("OwnerUserId")] public User Owner { get; set; }

        public ICollection<User> Members { get; set; }
    }
}