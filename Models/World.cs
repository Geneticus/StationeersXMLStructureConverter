using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

[XmlRoot("World", Namespace = "http://example.com/world")]
public class World
{
    [XmlElement("Entity")]
    public List<Entity> Entities { get; set; } = new List<Entity>();
}

public class Entity
{
    [XmlAttribute("id")]
    public string Id { get; set; } = string.Empty;

    [XmlAttribute("name")]
    public string? Name { get; set; }

    [XmlElement("Component")]
    public List<Component> Components { get; set; } = new List<Component>();
}
