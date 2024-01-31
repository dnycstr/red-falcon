using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RedFalcon.API.Controllers
{
    [Route("api/taxes")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        public readonly List<TaxDto> _dummyTaxes = new List<TaxDto>();

        public TaxController()
        {
            _dummyTaxes.Add(new TaxDto { Id = 1, Name = "Ten Percent", Shortname = "10 %", Rate = 10 });
            _dummyTaxes.Add(new TaxDto { Id = 2, Name = "Eleven Percent", Shortname = "11 %", Rate = 11 });
            _dummyTaxes.Add(new TaxDto { Id = 3, Name = "Twelve Percent", Shortname = "12 %", Rate = 12 });

        }

        // Get List
        [HttpGet]
        public IActionResult GetTaxes() 
        {
            return Ok(new
            {
                data = _dummyTaxes,
                total = _dummyTaxes.Count,
                page = 1,
                pageSize = 10,
                totalPages = 1,
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetTaxById(int id) 
        { 
            var result = _dummyTaxes.FirstOrDefault(o => o.Id == id);
            if (result == null)
                return NotFound();

            return Ok(result);  
        }

        [HttpPost]
        public IActionResult CreateTax([FromBody] TaxDto tax)
        {
            _dummyTaxes.Add(tax);

            throw new Exception("Test Error");

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTax([FromRoute] int id, [FromBody] TaxDto tax)
        {
            var taxToUpdate = _dummyTaxes.FirstOrDefault(o => o.Id == id);
            if (taxToUpdate == null)
                return NotFound();

            taxToUpdate.Name = tax.Name;
            taxToUpdate.Shortname = tax.Shortname;
            taxToUpdate.Rate = tax.Rate;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTaxById([FromRoute] int id)
        {
            var taxToUpdate = _dummyTaxes.FirstOrDefault(o => o.Id == id);

            if (taxToUpdate == null) return NotFound();

            _dummyTaxes.Remove(taxToUpdate);

            return Ok();
        }

    }

    public class TaxDto
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public decimal Rate { get; set; }
    }
}
