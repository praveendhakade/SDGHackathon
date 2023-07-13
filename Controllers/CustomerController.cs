using Microsoft.AspNetCore.Mvc;
using sdgshackathon.Data;
using sdgshackathon.Dtos;
using sdgshackathon.Models;

namespace sdgshackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DataContextDapper _dapper;

        public CustomerController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }
        [HttpGet("TestConnection")]
        public DateTime TestConnection()
        {
            return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
        }

        [HttpGet("GetCustomers")]
        public IEnumerable<Customer> GetCustomers()
        {
            string sql = @"
                SELECT  * FROM  SdgAppSchema.Customers";

            IEnumerable<Customer> customers = _dapper.LoadData<Customer>(sql);
            return customers;
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(AddCustomerDto customer)
        {
            string sql = @"INSERT INTO SdgAppSchema.Customers(
                [Title],
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Phone],
                [Aadhar],
                [Pan],
                [Occupation],
                [DateOfBirth]
            ) VALUES (" +
                "  '" + customer.Title +
                "', '" + customer.FirstName +
                "', '" + customer.LastName +
                "', '" + customer.Email +
                "', '" + customer.Gender +
                "', '" + customer.Phone +
                "', '" + customer.Aadhar +
                "', '" + customer.Pan +
                "', '" + customer.Occupation +
                "', '" + customer.DateOfBirth +
               "')";
            // Console.WriteLine(sql);
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }

            throw new Exception("Failed to add user!");
        }

    }
}