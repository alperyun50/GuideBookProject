using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuideBookProject.Models
{
    public class Person
    {
        [Key]
        public int UserID { get; set; }

        [Column(TypeName = "VarChar(20)")]
        public string Name { get; set; }

        [Column(TypeName = "VarChar(20)")]
        public string Surname { get; set; }

        [Column(TypeName = "VarChar(20)")]
        public string Company { get; set; }

        // one person can has many communication infos
        ICollection<CommInfo> CommInfos { get; set; }

        public bool Status { get; set; }
    }
}
