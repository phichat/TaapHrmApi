using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaapHrmApi.Model;

namespace TaapHrmApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly db_taapHrmContext ctx;

        public UsersController(db_taapHrmContext context)
        {
            ctx = context;
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserByIdAsync(string id) {
            try {
                var u = await ctx.HrmUsers.ToListAsync();
                MD5 md5Hash = MD5.Create();
                var _u = new UsersRes();

                u.ForEach(x =>
                {
                    if (VerifyMd5Hash(md5Hash, x.Id.ToString(), id))
                    {
                        _u.VtId = x.Id;
                        _u.VtTypeUser = x.UserType;
                        _u.VtUserName = x.UserName;
                        
                        return;
                    }
                });

                if (_u == null)
                    return NotFound();

                switch(_u.VtTypeUser) {
                    case 2:
                        _u.VtNameDeposit = "admin";
                        break;

                    case 3:
                        var emp = ctx.HrmEmployee.FirstOrDefault(x => x.IdEmp == _u.VtId);

                        var dep = (from dp in ctx.HrmDepartmentPosition
                                   join d in ctx.HrmDepartment on dp.DepIdDeposi equals d.IdDep into a1

                                   from dept in a1.DefaultIfEmpty()
                                   where dp.IdDeposi == emp.DepartPosiIdEmp

                                   select new
                                   {
                                       dp.NameDeposi
                                   }).FirstOrDefault();

                        _u.VtNameDeposit = dep.NameDeposi;
                        break;

                    default:
                        return NotFound();
                }

                return Ok(_u);
            } catch(Exception ex) {
                return StatusCode(500);
            }
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash) ? true : false;
        }

    }

    public class UsersRes {
       public int VtId { get; set; }
       public string VtNameDeposit { get; set; }
       public int VtTypeUser { get; set; }
       public string VtUserName { get; set; }
    }
}
