using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Service.Catalog.product;
using Ecommerce.ViewModel.Catalog.product.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;
        public ProductController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }
        [HttpGet("public-paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]PublicProductPagingRequest request)
        {
            var productResult = await _publicProductService.GetAllByCategoryId(request);
            return Ok(productResult);

        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageProductService.Delete(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id,string languageid)
        {
            var product = await _manageProductService.GetById(id, languageid);
            if(product == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(product);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var productId = await _manageProductService.Create(request);
            if(productId == 0)
            {
                return BadRequest("Not Found");
            }
            var product = await _manageProductService.GetById(productId, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm]ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var product = await _manageProductService.Update(request);
            if(product == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}