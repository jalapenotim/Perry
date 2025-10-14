using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using Fusion_System_Info;

namespace CrestronModule_FUSION_SSI_SYSTEM_INFORMATION_V1_5
{
    public class CrestronModuleClass_FUSION_SSI_SYSTEM_INFORMATION_V1_5 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput PROCESS;
        Crestron.Logos.SplusObjects.DigitalInput REBOOT_PROCESSOR;
        Crestron.Logos.SplusObjects.BufferInput CONSOLE_RX__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput DHCP_ON;
        Crestron.Logos.SplusObjects.StringOutput CONSOLE_TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput PROCESSOR_MODEL;
        Crestron.Logos.SplusObjects.StringOutput PROCESSOR_FIRMWARE;
        Crestron.Logos.SplusObjects.StringOutput FIRMWARE_DATE;
        Crestron.Logos.SplusObjects.StringOutput PROCESSOR_MAC;
        Crestron.Logos.SplusObjects.StringOutput PROCESSOR_IP;
        Crestron.Logos.SplusObjects.StringOutput PROCESSOR_HOSTNAME;
        Crestron.Logos.SplusObjects.StringOutput PROCESSOR_SERIAL;
        Crestron.Logos.SplusObjects.StringOutput PROCESSOR_UPTIME;
        Crestron.Logos.SplusObjects.StringOutput PROGRAM_UPTIME;
        Crestron.Logos.SplusObjects.StringOutput PROGRAMMER_NAME;
        Crestron.Logos.SplusObjects.StringOutput SYSTEM_NAME;
        Crestron.Logos.SplusObjects.StringOutput SOURCE_FILE;
        Crestron.Logos.SplusObjects.StringOutput COMPILE_DATE;
        ushort STEPNUM = 0;
        ushort HASRAN = 0;
        SYSTEM_INFO THIS;
        Fusion_System_Info.FusionSystemInfo FUSIONSYSTEMINFO;
        
        ushort [] DAYS_IN_MONTH;
        ushort DD = 0;
        ushort MM = 0;
        ushort YYYY = 0;
        ushort DAYCOUNTER = 0;
        CrestronString [] PLANTCODES;
        CrestronString SERIALNUMBERCHARACTERS;
        private void SENDCOMMAND (  SplusExecutionContext __context__, ushort I ) 
            { 
            
            __context__.SourceCodeLine = 98;
            STEPNUM = (ushort) ( I ) ; 
            __context__.SourceCodeLine = 100;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.GetSeries() == 2))  ) ) 
                { 
                __context__.SourceCodeLine = 102;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_1__ = ((int)I);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 106;
                            CONSOLE_TX__DOLLAR__  .UpdateValue ( "ver\u000d"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 110;
                            CONSOLE_TX__DOLLAR__  .UpdateValue ( "est\u000d"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 114;
                            CONSOLE_TX__DOLLAR__  .UpdateValue ( "uptime\u000d"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 118;
                            CONSOLE_TX__DOLLAR__  .UpdateValue ( "proguptime\u000d"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 122;
                            CONSOLE_TX__DOLLAR__  .UpdateValue ( "progcomments\u000d"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 126;
                            CONSOLE_TX__DOLLAR__  .UpdateValue ( "hostname\u000d"  ) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 130;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.GetSeries() == 3) ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.GetSeries() == 4) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 132;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_2__ = ((int)I);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 136;
                                CONSOLE_TX__DOLLAR__  .UpdateValue ( "ver\u000d"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 140;
                                CONSOLE_TX__DOLLAR__  .UpdateValue ( "ipconfig\u000d"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 144;
                                CONSOLE_TX__DOLLAR__  .UpdateValue ( "uptime\u000d"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 148;
                                CONSOLE_TX__DOLLAR__  .UpdateValue ( "proguptime:" + Functions.ItoA (  (int) ( GetProgramNumber() ) ) + "\u000d"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 5) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 152;
                                CONSOLE_TX__DOLLAR__  .UpdateValue ( "progcomments:" + Functions.ItoA (  (int) ( GetProgramNumber() ) ) + "\u000d"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 6) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 156;
                                CONSOLE_TX__DOLLAR__  .UpdateValue ( "hostname\u000d"  ) ; 
                                } 
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                }
            
            
            }
            
        private void VC4GETSYSTEMINFO (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 164;
            
            
            }
            
        object PROCESS_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 230;
                __context__.SourceCodeLine = 234;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FUSIONSYSTEMINFO.DevicePlatform() == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 236;
                    VC4GETSYSTEMINFO (  __context__  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 240;
                    STEPNUM = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 241;
                    SENDCOMMAND (  __context__ , (ushort)( STEPNUM )) ; 
                    } 
                
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object REBOOT_PROCESSOR_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 249;
            CONSOLE_TX__DOLLAR__  .UpdateValue ( "reboot\u000d"  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
private ushort ISLEAPYEAR (  SplusExecutionContext __context__, ushort Y ) 
    { 
    
    __context__.SourceCodeLine = 256;
    return (ushort)( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Mod( Y , 4 ) == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (Mod( Y , 100 ) != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (Mod( Y , 400 ) == 0) )) )) ; 
    
    }
    
private void NEXT_DAY (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 261;
    DD = (ushort) ( (DD + 1) ) ; 
    __context__.SourceCodeLine = 262;
    DAYCOUNTER = (ushort) ( (DAYCOUNTER + 1) ) ; 
    __context__.SourceCodeLine = 263;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( DD > DAYS_IN_MONTH[ MM ] ))  ) ) 
        { 
        __context__.SourceCodeLine = 264;
        DD = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 265;
        MM = (ushort) ( (MM + 1) ) ; 
        __context__.SourceCodeLine = 266;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( MM > 12 ))  ) ) 
            { 
            __context__.SourceCodeLine = 267;
            MM = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 268;
            YYYY = (ushort) ( (YYYY + 1) ) ; 
            __context__.SourceCodeLine = 269;
            if ( Functions.TestForTrue  ( ( ISLEAPYEAR( __context__ , (ushort)( YYYY ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 270;
                DAYS_IN_MONTH [ 2] = (ushort) ( 29 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 272;
                DAYS_IN_MONTH [ 2] = (ushort) ( 28 ) ; 
                } 
            
            } 
        
        } 
    
    
    }
    
private void SET_DATE (  SplusExecutionContext __context__, ushort D , ushort M , ushort Y ) 
    { 
    
    __context__.SourceCodeLine = 280;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( M < 1 ))  ) ) 
        { 
        __context__.SourceCodeLine = 282;
        M = (ushort) ( 1 ) ; 
        } 
    
    __context__.SourceCodeLine = 284;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( M > 12 ))  ) ) 
        { 
        __context__.SourceCodeLine = 286;
        M = (ushort) ( 12 ) ; 
        } 
    
    __context__.SourceCodeLine = 288;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( D < 1 ))  ) ) 
        { 
        __context__.SourceCodeLine = 290;
        D = (ushort) ( 1 ) ; 
        } 
    
    __context__.SourceCodeLine = 292;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( D > DAYS_IN_MONTH[ M ] ))  ) ) 
        { 
        __context__.SourceCodeLine = 294;
        D = (ushort) ( DAYS_IN_MONTH[ M ] ) ; 
        } 
    
    __context__.SourceCodeLine = 297;
    if ( Functions.TestForTrue  ( ( ISLEAPYEAR( __context__ , (ushort)( Y ) ))  ) ) 
        { 
        __context__.SourceCodeLine = 298;
        DAYS_IN_MONTH [ 2] = (ushort) ( 29 ) ; 
        } 
    
    else 
        { 
        __context__.SourceCodeLine = 300;
        DAYS_IN_MONTH [ 2] = (ushort) ( 28 ) ; 
        } 
    
    __context__.SourceCodeLine = 302;
    DD = (ushort) ( D ) ; 
    __context__.SourceCodeLine = 303;
    MM = (ushort) ( M ) ; 
    __context__.SourceCodeLine = 304;
    YYYY = (ushort) ( Y ) ; 
    
    }
    
