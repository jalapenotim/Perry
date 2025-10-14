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

namespace CrestronModule_FUSION_SSI_OCCUPANCY_SENSOR_V1_02
{
    public class CrestronModuleClass_FUSION_SSI_OCCUPANCY_SENSOR_V1_02 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput FUSION_OFFLINE_HELD;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_OCCUPIED_HELD;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_UNOCCUPIED_HELD;
        Crestron.Logos.SplusObjects.BufferInput ROOM_OCCUPANCY_INFO_RX__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_OCCUPIED_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_UNOCCUPIED_FB;
        Crestron.Logos.SplusObjects.StringOutput OCCUPANCY_STATE_TXT__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput ROOM_OCCUPANCY_INFO_TX__DOLLAR__;
        UShortParameter DEBUGMODE;
        UShortParameter OCCUPANCYMODE;
        ushort G_NDEBUG = 0;
        ushort G_NLASTSTATE = 0;
        ushort G_NLASTTRANSMITTEDSTATE = 0;
        private CrestronString FNEXTRACTDATA (  SplusExecutionContext __context__, CrestronString SSTARTTAG__DOLLAR__ , CrestronString SENDTAG__DOLLAR__ , CrestronString SDATA__DOLLAR__ ) 
            { 
            ushort NSTARTPOS = 0;
            ushort NENDPOSITION = 0;
            ushort NCOUNT = 0;
            
            CrestronString SRETURNDATA__DOLLAR__;
            SRETURNDATA__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 108;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 108;
                Trace( "*** Start Function fnExtractData ***\r\n") ; 
                }
            
            __context__.SourceCodeLine = 109;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 109;
                Trace( "sStartTag$ = {0}\r\n", SSTARTTAG__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 110;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 110;
                Trace( "sEndTag$ = {0}\r\n", SENDTAG__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 111;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 111;
                Trace( "sData$ = {0}\r\n", SDATA__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 113;
            NSTARTPOS = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 115;
            NSTARTPOS = (ushort) ( Functions.Find( SSTARTTAG__DOLLAR__ , SDATA__DOLLAR__ ) ) ; 
            __context__.SourceCodeLine = 116;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 116;
                Trace( "nStartPos = {0:d}\r\n", (ushort)NSTARTPOS) ; 
                }
            
            __context__.SourceCodeLine = 118;
            if ( Functions.TestForTrue  ( ( NSTARTPOS)  ) ) 
                { 
                __context__.SourceCodeLine = 120;
                NSTARTPOS = (ushort) ( (NSTARTPOS + Functions.Length( SSTARTTAG__DOLLAR__ )) ) ; 
                __context__.SourceCodeLine = 121;
                NENDPOSITION = (ushort) ( Functions.Find( SENDTAG__DOLLAR__ , SDATA__DOLLAR__ , NSTARTPOS ) ) ; 
                __context__.SourceCodeLine = 122;
                NCOUNT = (ushort) ( (NENDPOSITION - NSTARTPOS) ) ; 
                __context__.SourceCodeLine = 124;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 124;
                    Trace( "nStartPos = {0:d}\r\n", (ushort)NSTARTPOS) ; 
                    }
                
                __context__.SourceCodeLine = 125;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 125;
                    Trace( "nEndPosition = {0:d}\r\n", (ushort)NENDPOSITION) ; 
                    }
                
                __context__.SourceCodeLine = 126;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 126;
                    Trace( "nCount = {0:d}\r\n", (ushort)NCOUNT) ; 
                    }
                
                __context__.SourceCodeLine = 128;
                MakeString ( SRETURNDATA__DOLLAR__ , "{0}", Functions.Mid ( SDATA__DOLLAR__ ,  (int) ( NSTARTPOS ) ,  (int) ( NCOUNT ) ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 132;
                MakeString ( SRETURNDATA__DOLLAR__ , "{0}", "Not Found" ) ; 
                } 
            
            __context__.SourceCodeLine = 135;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 135;
                Trace( "sReturnData$ = {0}\r\n", SRETURNDATA__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 136;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 136;
                Trace( "*** End Function fnExtractData ***\r\n") ; 
                }
            
            __context__.SourceCodeLine = 138;
            return ( SRETURNDATA__DOLLAR__ ) ; 
            
            }
            
