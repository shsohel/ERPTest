using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPTest.Models.ViewModels
{
    public class SizeViewModel
    {
        public int? Id { get; set; }
        public Guid SizeNo { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
