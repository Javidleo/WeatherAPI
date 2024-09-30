using static WeatherAPI.Model.GetWeatherModel;

namespace WeatherAPI.Model;
public class Location
{
    public string Name { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
    public decimal Lat { get; set; }
    public decimal Lon { get; set; }
    public DateTime LocalTime { get; set; }
}
public class Current
{
    public DateTime Last_Updated { get; set; }
    public Condition Condition { get; set; }
}
public class Condition
{
    public string Text { get; set; }
    public string Icon { get; set; }
    public int Code { get; set; }
}
public class GetWeatherModel
{
    public Current Current { get; set; }
    public Location Location { get; set; }
    public decimal Wind_Mph { get; set; }
    public decimal Wind_Kph { get; set; }
    public int Wind_Degree {  get; set; }
    public string Wind_Dir { get; set; }
}