        private void FNUPDATEOUTPUTS (  SplusExecutionContext __context__, ushort NOCCUPANCYSTATE ) 
            { 
            
            __context__.SourceCodeLine = 143;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 143;
                Trace( "*** Start Function fnUpdateOutputs(nOccupancyState = {0:d}) ***\r\n", (ushort)NOCCUPANCYSTATE) ; 
                }
            
            __context__.SourceCodeLine = 144;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 144;
                Trace( "g_nLastState = {0:d}\r\n", (ushort)G_NLASTSTATE) ; 
                }
            
            __context__.SourceCodeLine = 145;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_NLASTSTATE != NOCCUPANCYSTATE))  ) ) 
                { 
                __context__.SourceCodeLine = 147;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 147;
                    Trace( "Inside if(g_nLastState <> nOccupancyState)\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 148;
                G_NLASTSTATE = (ushort) ( NOCCUPANCYSTATE ) ; 
                __context__.SourceCodeLine = 149;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NOCCUPANCYSTATE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 151;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 151;
                        Trace( "Room is now unoccupied\r\n") ; 
                        }
                    
                    __context__.SourceCodeLine = 152;
                    ROOM_OCCUPIED_FB  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 153;
                    ROOM_UNOCCUPIED_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 155;
                    MakeString ( OCCUPANCY_STATE_TXT__DOLLAR__ , "{0}", "Unoccupied" ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 159;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 159;
                        Trace( "Room is now Occupied\r\n") ; 
                        }
                    
                    __context__.SourceCodeLine = 160;
                    ROOM_UNOCCUPIED_FB  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 161;
                    ROOM_OCCUPIED_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 163;
                    MakeString ( OCCUPANCY_STATE_TXT__DOLLAR__ , "{0}", "Occupied" ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 166;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 166;
                Trace( "*** End Function fnUpdateOutputs ***\r\n") ; 
                }
            
            
            }
            
        private void FNSENDOCCUPANCYDATA (  SplusExecutionContext __context__, ushort NOCCUPANCYSTATE , CrestronString SSENSORTYPE__DOLLAR__ ) 
            { 
            CrestronString STEMP__DOLLAR__;
            STEMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
            
            
            __context__.SourceCodeLine = 173;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 173;
                Trace( "*** Start Function fnSendOccupancyData(nOccupancyState = {0:d}) ***\r\n", (ushort)NOCCUPANCYSTATE) ; 
                }
            
            __context__.SourceCodeLine = 174;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 174;
                Trace( "g_nLastTransmittedState = {0:d}\r\n", (ushort)G_NLASTTRANSMITTEDSTATE) ; 
                }
            
            __context__.SourceCodeLine = 175;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 175;
                Trace( "Fusion_Offline_Held = {0:d}\r\n", (ushort)FUSION_OFFLINE_HELD  .Value) ; 
                }
            
            __context__.SourceCodeLine = 182;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_NLASTTRANSMITTEDSTATE != NOCCUPANCYSTATE) ) && Functions.TestForTrue ( Functions.Not( FUSION_OFFLINE_HELD  .Value ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 184;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 184;
                    Trace( "Inside if(g_nLastTransmittedState <> nOccupancyState && !Fusion_Offline_Held)\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 185;
                G_NLASTTRANSMITTEDSTATE = (ushort) ( NOCCUPANCYSTATE ) ; 
                __context__.SourceCodeLine = 187;
                MakeString ( STEMP__DOLLAR__ , "<Occupancy>") ; 
                __context__.SourceCodeLine = 188;
                MakeString ( STEMP__DOLLAR__ , "{0}<Type>{1}</Type>", STEMP__DOLLAR__ , SSENSORTYPE__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 190;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NOCCUPANCYSTATE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 192;
                    MakeString ( STEMP__DOLLAR__ , "{0}<State>{1}</State>", STEMP__DOLLAR__ , "Unoccupied" ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 196;
                    MakeString ( STEMP__DOLLAR__ , "{0}<State>{1}</State>", STEMP__DOLLAR__ , "Occupied" ) ; 
                    } 
                
                __context__.SourceCodeLine = 198;
                MakeString ( STEMP__DOLLAR__ , "{0}</Occupancy>", STEMP__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 199;
                ROOM_OCCUPANCY_INFO_TX__DOLLAR__  .UpdateValue ( STEMP__DOLLAR__  ) ; 
                } 
            
            __context__.SourceCodeLine = 207;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 207;
                Trace( "*** End Function fnSendOccupancyData ***\r\n") ; 
                }
            
            
            }
            
        private void FNPOLLOCCUPANCYDATA (  SplusExecutionContext __context__ ) 
            { 
            CrestronString STEMP__DOLLAR__;
            STEMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
            
            
            __context__.SourceCodeLine = 214;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 214;
                Trace( "*** Start Function fnPollOccupancyData\r\n") ; 
                }
            
            __context__.SourceCodeLine = 215;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 215;
                Trace( "Fusion_Offline_Held = {0:d}\r\n", (ushort)FUSION_OFFLINE_HELD  .Value) ; 
                }
            
            __context__.SourceCodeLine = 223;
            if ( Functions.TestForTrue  ( ( Functions.Not( FUSION_OFFLINE_HELD  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 225;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 225;
                    Trace( "Inside if(!Fusion_Offline_Held)\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 227;
                MakeString ( STEMP__DOLLAR__ , "<Occupancy>") ; 
                __context__.SourceCodeLine = 228;
                MakeString ( STEMP__DOLLAR__ , "{0}<State>?</State>", STEMP__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 229;
                MakeString ( STEMP__DOLLAR__ , "{0}</Occupancy>", STEMP__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 231;
                ROOM_OCCUPANCY_INFO_TX__DOLLAR__  .UpdateValue ( STEMP__DOLLAR__  ) ; 
                } 
            
            __context__.SourceCodeLine = 239;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 239;
                Trace( "*** End Function fnPollOccupancyData ***\r\n") ; 
                }
            
            
            }
            
        object FUSION_OFFLINE_HELD_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 247;
                G_NLASTTRANSMITTEDSTATE = (ushort) ( 999 ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object FUSION_OFFLINE_HELD_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 252;
            Functions.Delay (  (int) ( 500 ) ) ; 
            __context__.SourceCodeLine = 253;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM_OCCUPIED_HELD  .Value ) && Functions.TestForTrue ( Functions.BoolToInt (OCCUPANCYMODE  .Value == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 255;
                FNSENDOCCUPANCYDATA (  __context__ , (ushort)( 1 ), "Local") ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 257;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM_OCCUPIED_HELD  .Value ) && Functions.TestForTrue ( Functions.BoolToInt (OCCUPANCYMODE  .Value == 1) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 259;
                    FNSENDOCCUPANCYDATA (  __context__ , (ushort)( 1 ), "Remote") ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 261;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM_UNOCCUPIED_HELD  .Value ) && Functions.TestForTrue ( Functions.BoolToInt (OCCUPANCYMODE  .Value == 0) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 263;
                        FNSENDOCCUPANCYDATA (  __context__ , (ushort)( 0 ), "Local") ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 265;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM_UNOCCUPIED_HELD  .Value ) && Functions.TestForTrue ( Functions.BoolToInt (OCCUPANCYMODE  .Value == 1) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 267;
                            FNSENDOCCUPANCYDATA (  __context__ , (ushort)( 0 ), "Remote") ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 269;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM_OCCUPIED_HELD  .Value ) ) && Functions.TestForTrue ( Functions.Not( ROOM_UNOCCUPIED_HELD  .Value ) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (G_NLASTSTATE == 999) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 271;
                                FNPOLLOCCUPANCYDATA (  __context__  ) ; 
                                } 
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object ROOM_OCCUPIED_HELD_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 277;
        FNUPDATEOUTPUTS (  __context__ , (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 278;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (OCCUPANCYMODE  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 280;
            FNSENDOCCUPANCYDATA (  __context__ , (ushort)( 1 ), "Local") ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 284;
            FNSENDOCCUPANCYDATA (  __context__ , (ushort)( 1 ), "Remote") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_UNOCCUPIED_HELD_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 290;
        FNUPDATEOUTPUTS (  __context__ , (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 291;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (OCCUPANCYMODE  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 293;
            FNSENDOCCUPANCYDATA (  __context__ , (ushort)( 0 ), "Local") ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 297;
            FNSENDOCCUPANCYDATA (  __context__ , (ushort)( 0 ), "Remote") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_OCCUPANCY_INFO_RX__DOLLAR___OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP__DOLLAR__;
        CrestronString SCURRENTSTATE__DOLLAR__;
        STEMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5000, this );
        SCURRENTSTATE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
        
        
        __context__.SourceCodeLine = 305;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 307;
            STEMP__DOLLAR__  .UpdateValue ( Functions.Gather ( "</Occupancy>" , ROOM_OCCUPANCY_INFO_RX__DOLLAR__ )  ) ; 
            __context__.SourceCodeLine = 308;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 308;
                Trace( "sTemp$ = {0}\r\n", STEMP__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 309;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (OCCUPANCYMODE  .Value == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 311;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 311;
                    Trace( "Inside Remote Mode\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 317;
                MakeString ( SCURRENTSTATE__DOLLAR__ , "{0}", FNEXTRACTDATA (  __context__ , "<State>", "</State>", STEMP__DOLLAR__) ) ; 
                __context__.SourceCodeLine = 318;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 318;
                    Trace( "sCurrentState$ = {0}\r\n", SCURRENTSTATE__DOLLAR__ ) ; 
                    }
                
                __context__.SourceCodeLine = 319;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SCURRENTSTATE__DOLLAR__ == "Occupied"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 321;
                    FNUPDATEOUTPUTS (  __context__ , (ushort)( 1 )) ; 
                    __context__.SourceCodeLine = 322;
                    FNSENDOCCUPANCYDATA (  __context__ , (ushort)( 1 ), "Remote") ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 326;
                    FNUPDATEOUTPUTS (  __context__ , (ushort)( 0 )) ; 
                    __context__.SourceCodeLine = 327;
                    FNSENDOCCUPANCYDATA (  __context__ , (ushort)( 0 ), "Remote") ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 332;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 332;
                    Trace( "Inside Local Mode\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 335;
                MakeString ( SCURRENTSTATE__DOLLAR__ , "{0}", FNEXTRACTDATA (  __context__ , "<State>", "</State>", STEMP__DOLLAR__) ) ; 
                __context__.SourceCodeLine = 336;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 336;
                    Trace( "sCurrentState$ = {0}\r\n", SCURRENTSTATE__DOLLAR__ ) ; 
                    }
                
                __context__.SourceCodeLine = 337;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SCURRENTSTATE__DOLLAR__ == "Occupied"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 339;
                    FNUPDATEOUTPUTS (  __context__ , (ushort)( 1 )) ; 
                    __context__.SourceCodeLine = 340;
                    FNSENDOCCUPANCYDATA (  __context__ , (ushort)( 1 ), "Remote") ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 344;
                    FNUPDATEOUTPUTS (  __context__ , (ushort)( 0 )) ; 
                    __context__.SourceCodeLine = 345;
                    FNSENDOCCUPANCYDATA (  __context__ , (ushort)( 0 ), "Remote") ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 305;
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
        
        __context__.SourceCodeLine = 356;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 358;
        G_NDEBUG = (ushort) ( DEBUGMODE  .Value ) ; 
        __context__.SourceCodeLine = 360;
        G_NLASTSTATE = (ushort) ( 999 ) ; 
        __context__.SourceCodeLine = 361;
        G_NLASTTRANSMITTEDSTATE = (ushort) ( 999 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    FUSION_OFFLINE_HELD = new Crestron.Logos.SplusObjects.DigitalInput( FUSION_OFFLINE_HELD__DigitalInput__, this );
    m_DigitalInputList.Add( FUSION_OFFLINE_HELD__DigitalInput__, FUSION_OFFLINE_HELD );
    
    ROOM_OCCUPIED_HELD = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_OCCUPIED_HELD__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_OCCUPIED_HELD__DigitalInput__, ROOM_OCCUPIED_HELD );
    
    ROOM_UNOCCUPIED_HELD = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_UNOCCUPIED_HELD__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_UNOCCUPIED_HELD__DigitalInput__, ROOM_UNOCCUPIED_HELD );
    
    ROOM_OCCUPIED_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_OCCUPIED_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_OCCUPIED_FB__DigitalOutput__, ROOM_OCCUPIED_FB );
    
    ROOM_UNOCCUPIED_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_UNOCCUPIED_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_UNOCCUPIED_FB__DigitalOutput__, ROOM_UNOCCUPIED_FB );
    
    OCCUPANCY_STATE_TXT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( OCCUPANCY_STATE_TXT__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( OCCUPANCY_STATE_TXT__DOLLAR____AnalogSerialOutput__, OCCUPANCY_STATE_TXT__DOLLAR__ );
    
    ROOM_OCCUPANCY_INFO_TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( ROOM_OCCUPANCY_INFO_TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( ROOM_OCCUPANCY_INFO_TX__DOLLAR____AnalogSerialOutput__, ROOM_OCCUPANCY_INFO_TX__DOLLAR__ );
    
    ROOM_OCCUPANCY_INFO_RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( ROOM_OCCUPANCY_INFO_RX__DOLLAR____AnalogSerialInput__, 5000, this );
    m_StringInputList.Add( ROOM_OCCUPANCY_INFO_RX__DOLLAR____AnalogSerialInput__, ROOM_OCCUPANCY_INFO_RX__DOLLAR__ );
    
    DEBUGMODE = new UShortParameter( DEBUGMODE__Parameter__, this );
    m_ParameterList.Add( DEBUGMODE__Parameter__, DEBUGMODE );
    
    OCCUPANCYMODE = new UShortParameter( OCCUPANCYMODE__Parameter__, this );
    m_ParameterList.Add( OCCUPANCYMODE__Parameter__, OCCUPANCYMODE );
    
    
    FUSION_OFFLINE_HELD.OnDigitalPush.Add( new InputChangeHandlerWrapper( FUSION_OFFLINE_HELD_OnPush_0, false ) );
    FUSION_OFFLINE_HELD.OnDigitalRelease.Add( new InputChangeHandlerWrapper( FUSION_OFFLINE_HELD_OnRelease_1, false ) );
    ROOM_OCCUPIED_HELD.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_OCCUPIED_HELD_OnPush_2, false ) );
    ROOM_UNOCCUPIED_HELD.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_UNOCCUPIED_HELD_OnPush_3, false ) );
    ROOM_OCCUPANCY_INFO_RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( ROOM_OCCUPANCY_INFO_RX__DOLLAR___OnChange_4, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_FUSION_SSI_OCCUPANCY_SENSOR_V1_02 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint FUSION_OFFLINE_HELD__DigitalInput__ = 0;
const uint ROOM_OCCUPIED_HELD__DigitalInput__ = 1;
const uint ROOM_UNOCCUPIED_HELD__DigitalInput__ = 2;
const uint ROOM_OCCUPANCY_INFO_RX__DOLLAR____AnalogSerialInput__ = 0;
const uint ROOM_OCCUPIED_FB__DigitalOutput__ = 0;
const uint ROOM_UNOCCUPIED_FB__DigitalOutput__ = 1;
const uint OCCUPANCY_STATE_TXT__DOLLAR____AnalogSerialOutput__ = 0;
const uint ROOM_OCCUPANCY_INFO_TX__DOLLAR____AnalogSerialOutput__ = 1;
const uint DEBUGMODE__Parameter__ = 10;
const uint OCCUPANCYMODE__Parameter__ = 11;

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
