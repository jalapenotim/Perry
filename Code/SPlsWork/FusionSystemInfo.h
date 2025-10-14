namespace Fusion_System_Info;
        // class declarations
         class FusionSystemInfo;
     class FusionSystemInfo 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION Initialize ();
        STRING_FUNCTION GetIPAddress ();
        STRING_FUNCTION GetDHCPState ();
        STRING_FUNCTION GetMACAddress ();
        STRING_FUNCTION GetHostName ();
        LONG_INTEGER_FUNCTION DevicePlatform ();
        STRING_FUNCTION FirmwareVersion ();
        STRING_FUNCTION SerialNumber ();
        STRING_FUNCTION GenerateGUID ();
        STRING_FUNCTION GetFormattedMACAddr ();
        STRING_FUNCTION GetCompileDate ();
        STRING_FUNCTION GetProgramFileName ();
        STRING_FUNCTION GetFileStorageLocation ();
        STRING_FUNCTION RoomID ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

