using System.Runtime.InteropServices;
using DeviceManagement.constants;

namespace DeviceManagement.imports;

[StructLayout(LayoutKind.Sequential)]
public struct SP_PROPCHANGE_PARAMS
{
    public SP_CLASSINSTALL_HEADER ClassInstallHeader;
    public DICS StateChange;
    public DICS_FLAG Scope;
    public UInt32 HwProfile;
}