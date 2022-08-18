using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using DeviceManagement.constants;

namespace DeviceManagement.imports;

public static class WinApi
{
    private const string SETUPAPI = "setupapi.dll";
    private const string ADVAPI = "advapi32.dll";
    private const int ERROR_INVALID_DATA = 13;
    private const int ERROR_INSUFFICIENT_BUFFER = 122;

    [DllImport( SETUPAPI, SetLastError = true, CharSet = CharSet.Unicode )]
    public static extern SafeDeviceInformationSetHandle SetupDiGetClassDevsW(
        [In] ref Guid ClassGuid,
        [In] IntPtr Enumerator,
        IntPtr parent,
        DIGCF flags
    );

    [DllImport( SETUPAPI, SetLastError = true )]
    [ReliabilityContract( Consistency.WillNotCorruptState, Cer.Success )]
    public static extern bool SetupDiDestroyDeviceInfoList( IntPtr handle );

    [DllImport( SETUPAPI, SetLastError = true )]
    public static extern bool SetupDiEnumDeviceInfo(
        SafeDeviceInformationSetHandle deviceInfoSet,
        uint memberIndex,
        [Out] out SP_DEVINFO_DATA deviceInfoData
    );

    [DllImport( SETUPAPI, SetLastError = true )]
    public static extern bool SetupDiSetClassInstallParams(
        SafeDeviceInformationSetHandle deviceInfoSet,
        [In] ref SP_DEVINFO_DATA deviceInfoData,
        [In] ref SP_PROPCHANGE_PARAMS classInstallParams,
        UInt32 ClassInstallParamsSize );

    [DllImport( SETUPAPI, SetLastError = true )]
    public static extern bool SetupDiChangeState(
        SafeDeviceInformationSetHandle deviceInfoSet,
        [In] ref SP_DEVINFO_DATA deviceInfoData
    );

    [DllImport( SETUPAPI, SetLastError = true )]
    static extern bool SetupDiGetDeviceRegistryPropertyW(
        SafeDeviceInformationSetHandle DeviceInfoSet,
        [In] ref SP_DEVINFO_DATA DeviceInfoData,
        uint Property,
        [Out] out uint PropertyRegDataType,
        IntPtr PropertyBuffer,
        uint PropertyBufferSize,
        [In, Out] ref uint RequiredSize
    );

    public static void IsWin32CallSuccess( bool success )
    {
        if ( !success )
        {
            throw new Win32Exception();
        }
    }

    public static void CheckWin32Error( string message, int lasterror = -1 )
    {
        var code = lasterror == -1 ? Marshal.GetLastWin32Error() : lasterror;
        if ( code != 0 )
            throw new ApplicationException( $"Win API error (Code {code}): {message}" );
    }

    public static string? PropertyForDevice( SafeDeviceInformationSetHandle info, SP_DEVINFO_DATA devdata, uint propId )
    {
        uint proptype, outsize = 0, bufferSize = 2560;
        var buffer = IntPtr.Zero;
        try
        {
            buffer = Marshal.AllocHGlobal( ( int )bufferSize );
            SetupDiGetDeviceRegistryPropertyW(
                info,
                ref devdata,
                propId,
                out proptype,
                buffer,
                bufferSize,
                ref outsize
            );
            var errcode = Marshal.GetLastWin32Error();
            if ( errcode == ERROR_INVALID_DATA ) return null;
            CheckWin32Error( "SetupDiGetDeviceProperty", errcode );
            return Marshal.PtrToStringUni( buffer );
        }
        finally
        {
            if ( buffer != IntPtr.Zero )
                Marshal.FreeHGlobal( buffer );
        }
    }
}