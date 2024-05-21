using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SoftServe_Practice.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва фільму є обов'язковою.")]
        [StringLength(100, ErrorMessage = "Назва фільму не може бути довшою за 100 символів.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Опис фільму є обов'язковим.")]
        [StringLength(1000, ErrorMessage = "Опис фільму не може бути довшим за 1000 символів.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Тривалість фільму є обов'язковою.")]
        [Range(1, 600, ErrorMessage = "Тривалість фільму повинна бути від 1 до 600 хвилин.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Жанр фільму є обов'язковим.")]
        [StringLength(50, ErrorMessage = "Жанр фільму не може бути довшим за 50 символів.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Дата виходу фільму є обов'язковою.")]
        public DateTime ReleaseDate { get; set; }

        [ValidateNever]
        public ICollection<Session> Sessions { get; set; }
    }

}
