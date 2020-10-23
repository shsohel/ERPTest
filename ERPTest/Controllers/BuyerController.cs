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
    public class BuyerController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";

        private readonly BuyerDbContext _bContext;

        public BuyerController(BuyerDbContext bcontext)
        {
            _bContext = bcontext;
        }

        //Start GET Buyer Personal Info Table Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyerPersonalInfoViewModel>>> GetBuyerPersonalInfos()
        {
            try
            {
                IEnumerable<BuyerPersonalInfo> buyerPersonalInfos = await _bContext.BuyerPersonalInfos.ToListAsync();
                List<BuyerPersonalInfoViewModel> buyerPersonalInfoViewModels = new List<BuyerPersonalInfoViewModel>();
                if (buyerPersonalInfos != null)
                {
                    foreach (BuyerPersonalInfo buyerPersonalInfo in buyerPersonalInfos)
                    {
                        buyerPersonalInfoViewModels.Add(assignDataBuyerViewModel(buyerPersonalInfo));
                    }
                    return Ok(new { status = 200, obj = buyerPersonalInfoViewModels, message = " The Buyer data retrive successfully." });
                }
                else
                {
                    return BadRequest(new { status = 404, message = message });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BuyerPersonalInfoViewModel>> GetBuyerPersonalInfo(int id)
        {
            try
            {
                if (id > 0)
                {
                    BuyerPersonalInfo buyerPersonalInfo = await _bContext.BuyerPersonalInfos.FindAsync(id);
                    if (buyerPersonalInfo != null)
                    {
                        return Ok(new { status = 200, obj = assignDataBuyerViewModel(buyerPersonalInfo), message = id + " : The Buyer data retrive successfully." });
                    }
                    else
                    {
                        return BadRequest(new { status = 404, message = id + " is not found" });
                    }
                }
                else
                {
                    return BadRequest(new { status = 404, message = message });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public BuyerPersonalInfoViewModel assignDataBuyerViewModel(BuyerPersonalInfo model)
        {
            BuyerPersonalInfoViewModel buyerPersonalInfoViewModel = new BuyerPersonalInfoViewModel
            {
                Id = model.Id,
                BuyerNo = model.BuyerNo,
                Name = model.Name,
                Organization = model.Organization,
                OrganizationTaxId = model.OrganizationTaxId,
                Position = model.Position,
                CreatedDate = model.CreatedDate,
                IsOwner = model.IsOwner,
                UpdatedDate = model.UpdatedDate
            };
            return buyerPersonalInfoViewModel;
        }
        //END GET Buyer Personal Info Table Data



        //Start GET Buyer Contact Info Table Data
        [HttpGet("contact")]
        public async Task<ActionResult<IEnumerable<BuyerContactInfoViewModel>>> GetBuyerContactInfos()
        {
            try
            {
                IEnumerable<BuyerContactInfo> buyerContactInfos = await _bContext.BuyerContactInfos.ToListAsync();
                List<BuyerContactInfoViewModel> buyerContactInfoViewModels = new List<BuyerContactInfoViewModel>();
                if (buyerContactInfos != null)
                {
                    foreach (BuyerContactInfo buyerPersonalInfo in buyerContactInfos)
                    {
                        buyerContactInfoViewModels.Add(assignDataBuyerContactViewModel(buyerPersonalInfo));
                    }
                    return Ok(new { status = 200, obj = buyerContactInfoViewModels, message = " The Buyer Contact data retrive successfully." });
                }
                else
                {
                    return BadRequest(new { status = 404, message = message });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("contact/{id}")]
        public async Task<ActionResult<BuyerContactInfoViewModel>> GetBuyerContactInfo(int id)
        {
            try
            {
                if (id > 0)
                {
                    BuyerContactInfo buyerContactInfo = await _bContext.BuyerContactInfos.FindAsync(id);
                    if (buyerContactInfo != null)
                    {
                        return Ok(new { status = 200, obj = assignDataBuyerContactViewModel(buyerContactInfo), message = id + " : The Buyer Contact data retrive successfully." });
                    }
                    else
                    {
                        return BadRequest(new { status = 404, message = id + " is not found" });
                    }
                }
                else
                {
                    return BadRequest(new { status = 404, message = message });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public BuyerContactInfoViewModel assignDataBuyerContactViewModel(BuyerContactInfo model)
        {
            BuyerContactInfoViewModel buyerContactInfoViewModel = new BuyerContactInfoViewModel
            {
                Id = model.Id,
                AddressDetails = model.AddressDetails,
                BuyerContactNo = model.BuyerContactNo,
                BuyerPersonalInfoId = model.BuyerPersonalInfoId,
                Country = model.Country,
                City = model.City,
                State = model.State,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate
            };
            return buyerContactInfoViewModel;
        }
        //End GET Buyer Contact Info Table Data

    }
}

