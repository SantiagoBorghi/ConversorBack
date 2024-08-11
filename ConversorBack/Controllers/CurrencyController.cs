using ConversorBack.Data;
using ConversorBack.DTOs;
using ConversorBack.Entities;
using ConversorBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConversorBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyService _currencyService;
        private readonly ConversorDeMonedaContext _context;
        public CurrencyController(CurrencyService currencyService, ConversorDeMonedaContext context)
        {
            _currencyService = currencyService;
            _context = context;
        }

        [HttpPost("CreateCurrency")]
        public IActionResult CreateCurrency(CurrencyForCreationDto dto)
        {
            try
            {
                _currencyService.CreateCurrency(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Currency Created!", dto);
        }

        [HttpPut("UpdateCurrency")]
        public IActionResult UpdateCurrency(int currencyId, CurrencyForCreationDto dto)
        {
            try
            {
                _currencyService.UpdateCurrency(currencyId, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Currency Updated!", dto);
        }

        [HttpDelete("DeleteCurrency")]
        public IActionResult DeleteCurrency(int currencyId)
        {
            _currencyService.DeleteCurrency(currencyId);

            return Ok(new { mensaje = "Currency successfully removed!" });
        }

        [HttpGet("Convert")]
        public IActionResult Convert(int userId, [FromQuery] double amount, [FromQuery] ConvertDto dto)
        {
            User? user = _context.Users.SingleOrDefault(u => u.Id == userId);
            if (user.TotalConversions != 0)
            {
                try
                {
                    double result = _currencyService.Convert(amount, dto);
                    user.TotalConversions -= 1;
                    _context.SaveChanges();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            else
            {
                string result = "The user has no more conversions";
                return Ok(result);
            }
        }
        [HttpGet("GetCurrency")]
        public IActionResult GetCurrency(int currencyId)
        {
            try
            {
                Currency currency = _currencyService.GetCurrency(currencyId);
                return Ok(currency);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAllCurrencies")]
        public ActionResult<List<Currency>> GetAllCurrencies()
        {
            try
            {
                var currencies = _currencyService.GetAllCurrencies();
                return Ok(currencies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
