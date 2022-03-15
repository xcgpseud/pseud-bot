using System.ComponentModel.DataAnnotations;
using Domain.DataModels.Interfaces;
using Domain.Entities.Interfaces;

namespace Domain.Entities.Racing;

public class VehicleEntity : BaseEntity, IEntity
{
    [Required]
    public string Uid { get; set; } = "";

    [Required]
    public string Name { get; set; } = "";

    public List<VehicleImage> ImageLinks { get; set; } = new List<VehicleImage>();

    public string Description { get; set; } = "";
}