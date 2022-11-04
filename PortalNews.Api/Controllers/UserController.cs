using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalNews.Api.Controllers.Enums;
using PortalNews.Api.Services;
using PortalNews.Application.DTO.UserDataTransferObject;
using PortalNews.Application.Services.Interfaces;

namespace PortalNews.Api.Controllers
{
    [Authorize(Roles = RoleEnum.ADMIN)]
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _service;

      



        public UserController(IUserService service)
        {
            _service = service;
        }


        [HttpGet]
        public ActionResult<LoginDTO> FindAll()
        {
            return Ok(_service.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult<FindUserDTO> FindById(string id)
        {
            var result = _service.FindById(id);
            return Ok(result); 
        }


        [HttpPost]
        public ActionResult<FindUserDTO> Save([FromBody] SaveUserDTO userDTO)
        {
            var result = _service.Save(userDTO);
            return Created($"/api/users/{result.Id}", result);
        }

    }
}
