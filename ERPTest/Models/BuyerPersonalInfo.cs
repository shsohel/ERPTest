using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPTest.Models
{
    public class BuyerPersonalInfo
    {
        public int Id { get; set; }
        public Guid BuyerNo { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string OrganizationTaxId { get; set; }
        public string Position { get; set; }
        public bool? IsOwner { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<BuyerContactInfo> BuyerContactInfos { get; set; }
    }
}
