using DerailValleyPlanner.Configs.Yard;
using DerailValleyPlanner.Services;

namespace DerailValleyPlanner.Models;

public class Yard
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Color { get; set; }
    public List<string> Directions { get; set; }
    public List<Group> Groups { get; set; }

    public Yard(YardConfig yardConfig)
    {
        Name = yardConfig.Name;
        Code = yardConfig.Code;
        Color = yardConfig.Color;
        Groups = yardConfig.Groups.Select(g => new Group(this, g)).ToList();
        Directions = yardConfig.Directions.Select(d => d.Type).ToList();
    }
}