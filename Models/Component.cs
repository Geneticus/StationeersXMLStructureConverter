using System.Xml.Serialization;

[XmlInclude(typeof(PositionComponent))]
[XmlInclude(typeof(PhysicsComponent))]
[XmlInclude(typeof(RenderComponent))]
// Add more [XmlInclude] for additional subtypes as discovered in full XML
[XmlRoot("Component")]
public abstract class Component
{
    [XmlAttribute("type")]
    public string Type { get; set; } = string.Empty;

    [XmlAttribute("id")]
    public string? Id { get; set; }
}

public class PositionComponent : Component
{
    [XmlElement("Transform")]
    public Transform Transform { get; set; } = new Transform();
}

public class PhysicsComponent : Component
{
    [XmlElement("Mass")]
    public double Mass { get; set; }

    [XmlElement("Velocity")]
    public Vector3 Velocity { get; set; } = new Vector3();
}

public class RenderComponent : Component
{
    [XmlElement("Mesh")]
    public string Mesh { get; set; } = string.Empty;

    [XmlElement("Material")]
    public string Material { get; set; } = string.Empty;
}

// Supporting types (from XSD/XML inference)
public class Transform
{
    [XmlElement("Position")]
    public Vector3 Position { get; set; } = new Vector3();

    [XmlElement("Rotation")]
    public Vector3 Rotation { get; set; } = new Vector3();

    [XmlElement("Scale")]
    public Vector3 Scale { get; set; } = new Vector3(1, 1, 1);
}

public class Vector3
{
    [XmlElement("X")]
    public double X { get; set; }

    [XmlElement("Y")]
    public double Y { get; set; }

    [XmlElement("Z")]
    public double Z { get; set; }
}
