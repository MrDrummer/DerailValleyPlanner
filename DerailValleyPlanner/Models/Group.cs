using DerailValleyPlanner.Configs.Yard;

namespace DerailValleyPlanner.Models;

public class Group
{
    public string Name { get; set; }
    public string Code { get; set; }
    private Yard Yard { get; set; }
    public Designation Designation { get; set; }
    public List<Track> Tracks { get; set; }

    public Group(Yard yard, YardGroupConfig groupConfig)
    {
        Yard = yard;
        Name = groupConfig.Name;
        Code = groupConfig.Code;
        // Designation = GroupConfig.Designation;
        Tracks = groupConfig.Tracks.Select(t => new Track(Yard, t)).ToList();
    }
}