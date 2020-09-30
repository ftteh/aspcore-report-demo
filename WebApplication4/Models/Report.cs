using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Report
    {
        [DisplayName("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [DisplayName("Title")]
        public string title { get; set; }

        [DisplayName("Uploader Id")]
        public int uploaderId { get; set; }

        [DisplayName("File")]
        public byte[] DataFiles { get; set; }

        [DisplayName("Uploaded Time")]
        public DateTime uploadedTime { get; set; }

        public ICollection<Readership> Readerships{ get; set; }
    }
}
