using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPTest.Context;
using ERPTest.Models;
using static ERPTest.Models.Enum.AllEnum;

namespace ERPTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BtestController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";

        private readonly BuyerDbContext _bContext;

        public BtestController(BuyerDbContext bcontext)
        {
            _bContext = bcontext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyerPersonalInfo>>> GetBuyerPersonalInfos()
        {
            try
            {
                return await _bContext.BuyerPersonalInfos.ToListAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<BuyerPersonalInfo>> GetBuyerPersonalInfo(int id)
        {
            try
            {
                if (id > 0)
                {
                    var buyerPersonalInfo = await _bContext.BuyerPersonalInfos.FindAsync(id);
                    return Ok(new { status = 200, obj = buyerPersonalInfo, message = id + " : The Buyer data retrive successfully." });
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

  

        [HttpPost]
        public async Task<ActionResult<BuyerPersonalInfo>> PostBuyerPersonalInfo(BuyerPersonalInfo model)
        {
            try
            {
                if (model !=null)
                {
                    BuyerPersonalInfo buyer = new BuyerPersonalInfo
                    {
                        Name = model.Name,
                        Organization = model.Organization,
                        OrganizationTaxId = model.OrganizationTaxId,
                        Position = model.Position,
                        IsOwner = Convert.ToBoolean(YesOrNo.Yes),
                        BuyerNo = Guid.Parse(DateTime.Now.ToString("ddMMyyhhmmssmmm")),
                        CreatedDate = DateTime.Now,
                    };
                    _bContext.BuyerPersonalInfos.Add(buyer);
                    await _bContext.SaveChangesAsync();
                    return Ok(new { status = 200, obj = buyer, message = " The Buyer data insterted successfully." });
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


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyerPersonalInfo( BuyerPersonalInfo model)
        {
            try
            {
                if (model.Id > 0)
                {
                    if (ModelState.IsValid)
                    {
                        BuyerPersonalInfo buyer = new BuyerPersonalInfo
                        {
                            Name = model.Name,
                            Organization = model.Organization,
                            OrganizationTaxId = model.OrganizationTaxId,
                            Position = model.Position,
                            IsOwner = model.IsOwner,
                            UpdatedDate = DateTime.Now
                        };
                        _bContext.Entry(buyer).State = EntityState.Modified;
                        await _bContext.SaveChangesAsync();
                        return Ok(new { status = 200, obj = buyer, message = " The Buyer data updated successfully." });
                    }
                    else
                    {
                        return BadRequest(new { status = 404, message = message });

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

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<BuyerPersonalInfo>> DeleteBuyerPersonalInfo(int id)
        //{
        //    var buyerPersonalInfo = await _bContext.BuyerPersonalInfos.FindAsync(id);
        //    if (buyerPersonalInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    _bContext.BuyerPersonalInfos.Remove(buyerPersonalInfo);
        //    await _bContext.SaveChangesAsync();

        //    return buyerPersonalInfo;
        //}

        //private bool BuyerPersonalInfoExists(int id)
        //{
        //    return _bContext.BuyerPersonalInfos.Any(e => e.Id == id);
        //}
    }
}
