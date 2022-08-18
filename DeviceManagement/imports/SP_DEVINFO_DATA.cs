using System.Runtime.InteropServices;

namespace DeviceManagement.imports;

[StructLayout(LayoutKind.Sequential)]
public struct SP_DEVINFO_DATA
{
    public UInt32 cbSize;
    public Guid ClassGuid;
    public UInt32 DevInst;
    public IntPtr Reserved;
}