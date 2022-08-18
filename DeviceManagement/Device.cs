namespace DeviceManagement;

public class Device
{
    public string Description { get; set; } = "";
    public string HardwareId { get; set; } = "";
    public string CompatibleIds { get; set; } = ""; 
    public string Class { get; set; } = ""; 
    public string ClassGuid { get; set; } = ""; 
    public string Driver { get; set; } = ""; 
    public string MFG { get; set; } = ""; 
    public string? Name { get; set; }
    public string PhysicalName { get; set; } = "";
    public string Enumerator { get; set; } = "";
}