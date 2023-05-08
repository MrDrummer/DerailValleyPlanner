using System.Xml;
using System.Xml.Serialization;

namespace XMLConfigTest;

internal abstract class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        var relativePath = args.Length > 0 ? args[0] : null;
        
        // CreateConfig(relativePath);
        // ReadConfig(relativePath);
        SerializeConfig(relativePath);
    }

    private static void CreateConfig(string? path)
    {
        var xmlDoc = new XmlDocument();
        var xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
        xmlDoc.AppendChild(xmlDeclaration);
        
        var root = xmlDoc.CreateElement("Config");
        xmlDoc.AppendChild(root);
        
        var setting1 = xmlDoc.CreateElement("Setting");
        setting1.SetAttribute("Name", "Setting1");
        setting1.SetAttribute("Value", "123");
        root.AppendChild(setting1);

        var setting2 = xmlDoc.CreateElement("Setting");
        setting2.SetAttribute("Name", "Setting2");
        setting2.SetAttribute("Value", "456");
        root.AppendChild(setting2);

        var outputPath = Path.Join(path, "config.xml");
        
        Console.WriteLine("Outputting at '{0}'", outputPath);
        
        xmlDoc.Save(outputPath);
    }

    private static void ReadConfig(string? path)
    {
        
        var outputPath = Path.Join(path, "config.xml");
        
        Console.WriteLine("Reading from '{0}'", outputPath);
        
        var xmlDoc = new XmlDocument();
        
        xmlDoc.Load(outputPath);

        var root = xmlDoc.DocumentElement;

        foreach (XmlNode node in root.ChildNodes)
        {
            if (node.NodeType == XmlNodeType.Element)
            {
                var setting = (XmlElement)node;
                var name = setting.GetAttribute("Name");
                var value = setting.GetAttribute("Value");
                var inner = setting.InnerText;
                Console.WriteLine("Setting: {0}={1} - inner: {2}", name, value, inner);
            }
        }
    }

    private static void SerializeConfig(string? path)
    {
        
        var outputPath = Path.Join(path, "Yards.xml");
        
        Console.WriteLine("Reading from '{0}'", outputPath);

        try
        {
            var serializer = new XmlSerializer(typeof(Config));
            using var reader = new StreamReader(outputPath);
            var config = (Config)serializer.Deserialize(reader);


            foreach (var designator in config.designator)
            {
                Console.WriteLine("name: {0}, code: {1}, value: {2}", designator.name, designator.code, designator.Value);
            }
        }
        catch (Exception ex)
        {
            
            // Catch exception and inspect InnerException property
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException?.Message);
        }
    }
}
