﻿using System.Reflection;
using System.Xml.Serialization;
using DerailValleyPlanner.Configs.Yard;
using DerailValleyPlanner.Models;

namespace DerailValleyPlanner.Services;

public class ConfigService
{
    public Config Config;
    private List<Yard> Yards { get; set; }
    
    public ConfigService()
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Configs\Yard\Yards.xml");
        LoadConfig(path);
    }
    
    public ConfigService(string path)
    {
        LoadConfig(path);
    }

    private void LoadConfig(string path)
    {
        var serializer = new XmlSerializer(typeof(Config));
        using var reader = new StreamReader(path);
        Config = (Config)serializer.Deserialize(reader);
        LoadYards();
    }

    private void LoadYards()
    {
        Yards = Config.Yards.Select(y => new Yard(Config.Designators, y)).ToList();
    }
}