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

namespace UserModule_BIAMP_LEVEL_PROCESSOR_V7_4
{
    public class UserModuleClass_BIAMP_LEVEL_PROCESSOR_V7_4 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput VOL_UP;
        Crestron.Logos.SplusObjects.DigitalInput VOL_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput POLL_LEVEL;
        Crestron.Logos.SplusObjects.DigitalInput SEND_NEW_LEVEL;
        Crestron.Logos.SplusObjects.AnalogInput VOLUME_MAX_LEVEL;
        Crestron.Logos.SplusObjects.AnalogInput VOLUME_MIN_LEVEL;
        Crestron.Logos.SplusObjects.AnalogInput NEW_VOLUME_LEVEL;
        Crestron.Logos.SplusObjects.StringInput VOLUME_DEVICE_ID;
        Crestron.Logos.SplusObjects.StringInput VOLUME_DEVICE_INSTANCE;
        Crestron.Logos.SplusObjects.StringInput VOLUME_INDEX1;
        Crestron.Logos.SplusObjects.StringInput VOLUME_INDEX2;
        Crestron.Logos.SplusObjects.StringInput VOLUME_COMMAND_TYPE;
        Crestron.Logos.SplusObjects.StringInput VOLUME_STEP;
        Crestron.Logos.SplusObjects.BufferInput DEVICE_RX__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput START_UP_OUT;
        Crestron.Logos.SplusObjects.AnalogOutput VOLUME_LEVEL;
        Crestron.Logos.SplusObjects.StringOutput DEVICE_TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput VOLUME_LEVEL_TEXT;
        ushort BRXOK = 0;
        ushort ISTEP = 0;
        ushort IMAXVOL = 0;
        ushort IMINVOL = 0;
        ushort IWAIT = 0;
        ushort IVOLINDEX1 = 0;
        ushort IVOLINDEX2 = 0;
        ushort IVOLUMESIGNED = 0;
        ushort IVOLUME = 0;
        short ITEMPVOLLIMIT = 0;
        short INEWVOL = 0;
        short ISIGNEDMAX = 0;
        short ISIGNEDMIN = 0;
        CrestronString STEMPDATA;
        CrestronString SVOL;
        CrestronString SVOLTEXT;
        CrestronString SVOLUMEPREFIX;
        CrestronString SVOLUMETYPE;
        CrestronString SINSTANCE;
        CrestronString SSTEP;
        CrestronString SSENDINST;
        CrestronString SSENDNAME;
        private void PROCESSVOLUMEDATA (  SplusExecutionContext __context__, CrestronString DATA ) 
            { 
            CrestronString STEMP;
            CrestronString SVAL;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
            SVAL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 74;
            STEMP  .UpdateValue ( Functions.Remove ( SVOLUMEPREFIX , DATA )  ) ; 
            __context__.SourceCodeLine = 75;
            SVOLTEXT  .UpdateValue ( Functions.Left ( DATA ,  (int) ( (Functions.Find( "\u002E" , DATA ) - 1) ) ) + Functions.Mid ( DATA ,  (int) ( (Functions.Find( "\u002E" , DATA ) + 1) ) ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 76;
            SVAL  .UpdateValue ( Functions.Remove ( "\u002E" , DATA )  ) ; 
            __context__.SourceCodeLine = 77;
            STEMP  .UpdateValue ( Functions.Left ( SVOLTEXT ,  (int) ( (Functions.Length( SVOLTEXT ) - 1) ) ) + "." + Functions.Right ( SVOLTEXT ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 79;
            if ( Functions.TestForTrue  ( ( Functions.Find( "-" , SVOLTEXT ))  ) ) 
                { 
                __context__.SourceCodeLine = 81;
                IVOLUMESIGNED = (ushort) ( (65536 - Functions.Atoi( SVAL )) ) ; 
                __context__.SourceCodeLine = 82;
                IVOLUME = (ushort) ( Functions.Abs( (Functions.Atoi( SVOLTEXT ) - 1000) ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 86;
                IVOLUMESIGNED = (ushort) ( Functions.Atoi( SVAL ) ) ; 
                __context__.SourceCodeLine = 87;
                IVOLUME = (ushort) ( (Functions.Atoi( SVOLTEXT ) + 1000) ) ; 
                } 
            
            __context__.SourceCodeLine = 89;
            VOLUME_LEVEL  .Value = (ushort) ( IVOLUMESIGNED ) ; 
            __context__.SourceCodeLine = 90;
            VOLUME_LEVEL_TEXT  .UpdateValue ( STEMP  ) ; 
            
            }
            
        private void FSENDCOMMAND (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 95;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VOL_UP  .Value == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 97;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (IVOLUME + ISTEP) <= IMAXVOL ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 99;
                    MakeString ( DEVICE_TX__DOLLAR__ , "INCD {0} {1}\u000A", SVOL , SSTEP ) ; 
                    __context__.SourceCodeLine = 100;
                    MakeString ( SVOLUMEPREFIX , "#INCD {0}\u0020", SVOL ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 102;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IVOLUME != IMAXVOL))  ) ) 
                        { 
                        __context__.SourceCodeLine = 104;
                        MakeString ( DEVICE_TX__DOLLAR__ , "SETD {0} {1:d}\u000A", SVOL , (short)((IMAXVOL - 1000) / 10)) ; 
                        __context__.SourceCodeLine = 105;
                        MakeString ( SVOLUMEPREFIX , "#SETD {0}\u0020", SVOL ) ; 
                        } 
                    
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 108;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VOL_DOWN  .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 110;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (IVOLUME - ISTEP) >= IMINVOL ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 112;
                        MakeString ( DEVICE_TX__DOLLAR__ , "INCD {0} -{1}\u000A", SVOL , SSTEP ) ; 
                        __context__.SourceCodeLine = 113;
                        MakeString ( SVOLUMEPREFIX , "#INCD {0}\u0020", SVOL ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 115;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IVOLUME != IMINVOL))  ) ) 
                            { 
                            __context__.SourceCodeLine = 117;
                            MakeString ( DEVICE_TX__DOLLAR__ , "SETD {0} {1:d}\u000A", SVOL , (short)((IMINVOL - 1000) / 10)) ; 
                            __context__.SourceCodeLine = 118;
                            MakeString ( SVOLUMEPREFIX , "#SETD {0}\u0020", SVOL ) ; 
                            } 
                        
                        }
                    
                    } 
                
                }
            
            
            }
            
        private void FRAMPWAIT (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 125;
            CreateWait ( "WRAMPWAIT" , 50 , WRAMPWAIT_Callback ) ;
            
            }
            
        public void WRAMPWAIT_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 127;
            IWAIT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 128;
            FSENDCOMMAND (  __context__  ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    object VOLUME_MAX_LEVEL_OnChange_0 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 137;
            ISIGNEDMAX = (short) ( VOLUME_MAX_LEVEL  .ShortValue ) ; 
            __context__.SourceCodeLine = 138;
            ITEMPVOLLIMIT = (short) ( VOLUME_MAX_LEVEL  .ShortValue ) ; 
            __context__.SourceCodeLine = 139;
            
            __context__.SourceCodeLine = 149;
            
            __context__.SourceCodeLine = 159;
            __context__.SourceCodeLine = 160;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITEMPVOLLIMIT > Functions.ToSignedLongInteger( -( 100 ) ) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITEMPVOLLIMIT <= 12 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 162;
                IMAXVOL = (ushort) ( ((ITEMPVOLLIMIT * 10) + 1000) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 166;
                IMAXVOL = (ushort) ( 1120 ) ; 
                } 
            
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object VOLUME_MIN_LEVEL_OnChange_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 173;
        ISIGNEDMIN = (short) ( VOLUME_MIN_LEVEL  .ShortValue ) ; 
        __context__.SourceCodeLine = 174;
        ITEMPVOLLIMIT = (short) ( VOLUME_MIN_LEVEL  .ShortValue ) ; 
        __context__.SourceCodeLine = 175;
        
        __context__.SourceCodeLine = 185;
        
        __context__.SourceCodeLine = 195;
        __context__.SourceCodeLine = 196;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITEMPVOLLIMIT >= Functions.ToSignedLongInteger( -( 100 ) ) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITEMPVOLLIMIT < 12 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 198;
            IMINVOL = (ushort) ( ((ITEMPVOLLIMIT * 10) + 1000) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 202;
            IMINVOL = (ushort) ( 0 ) ; 
            } 
        
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEVICE_RX__DOLLAR___OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 209;
        if ( Functions.TestForTrue  ( ( BRXOK)  ) ) 
            { 
            __context__.SourceCodeLine = 211;
            BRXOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 212;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "\r\n" , DEVICE_RX__DOLLAR__ ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 214;
                STEMPDATA  .UpdateValue ( Functions.Gather ( "\r\n" , DEVICE_RX__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 215;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "Send Name\u000D\u000A" , STEMPDATA ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 217;
                    START_UP_OUT  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 218;
                    SSENDNAME  .UpdateValue ( Functions.Left ( STEMPDATA ,  (int) ( (Functions.Length( STEMPDATA ) - 2) ) )  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 220;
                    if ( Functions.TestForTrue  ( ( Functions.Find( SVOLUMEPREFIX , STEMPDATA ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 222;
                        PROCESSVOLUMEDATA (  __context__ , STEMPDATA) ; 
                        __context__.SourceCodeLine = 223;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IWAIT == 0) ) && Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (VOL_UP  .Value == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (VOL_DOWN  .Value == 1) )) ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 225;
                            FSENDCOMMAND (  __context__  ) ; 
                            } 
                        
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 212;
                } 
            
            __context__.SourceCodeLine = 229;
            BRXOK = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_DEVICE_INSTANCE_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 235;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "\u0020" , VOLUME_DEVICE_INSTANCE ) > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 237;
            MakeString ( SINSTANCE , "\u0022{0}\u0022", Functions.Left ( VOLUME_DEVICE_INSTANCE ,  (int) ( 50 ) ) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 241;
            SINSTANCE  .UpdateValue ( Functions.Left ( VOLUME_DEVICE_INSTANCE ,  (int) ( 50 ) )  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_INDEX1_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 247;
        IVOLINDEX1 = (ushort) ( Functions.Atoi( VOLUME_INDEX1 ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_INDEX2_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 252;
        IVOLINDEX2 = (ushort) ( Functions.Atoi( VOLUME_INDEX2 ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_COMMAND_TYPE_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 257;
        START_UP_OUT  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 258;
        SVOLUMETYPE  .UpdateValue ( VOLUME_COMMAND_TYPE  ) ; 
        __context__.SourceCodeLine = 259;
        SVOLUMEPREFIX  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 260;
        SVOL  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 261;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IVOLINDEX1 > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IVOLINDEX2 > 0 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 263;
            MakeString ( SVOL , "{0} {1} {2} {3} {4}", VOLUME_DEVICE_ID , SVOLUMETYPE , SINSTANCE , VOLUME_INDEX1 , VOLUME_INDEX2 ) ; 
            __context__.SourceCodeLine = 265;
            MakeString ( SSENDINST , "{0} {1} {2} {3}", SVOLUMETYPE , SINSTANCE , VOLUME_INDEX1 , VOLUME_INDEX2 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 268;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IVOLINDEX1 > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (IVOLINDEX2 == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 270;
                MakeString ( SVOL , "{0} {1} {2} {3}", VOLUME_DEVICE_ID , SVOLUMETYPE , SINSTANCE , VOLUME_INDEX1 ) ; 
                __context__.SourceCodeLine = 272;
                MakeString ( SSENDINST , "{0} {1} {2}", SVOLUMETYPE , SINSTANCE , VOLUME_INDEX1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 277;
                MakeString ( SVOL , "{0} {1} {2}", VOLUME_DEVICE_ID , SVOLUMETYPE , SINSTANCE ) ; 
                __context__.SourceCodeLine = 278;
                MakeString ( SSENDINST , "{0} {1}", SVOLUMETYPE , SINSTANCE ) ; 
                } 
            
            }
        
        __context__.SourceCodeLine = 280;
        MakeString ( DEVICE_TX__DOLLAR__ , "{0}={1}\u000D\u000A", SSENDNAME , SSENDINST ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_STEP_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMPSTEP;
        STEMPSTEP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
        
        
        __context__.SourceCodeLine = 287;
        SSTEP  .UpdateValue ( VOLUME_STEP  ) ; 
        __context__.SourceCodeLine = 288;
        STEMPSTEP  .UpdateValue ( Functions.Left ( SSTEP ,  (int) ( 1 ) ) + Functions.Right ( SSTEP ,  (int) ( 1 ) )  ) ; 
        __context__.SourceCodeLine = 289;
        ISTEP = (ushort) ( Functions.Atoi( STEMPSTEP ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOL_UP_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 294;
        IWAIT = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 295;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (IVOLUME + ISTEP) <= IMAXVOL ))  ) ) 
            { 
            __context__.SourceCodeLine = 297;
            MakeString ( DEVICE_TX__DOLLAR__ , "INCD {0} {1}\u000A", SVOL , SSTEP ) ; 
            __context__.SourceCodeLine = 298;
            MakeString ( SVOLUMEPREFIX , "#INCD {0}\u0020", SVOL ) ; 
            __context__.SourceCodeLine = 299;
            FRAMPWAIT (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 301;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IVOLUME != IMAXVOL))  ) ) 
                { 
                __context__.SourceCodeLine = 303;
                MakeString ( DEVICE_TX__DOLLAR__ , "SETD {0} {1:d}\u000A", SVOL , (short)((IMAXVOL - 1000) / 10)) ; 
                __context__.SourceCodeLine = 304;
                MakeString ( SVOLUMEPREFIX , "#SETD {0}\u0020", SVOL ) ; 
                __context__.SourceCodeLine = 305;
                FRAMPWAIT (  __context__  ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOL_DOWN_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 312;
        IWAIT = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 313;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (IVOLUME - ISTEP) >= IMINVOL ))  ) ) 
            { 
            __context__.SourceCodeLine = 315;
            MakeString ( DEVICE_TX__DOLLAR__ , "INCD {0} -{1}\u000A", SVOL , SSTEP ) ; 
            __context__.SourceCodeLine = 316;
            MakeString ( SVOLUMEPREFIX , "#INCD {0}\u0020", SVOL ) ; 
            __context__.SourceCodeLine = 317;
            FRAMPWAIT (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 319;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IVOLUME != IMINVOL))  ) ) 
                { 
                __context__.SourceCodeLine = 321;
                MakeString ( DEVICE_TX__DOLLAR__ , "SETD {0} {1:d}\u000A", SVOL , (short)((IMINVOL - 1000) / 10)) ; 
                __context__.SourceCodeLine = 322;
                MakeString ( SVOLUMEPREFIX , "#SETD {0}\u0020", SVOL ) ; 
                __context__.SourceCodeLine = 323;
                FRAMPWAIT (  __context__  ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SEND_NEW_LEVEL_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 329;
        INEWVOL = (short) ( NEW_VOLUME_LEVEL  .ShortValue ) ; 
        __context__.SourceCodeLine = 330;
        
        __context__.SourceCodeLine = 337;
        
        __context__.SourceCodeLine = 344;
        __context__.SourceCodeLine = 345;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( INEWVOL >= ISIGNEDMIN ) ) && Functions.TestForTrue ( Functions.BoolToInt ( INEWVOL <= ISIGNEDMAX ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 347;
            MakeString ( DEVICE_TX__DOLLAR__ , "SETD {0} {1:d}\u000A", SVOL , (short)NEW_VOLUME_LEVEL  .UshortValue) ; 
            __context__.SourceCodeLine = 348;
            MakeString ( SVOLUMEPREFIX , "#SETD {0}\u0020", SVOL ) ; 
            } 
        
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POLL_LEVEL_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 355;
        MakeString ( DEVICE_TX__DOLLAR__ , "GETD {0}\u000A", SVOL ) ; 
        __context__.SourceCodeLine = 356;
        MakeString ( SVOLUMEPREFIX , "#GETD {0}\u0020", SVOL ) ; 
        
        
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
        
        __context__.SourceCodeLine = 365;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 366;
        BRXOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 367;
        SSTEP  .UpdateValue ( "1.0"  ) ; 
        __context__.SourceCodeLine = 368;
        ISTEP = (ushort) ( 10 ) ; 
        __context__.SourceCodeLine = 369;
        IWAIT = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 370;
        IVOLUME = (ushort) ( 1000 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    SVOL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    SVOLTEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    SVOLUMEPREFIX  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
    SVOLUMETYPE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    SINSTANCE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 52, this );
    SSTEP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    SSENDINST  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
    SSENDNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    VOL_UP = new Crestron.Logos.SplusObjects.DigitalInput( VOL_UP__DigitalInput__, this );
    m_DigitalInputList.Add( VOL_UP__DigitalInput__, VOL_UP );
    
    VOL_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( VOL_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( VOL_DOWN__DigitalInput__, VOL_DOWN );
    
    POLL_LEVEL = new Crestron.Logos.SplusObjects.DigitalInput( POLL_LEVEL__DigitalInput__, this );
    m_DigitalInputList.Add( POLL_LEVEL__DigitalInput__, POLL_LEVEL );
    
    SEND_NEW_LEVEL = new Crestron.Logos.SplusObjects.DigitalInput( SEND_NEW_LEVEL__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_NEW_LEVEL__DigitalInput__, SEND_NEW_LEVEL );
    
    START_UP_OUT = new Crestron.Logos.SplusObjects.DigitalOutput( START_UP_OUT__DigitalOutput__, this );
    m_DigitalOutputList.Add( START_UP_OUT__DigitalOutput__, START_UP_OUT );
    
    VOLUME_MAX_LEVEL = new Crestron.Logos.SplusObjects.AnalogInput( VOLUME_MAX_LEVEL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VOLUME_MAX_LEVEL__AnalogSerialInput__, VOLUME_MAX_LEVEL );
    
    VOLUME_MIN_LEVEL = new Crestron.Logos.SplusObjects.AnalogInput( VOLUME_MIN_LEVEL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VOLUME_MIN_LEVEL__AnalogSerialInput__, VOLUME_MIN_LEVEL );
    
    NEW_VOLUME_LEVEL = new Crestron.Logos.SplusObjects.AnalogInput( NEW_VOLUME_LEVEL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( NEW_VOLUME_LEVEL__AnalogSerialInput__, NEW_VOLUME_LEVEL );
    
    VOLUME_LEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME_LEVEL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VOLUME_LEVEL__AnalogSerialOutput__, VOLUME_LEVEL );
    
    VOLUME_DEVICE_ID = new Crestron.Logos.SplusObjects.StringInput( VOLUME_DEVICE_ID__AnalogSerialInput__, 2, this );
    m_StringInputList.Add( VOLUME_DEVICE_ID__AnalogSerialInput__, VOLUME_DEVICE_ID );
    
    VOLUME_DEVICE_INSTANCE = new Crestron.Logos.SplusObjects.StringInput( VOLUME_DEVICE_INSTANCE__AnalogSerialInput__, 50, this );
    m_StringInputList.Add( VOLUME_DEVICE_INSTANCE__AnalogSerialInput__, VOLUME_DEVICE_INSTANCE );
    
    VOLUME_INDEX1 = new Crestron.Logos.SplusObjects.StringInput( VOLUME_INDEX1__AnalogSerialInput__, 2, this );
    m_StringInputList.Add( VOLUME_INDEX1__AnalogSerialInput__, VOLUME_INDEX1 );
    
    VOLUME_INDEX2 = new Crestron.Logos.SplusObjects.StringInput( VOLUME_INDEX2__AnalogSerialInput__, 2, this );
    m_StringInputList.Add( VOLUME_INDEX2__AnalogSerialInput__, VOLUME_INDEX2 );
    
    VOLUME_COMMAND_TYPE = new Crestron.Logos.SplusObjects.StringInput( VOLUME_COMMAND_TYPE__AnalogSerialInput__, 15, this );
    m_StringInputList.Add( VOLUME_COMMAND_TYPE__AnalogSerialInput__, VOLUME_COMMAND_TYPE );
    
    VOLUME_STEP = new Crestron.Logos.SplusObjects.StringInput( VOLUME_STEP__AnalogSerialInput__, 3, this );
    m_StringInputList.Add( VOLUME_STEP__AnalogSerialInput__, VOLUME_STEP );
    
    DEVICE_TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( DEVICE_TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( DEVICE_TX__DOLLAR____AnalogSerialOutput__, DEVICE_TX__DOLLAR__ );
    
    VOLUME_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( VOLUME_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( VOLUME_LEVEL_TEXT__AnalogSerialOutput__, VOLUME_LEVEL_TEXT );
    
    DEVICE_RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( DEVICE_RX__DOLLAR____AnalogSerialInput__, 2000, this );
    m_StringInputList.Add( DEVICE_RX__DOLLAR____AnalogSerialInput__, DEVICE_RX__DOLLAR__ );
    
    WRAMPWAIT_Callback = new WaitFunction( WRAMPWAIT_CallbackFn );
    
    VOLUME_MAX_LEVEL.OnAnalogChange.Add( new InputChangeHandlerWrapper( VOLUME_MAX_LEVEL_OnChange_0, false ) );
    VOLUME_MIN_LEVEL.OnAnalogChange.Add( new InputChangeHandlerWrapper( VOLUME_MIN_LEVEL_OnChange_1, false ) );
    DEVICE_RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( DEVICE_RX__DOLLAR___OnChange_2, false ) );
    VOLUME_DEVICE_INSTANCE.OnSerialChange.Add( new InputChangeHandlerWrapper( VOLUME_DEVICE_INSTANCE_OnChange_3, false ) );
    VOLUME_INDEX1.OnSerialChange.Add( new InputChangeHandlerWrapper( VOLUME_INDEX1_OnChange_4, false ) );
    VOLUME_INDEX2.OnSerialChange.Add( new InputChangeHandlerWrapper( VOLUME_INDEX2_OnChange_5, false ) );
    VOLUME_COMMAND_TYPE.OnSerialChange.Add( new InputChangeHandlerWrapper( VOLUME_COMMAND_TYPE_OnChange_6, false ) );
    VOLUME_STEP.OnSerialChange.Add( new InputChangeHandlerWrapper( VOLUME_STEP_OnChange_7, false ) );
    VOL_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOL_UP_OnPush_8, false ) );
    VOL_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOL_DOWN_OnPush_9, false ) );
    SEND_NEW_LEVEL.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_NEW_LEVEL_OnPush_10, false ) );
    POLL_LEVEL.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_LEVEL_OnPush_11, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BIAMP_LEVEL_PROCESSOR_V7_4 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction WRAMPWAIT_Callback;


const uint VOL_UP__DigitalInput__ = 0;
const uint VOL_DOWN__DigitalInput__ = 1;
const uint POLL_LEVEL__DigitalInput__ = 2;
const uint SEND_NEW_LEVEL__DigitalInput__ = 3;
const uint VOLUME_MAX_LEVEL__AnalogSerialInput__ = 0;
const uint VOLUME_MIN_LEVEL__AnalogSerialInput__ = 1;
const uint NEW_VOLUME_LEVEL__AnalogSerialInput__ = 2;
const uint VOLUME_DEVICE_ID__AnalogSerialInput__ = 3;
const uint VOLUME_DEVICE_INSTANCE__AnalogSerialInput__ = 4;
const uint VOLUME_INDEX1__AnalogSerialInput__ = 5;
const uint VOLUME_INDEX2__AnalogSerialInput__ = 6;
const uint VOLUME_COMMAND_TYPE__AnalogSerialInput__ = 7;
const uint VOLUME_STEP__AnalogSerialInput__ = 8;
const uint DEVICE_RX__DOLLAR____AnalogSerialInput__ = 9;
const uint START_UP_OUT__DigitalOutput__ = 0;
const uint VOLUME_LEVEL__AnalogSerialOutput__ = 0;
const uint DEVICE_TX__DOLLAR____AnalogSerialOutput__ = 1;
const uint VOLUME_LEVEL_TEXT__AnalogSerialOutput__ = 2;

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
