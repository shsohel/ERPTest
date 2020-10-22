using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPTest.Context;
using ERPTest.Models;
using ERPTest.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERPTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly AttributeDbContext attributeDbContext;
        private readonly BuyerDbContext buyerDbContext;

        public PublicController(BuyerDbContext buyerDbContext, AttributeDbContext attributeDbContext)
        {
            this.buyerDbContext = buyerDbContext;
            this.attributeDbContext = attributeDbContext;
        }


        //GET ALL TABLE DATA as a List
        [HttpGet]
        public async Task<ActionResult<PublicViewModel>> GetPublicData()
        {
            try
            {
                var buyerPersonalInfos = await buyerDbContext.BuyerPersonalInfos.ToListAsync();
                var buyerContactInfos = await buyerDbContext.BuyerContactInfos.ToListAsync();

                var colors = await attributeDbContext.Colors.ToListAsync();
                var currencies = await attributeDbContext.Currencies.ToListAsync();
                var sizes = await attributeDbContext.Sizes.ToListAsync();

                PublicViewModel publicViewModel = new PublicViewModel
                {
                    lstBuyerContactInfos = buyerContactInfos,
                    lstBuyerPersonalInfos = buyerPersonalInfos,
                    lstColors = colors,
                    lstCurrencies = currencies,
                    lstSizes = sizes,
                };
                return publicViewModel;
            }
            catch (Exception e)
            {
                throw e;
            }          
        }

    }
}
