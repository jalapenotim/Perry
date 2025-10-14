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

namespace CrestronModule_FUSION_SSI_EQUIPMENT_STRING_PREPEND_V1_1_0
{
    public class CrestronModuleClass_FUSION_SSI_EQUIPMENT_STRING_PREPEND_V1_1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.StringInput STATUS_MESSAGE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput PREPENDED_STATUS_MESSAGE__DOLLAR__;
        CrestronString [] PREFIX;
        private CrestronString PREPEND (  SplusExecutionContext __context__, CrestronString DATA ) 
            { 
            ushort SEVERITY = 0;
            
            CrestronString HEADER;
            CrestronString NEW_DATA;
            HEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            NEW_DATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 24;
            HEADER  .UpdateValue ( Functions.Remove ( ":" , DATA )  ) ; 
            __context__.SourceCodeLine = 26;
            SEVERITY = (ushort) ( Functions.Atoi( HEADER ) ) ; 
            __context__.SourceCodeLine = 28;
            NEW_DATA  .UpdateValue ( HEADER + PREFIX [ SEVERITY ] + DATA  ) ; 
            __context__.SourceCodeLine = 30;
            return ( NEW_DATA ) ; 
            
            }
            
        object STATUS_MESSAGE__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 39;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( STATUS_MESSAGE__DOLLAR__ ) > 3 ) ) && Functions.TestForTrue ( Functions.Find( ":" , STATUS_MESSAGE__DOLLAR__ , 2 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 41;
                    PREPENDED_STATUS_MESSAGE__DOLLAR__  .UpdateValue ( PREPEND (  __context__ , STATUS_MESSAGE__DOLLAR__)  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 45;
                    Print( "Bad Data in Fusion SSI Equipment String Prepend\r\n") ; 
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
            
            __context__.SourceCodeLine = 51;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 53;
            PREFIX [ 0 ]  .UpdateValue ( "ok-"  ) ; 
            __context__.SourceCodeLine = 54;
            PREFIX [ 1 ]  .UpdateValue ( "notice-"  ) ; 
            __context__.SourceCodeLine = 55;
            PREFIX [ 2 ]  .UpdateValue ( "warning-"  ) ; 
            __context__.SourceCodeLine = 56;
            PREFIX [ 3 ]  .UpdateValue ( "critical-"  ) ; 
            __context__.SourceCodeLine = 57;
            PREFIX [ 4 ]  .UpdateValue ( "fatal-"  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        PREFIX  = new CrestronString[ 5 ];
        for( uint i = 0; i < 5; i++ )
            PREFIX [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        STATUS_MESSAGE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( STATUS_MESSAGE__DOLLAR____AnalogSerialInput__, 100, this );
        m_StringInputList.Add( STATUS_MESSAGE__DOLLAR____AnalogSerialInput__, STATUS_MESSAGE__DOLLAR__ );
        
        PREPENDED_STATUS_MESSAGE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( PREPENDED_STATUS_MESSAGE__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( PREPENDED_STATUS_MESSAGE__DOLLAR____AnalogSerialOutput__, PREPENDED_STATUS_MESSAGE__DOLLAR__ );
        
        
        STATUS_MESSAGE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( STATUS_MESSAGE__DOLLAR___OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public CrestronModuleClass_FUSION_SSI_EQUIPMENT_STRING_PREPEND_V1_1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint STATUS_MESSAGE__DOLLAR____AnalogSerialInput__ = 0;
    const uint PREPENDED_STATUS_MESSAGE__DOLLAR____AnalogSerialOutput__ = 0;
    
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
