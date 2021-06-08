
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace API.Controllers
{
    
    public class CustomersController : BaseApiController
    {
       // private const string V = "api/[controller]";
        private readonly DataContext context;

        public CustomersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AppCustomer>>> GetCustomers()
        {
            return await context.Customer.ToListAsync();

        }

        //api/customers/2
        [HttpGet("{id}")]

        public async Task<ActionResult<AppCustomer>> GetCustomer(int id)
        {
            return await context.Customer.FindAsync(id);

        }
    }
}