private void SKIP_DAYS (  SplusExecutionContext __context__, uint X ) 
    { 
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 310;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)(X - 1); 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 312;
        NEXT_DAY (  __context__  ) ; 
        __context__.SourceCodeLine = 310;
        } 
    
    
    }
    
private void GETABSOLUTEWEEKANDYEAR (  SplusExecutionContext __context__, uint TOTALWEEKS , ref ushort WEEK , ref ushort YEAR ) 
    { 
    ushort STARTDATE = 0;
    ushort TARGETDATE = 0;
    ushort COMPLETEYEARS = 0;
    
    
    __context__.SourceCodeLine = 325;
    SET_DATE (  __context__ , (ushort)( 1 ), (ushort)( 1 ), (ushort)( 2016 )) ; 
    __context__.SourceCodeLine = 326;
    SKIP_DAYS (  __context__ , (uint)( (TOTALWEEKS * 7) )) ; 
    __context__.SourceCodeLine = 328;
    COMPLETEYEARS = (ushort) ( (YYYY - 2016) ) ; 
    __context__.SourceCodeLine = 330;
    YEAR = (ushort) ( YYYY ) ; 
    __context__.SourceCodeLine = 331;
    WEEK = (ushort) ( (TOTALWEEKS - ((COMPLETEYEARS * 365) / 7)) ) ; 
    
    }
    
