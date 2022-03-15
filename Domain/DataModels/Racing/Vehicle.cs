using Domain.DataModels.Interfaces;

namespace Domain.DataModels.Racing;

public class Vehicle : IModel
{
    public string Uid { get; set; } = "";

    public string Name { get; set; } = "";

    public List<string> ImageLinks { get; set; } = new List<string>();

    public string Description { get; set; } = "";
}