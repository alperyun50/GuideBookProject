using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuideBookProject.Models
{
    public class CommInfo
    {
        [Key]
        public int CommInfoID { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        // FKey
        public int UserID { get; set; }

        public Person Person { get; set; }
    }
}
