using System.Runtime.InteropServices;
using DeviceManagement.constants;

namespace DeviceManagement.imports;

[StructLayout(LayoutKind.Sequential)]
public struct SP_CLASSINSTALL_HEADER
{
    public UInt32 cbSize;
    public DIF InstallFunction;
}