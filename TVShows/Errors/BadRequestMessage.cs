using System.ComponentModel.DataAnnotations;

namespace TVShows.WEB.Errors
{
    public class BadRequestMessage
    {
        [Required]
        public string Message { get; set; }
    }
}
