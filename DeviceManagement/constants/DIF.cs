﻿namespace DeviceManagement.constants;

public enum DIF : uint
{
    SELECTDEVICE = 0x00000001,
    INSTALLDEVICE = 0x00000002,
    ASSIGNRESOURCES = 0x00000003,
    PROPERTIES = 0x00000004,
    REMOVE = 0x00000005,
    FIRSTTIMESETUP = 0x00000006,
    FOUNDDEVICE = 0x00000007,
    SELECTCLASSDRIVERS = 0x00000008,
    VALIDATECLASSDRIVERS = 0x00000009,
    INSTALLCLASSDRIVERS = 0x0000000A,
    CALCDISKSPACE = 0x0000000B,
    DESTROYPRIVATEDATA = 0x0000000C,
    VALIDATEDRIVER = 0x0000000D,
    DETECT = 0x0000000F,
    INSTALLWIZARD = 0x00000010,
    DESTROYWIZARDDATA = 0x00000011,
    PROPERTYCHANGE = 0x00000012,
    ENABLECLASS = 0x00000013,
    DETECTVERIFY = 0x00000014,
    INSTALLDEVICEFILES = 0x00000015,
    UNREMOVE = 0x00000016,
    SELECTBESTCOMPATDRV = 0x00000017,
    ALLOW_INSTALL = 0x00000018,
    REGISTERDEVICE = 0x00000019,
    NEWDEVICEWIZARD_PRESELECT = 0x0000001A,
    NEWDEVICEWIZARD_SELECT = 0x0000001B,
    NEWDEVICEWIZARD_PREANALYZE = 0x0000001C,
    NEWDEVICEWIZARD_POSTANALYZE = 0x0000001D,
    NEWDEVICEWIZARD_FINISHINSTALL = 0x0000001E,
    UNUSED1 = 0x0000001F,
    INSTALLINTERFACES = 0x00000020,
    DETECTCANCEL = 0x00000021,
    REGISTER_COINSTALLERS = 0x00000022,
    ADDPROPERTYPAGE_ADVANCED = 0x00000023,
    ADDPROPERTYPAGE_BASIC = 0x00000024,
    RESERVED1 = 0x00000025,
    TROUBLESHOOTER = 0x00000026,
    POWERMESSAGEWAKE = 0x00000027,
    ADDREMOTEPROPERTYPAGE_ADVANCED = 0x00000028,
    UPDATEDRIVER_UI = 0x00000029,
    FINISHINSTALL_ACTION = 0x0000002A,
    RESERVED2 = 0x00000030,
}