private CrestronString CONVERTTSIDTOSERIALNUMBER (  SplusExecutionContext __context__, uint TSID ) 
    { 
    uint NSEQ = 0;
    uint NPLANTID = 0;
    uint NTOTALWEEKS = 0;
    uint NSCHEMA = 0;
    uint NTEMP1 = 0;
    uint NTEMP2 = 0;
    uint NTEMP3 = 0;
    
    ushort WEEK = 0;
    ushort YEAR = 0;
    
    CrestronString SERIALNUM;
    SERIALNUM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 12, this );
    
    
    __context__.SourceCodeLine = 342;
    NSCHEMA = (uint) ( ((TSID & 3221225472) >> 30) ) ; 
    __context__.SourceCodeLine = 344;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NSCHEMA != 2))  ) ) 
        { 
        __context__.SourceCodeLine = 346;
        NTEMP1 = (uint) ( (((2147483648 & TSID) >> 4) | (TSID & 134217727)) ) ; 
        __context__.SourceCodeLine = 347;
        NTEMP2 = (uint) ( ((2013265920 & TSID) >> 27) ) ; 
        __context__.SourceCodeLine = 348;
        NTEMP3 = (uint) ( ((117440512 & TSID) >> 24) ) ; 
        __context__.SourceCodeLine = 350;
        SERIALNUM  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 352;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NTEMP2 != 0))  ) ) 
            { 
            __context__.SourceCodeLine = 354;
            SERIALNUM  .UpdateValue ( SERIALNUM + Functions.Mid ( SERIALNUMBERCHARACTERS ,  (int) ( (NTEMP2 + 1) ) ,  (int) ( 1 ) )  ) ; 
            } 
        
        __context__.SourceCodeLine = 356;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (NTEMP2 != 0) ) && Functions.TestForTrue ( Functions.BoolToInt (NTEMP3 == 0) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 358;
            SERIALNUM  .UpdateValue ( SERIALNUM + " "  ) ; 
            } 
        
        __context__.SourceCodeLine = 360;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NTEMP1 > 9999999 ))  ) ) 
            { 
            __context__.SourceCodeLine = 362;
            MakeString ( SERIALNUM , "{0}{1:d1}", SERIALNUM , (int)NTEMP1) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 366;
            MakeString ( SERIALNUM , "{0}{1:d7}", SERIALNUM , (int)NTEMP1) ; 
            } 
        
        } 
    
    else 
        { 
        __context__.SourceCodeLine = 371;
        NSEQ = (uint) ( (TSID & 32767) ) ; 
        __context__.SourceCodeLine = 372;
        NPLANTID = (uint) ( ((TSID & 1015808) >> 15) ) ; 
        __context__.SourceCodeLine = 373;
        NTOTALWEEKS = (uint) ( ((TSID & 1072693248) >> 20) ) ; 
        __context__.SourceCodeLine = 375;
        GETABSOLUTEWEEKANDYEAR (  __context__ , (uint)( NTOTALWEEKS ),   ref  WEEK ,   ref  YEAR ) ; 
        __context__.SourceCodeLine = 377;
        MakeString ( SERIALNUM , "{0:d2}{1:d2}{2}{3:d5}", (short)(YEAR - 2000), (short)WEEK, PLANTCODES [ NPLANTID ] , (int)NSEQ) ; 
        } 
    
    __context__.SourceCodeLine = 380;
    return ( SERIALNUM ) ; 
    
    }
    
