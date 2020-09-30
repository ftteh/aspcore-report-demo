using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class User
    {
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("Username")]
        public string username { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DisplayName("Role")]
        public string role { get; set; }

        public ICollection<Readership> Readerships { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
