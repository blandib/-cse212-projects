

using System.Text.Json;


public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public string type { get; set; }
    public Metadata metadata { get; set; }
    public List<Feature> features { get; set; } 
}
public class Metadata
{
    public string generated { get; set; }
    
    public string title { get; set; }
    public int status { get; set; }
    
    public int count { get; set; }
}   
public class Feature
{
    public string type { get; set; }
    public Properties properties { get; set; }
    public Geometry geometry { get; set; }
    public string id { get; set; }
}
public class Properties
{
    public  double? mag { get; set; }
    public string  place { get; set; }
    public  long time { get; set; }
    public string alert { get; set; }
    public string status { get; set; }
    public int tsunami { get; set; }
}
public class Geometry
{
    public string type { get; set; }
    public List<double> coordinates { get; set; }
}
