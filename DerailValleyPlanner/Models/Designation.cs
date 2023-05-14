using DerailValleyPlanner.Configs.Yard;

namespace DerailValleyPlanner.Models;

public class Designation
{
    public string Name { get; set; }
    public string Code { get; set; }
    
    // public Designation(Config config, YardGroupConfig groupConfig)
    // {
    //     List<DesignatorConfig> designators = new List<DesignatorConfig>();
    //
    //     var des = designators.Find(d => d.name == groupConfig.name);
    //
    //     Name = des.name;
    //     Code = des.code;
    // }
}