using System;
using System.Runtime.InteropServices;
using DeviceManagement.constants;
using DeviceManagement.imports;
using static DeviceManagement.imports.WinApi;

namespace DeviceManagement
{
    public class DeviceManager
    {
        const uint ERROR_NO_MORE_ITEMS = 259;

        public bool RestartDevice( string physicalName )
        {
            var devData = new SP_DEVINFO_DATA();
            using var info = GetDevice( physicalName, ref devData );
            return SetupDiRestartDevices( info, ref devData );
        }

        public void ChangeDeviceState( string physicalName, bool disable )
        {
            var devData = new SP_DEVINFO_DATA();
            using var info = GetDevice( physicalName, ref devData );

            if ( info != null )
            {
                SP_CLASSINSTALL_HEADER header = new SP_CLASSINSTALL_HEADER();
                header.cbSize = ( UInt32 )Marshal.SizeOf( header );
                header.InstallFunction = DIF.PROPERTYCHANGE;

                SP_PROPCHANGE_PARAMS propchangeparams = new SP_PROPCHANGE_PARAMS();
                propchangeparams.ClassInstallHeader = header;
                propchangeparams.StateChange = disable ? DICS.DISABLE : DICS.ENABLE;
                propchangeparams.Scope = DICS_FLAG.GLOBAL;
                propchangeparams.HwProfile = 0;

                SetupDiSetClassInstallParams(
                    info,
                    ref devData,
                    ref propchangeparams,
                    ( UInt32 )Marshal.SizeOf( propchangeparams )
                );
                CheckWin32Error( "SetupDiSetClassInstallParams" );

                SetupDiChangeState( info, ref devData );
                CheckWin32Error( "SetupDiChangeState" );
            }
        }

        public Device? GetDevice( string physicalName )
        {
            var devData = new SP_DEVINFO_DATA();
            Device? device = null;

            using var info = GetDevice( physicalName, ref devData );
            if ( info != null )
            {
                device = CreateDevice( info, devData );
            }

            return device;
        }

        public List<Device> GetDevices()
        {
            var devices = new List<Device>();
            var emptyGuid = Guid.Empty;

            using var infoHandle = SetupDiGetClassDevsW(
                ref emptyGuid,
                IntPtr.Zero,
                IntPtr.Zero,
                DIGCF.ALLCLASSES | DIGCF.PRESENT
            );

            CheckWin32Error( "SetupDiGetClassDevs" );

            var devData = new SP_DEVINFO_DATA();
            devData.cbSize = ( uint )Marshal.SizeOf( devData );

            for ( uint i = 0;; i++ )
            {
                SetupDiEnumDeviceInfo( infoHandle, i, out devData );
                if ( Marshal.GetLastWin32Error() == ERROR_NO_MORE_ITEMS )
                    break;
                CheckWin32Error( "SetupDiEnumDeviceInfo" );
                devices.Add(CreateDevice(infoHandle, devData));
            }

            return devices;
        }

        private Device CreateDevice( SafeDeviceInformationSetHandle info, SP_DEVINFO_DATA devData )
        {
            return new Device
            {
                Class = PropertyForDevice( info, devData, ( uint )SPDRP.CLASS ) ?? "",
                ClassGuid = PropertyForDevice( info, devData, ( uint )SPDRP.CLASSGUID ) ?? "",
                CompatibleIds = PropertyForDevice( info, devData, ( uint )SPDRP.COMPATIBLEIDS ) ?? "",
                Description = PropertyForDevice( info, devData, ( uint )SPDRP.DEVICEDESC ) ?? "",
                Driver = PropertyForDevice( info, devData, ( uint )SPDRP.DRIVER ) ?? "",
                Enumerator = PropertyForDevice( info, devData, ( uint )SPDRP.ENUMERATOR_NAME ) ?? "",
                HardwareId = PropertyForDevice( info, devData, ( uint )SPDRP.HARDWAREID ) ?? "",
                MFG = PropertyForDevice( info, devData, ( uint )SPDRP.MFG ) ?? "",
                Name = PropertyForDevice( info, devData, ( uint )SPDRP.FRIENDLYNAME ),
                PhysicalName = PropertyForDevice( info, devData, ( uint )SPDRP.PHYSICAL_DEVICE_OBJECT_NAME ) ?? ""
            };
        }

        /// <summary>
        /// Requires destroying info when done, even if it failed
        /// </summary>
        /// <param name="physicalName"></param>
        /// <param name="info"></param>
        /// <param name="devData"></param>
        /// <returns></returns>
        private SafeDeviceInformationSetHandle? GetDevice(
            string physicalName,
            ref SP_DEVINFO_DATA devData
        )
        {
            var emptyGuid = Guid.Empty;

            var info = SetupDiGetClassDevsW( ref emptyGuid, IntPtr.Zero, IntPtr.Zero,
                                             DIGCF.ALLCLASSES | DIGCF.PRESENT );
            CheckWin32Error( "SetupDiGetClassDevs" );

            devData = new SP_DEVINFO_DATA();
            devData.cbSize = ( uint )Marshal.SizeOf( devData );

            for ( uint i = 0;; i++ )
            {
                SetupDiEnumDeviceInfo( info, i, out devData );
                if ( Marshal.GetLastWin32Error() == ERROR_NO_MORE_ITEMS )
                    break;
                CheckWin32Error( "SetupDiEnumDeviceInfo" );

                var physicalObjectName =
                    PropertyForDevice( info, devData, ( uint )SPDRP.PHYSICAL_DEVICE_OBJECT_NAME ) ?? "";

                if ( physicalName == physicalObjectName ) return info;
            }

            return null;
        }
    }
}