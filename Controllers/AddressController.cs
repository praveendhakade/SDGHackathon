using Microsoft.AspNetCore.Mvc;
using sdgshackathon.Data;
using sdgshackathon.Dtos;
using sdgshackathon.Models;

namespace sdgshackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly DataContextDapper _dapper;

        public AddressController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("GetAddressByCustomerId/{customerId}")]
        public IEnumerable<Address> GetAddressesByCustomerId(int customerId)
        {
            string sql = @"SELECT [AddressId],
                [HouseNo],
                [CustomerId],
                [Tower],
                [StreetAddress1],
                [StreetAddress2],
                [Country],
                [StateName],
                [City],
                [ZipCode] FROM SdgAppSchema.Addresses 
                WHERE SdgAppSchema.Addresses.CustomerId = " + customerId.ToString();

            return _dapper.LoadData<Address>(sql);
        }

        [HttpPost("PostAddress")]
        public IActionResult PostAddress(PostAddressDto addressToPost)
        {
            string sql = @"INSERT INTO SdgAppSchema.Addresses(
                [HouseNo],
                [CustomerId],
                [Tower],
                [StreetAddress1],
                [StreetAddress2],
                [Country],
                [StateName],
                [City],
                [ZipCode]
            ) VALUES (" +
                    "  '" + addressToPost.HouseNo +
                    "', '" + addressToPost.CustomerId +
                    "', '" + addressToPost.Tower +
                    "', '" + addressToPost.StreetAddress1 +
                    "', '" + addressToPost.StreetAddress2 +
                    "', '" + addressToPost.Country +
                    "', '" + addressToPost.StateName +
                    "', '" + addressToPost.City +
                    "', '" + addressToPost.ZipCode +
                   "')";
            Console.WriteLine(sql);
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }

            throw new Exception("Failed to add user!");
        }

        [HttpPut("EditAddress")]
        public IActionResult EditAddress(Address addressToEdit)
        {
            string sql = @"UPDATE SdgAppSchema.Addresses
            SET HouseNo = '" + addressToEdit.HouseNo +
                "', Tower= '" + addressToEdit.Tower +
                "', StreetAddress1= '" + addressToEdit.StreetAddress1 +
                "', StreetAddress2= '" + addressToEdit.StreetAddress2 +
                "', Country = '" + addressToEdit.Country +
                "', StateName= '" + addressToEdit.StateName +
                "', City= '" + addressToEdit.City +
                "', ZipCode= '" + addressToEdit.ZipCode +
                "' WHERE AddressId = '" + addressToEdit.AddressId +
                "' AND CustomerId = " + addressToEdit.CustomerId;
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }

            throw new Exception("Failed to edit user!");
        }

        [HttpDelete("DeleteAddress/{addressId}")]
        public IActionResult DeleteAddress(int addressId)
        {
            string sql = @"DELETE FROM SdgAppSchema.Addresses
                WHERE AddressId = " + addressId.ToString();

            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }

            throw new Exception("Failed to delete user!");
        }


    }
}