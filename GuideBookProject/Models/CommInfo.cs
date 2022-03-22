using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuideBookProject.Models
{
    public class CommInfo
    {
        [Key]
        public int CommInfoID { get; set; }

        [Column(TypeName = "VarChar(40)")]
        public string Email { get; set; }

        [Column(TypeName = "VarChar(30)")]
        public string Location { get; set; }

        public bool Status { get; set; }

        // FKey
        public int UserID { get; set; }

        public Person Person { get; set; }
    }
}
