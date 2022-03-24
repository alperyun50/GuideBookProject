using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideBookProject.Models
{
    public class CommInfoDTO
    {
        public string Email { get; set; }

        public string Location { get; set; }

        public string TelNo { get; set; }

        // FKey
        public int PersonID { get; set; }

        public bool Status { get; set; } = true;
    }
}
