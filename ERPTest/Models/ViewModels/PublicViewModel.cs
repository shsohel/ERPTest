using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPTest.Models.ViewModels
{
    public class PublicViewModel
    {
        public List<BuyerPersonalInfo> lstBuyerPersonalInfos { get; set; }
        public List<BuyerContactInfo> lstBuyerContactInfos { get; set; }
        public List<Color> lstColors { get; set; }
        public List<Currency> lstCurrencies { get; set; }
        public List<Size> lstSizes { get; set; }
    }
}
