using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record BookDtoForUpdate : BookDtoForManipulation
    {
        [Required]
        public int Id { get; init; }

        [Required(ErrorMessage = "CategoryId is required.")]
        public int CategoryId { get; init; }
    } 
}
