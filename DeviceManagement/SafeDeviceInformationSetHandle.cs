using System.Security;
using DeviceManagement.imports;
using Microsoft.Win32.SafeHandles;

namespace DeviceManagement;

public class SafeDeviceInformationSetHandle : SafeHandleMinusOneIsInvalid
{
    private SafeDeviceInformationSetHandle() : base(true)
    { }

    private SafeDeviceInformationSetHandle(IntPtr preexistingHandle, bool ownsHandle) : base(ownsHandle)
    {
        SetHandle(preexistingHandle);
    }

    [SecurityCritical]
    protected override bool ReleaseHandle()
    {
        return WinApi.SetupDiDestroyDeviceInfoList(handle);
    }
}