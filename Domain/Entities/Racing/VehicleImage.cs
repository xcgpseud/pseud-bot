using System.ComponentModel.DataAnnotations;
using Domain.Entities.Interfaces;

namespace Domain.Entities.Racing;

public class VehicleImage : BaseEntity, IEntity
{
    [Required]
    public string Url { get; set; } = "";
}