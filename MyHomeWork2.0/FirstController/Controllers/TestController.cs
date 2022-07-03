using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FirstController.Controllers
{
    [Route("bank/[controller]")]
    [ApiController]

    public class TestController : ControllerBase
    {
        private static readonly string[]
             _nameCustromer = { "Timur", "Dima", "Alexandra", "Vlad", "Valentina" },
             _typeCustromer = { "individuals", "entities" };

        [HttpGet]
        public IEnumerable<Customer> GetCustromer()
        {
            int numCust = 0;

            return Enumerable.Range(1, 5).Select(index => new Customer
            {
                Name = _nameCustromer[numCust++],
                CustromerId = Guid.NewGuid().ToString(),
                TypeCustromer = _typeCustromer[Extensions.GetRandomBetween(0, _typeCustromer.Length)],
                CardNumber = $"12345678{Extensions.GetRandomBetween(10000000, 99999999)}"
            })
           .ToArray();
        }




        //private readonly ILogger<TestController> _logger;

        //public TestController(ILogger<TestController> logger)
        //{
        //    _logger = logger;
        //}
    }
}