private CrestronString SFPARSE (  SplusExecutionContext __context__, CrestronString LS_TEMP ) 
    { 
    ushort LI_LOC1 = 0;
    ushort LI_LOC2 = 0;
    ushort LI_LOC3 = 0;
    
    CrestronString LS_DHCP;
    CrestronString LS_WEBSERVER;
    CrestronString LS_SERIALNUMBER;
    CrestronString NEW_SERIALNUMBER;
    LS_DHCP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    LS_WEBSERVER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    LS_SERIALNUMBER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    NEW_SERIALNUMBER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 12, this );
    
    
    __context__.SourceCodeLine = 391;
    
        {
        int __SPLS_TMPVAR__SWTCH_3__ = ((int)STEPNUM);
        
            { 
            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                { 
                __context__.SourceCodeLine = 396;
                LI_LOC1 = (ushort) ( Functions.Find( "\u005B\u0076" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 397;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 399;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u0028" , LS_TEMP , (LI_LOC1 + 2) ) ) ; 
                    __context__.SourceCodeLine = 400;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.FIRMWARE != Functions.Mid( LS_TEMP , (int)( (LI_LOC1 + 2) ) , (int)( ((LI_LOC2 - LI_LOC1) - 3) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 402;
                        THIS . FIRMWARE  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 2) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 3) ) )  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 404;
                    PROCESSOR_FIRMWARE  .UpdateValue ( THIS . FIRMWARE  ) ; 
                    } 
                
                __context__.SourceCodeLine = 408;
                LI_LOC1 = (ushort) ( Functions.Find( "\u0028" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 409;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 411;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u0029" , LS_TEMP , (LI_LOC1 + 1) ) ) ; 
                    __context__.SourceCodeLine = 412;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.FIRMWARE_DATE != Functions.Mid( LS_TEMP , (int)( (LI_LOC1 + 1) ) , (int)( ((LI_LOC2 - LI_LOC1) - 1) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 414;
                        THIS . FIRMWARE_DATE  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 1) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 1) ) )  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 416;
                    FIRMWARE_DATE  .UpdateValue ( THIS . FIRMWARE_DATE  ) ; 
                    } 
                
                __context__.SourceCodeLine = 420;
                LI_LOC1 = (ushort) ( Functions.Find( "\u002C\u0020\u0023" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 421;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 423;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u005D" , LS_TEMP , (LI_LOC1 + 9) ) ) ; 
                    __context__.SourceCodeLine = 424;
                    LS_SERIALNUMBER  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 3) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 3) ) )  ) ; 
                    __context__.SourceCodeLine = 426;
                    NEW_SERIALNUMBER  .UpdateValue ( CONVERTTSIDTOSERIALNUMBER (  __context__ , (uint)( Functions.HextoL( LS_SERIALNUMBER ) ))  ) ; 
                    __context__.SourceCodeLine = 427;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.SERIAL != NEW_SERIALNUMBER))  ) ) 
                        { 
                        __context__.SourceCodeLine = 429;
                        THIS . SERIAL  .UpdateValue ( NEW_SERIALNUMBER  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 431;
                    PROCESSOR_SERIAL  .UpdateValue ( THIS . SERIAL  ) ; 
                    } 
                
                __context__.SourceCodeLine = 435;
                LI_LOC1 = (ushort) ( Functions.Find( "Cntrl" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 436;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 438;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.MODEL != Functions.Left( LS_TEMP , (int)( (LI_LOC1 - 2) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 440;
                        THIS . MODEL  .UpdateValue ( Functions.Left ( LS_TEMP ,  (int) ( (LI_LOC1 - 2) ) )  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 442;
                    PROCESSOR_MODEL  .UpdateValue ( THIS . MODEL  ) ; 
                    __context__.SourceCodeLine = 443;
                    STEPNUM = (ushort) ( (STEPNUM + 1) ) ; 
                    __context__.SourceCodeLine = 444;
                    SENDCOMMAND (  __context__ , (ushort)( STEPNUM )) ; 
                    } 
                
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                { 
                __context__.SourceCodeLine = 449;
                __context__.SourceCodeLine = 501;
                LI_LOC1 = (ushort) ( Functions.Find( "DHCP" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 502;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 504;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u000D\u000A" , LS_TEMP , (LI_LOC1 + 22) ) ) ; 
                    __context__.SourceCodeLine = 505;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.DHCP != Functions.Mid( LS_TEMP , (int)( (LI_LOC1 + 22) ) , (int)( ((LI_LOC2 - LI_LOC1) - 22) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 507;
                        THIS . DHCP  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 22) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 22) ) )  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 509;
                    THIS . DHCP  .UpdateValue ( Functions.Lower ( THIS . DHCP )  ) ; 
                    __context__.SourceCodeLine = 510;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "on" , THIS.DHCP ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 512;
                        DHCP_ON  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 514;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "off" , THIS.DHCP ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 516;
                            DHCP_ON  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 521;
                LI_LOC1 = (ushort) ( Functions.Find( "IP Address" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 522;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 524;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u000D\u000A" , LS_TEMP , (LI_LOC1 + 22) ) ) ; 
                    __context__.SourceCodeLine = 526;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.IP != Functions.Mid( LS_TEMP , (int)( (LI_LOC1 + 22) ) , (int)( ((LI_LOC2 - LI_LOC1) - 22) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 528;
                        THIS . IP  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 22) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 22) ) )  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 530;
                    PROCESSOR_IP  .UpdateValue ( THIS . IP  ) ; 
                    } 
                
                __context__.SourceCodeLine = 534;
                LI_LOC1 = (ushort) ( Functions.Find( "MAC Address" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 535;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 537;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u000D\u000A" , LS_TEMP , (LI_LOC1 + 22) ) ) ; 
                    __context__.SourceCodeLine = 538;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.MAC != Functions.Mid( LS_TEMP , (int)( (LI_LOC1 + 22) ) , (int)( ((LI_LOC2 - LI_LOC1) - 22) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 540;
                        THIS . MAC  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 22) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 22) ) )  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 542;
                    PROCESSOR_MAC  .UpdateValue ( THIS . MAC  ) ; 
                    __context__.SourceCodeLine = 543;
                    STEPNUM = (ushort) ( (STEPNUM + 1) ) ; 
                    __context__.SourceCodeLine = 544;
                    SENDCOMMAND (  __context__ , (ushort)( STEPNUM )) ; 
                    } 
                
                
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                { 
                __context__.SourceCodeLine = 552;
                LI_LOC1 = (ushort) ( Functions.Find( "running for" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 553;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 555;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u000D\u000A" , LS_TEMP , (LI_LOC1 + 12) ) ) ; 
                    __context__.SourceCodeLine = 556;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.PROCESSOR_UPTIME != Functions.Mid( LS_TEMP , (int)( (LI_LOC1 + 12) ) , (int)( ((LI_LOC2 - LI_LOC1) - 12) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 558;
                        THIS . PROCESSOR_UPTIME  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 12) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 12) ) )  ) ; 
                        __context__.SourceCodeLine = 559;
                        PROCESSOR_UPTIME  .UpdateValue ( THIS . PROCESSOR_UPTIME  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 561;
                    STEPNUM = (ushort) ( (STEPNUM + 1) ) ; 
                    __context__.SourceCodeLine = 562;
                    SENDCOMMAND (  __context__ , (ushort)( STEPNUM )) ; 
                    } 
                
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 4) ) ) ) 
                { 
                __context__.SourceCodeLine = 568;
                LI_LOC1 = (ushort) ( Functions.Find( "running for" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 569;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 571;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u000D\u000A" , LS_TEMP , (LI_LOC1 + 12) ) ) ; 
                    __context__.SourceCodeLine = 572;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.PROGRAM_UPTIME != Functions.Mid( LS_TEMP , (int)( (LI_LOC1 + 12) ) , (int)( ((LI_LOC2 - LI_LOC1) - 12) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 574;
                        THIS . PROGRAM_UPTIME  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 12) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 12) ) )  ) ; 
                        __context__.SourceCodeLine = 575;
                        PROGRAM_UPTIME  .UpdateValue ( THIS . PROGRAM_UPTIME  ) ; 
                        __context__.SourceCodeLine = 577;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HASRAN == 1))  ) ) 
                            { 
                            } 
                        
                        else 
                            { 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 587;
                    STEPNUM = (ushort) ( (STEPNUM + 1) ) ; 
                    __context__.SourceCodeLine = 588;
                    SENDCOMMAND (  __context__ , (ushort)( STEPNUM )) ; 
                    } 
                
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 5) ) ) ) 
                { 
                __context__.SourceCodeLine = 594;
                LI_LOC1 = (ushort) ( Functions.Find( "Program File:" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 595;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 597;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u000D\u000A" , LS_TEMP , (LI_LOC1 + 14) ) ) ; 
                    __context__.SourceCodeLine = 598;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.FILE != Functions.Mid( LS_TEMP , (int)( (LI_LOC1 + 14) ) , (int)( ((LI_LOC2 - LI_LOC1) - 14) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 600;
                        THIS . FILE  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 14) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 14) ) )  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 602;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.GetSeries() == 2))  ) ) 
                        { 
                        __context__.SourceCodeLine = 604;
                        SOURCE_FILE  .UpdateValue ( THIS . FILE  ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 606;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.GetSeries() == 3) ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.GetSeries() == 4) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 608;
                            SOURCE_FILE  .UpdateValue ( "Slot " + Functions.ItoA (  (int) ( GetProgramNumber() ) ) + ":" + THIS . FILE  ) ; 
                            } 
                        
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 613;
                LI_LOC1 = (ushort) ( Functions.Find( "Compiled On:" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 614;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 616;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u000D\u000A" , LS_TEMP , (LI_LOC1 + 14) ) ) ; 
                    __context__.SourceCodeLine = 617;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.COMPILE_DATE != Functions.Mid( LS_TEMP , (int)( (LI_LOC1 + 14) ) , (int)( ((LI_LOC2 - LI_LOC1) - 14) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 619;
                        THIS . COMPILE_DATE  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 14) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 14) ) )  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 621;
                    COMPILE_DATE  .UpdateValue ( THIS . COMPILE_DATE  ) ; 
                    } 
                
                __context__.SourceCodeLine = 625;
                LI_LOC1 = (ushort) ( Functions.Find( "System Name:" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 626;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 628;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u000D\u000A" , LS_TEMP , (LI_LOC1 + 14) ) ) ; 
                    __context__.SourceCodeLine = 629;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.SYSTEM != Functions.Mid( LS_TEMP , (int)( (LI_LOC1 + 14) ) , (int)( ((LI_LOC2 - LI_LOC1) - 14) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 631;
                        THIS . SYSTEM  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 14) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 14) ) )  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 633;
                    SYSTEM_NAME  .UpdateValue ( THIS . SYSTEM  ) ; 
                    } 
                
                __context__.SourceCodeLine = 637;
                LI_LOC1 = (ushort) ( Functions.Find( "Programmer:" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 638;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 640;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u000D\u000A" , LS_TEMP , (LI_LOC1 + 14) ) ) ; 
                    __context__.SourceCodeLine = 641;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.PROGRAMMER != Functions.Mid( LS_TEMP , (int)( (LI_LOC1 + 14) ) , (int)( ((LI_LOC2 - LI_LOC1) - 14) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 643;
                        THIS . PROGRAMMER  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 14) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 14) ) )  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 645;
                    PROGRAMMER_NAME  .UpdateValue ( THIS . PROGRAMMER  ) ; 
                    __context__.SourceCodeLine = 646;
                    STEPNUM = (ushort) ( (STEPNUM + 1) ) ; 
                    __context__.SourceCodeLine = 647;
                    SENDCOMMAND (  __context__ , (ushort)( STEPNUM )) ; 
                    } 
                
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 6) ) ) ) 
                { 
                __context__.SourceCodeLine = 653;
                LI_LOC1 = (ushort) ( Functions.Find( "Host Name:" , LS_TEMP ) ) ; 
                __context__.SourceCodeLine = 654;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LI_LOC1 != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 656;
                    LI_LOC2 = (ushort) ( Functions.Find( "\u000D\u000A" , LS_TEMP , (LI_LOC1 + 11) ) ) ; 
                    __context__.SourceCodeLine = 657;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THIS.HOSTNAME != Functions.Mid( LS_TEMP , (int)( (LI_LOC1 + 11) ) , (int)( ((LI_LOC2 - LI_LOC1) - 11) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 659;
                        THIS . HOSTNAME  .UpdateValue ( Functions.Mid ( LS_TEMP ,  (int) ( (LI_LOC1 + 11) ) ,  (int) ( ((LI_LOC2 - LI_LOC1) - 11) ) )  ) ; 
                        __context__.SourceCodeLine = 660;
                        HASRAN = (ushort) ( 1 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 662;
                    PROCESSOR_HOSTNAME  .UpdateValue ( THIS . HOSTNAME  ) ; 
                    } 
                
                } 
            
            } 
            
        }
        
    
    
    return ""; // default return value (none specified in module)
    }
    
