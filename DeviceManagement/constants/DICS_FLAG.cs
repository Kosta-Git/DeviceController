namespace DeviceManagement.constants;

[Flags]
public enum DICS_FLAG : uint
{
    GLOBAL = 0x00000001,
    CONFIGSPECIFIC = 0x00000002,
    CONFIGGENERAL = 0x00000004,
}