using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly PalitaxDbContext _context;

        public ItemsController(PalitaxDbContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItem()
        {
            try
            {
                return await _context.Item.ToListAsync();
            }
            catch
            {
                throw new Exception("Something went wrong. Please contact Admin or try again later");
            }
        }
    }
}
