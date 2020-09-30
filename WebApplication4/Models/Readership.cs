using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Readership
    {
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("View")]
        public int view { get; set; }

        [DisplayName("Report Id")]
        public int reportId { get; set; }

        [DisplayName("User Id")]
        public int userId { get; set; }

        [DisplayName("Last Access Time")]
        public DateTime lastAccessTime { get; set; }

        public Report report { get; set; }

        public User User { get; set; }
    }
}
