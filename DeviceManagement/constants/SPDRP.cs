using System.Runtime.InteropServices;

namespace DeviceManagement.constants;

public enum SPDRP : uint
{
    /// <summary>
    /// DeviceDesc (R/W)
    /// </summary>
    DEVICEDESC = 0x00000000,

    /// <summary>
    /// HardwareID (R/W)
    /// </summary>
    HARDWAREID = 0x00000001,

    /// <summary>
    /// CompatibleIDs (R/W)
    /// </summary>
    COMPATIBLEIDS = 0x00000002,

    /// <summary>
    /// unused
    /// </summary>
    UNUSED0 = 0x00000003,

    /// <summary>
    /// Service (R/W)
    /// </summary>
    SERVICE = 0x00000004,

    /// <summary>
    /// unused
    /// </summary>
    UNUSED1 = 0x00000005,

    /// <summary>
    /// unused
    /// </summary>
    UNUSED2 = 0x00000006,

    /// <summary>
    /// Class (R--tied to ClassGUID)
    /// </summary>
    CLASS = 0x00000007,

    /// <summary>
    /// ClassGUID (R/W)
    /// </summary>
    CLASSGUID = 0x00000008,

    /// <summary>
    /// Driver (R/W)
    /// </summary>
    DRIVER = 0x00000009,

    /// <summary>
    /// ConfigFlags (R/W)
    /// </summary>
    CONFIGFLAGS = 0x0000000A,

    /// <summary>
    /// Mfg (R/W)
    /// </summary>
    MFG = 0x0000000B,

    /// <summary>
    /// FriendlyName (R/W)
    /// </summary>
    FRIENDLYNAME = 0x0000000C,

    /// <summary>
    /// LocationInformation (R/W)
    /// </summary>
    LOCATION_INFORMATION = 0x0000000D,

    /// <summary>
    /// PhysicalDeviceObjectName (R)
    /// </summary>
    PHYSICAL_DEVICE_OBJECT_NAME = 0x0000000E,

    /// <summary>
    /// Capabilities (R)
    /// </summary>
    CAPABILITIES = 0x0000000F,

    /// <summary>
    /// UiNumber (R)
    /// </summary>
    UI_NUMBER = 0x00000010,

    /// <summary>
    /// UpperFilters (R/W)
    /// </summary>
    UPPERFILTERS = 0x00000011,

    /// <summary>
    /// LowerFilters (R/W)
    /// </summary>
    LOWERFILTERS = 0x00000012,

    /// <summary>
    /// BusTypeGUID (R)
    /// </summary>
    BUSTYPEGUID = 0x00000013,

    /// <summary>
    /// LegacyBusType (R)
    /// </summary>
    LEGACYBUSTYPE = 0x00000014,

    /// <summary>
    /// BusNumber (R)
    /// </summary>
    BUSNUMBER = 0x00000015,

    /// <summary>
    /// Enumerator Name (R)
    /// </summary>
    ENUMERATOR_NAME = 0x00000016,

    /// <summary>
    /// Security (R/W, binary form)
    /// </summary>
    SECURITY = 0x00000017,

    /// <summary>
    /// Security (W, SDS form)
    /// </summary>
    SECURITY_SDS = 0x00000018,

    /// <summary>
    /// Device Type (R/W)
    /// </summary>
    DEVTYPE = 0x00000019,

    /// <summary>
    /// Device is exclusive-access (R/W)
    /// </summary>
    EXCLUSIVE = 0x0000001A,

    /// <summary>
    /// Device Characteristics (R/W)
    /// </summary>
    CHARACTERISTICS = 0x0000001B,

    /// <summary>
    /// Device Address (R)
    /// </summary>
    ADDRESS = 0x0000001C,

    /// <summary>
    /// UiNumberDescFormat (R/W)
    /// </summary>
    UI_NUMBER_DESC_FORMAT = 0X0000001D,

    /// <summary>
    /// Device Power Data (R)
    /// </summary>
    DEVICE_POWER_DATA = 0x0000001E,

    /// <summary>
    /// Removal Policy (R)
    /// </summary>
    REMOVAL_POLICY = 0x0000001F,

    /// <summary>
    /// Hardware Removal Policy (R)
    /// </summary>
    REMOVAL_POLICY_HW_DEFAULT = 0x00000020,

    /// <summary>
    /// Removal Policy Override (RW)
    /// </summary>
    REMOVAL_POLICY_OVERRIDE = 0x00000021,

    /// <summary>
    /// Device Install State (R)
    /// </summary>
    INSTALL_STATE = 0x00000022,

    /// <summary>
    /// Device Location Paths (R)
    /// </summary>
    LOCATION_PATHS = 0x00000023,
}