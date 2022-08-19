// See https://aka.ms/new-console-template for more information

using DeviceManagement;
using Newtonsoft.Json;

var devices = new DeviceManager().GetDevices();

File.WriteAllText(
    "out.json",
    JsonConvert.SerializeObject( devices, Formatting.Indented )
);