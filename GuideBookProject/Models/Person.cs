using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuideBookProject.Models
{
    public class Person
    {
        [Key]
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

        // one person can have many communication infos
        ICollection<CommInfo> CommInfos { get; set; }
    }
}
