using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = "";

    [Required]
    public decimal Price { get; set; }

    public int Quantity { get; set; }
    public string Category { get; set; } = "";
    public string Description { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public bool IsAvailable { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}