object CONSOLE_RX__DOLLAR___OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString LS_RESPONSE;
        LS_RESPONSE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1500, this );
        
        
        __context__.SourceCodeLine = 672;
        while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( CONSOLE_RX__DOLLAR__ ) > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 674;
            LS_RESPONSE  .UpdateValue ( Functions.Remove ( "\u003E" , CONSOLE_RX__DOLLAR__ )  ) ; 
            __context__.SourceCodeLine = 677;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( LS_RESPONSE ) > 0 ))  ) ) 
                { 
                } 
            
            __context__.SourceCodeLine = 682;
            SFPARSE (  __context__ , LS_RESPONSE) ; 
            __context__.SourceCodeLine = 672;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 690;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 691;
        THIS . DHCP  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 692;
        THIS . MODEL  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 693;
        THIS . FIRMWARE  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 694;
        THIS . FIRMWARE_DATE  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 695;
        THIS . MAC  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 696;
        THIS . IP  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 697;
        THIS . HOSTNAME  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 698;
        THIS . SERIAL  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 699;
        THIS . PROGRAM_UPTIME  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 700;
        THIS . PROCESSOR_UPTIME  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 701;
        THIS . PROGRAMMER  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 702;
        THIS . SYSTEM  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 703;
        THIS . FILE  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 704;
        THIS . COMPILE_DATE  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 706;
        DAYS_IN_MONTH [ 0] = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 707;
        DAYS_IN_MONTH [ 1] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 708;
        DAYS_IN_MONTH [ 2] = (ushort) ( 28 ) ; 
        __context__.SourceCodeLine = 709;
        DAYS_IN_MONTH [ 3] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 710;
        DAYS_IN_MONTH [ 4] = (ushort) ( 30 ) ; 
        __context__.SourceCodeLine = 711;
        DAYS_IN_MONTH [ 5] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 712;
        DAYS_IN_MONTH [ 6] = (ushort) ( 30 ) ; 
        __context__.SourceCodeLine = 713;
        DAYS_IN_MONTH [ 7] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 714;
        DAYS_IN_MONTH [ 8] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 715;
        DAYS_IN_MONTH [ 9] = (ushort) ( 30 ) ; 
        __context__.SourceCodeLine = 716;
        DAYS_IN_MONTH [ 10] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 717;
        DAYS_IN_MONTH [ 11] = (ushort) ( 30 ) ; 
        __context__.SourceCodeLine = 718;
        DAYS_IN_MONTH [ 12] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 720;
        PLANTCODES [ 0 ]  .UpdateValue ( "CRR"  ) ; 
        __context__.SourceCodeLine = 721;
        PLANTCODES [ 1 ]  .UpdateValue ( "CRC"  ) ; 
        __context__.SourceCodeLine = 722;
        PLANTCODES [ 2 ]  .UpdateValue ( "CRO"  ) ; 
        __context__.SourceCodeLine = 723;
        PLANTCODES [ 3 ]  .UpdateValue ( "JBG"  ) ; 
        __context__.SourceCodeLine = 724;
        PLANTCODES [ 4 ]  .UpdateValue ( "JBH"  ) ; 
        __context__.SourceCodeLine = 725;
        PLANTCODES [ 5 ]  .UpdateValue ( "NEJ"  ) ; 
        __context__.SourceCodeLine = 726;
        PLANTCODES [ 6 ]  .UpdateValue ( "NEK"  ) ; 
        __context__.SourceCodeLine = 727;
        PLANTCODES [ 7 ]  .UpdateValue ( "BEG"  ) ; 
        __context__.SourceCodeLine = 728;
        PLANTCODES [ 8 ]  .UpdateValue ( "MCB"  ) ; 
        __context__.SourceCodeLine = 729;
        PLANTCODES [ 9 ]  .UpdateValue ( "MCM"  ) ; 
        __context__.SourceCodeLine = 730;
        PLANTCODES [ 10 ]  .UpdateValue ( "NPM"  ) ; 
        __context__.SourceCodeLine = 731;
        PLANTCODES [ 11 ]  .UpdateValue ( "OMA"  ) ; 
        __context__.SourceCodeLine = 732;
        PLANTCODES [ 12 ]  .UpdateValue ( "RWA"  ) ; 
        __context__.SourceCodeLine = 733;
        PLANTCODES [ 13 ]  .UpdateValue ( "ATH"  ) ; 
        __context__.SourceCodeLine = 734;
        PLANTCODES [ 14 ]  .UpdateValue ( "U14"  ) ; 
        __context__.SourceCodeLine = 735;
        PLANTCODES [ 15 ]  .UpdateValue ( "U15"  ) ; 
        __context__.SourceCodeLine = 736;
        PLANTCODES [ 16 ]  .UpdateValue ( "U16"  ) ; 
        __context__.SourceCodeLine = 737;
        PLANTCODES [ 17 ]  .UpdateValue ( "U17"  ) ; 
        __context__.SourceCodeLine = 738;
        PLANTCODES [ 18 ]  .UpdateValue ( "U18"  ) ; 
        __context__.SourceCodeLine = 739;
        PLANTCODES [ 19 ]  .UpdateValue ( "U19"  ) ; 
        __context__.SourceCodeLine = 740;
        PLANTCODES [ 20 ]  .UpdateValue ( "U20"  ) ; 
        __context__.SourceCodeLine = 741;
        PLANTCODES [ 21 ]  .UpdateValue ( "U21"  ) ; 
        __context__.SourceCodeLine = 742;
        PLANTCODES [ 22 ]  .UpdateValue ( "U22"  ) ; 
        __context__.SourceCodeLine = 743;
        PLANTCODES [ 23 ]  .UpdateValue ( "U23"  ) ; 
        __context__.SourceCodeLine = 744;
        PLANTCODES [ 24 ]  .UpdateValue ( "U24"  ) ; 
        __context__.SourceCodeLine = 745;
        PLANTCODES [ 25 ]  .UpdateValue ( "U25"  ) ; 
        __context__.SourceCodeLine = 746;
        PLANTCODES [ 26 ]  .UpdateValue ( "U26"  ) ; 
        __context__.SourceCodeLine = 747;
        PLANTCODES [ 27 ]  .UpdateValue ( "U27"  ) ; 
        __context__.SourceCodeLine = 748;
        PLANTCODES [ 28 ]  .UpdateValue ( "U28"  ) ; 
        __context__.SourceCodeLine = 749;
        PLANTCODES [ 29 ]  .UpdateValue ( "U29"  ) ; 
        __context__.SourceCodeLine = 750;
        PLANTCODES [ 30 ]  .UpdateValue ( "U30"  ) ; 
        __context__.SourceCodeLine = 751;
        PLANTCODES [ 31 ]  .UpdateValue ( "U31"  ) ; 
        __context__.SourceCodeLine = 753;
        SERIALNUMBERCHARACTERS  .UpdateValue ( " ABCDEFGXHI*JK$L"  ) ; 
        __context__.SourceCodeLine = 754;
        __context__.SourceCodeLine = 757;
        FUSIONSYSTEMINFO . Initialize ( ) ; 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    DAYS_IN_MONTH  = new ushort[ 13 ];
    SERIALNUMBERCHARACTERS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
    PLANTCODES  = new CrestronString[ 33 ];
    for( uint i = 0; i < 33; i++ )
        PLANTCODES [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    THIS  = new SYSTEM_INFO( this, true );
    THIS .PopulateCustomAttributeList( false );
    
    PROCESS = new Crestron.Logos.SplusObjects.DigitalInput( PROCESS__DigitalInput__, this );
    m_DigitalInputList.Add( PROCESS__DigitalInput__, PROCESS );
    
    REBOOT_PROCESSOR = new Crestron.Logos.SplusObjects.DigitalInput( REBOOT_PROCESSOR__DigitalInput__, this );
    m_DigitalInputList.Add( REBOOT_PROCESSOR__DigitalInput__, REBOOT_PROCESSOR );
    
    DHCP_ON = new Crestron.Logos.SplusObjects.DigitalOutput( DHCP_ON__DigitalOutput__, this );
    m_DigitalOutputList.Add( DHCP_ON__DigitalOutput__, DHCP_ON );
    
    CONSOLE_TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( CONSOLE_TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( CONSOLE_TX__DOLLAR____AnalogSerialOutput__, CONSOLE_TX__DOLLAR__ );
    
    PROCESSOR_MODEL = new Crestron.Logos.SplusObjects.StringOutput( PROCESSOR_MODEL__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PROCESSOR_MODEL__AnalogSerialOutput__, PROCESSOR_MODEL );
    
    PROCESSOR_FIRMWARE = new Crestron.Logos.SplusObjects.StringOutput( PROCESSOR_FIRMWARE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PROCESSOR_FIRMWARE__AnalogSerialOutput__, PROCESSOR_FIRMWARE );
    
    FIRMWARE_DATE = new Crestron.Logos.SplusObjects.StringOutput( FIRMWARE_DATE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FIRMWARE_DATE__AnalogSerialOutput__, FIRMWARE_DATE );
    
    PROCESSOR_MAC = new Crestron.Logos.SplusObjects.StringOutput( PROCESSOR_MAC__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PROCESSOR_MAC__AnalogSerialOutput__, PROCESSOR_MAC );
    
    PROCESSOR_IP = new Crestron.Logos.SplusObjects.StringOutput( PROCESSOR_IP__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PROCESSOR_IP__AnalogSerialOutput__, PROCESSOR_IP );
    
    PROCESSOR_HOSTNAME = new Crestron.Logos.SplusObjects.StringOutput( PROCESSOR_HOSTNAME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PROCESSOR_HOSTNAME__AnalogSerialOutput__, PROCESSOR_HOSTNAME );
    
    PROCESSOR_SERIAL = new Crestron.Logos.SplusObjects.StringOutput( PROCESSOR_SERIAL__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PROCESSOR_SERIAL__AnalogSerialOutput__, PROCESSOR_SERIAL );
    
    PROCESSOR_UPTIME = new Crestron.Logos.SplusObjects.StringOutput( PROCESSOR_UPTIME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PROCESSOR_UPTIME__AnalogSerialOutput__, PROCESSOR_UPTIME );
    
    PROGRAM_UPTIME = new Crestron.Logos.SplusObjects.StringOutput( PROGRAM_UPTIME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PROGRAM_UPTIME__AnalogSerialOutput__, PROGRAM_UPTIME );
    
    PROGRAMMER_NAME = new Crestron.Logos.SplusObjects.StringOutput( PROGRAMMER_NAME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PROGRAMMER_NAME__AnalogSerialOutput__, PROGRAMMER_NAME );
    
    SYSTEM_NAME = new Crestron.Logos.SplusObjects.StringOutput( SYSTEM_NAME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SYSTEM_NAME__AnalogSerialOutput__, SYSTEM_NAME );
    
    SOURCE_FILE = new Crestron.Logos.SplusObjects.StringOutput( SOURCE_FILE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SOURCE_FILE__AnalogSerialOutput__, SOURCE_FILE );
    
    COMPILE_DATE = new Crestron.Logos.SplusObjects.StringOutput( COMPILE_DATE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( COMPILE_DATE__AnalogSerialOutput__, COMPILE_DATE );
    
    CONSOLE_RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( CONSOLE_RX__DOLLAR____AnalogSerialInput__, 3000, this );
    m_StringInputList.Add( CONSOLE_RX__DOLLAR____AnalogSerialInput__, CONSOLE_RX__DOLLAR__ );
    
    
    PROCESS.OnDigitalPush.Add( new InputChangeHandlerWrapper( PROCESS_OnPush_0, false ) );
    REBOOT_PROCESSOR.OnDigitalPush.Add( new InputChangeHandlerWrapper( REBOOT_PROCESSOR_OnPush_1, false ) );
    CONSOLE_RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( CONSOLE_RX__DOLLAR___OnChange_2, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    FUSIONSYSTEMINFO  = new Fusion_System_Info.FusionSystemInfo();
    
    
}

public CrestronModuleClass_FUSION_SSI_SYSTEM_INFORMATION_V1_5 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint PROCESS__DigitalInput__ = 0;
const uint REBOOT_PROCESSOR__DigitalInput__ = 1;
const uint CONSOLE_RX__DOLLAR____AnalogSerialInput__ = 0;
const uint DHCP_ON__DigitalOutput__ = 0;
const uint CONSOLE_TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint PROCESSOR_MODEL__AnalogSerialOutput__ = 1;
const uint PROCESSOR_FIRMWARE__AnalogSerialOutput__ = 2;
const uint FIRMWARE_DATE__AnalogSerialOutput__ = 3;
const uint PROCESSOR_MAC__AnalogSerialOutput__ = 4;
const uint PROCESSOR_IP__AnalogSerialOutput__ = 5;
const uint PROCESSOR_HOSTNAME__AnalogSerialOutput__ = 6;
const uint PROCESSOR_SERIAL__AnalogSerialOutput__ = 7;
const uint PROCESSOR_UPTIME__AnalogSerialOutput__ = 8;
const uint PROGRAM_UPTIME__AnalogSerialOutput__ = 9;
const uint PROGRAMMER_NAME__AnalogSerialOutput__ = 10;
const uint SYSTEM_NAME__AnalogSerialOutput__ = 11;
const uint SOURCE_FILE__AnalogSerialOutput__ = 12;
const uint COMPILE_DATE__AnalogSerialOutput__ = 13;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}

[SplusStructAttribute(-1, true, false)]
public class SYSTEM_INFO : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public CrestronString  DHCP;
    
    [SplusStructAttribute(1, false, false)]
    public CrestronString  MODEL;
    
    [SplusStructAttribute(2, false, false)]
    public CrestronString  FIRMWARE;
    
    [SplusStructAttribute(3, false, false)]
    public CrestronString  FIRMWARE_DATE;
    
    [SplusStructAttribute(4, false, false)]
    public CrestronString  MAC;
    
    [SplusStructAttribute(5, false, false)]
    public CrestronString  IP;
    
    [SplusStructAttribute(6, false, false)]
    public CrestronString  HOSTNAME;
    
    [SplusStructAttribute(7, false, false)]
    public CrestronString  SERIAL;
    
    [SplusStructAttribute(8, false, false)]
    public CrestronString  PROCESSOR_UPTIME;
    
    [SplusStructAttribute(9, false, false)]
    public CrestronString  PROGRAM_UPTIME;
    
    [SplusStructAttribute(10, false, false)]
    public CrestronString  PROGRAMMER;
    
    [SplusStructAttribute(11, false, false)]
    public CrestronString  SYSTEM;
    
    [SplusStructAttribute(12, false, false)]
    public CrestronString  FILE;
    
    [SplusStructAttribute(13, false, false)]
    public CrestronString  COMPILE_DATE;
    
    
    public SYSTEM_INFO( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        DHCP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        MODEL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        FIRMWARE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        FIRMWARE_DATE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        MAC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        IP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        HOSTNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        SERIAL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        PROCESSOR_UPTIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        PROGRAM_UPTIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        PROGRAMMER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        SYSTEM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        FILE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 140, Owner );
        COMPILE_DATE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        
        
    }
    
}

}
