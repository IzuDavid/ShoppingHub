using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using System.Text;




namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }
    }

    [HttpPost("register")]

    public async Task<ActionResult<AppCustomer>> Register(string username, string password)
    {//
        using var hmac = new HMACSHA512();

        var customer = new AppCustomer
        {
            UserName = username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return customer;
    }
}