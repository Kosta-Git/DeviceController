// See https://aka.ms/new-console-template for more information

using DeviceManagement;
using Newtonsoft.Json;

var devices = new DeviceManager().GetDevices();

var ids = new List<string>()
{
    "\\Device\\00000113",
    "\\Device\\00000110",
    "\\Device\\0000010f"
};

foreach ( var id in ids )
{
    new DeviceManager().ChangeDeviceState(id, false);
}

File.WriteAllText(
    "out.json",
    JsonConvert.SerializeObject( devices, Formatting.Indented )
);