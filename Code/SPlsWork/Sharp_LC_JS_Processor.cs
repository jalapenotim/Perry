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

namespace UserModule_SHARP_LC_JS_PROCESSOR
{
    public class UserModuleClass_SHARP_LC_JS_PROCESSOR : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput RESPONSE_TIMEOUT;
        Crestron.Logos.SplusObjects.DigitalInput RESPONSE_TIMEOUT_2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> POWER;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> INPUT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> AVMODE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> ASPECT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> VOLUMEMUTE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> POLL;
        Crestron.Logos.SplusObjects.StringInput FROM_DEVICE;
        Crestron.Logos.SplusObjects.DigitalOutput IWAITINGFORRESPONSE;
        Crestron.Logos.SplusObjects.AnalogOutput CURRENT_POWER;
        Crestron.Logos.SplusObjects.AnalogOutput CURRENT_INPUT;
        Crestron.Logos.SplusObjects.AnalogOutput CURRENT_AVMODE;
        Crestron.Logos.SplusObjects.AnalogOutput CURRENT_ASPECT;
        Crestron.Logos.SplusObjects.AnalogOutput CURRENT_VOLUMEMUTE;
        Crestron.Logos.SplusObjects.AnalogOutput CURRENT_VOLUME;
        Crestron.Logos.SplusObjects.StringOutput TO_DEVICE;
        ushort ICOMMAND = 0;
        ushort IVALUE = 0;
        ushort IVALUEIN = 0;
        ushort ALOC = 0;
        ushort IPOWERQUEUE = 0;
        ushort IINPUTQUEUE = 0;
        ushort IAVMODEQUEUE = 0;
        ushort IASPECTQUEUE = 0;
        ushort IVOLUMEMUTEQUEUE = 0;
        ushort IPOLLQUEUE = 0;
        ushort IPOWERSENT = 0;
        ushort IINPUTSENT = 0;
        ushort IAVMODESENT = 0;
        ushort IASPECTSENT = 0;
        ushort IVOLUMEMUTESENT = 0;
        ushort IPOLLSENT = 0;
        CrestronString STODEVICETEMP;
        private CrestronString SENDPOWER (  SplusExecutionContext __context__, ushort IVALUE ) 
            { 
            
            __context__.SourceCodeLine = 100;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)IVALUE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 103;
                        STODEVICETEMP  .UpdateValue ( "POWR1   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 105;
                        STODEVICETEMP  .UpdateValue ( "POWR0   \u000D"  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 107;
            return ( STODEVICETEMP ) ; 
            
            }
            
        private CrestronString SENDINPUT (  SplusExecutionContext __context__, ushort IVALUE ) 
            { 
            
            __context__.SourceCodeLine = 114;
            
                {
                int __SPLS_TMPVAR__SWTCH_2__ = ((int)IVALUE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 117;
                        STODEVICETEMP  .UpdateValue ( "IAVD1   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 119;
                        STODEVICETEMP  .UpdateValue ( "IAVD2   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 121;
                        STODEVICETEMP  .UpdateValue ( "IAVD3   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 123;
                        STODEVICETEMP  .UpdateValue ( "IAVD4   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 125;
                        STODEVICETEMP  .UpdateValue ( "IAVD5   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 127;
                        STODEVICETEMP  .UpdateValue ( "IAVD6   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 129;
                        STODEVICETEMP  .UpdateValue ( "IAVD7   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 131;
                        STODEVICETEMP  .UpdateValue ( "IAVD8   \u000D"  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 133;
            return ( STODEVICETEMP ) ; 
            
            }
            
        private CrestronString SENDAVMODE (  SplusExecutionContext __context__, ushort IVALUE ) 
            { 
            
            __context__.SourceCodeLine = 139;
            
                {
                int __SPLS_TMPVAR__SWTCH_3__ = ((int)IVALUE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 142;
                        STODEVICETEMP  .UpdateValue ( "AVMD1   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 144;
                        STODEVICETEMP  .UpdateValue ( "AVMD2   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 146;
                        STODEVICETEMP  .UpdateValue ( "AVMD3   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 148;
                        STODEVICETEMP  .UpdateValue ( "AVMD4   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 150;
                        STODEVICETEMP  .UpdateValue ( "AVMD5   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 152;
                        STODEVICETEMP  .UpdateValue ( "AVMD6   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 154;
                        STODEVICETEMP  .UpdateValue ( "AVMD7   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 156;
                        STODEVICETEMP  .UpdateValue ( "AVMD100 \u000D"  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 158;
            return ( STODEVICETEMP ) ; 
            
            }
            
        private CrestronString SENDASPECT (  SplusExecutionContext __context__, ushort IVALUE ) 
            { 
            
            __context__.SourceCodeLine = 164;
            
                {
                int __SPLS_TMPVAR__SWTCH_4__ = ((int)IVALUE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 167;
                        STODEVICETEMP  .UpdateValue ( "WIDE1   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 169;
                        STODEVICETEMP  .UpdateValue ( "WIDE2   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 171;
                        STODEVICETEMP  .UpdateValue ( "WIDE3   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 173;
                        STODEVICETEMP  .UpdateValue ( "WIDE4   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 175;
                        STODEVICETEMP  .UpdateValue ( "WIDE5   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 177;
                        STODEVICETEMP  .UpdateValue ( "WIDE6   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 179;
                        STODEVICETEMP  .UpdateValue ( "WIDE7   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 181;
                        STODEVICETEMP  .UpdateValue ( "WIDE8   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 9) ) ) ) 
                        {
                        __context__.SourceCodeLine = 183;
                        STODEVICETEMP  .UpdateValue ( "WIDE9   \u000D"  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 185;
            return ( STODEVICETEMP ) ; 
            
            }
            
        private CrestronString SENDVOLUMEMUTE (  SplusExecutionContext __context__, ushort IVALUE ) 
            { 
            
            __context__.SourceCodeLine = 191;
            
                {
                int __SPLS_TMPVAR__SWTCH_5__ = ((int)IVALUE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 194;
                        STODEVICETEMP  .UpdateValue ( "MUTE1   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 196;
                        STODEVICETEMP  .UpdateValue ( "MUTE2   \u000D"  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 198;
            return ( STODEVICETEMP ) ; 
            
            }
            
        private CrestronString SENDPOLL (  SplusExecutionContext __context__, ushort IVALUE ) 
            { 
            
            __context__.SourceCodeLine = 204;
            
                {
                int __SPLS_TMPVAR__SWTCH_6__ = ((int)IVALUE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 207;
                        STODEVICETEMP  .UpdateValue ( "POWR?   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 209;
                        STODEVICETEMP  .UpdateValue ( "IAVD?   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 211;
                        STODEVICETEMP  .UpdateValue ( "AVMD?   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 213;
                        STODEVICETEMP  .UpdateValue ( "WIDE?   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 215;
                        STODEVICETEMP  .UpdateValue ( "MUTE?   \u000D"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 217;
                        STODEVICETEMP  .UpdateValue ( "VOLM?   \u000D"  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 219;
            return ( STODEVICETEMP ) ; 
            
            }
            
        private void SENDCOMMANDQUEUED (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 224;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IWAITINGFORRESPONSE  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IPOWERQUEUE != 0) ) || Functions.TestForTrue ( Functions.BoolToInt (IINPUTQUEUE != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (IAVMODEQUEUE != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (IASPECTQUEUE != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (IVOLUMEMUTEQUEUE != 0) )) ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 226;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPOWERQUEUE != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 228;
                    TO_DEVICE  .UpdateValue ( SENDPOWER (  __context__ , (ushort)( IPOWERQUEUE ))  ) ; 
                    __context__.SourceCodeLine = 229;
                    ICOMMAND = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 230;
                    IPOWERSENT = (ushort) ( IPOWERQUEUE ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 232;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IINPUTQUEUE != 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 234;
                        TO_DEVICE  .UpdateValue ( SENDINPUT (  __context__ , (ushort)( IINPUTQUEUE ))  ) ; 
                        __context__.SourceCodeLine = 235;
                        ICOMMAND = (ushort) ( 2 ) ; 
                        __context__.SourceCodeLine = 236;
                        IINPUTSENT = (ushort) ( IINPUTQUEUE ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 238;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IAVMODEQUEUE != 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 240;
                            TO_DEVICE  .UpdateValue ( SENDAVMODE (  __context__ , (ushort)( IAVMODEQUEUE ))  ) ; 
                            __context__.SourceCodeLine = 241;
                            ICOMMAND = (ushort) ( 3 ) ; 
                            __context__.SourceCodeLine = 242;
                            IAVMODESENT = (ushort) ( IAVMODEQUEUE ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 244;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IASPECTQUEUE != 0))  ) ) 
                                { 
                                __context__.SourceCodeLine = 246;
                                TO_DEVICE  .UpdateValue ( SENDASPECT (  __context__ , (ushort)( IASPECTQUEUE ))  ) ; 
                                __context__.SourceCodeLine = 247;
                                ICOMMAND = (ushort) ( 4 ) ; 
                                __context__.SourceCodeLine = 248;
                                IASPECTSENT = (ushort) ( IASPECTQUEUE ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 250;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IVOLUMEMUTEQUEUE != 0))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 252;
                                    TO_DEVICE  .UpdateValue ( SENDVOLUMEMUTE (  __context__ , (ushort)( IVOLUMEMUTEQUEUE ))  ) ; 
                                    __context__.SourceCodeLine = 253;
                                    ICOMMAND = (ushort) ( 5 ) ; 
                                    __context__.SourceCodeLine = 254;
                                    IVOLUMEMUTESENT = (ushort) ( IVOLUMEMUTEQUEUE ) ; 
                                    } 
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                } 
            
            
            }
            
        object POWER_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 266;
                IPOWERQUEUE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 268;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IWAITINGFORRESPONSE  .Value == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 270;
                    TO_DEVICE  .UpdateValue ( SENDPOWER (  __context__ , (ushort)( IPOWERQUEUE ))  ) ; 
                    __context__.SourceCodeLine = 271;
                    ICOMMAND = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 272;
                    IPOWERSENT = (ushort) ( IPOWERQUEUE ) ; 
                    __context__.SourceCodeLine = 273;
                    IWAITINGFORRESPONSE  .Value = (ushort) ( 1 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object INPUT_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 279;
            IINPUTQUEUE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 280;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IWAITINGFORRESPONSE  .Value == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 282;
                TO_DEVICE  .UpdateValue ( SENDINPUT (  __context__ , (ushort)( IINPUTQUEUE ))  ) ; 
                __context__.SourceCodeLine = 283;
                ICOMMAND = (ushort) ( 2 ) ; 
                __context__.SourceCodeLine = 284;
                IINPUTSENT = (ushort) ( IINPUTQUEUE ) ; 
                __context__.SourceCodeLine = 285;
                IWAITINGFORRESPONSE  .Value = (ushort) ( 1 ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object AVMODE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 291;
        IAVMODEQUEUE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 292;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IWAITINGFORRESPONSE  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 294;
            TO_DEVICE  .UpdateValue ( SENDAVMODE (  __context__ , (ushort)( IAVMODEQUEUE ))  ) ; 
            __context__.SourceCodeLine = 295;
            ICOMMAND = (ushort) ( 3 ) ; 
            __context__.SourceCodeLine = 296;
            IAVMODESENT = (ushort) ( IAVMODEQUEUE ) ; 
            __context__.SourceCodeLine = 297;
            IWAITINGFORRESPONSE  .Value = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ASPECT_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 303;
        IASPECTQUEUE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 304;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IWAITINGFORRESPONSE  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 306;
            TO_DEVICE  .UpdateValue ( SENDASPECT (  __context__ , (ushort)( IASPECTQUEUE ))  ) ; 
            __context__.SourceCodeLine = 307;
            ICOMMAND = (ushort) ( 4 ) ; 
            __context__.SourceCodeLine = 308;
            IASPECTSENT = (ushort) ( IASPECTQUEUE ) ; 
            __context__.SourceCodeLine = 309;
            IWAITINGFORRESPONSE  .Value = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUMEMUTE_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 315;
        IVOLUMEMUTEQUEUE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 316;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IWAITINGFORRESPONSE  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 318;
            TO_DEVICE  .UpdateValue ( SENDVOLUMEMUTE (  __context__ , (ushort)( IVOLUMEMUTEQUEUE ))  ) ; 
            __context__.SourceCodeLine = 319;
            ICOMMAND = (ushort) ( 5 ) ; 
            __context__.SourceCodeLine = 320;
            IVOLUMEMUTESENT = (ushort) ( IVOLUMEMUTEQUEUE ) ; 
            __context__.SourceCodeLine = 321;
            IWAITINGFORRESPONSE  .Value = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POLL_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 327;
        IPOLLQUEUE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 328;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IWAITINGFORRESPONSE  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 330;
            TO_DEVICE  .UpdateValue ( SENDPOLL (  __context__ , (ushort)( IPOLLQUEUE ))  ) ; 
            __context__.SourceCodeLine = 331;
            ICOMMAND = (ushort) ( 30 ) ; 
            __context__.SourceCodeLine = 332;
            IPOLLSENT = (ushort) ( IPOLLQUEUE ) ; 
            __context__.SourceCodeLine = 333;
            IWAITINGFORRESPONSE  .Value = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FROM_DEVICE_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 339;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FROM_DEVICE == "OK\u000D"))  ) ) 
            { 
            __context__.SourceCodeLine = 341;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMAND == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 343;
                CURRENT_POWER  .Value = (ushort) ( IPOWERSENT ) ; 
                __context__.SourceCodeLine = 344;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENT_POWER  .Value == IPOWERQUEUE))  ) ) 
                    {
                    __context__.SourceCodeLine = 345;
                    IPOWERQUEUE = (ushort) ( 0 ) ; 
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 347;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMAND == 2))  ) ) 
                    { 
                    __context__.SourceCodeLine = 349;
                    CURRENT_INPUT  .Value = (ushort) ( IINPUTSENT ) ; 
                    __context__.SourceCodeLine = 350;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENT_INPUT  .Value == IINPUTQUEUE))  ) ) 
                        {
                        __context__.SourceCodeLine = 351;
                        IINPUTQUEUE = (ushort) ( 0 ) ; 
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 353;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMAND == 3))  ) ) 
                        { 
                        __context__.SourceCodeLine = 355;
                        CURRENT_AVMODE  .Value = (ushort) ( IAVMODESENT ) ; 
                        __context__.SourceCodeLine = 356;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENT_AVMODE  .Value == IAVMODEQUEUE))  ) ) 
                            {
                            __context__.SourceCodeLine = 357;
                            IAVMODEQUEUE = (ushort) ( 0 ) ; 
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 359;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMAND == 4))  ) ) 
                            { 
                            __context__.SourceCodeLine = 361;
                            CURRENT_ASPECT  .Value = (ushort) ( IASPECTSENT ) ; 
                            __context__.SourceCodeLine = 362;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENT_ASPECT  .Value == IASPECTQUEUE))  ) ) 
                                {
                                __context__.SourceCodeLine = 363;
                                IASPECTQUEUE = (ushort) ( 0 ) ; 
                                }
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 365;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMAND == 5))  ) ) 
                                { 
                                __context__.SourceCodeLine = 367;
                                CURRENT_VOLUMEMUTE  .Value = (ushort) ( IVOLUMEMUTESENT ) ; 
                                __context__.SourceCodeLine = 368;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENT_VOLUMEMUTE  .Value == IVOLUMEMUTEQUEUE))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 369;
                                    IVOLUMEMUTEQUEUE = (ushort) ( 0 ) ; 
                                    }
                                
                                } 
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 372;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (FROM_DEVICE == "ERR\u000D") ) || Functions.TestForTrue ( Functions.BoolToInt (FROM_DEVICE == "\u00FF\u00FF\u00FF") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 374;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMAND == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 375;
                    IPOWERQUEUE = (ushort) ( 0 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 376;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMAND == 2))  ) ) 
                        {
                        __context__.SourceCodeLine = 377;
                        IINPUTQUEUE = (ushort) ( 0 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 378;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMAND == 3))  ) ) 
                            {
                            __context__.SourceCodeLine = 379;
                            IAVMODEQUEUE = (ushort) ( 0 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 380;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMAND == 4))  ) ) 
                                {
                                __context__.SourceCodeLine = 381;
                                IASPECTQUEUE = (ushort) ( 0 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 382;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMAND == 5))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 383;
                                    IVOLUMEMUTEQUEUE = (ushort) ( 0 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 384;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMAND == 30))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 385;
                                        IPOLLQUEUE = (ushort) ( 0 ) ; 
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 389;
                IVALUEIN = (ushort) ( Functions.Atoi( FROM_DEVICE ) ) ; 
                __context__.SourceCodeLine = 390;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPOLLSENT == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 392;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_7__ = ((int)IVALUEIN);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 395;
                                CURRENT_POWER  .Value = (ushort) ( 1 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 0) ) ) ) 
                                {
                                __context__.SourceCodeLine = 397;
                                CURRENT_POWER  .Value = (ushort) ( 2 ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                __context__.SourceCodeLine = 400;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPOLLSENT == 2))  ) ) 
                    { 
                    __context__.SourceCodeLine = 402;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_8__ = ((int)IVALUEIN);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 405;
                                CURRENT_INPUT  .Value = (ushort) ( 1 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 407;
                                CURRENT_INPUT  .Value = (ushort) ( 2 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 3) ) ) ) 
                                {
                                __context__.SourceCodeLine = 409;
                                CURRENT_INPUT  .Value = (ushort) ( 3 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 4) ) ) ) 
                                {
                                __context__.SourceCodeLine = 411;
                                CURRENT_INPUT  .Value = (ushort) ( 4 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 5) ) ) ) 
                                {
                                __context__.SourceCodeLine = 413;
                                CURRENT_INPUT  .Value = (ushort) ( 5 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 6) ) ) ) 
                                {
                                __context__.SourceCodeLine = 415;
                                CURRENT_INPUT  .Value = (ushort) ( 6 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 7) ) ) ) 
                                {
                                __context__.SourceCodeLine = 417;
                                CURRENT_INPUT  .Value = (ushort) ( 7 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 8) ) ) ) 
                                {
                                __context__.SourceCodeLine = 419;
                                CURRENT_INPUT  .Value = (ushort) ( 8 ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                __context__.SourceCodeLine = 422;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPOLLSENT == 3))  ) ) 
                    { 
                    __context__.SourceCodeLine = 424;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_9__ = ((int)IVALUEIN);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 427;
                                CURRENT_AVMODE  .Value = (ushort) ( 1 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 429;
                                CURRENT_AVMODE  .Value = (ushort) ( 2 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 3) ) ) ) 
                                {
                                __context__.SourceCodeLine = 431;
                                CURRENT_AVMODE  .Value = (ushort) ( 3 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 4) ) ) ) 
                                {
                                __context__.SourceCodeLine = 433;
                                CURRENT_AVMODE  .Value = (ushort) ( 4 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 5) ) ) ) 
                                {
                                __context__.SourceCodeLine = 435;
                                CURRENT_AVMODE  .Value = (ushort) ( 5 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 6) ) ) ) 
                                {
                                __context__.SourceCodeLine = 437;
                                CURRENT_AVMODE  .Value = (ushort) ( 6 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 7) ) ) ) 
                                {
                                __context__.SourceCodeLine = 439;
                                CURRENT_AVMODE  .Value = (ushort) ( 7 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 100) ) ) ) 
                                {
                                __context__.SourceCodeLine = 441;
                                CURRENT_AVMODE  .Value = (ushort) ( 8 ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                __context__.SourceCodeLine = 444;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPOLLSENT == 4))  ) ) 
                    { 
                    __context__.SourceCodeLine = 446;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_10__ = ((int)IVALUEIN);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 449;
                                CURRENT_ASPECT  .Value = (ushort) ( 1 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 451;
                                CURRENT_ASPECT  .Value = (ushort) ( 2 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 3) ) ) ) 
                                {
                                __context__.SourceCodeLine = 453;
                                CURRENT_ASPECT  .Value = (ushort) ( 3 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 4) ) ) ) 
                                {
                                __context__.SourceCodeLine = 455;
                                CURRENT_ASPECT  .Value = (ushort) ( 4 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 5) ) ) ) 
                                {
                                __context__.SourceCodeLine = 457;
                                CURRENT_ASPECT  .Value = (ushort) ( 5 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 6) ) ) ) 
                                {
                                __context__.SourceCodeLine = 459;
                                CURRENT_ASPECT  .Value = (ushort) ( 6 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 7) ) ) ) 
                                {
                                __context__.SourceCodeLine = 461;
                                CURRENT_ASPECT  .Value = (ushort) ( 7 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 8) ) ) ) 
                                {
                                __context__.SourceCodeLine = 463;
                                CURRENT_ASPECT  .Value = (ushort) ( 8 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 9) ) ) ) 
                                {
                                __context__.SourceCodeLine = 465;
                                CURRENT_ASPECT  .Value = (ushort) ( 9 ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                __context__.SourceCodeLine = 468;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPOLLSENT == 5))  ) ) 
                    { 
                    __context__.SourceCodeLine = 470;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_11__ = ((int)IVALUEIN);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 473;
                                CURRENT_VOLUMEMUTE  .Value = (ushort) ( 1 ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 475;
                                CURRENT_VOLUMEMUTE  .Value = (ushort) ( 2 ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                __context__.SourceCodeLine = 478;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPOLLSENT == 6))  ) ) 
                    { 
                    __context__.SourceCodeLine = 480;
                    CURRENT_VOLUME  .Value = (ushort) ( IVALUEIN ) ; 
                    } 
                
                } 
            
            }
        
        __context__.SourceCodeLine = 483;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IWAITINGFORRESPONSE  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IPOWERQUEUE != 0) ) || Functions.TestForTrue ( Functions.BoolToInt (IINPUTQUEUE != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (IAVMODEQUEUE != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (IASPECTQUEUE != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (IVOLUMEMUTEQUEUE != 0) )) ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 485;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPOWERQUEUE != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 487;
                TO_DEVICE  .UpdateValue ( SENDPOWER (  __context__ , (ushort)( IPOWERQUEUE ))  ) ; 
                __context__.SourceCodeLine = 488;
                ICOMMAND = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 489;
                IPOWERSENT = (ushort) ( IPOWERQUEUE ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 491;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IINPUTQUEUE != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 493;
                    TO_DEVICE  .UpdateValue ( SENDINPUT (  __context__ , (ushort)( IINPUTQUEUE ))  ) ; 
                    __context__.SourceCodeLine = 494;
                    ICOMMAND = (ushort) ( 2 ) ; 
                    __context__.SourceCodeLine = 495;
                    IINPUTSENT = (ushort) ( IINPUTQUEUE ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 497;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IAVMODEQUEUE != 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 499;
                        TO_DEVICE  .UpdateValue ( SENDAVMODE (  __context__ , (ushort)( IAVMODEQUEUE ))  ) ; 
                        __context__.SourceCodeLine = 500;
                        ICOMMAND = (ushort) ( 3 ) ; 
                        __context__.SourceCodeLine = 501;
                        IAVMODESENT = (ushort) ( IAVMODEQUEUE ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 503;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IASPECTQUEUE != 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 505;
                            TO_DEVICE  .UpdateValue ( SENDASPECT (  __context__ , (ushort)( IASPECTQUEUE ))  ) ; 
                            __context__.SourceCodeLine = 506;
                            ICOMMAND = (ushort) ( 4 ) ; 
                            __context__.SourceCodeLine = 507;
                            IASPECTSENT = (ushort) ( IASPECTQUEUE ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 509;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IVOLUMEMUTEQUEUE != 0))  ) ) 
                                { 
                                __context__.SourceCodeLine = 511;
                                TO_DEVICE  .UpdateValue ( SENDVOLUMEMUTE (  __context__ , (ushort)( IVOLUMEMUTEQUEUE ))  ) ; 
                                __context__.SourceCodeLine = 512;
                                ICOMMAND = (ushort) ( 5 ) ; 
                                __context__.SourceCodeLine = 513;
                                IVOLUMEMUTESENT = (ushort) ( IVOLUMEMUTEQUEUE ) ; 
                                } 
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 517;
            IWAITINGFORRESPONSE  .Value = (ushort) ( 0 ) ; 
            }
        
        __context__.SourceCodeLine = 518;
        IPOLLSENT = (ushort) ( 31 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RESPONSE_TIMEOUT_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 523;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IWAITINGFORRESPONSE  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IPOWERQUEUE != 0) ) || Functions.TestForTrue ( Functions.BoolToInt (IINPUTQUEUE != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (IAVMODEQUEUE != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (IASPECTQUEUE != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (IVOLUMEMUTEQUEUE != 0) )) ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 525;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPOWERQUEUE != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 527;
                TO_DEVICE  .UpdateValue ( SENDPOWER (  __context__ , (ushort)( IPOWERQUEUE ))  ) ; 
                __context__.SourceCodeLine = 528;
                ICOMMAND = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 529;
                IPOWERSENT = (ushort) ( IPOWERQUEUE ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 531;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IINPUTQUEUE != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 533;
                    TO_DEVICE  .UpdateValue ( SENDINPUT (  __context__ , (ushort)( IINPUTQUEUE ))  ) ; 
                    __context__.SourceCodeLine = 534;
                    ICOMMAND = (ushort) ( 2 ) ; 
                    __context__.SourceCodeLine = 535;
                    IINPUTSENT = (ushort) ( IINPUTQUEUE ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 537;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IAVMODEQUEUE != 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 539;
                        TO_DEVICE  .UpdateValue ( SENDAVMODE (  __context__ , (ushort)( IAVMODEQUEUE ))  ) ; 
                        __context__.SourceCodeLine = 540;
                        ICOMMAND = (ushort) ( 3 ) ; 
                        __context__.SourceCodeLine = 541;
                        IAVMODESENT = (ushort) ( IAVMODEQUEUE ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 543;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IASPECTQUEUE != 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 545;
                            TO_DEVICE  .UpdateValue ( SENDASPECT (  __context__ , (ushort)( IASPECTQUEUE ))  ) ; 
                            __context__.SourceCodeLine = 546;
                            ICOMMAND = (ushort) ( 4 ) ; 
                            __context__.SourceCodeLine = 547;
                            IASPECTSENT = (ushort) ( IASPECTQUEUE ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 549;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IVOLUMEMUTEQUEUE != 0))  ) ) 
                                { 
                                __context__.SourceCodeLine = 551;
                                TO_DEVICE  .UpdateValue ( SENDVOLUMEMUTE (  __context__ , (ushort)( IVOLUMEMUTEQUEUE ))  ) ; 
                                __context__.SourceCodeLine = 552;
                                ICOMMAND = (ushort) ( 5 ) ; 
                                __context__.SourceCodeLine = 553;
                                IVOLUMEMUTESENT = (ushort) ( IVOLUMEMUTEQUEUE ) ; 
                                } 
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 557;
            IWAITINGFORRESPONSE  .Value = (ushort) ( 0 ) ; 
            }
        
        __context__.SourceCodeLine = 558;
        IPOLLSENT = (ushort) ( 31 ) ; 
        
        
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
        
        __context__.SourceCodeLine = 569;
        IWAITINGFORRESPONSE  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 570;
        IPOWERQUEUE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 571;
        IINPUTQUEUE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 572;
        IAVMODEQUEUE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 573;
        IASPECTQUEUE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 574;
        IVOLUMEMUTEQUEUE = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    STODEVICETEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    
    RESPONSE_TIMEOUT = new Crestron.Logos.SplusObjects.DigitalInput( RESPONSE_TIMEOUT__DigitalInput__, this );
    m_DigitalInputList.Add( RESPONSE_TIMEOUT__DigitalInput__, RESPONSE_TIMEOUT );
    
    RESPONSE_TIMEOUT_2 = new Crestron.Logos.SplusObjects.DigitalInput( RESPONSE_TIMEOUT_2__DigitalInput__, this );
    m_DigitalInputList.Add( RESPONSE_TIMEOUT_2__DigitalInput__, RESPONSE_TIMEOUT_2 );
    
    POWER = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        POWER[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( POWER__DigitalInput__ + i, POWER__DigitalInput__, this );
        m_DigitalInputList.Add( POWER__DigitalInput__ + i, POWER[i+1] );
    }
    
    INPUT = new InOutArray<DigitalInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        INPUT[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( INPUT__DigitalInput__ + i, INPUT__DigitalInput__, this );
        m_DigitalInputList.Add( INPUT__DigitalInput__ + i, INPUT[i+1] );
    }
    
    AVMODE = new InOutArray<DigitalInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        AVMODE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( AVMODE__DigitalInput__ + i, AVMODE__DigitalInput__, this );
        m_DigitalInputList.Add( AVMODE__DigitalInput__ + i, AVMODE[i+1] );
    }
    
    ASPECT = new InOutArray<DigitalInput>( 9, this );
    for( uint i = 0; i < 9; i++ )
    {
        ASPECT[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( ASPECT__DigitalInput__ + i, ASPECT__DigitalInput__, this );
        m_DigitalInputList.Add( ASPECT__DigitalInput__ + i, ASPECT[i+1] );
    }
    
    VOLUMEMUTE = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        VOLUMEMUTE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( VOLUMEMUTE__DigitalInput__ + i, VOLUMEMUTE__DigitalInput__, this );
        m_DigitalInputList.Add( VOLUMEMUTE__DigitalInput__ + i, VOLUMEMUTE[i+1] );
    }
    
    POLL = new InOutArray<DigitalInput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        POLL[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( POLL__DigitalInput__ + i, POLL__DigitalInput__, this );
        m_DigitalInputList.Add( POLL__DigitalInput__ + i, POLL[i+1] );
    }
    
    IWAITINGFORRESPONSE = new Crestron.Logos.SplusObjects.DigitalOutput( IWAITINGFORRESPONSE__DigitalOutput__, this );
    m_DigitalOutputList.Add( IWAITINGFORRESPONSE__DigitalOutput__, IWAITINGFORRESPONSE );
    
    CURRENT_POWER = new Crestron.Logos.SplusObjects.AnalogOutput( CURRENT_POWER__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CURRENT_POWER__AnalogSerialOutput__, CURRENT_POWER );
    
    CURRENT_INPUT = new Crestron.Logos.SplusObjects.AnalogOutput( CURRENT_INPUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CURRENT_INPUT__AnalogSerialOutput__, CURRENT_INPUT );
    
    CURRENT_AVMODE = new Crestron.Logos.SplusObjects.AnalogOutput( CURRENT_AVMODE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CURRENT_AVMODE__AnalogSerialOutput__, CURRENT_AVMODE );
    
    CURRENT_ASPECT = new Crestron.Logos.SplusObjects.AnalogOutput( CURRENT_ASPECT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CURRENT_ASPECT__AnalogSerialOutput__, CURRENT_ASPECT );
    
    CURRENT_VOLUMEMUTE = new Crestron.Logos.SplusObjects.AnalogOutput( CURRENT_VOLUMEMUTE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CURRENT_VOLUMEMUTE__AnalogSerialOutput__, CURRENT_VOLUMEMUTE );
    
    CURRENT_VOLUME = new Crestron.Logos.SplusObjects.AnalogOutput( CURRENT_VOLUME__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CURRENT_VOLUME__AnalogSerialOutput__, CURRENT_VOLUME );
    
    FROM_DEVICE = new Crestron.Logos.SplusObjects.StringInput( FROM_DEVICE__AnalogSerialInput__, 25, this );
    m_StringInputList.Add( FROM_DEVICE__AnalogSerialInput__, FROM_DEVICE );
    
    TO_DEVICE = new Crestron.Logos.SplusObjects.StringOutput( TO_DEVICE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_DEVICE__AnalogSerialOutput__, TO_DEVICE );
    
    
    for( uint i = 0; i < 2; i++ )
        POWER[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( POWER_OnPush_0, false ) );
        
    for( uint i = 0; i < 8; i++ )
        INPUT[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( INPUT_OnPush_1, false ) );
        
    for( uint i = 0; i < 8; i++ )
        AVMODE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( AVMODE_OnPush_2, false ) );
        
    for( uint i = 0; i < 9; i++ )
        ASPECT[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( ASPECT_OnPush_3, false ) );
        
    for( uint i = 0; i < 2; i++ )
        VOLUMEMUTE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUMEMUTE_OnPush_4, false ) );
        
    for( uint i = 0; i < 6; i++ )
        POLL[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_OnPush_5, false ) );
        
    FROM_DEVICE.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_DEVICE_OnChange_6, false ) );
    RESPONSE_TIMEOUT.OnDigitalPush.Add( new InputChangeHandlerWrapper( RESPONSE_TIMEOUT_OnPush_7, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_SHARP_LC_JS_PROCESSOR ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint RESPONSE_TIMEOUT__DigitalInput__ = 0;
const uint RESPONSE_TIMEOUT_2__DigitalInput__ = 1;
const uint POWER__DigitalInput__ = 2;
const uint INPUT__DigitalInput__ = 4;
const uint AVMODE__DigitalInput__ = 12;
const uint ASPECT__DigitalInput__ = 20;
const uint VOLUMEMUTE__DigitalInput__ = 29;
const uint POLL__DigitalInput__ = 31;
const uint FROM_DEVICE__AnalogSerialInput__ = 0;
const uint IWAITINGFORRESPONSE__DigitalOutput__ = 0;
const uint CURRENT_POWER__AnalogSerialOutput__ = 0;
const uint CURRENT_INPUT__AnalogSerialOutput__ = 1;
const uint CURRENT_AVMODE__AnalogSerialOutput__ = 2;
const uint CURRENT_ASPECT__AnalogSerialOutput__ = 3;
const uint CURRENT_VOLUMEMUTE__AnalogSerialOutput__ = 4;
const uint CURRENT_VOLUME__AnalogSerialOutput__ = 5;
const uint TO_DEVICE__AnalogSerialOutput__ = 6;

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


}
