using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ODataController
    {
        private static List<Customer> customers = new List<Customer>(
            Enumerable.Range(1, 3).Select(idx => new Customer
            {
                Id = idx,
                Name = new LocalizableString(new Dictionary<string, string>() { ["en"] = "english", ["fr"] = "french"})
            }));

        [EnableQuery]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(customers);
        }
    }
}
