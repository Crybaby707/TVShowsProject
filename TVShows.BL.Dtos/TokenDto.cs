using System.ComponentModel.DataAnnotations;

namespace TVShows.BL.Dtos
{
    public class TokenDto
    {
        [Required]
        public string Token { get; set; }
    }
}
