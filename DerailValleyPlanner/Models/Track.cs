using DerailValleyPlanner.Configs.Yard;

namespace DerailValleyPlanner.Models;

public class Track
{
    public sbyte Id { get; set; }
    public List<string> Direction { get; set; }
    private Yard Yard { get; set; }
    public string Note { get; set; }
    public string TypeName { get; set; }
    public string TypeCode { get; set; }
    

    public Track(Yard yard, YardGroupTrackConfig trackConfig)
    {
        Id = trackConfig.Id;
        Note = trackConfig.Note;
        Yard = yard;
        Direction = trackConfig.Direction == null
            ? new List<string> { trackConfig.Direction }
            : yard.Directions;
        var des = yard.DesignatorConfig.Find(d => d.Code == trackConfig.Type);
        TypeName = des.Name;
        TypeCode = des.Code;
    }
}