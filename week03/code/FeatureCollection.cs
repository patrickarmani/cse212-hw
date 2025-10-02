public class FeatureCollection // Maps USGS GeoJSON
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public string? Type { get; set; }
    public List<Feature>? Features { get; set; }
}

public class Feature
{
    public string? Type { get; set; }
    public Properties? Properties { get; set; }
    public Geometry? Geometry { get; set; }
    public string? Id { get; set; }
}

public class Properties
{
    public double? Mag { get; set; }    // "mag"
    public string? Place { get; set; }  // "place"

}
public class Geometry
{
    public string? Type { get; set; }
    public List<double>? Coordinates { get; set; }
}