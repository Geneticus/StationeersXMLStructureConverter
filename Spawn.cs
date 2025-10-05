using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("Spawn")]
public class Spawn
{
    [XmlElement("item")]
    public List<Item> Items { get; set; } = new List<Item>();
}

public class Item
{
    [XmlAttribute("category")]
    public string Category { get; set; } = string.Empty;

    [XmlAttribute("id")]
    public string Id { get; set; } = string.Empty;

    [XmlElement("Item")]
    public ItemProperties Properties { get; set; } = new ItemProperties();
}

public class ItemProperties
{
    [XmlElement("Color")]
    public string Color { get; set; } = "Default";

    [XmlElement("Mass")]
    public double Mass { get; set; }

    [XmlElement("Pressure")]
    public double Pressure { get; set; }

    // Add more from new schema (e.g., DamageState as string)
}