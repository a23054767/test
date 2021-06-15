using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;
using System.Net.Http;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaskController : ControllerBase
    {
        private readonly MaskService _maskService;

        public MaskController(MaskService maskService)
        {
            _maskService = maskService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var maskCount = await _maskService.GetMaskInfo();
                return Ok(maskCount.FirstOrDefault());
            }
            catch (HttpRequestException ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
