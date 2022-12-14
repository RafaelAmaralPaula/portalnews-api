using System.Text.Json.Serialization;

namespace PortalNews.Application.DTO.UserDataTransferObject
{
    public class SaveUserDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        [JsonPropertyName("role_id")]
        public string RoleId { get;  set; }

    }
}
