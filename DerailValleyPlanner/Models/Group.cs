using DerailValleyPlanner.Configs.Yard;

namespace DerailValleyPlanner.Models;

public class Group
{
    public string Name { get; set; }
    public string Code { get; set; }
    private Yard Yard { get; set; }
    public List<Track> Tracks { get; set; }
    public List<string> Directions { get; set; }

    public Group(Yard yard, YardGroupConfig groupConfig)
    {
        Yard = yard;
        Name = groupConfig.Name;
        Code = groupConfig.Code;
        Directions = groupConfig.Directions.Count == 0
            ? yard.Directions
            : groupConfig.Directions.Select(d => d.Type).ToList();
        Tracks = groupConfig.Tracks.Select(t => new Track(Yard, this, t)).ToList();
    }
}