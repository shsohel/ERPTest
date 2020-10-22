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
    public class AttributeController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly AttributeDbContext _dbAttrContex;

        public AttributeController(AttributeDbContext dbAttrContex)
        {
            _dbAttrContex = dbAttrContex;
        }

        //Start Color Get
        [HttpGet("color")]
        public async Task<ActionResult<IEnumerable<ColorViewModel>>> GetColors()
        {
            try
            {
                IEnumerable<Color> colors = await _dbAttrContex.Colors.ToListAsync();
                List<ColorViewModel> colorViewModels = new List<ColorViewModel>();
                if (colors != null)
                {
                    foreach (Color color in colors)
                    {
                        colorViewModels.Add(assignDataColorViewModel(color));
                    }
                    return Ok(new { status = 200, obj = colorViewModels, message = " Colors data retrive successfully." });
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

        [HttpGet("color/{id}")]
        public async Task<ActionResult<ColorViewModel>> GetColor(int id)
        {
            try
            {
                if (id > 0)
                {
                    Color color = await _dbAttrContex.Colors.FindAsync(id);
                    if (color != null)
                    {
                        return Ok(new { status = 200, obj = assignDataColorViewModel(color), message = id + " : The Color data retrive successfully." });
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
        public ColorViewModel assignDataColorViewModel(Color model)
        {
            ColorViewModel colorViewModel = new ColorViewModel
            {
                Id = model.Id,
                ColorNo = model.ColorNo,
                Name = model.Name,
                Code=model.Code,
                Description=model.Description,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate
            };
            return colorViewModel;
        }
        //End Color Get


        //Start Currency Get
        [HttpGet("currency")]
        public async Task<ActionResult<IEnumerable<CurrencyViewModel>>> GetCurrencies()
        {
            try
            {
                IEnumerable<Currency> currencies = await _dbAttrContex.Currencies.ToListAsync();
                List<CurrencyViewModel> currencyViewModels = new List<CurrencyViewModel>();
                if (currencies != null)
                {
                    foreach (Currency currency in currencies)
                    {
                        currencyViewModels.Add(assignDataCurrencyViewModel(currency));
                    }
                    return Ok(new { status = 200, obj = currencyViewModels, message = " Currencies data retrive successfully." });
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

        [HttpGet("currency/{id}")]
        public async Task<ActionResult<CurrencyViewModel>> GetCurrency(int id)
        {
            try
            {
                if (id > 0)
                {
                    Currency currency = await _dbAttrContex.Currencies.FindAsync(id);
                    if (currency != null)
                    {
                        return Ok(new { status = 200, obj = assignDataCurrencyViewModel(currency), message = id + " : The Currency data retrive successfully." });
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
        public CurrencyViewModel assignDataCurrencyViewModel(Currency model)
        {
            CurrencyViewModel currencyViewModel = new CurrencyViewModel
            {
                Id = model.Id,
                CurrencyNo=model.CurrencyNo,
                ISO=model.ISO,
                Name = model.Name,
                Description = model.Description,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate
            };
            return currencyViewModel;
        }
        //End Currency Get


        //Start Size Get
        [HttpGet("size")]
        public async Task<ActionResult<IEnumerable<SizeViewModel>>> GetSizes()
        {
            try
            {
                IEnumerable<Size> sizes = await _dbAttrContex.Sizes.ToListAsync();
                List<SizeViewModel> sizeViewModels = new List<SizeViewModel>();
                if (sizes != null)
                {
                    foreach (Size size in sizes)
                    {
                        sizeViewModels.Add(assignDataSizeViewModel(size));
                    }
                    return Ok(new { status = 200, obj = sizeViewModels, message = " Sizes data retrive successfully." });
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

        [HttpGet("size/{id}")]
        public async Task<ActionResult<SizeViewModel>> GetSize(int id)
        {
            try
            {
                if (id > 0)
                {
                    Size size = await _dbAttrContex.Sizes.FindAsync(id);
                    if (size != null)
                    {
                        return Ok(new { status = 200, obj = assignDataSizeViewModel(size), message = id + " : The Size data retrive successfully." });
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
        public SizeViewModel assignDataSizeViewModel(Size model)
        {
            SizeViewModel sizeViewModel = new SizeViewModel
            {
                Id = model.Id,
                SizeNo=model.SizeNo,
                Value=model.Value,
                Name = model.Name,
                Description = model.Description,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate
            };
            return sizeViewModel;
        }
        //End Size Get
    }
}
