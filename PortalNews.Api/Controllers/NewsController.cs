using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalNews.Api.Controllers.Enums;
using PortalNews.Application.DTO.NewsDataTransferObject;
using PortalNews.Application.Services.Interfaces;

namespace PortalNews.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;

        private readonly INewsService _service;

        public NewsController(ILogger<NewsController> logger, INewsService service)
        {
            _logger = logger;
            _service = service;
        }


      
        [HttpGet]
        public ActionResult<List<FindNewsDTO>> FindAll()
        {
            var result = _service.FindAll();
            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public ActionResult<FindNewsDTO> FindById(string id)
        {
            var result = _service.FindById(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<FindNewsDTO> Save([FromBody] NewsDTO newsDTO)
        {
            var result = _service.Save(newsDTO);
            return Created($"api/news/{result.Id}", result);
        }


        [Authorize(Roles = RoleEnum.ADMIN)]
        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] NewsDTO newsDTO)
        {
            _service.Update(id, newsDTO);
            return NoContent();
        }

        [Authorize(Roles = RoleEnum.ADMIN)]
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _service.Delete(id);
            return NoContent();
        }


    }
}
