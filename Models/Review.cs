using System;
using System.ComponentModel.DataAnnotations;

namespace restauranter.Models
{
  public class Review : BaseEntity
  {
    public int ReviewId { get; set; }

    [Required]
    [Display(Name = "Reviewer Name")]
    public string Reviewer { get; set; }

    [Required]
    [Display(Name = "Restaurant Name")]
    public string Restaurant { get; set; }
    
    [Required]
    [PastDate]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    [Display(Name = "Date of Visit")]
    public DateTime VisitedAt { get; set; }

    [Required]
    [Display(Name = "Review")]
    public string ReviewText { get; set; }

    [Required]
    [Range(0, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Stars { get; set; }

    public int Helpful { get; set; }

    public int Unhelpful { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
  }
}