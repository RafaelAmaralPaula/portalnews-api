using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalNews.Api.Controllers.Enums;
using PortalNews.Application.DTO.RoleDataTransferObject;
using PortalNews.Application.Services.Interfaces;

namespace PortalNews.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<RoleDTO>> FindAll()
        {
            return Ok(_service.FindAll());
        }


        [HttpGet("{id}")]
        public ActionResult<RoleDTO> FindById(string id)
        {
            var result = _service.FindById(id);
            return Ok(result);
        }

    }
}
