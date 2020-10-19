using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPTest.Models
{
    public class BuyerContactInfo
    {
        public int Id { get; set; }
        public Guid BuyerContactNo { get; set; }
        public int BuyerId { get; set; }
        public string  PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddressDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
