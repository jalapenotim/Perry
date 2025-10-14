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

namespace UserModule_DAYOFWEEK2
{
    public class UserModuleClass_DAYOFWEEK2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput UPDATE;
        Crestron.Logos.SplusObjects.DigitalOutput SUN;
        Crestron.Logos.SplusObjects.DigitalOutput MON;
        Crestron.Logos.SplusObjects.DigitalOutput TUE;
        Crestron.Logos.SplusObjects.DigitalOutput WED;
        Crestron.Logos.SplusObjects.DigitalOutput THU;
        Crestron.Logos.SplusObjects.DigitalOutput FRI;
        Crestron.Logos.SplusObjects.DigitalOutput SAT;
        object UPDATE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 105;
                _SplusNVRAM.CURRDAY = (ushort) ( Functions.GetDayOfWeekNum() ) ; 
                __context__.SourceCodeLine = 106;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)6; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 108;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.I == _SplusNVRAM.CURRDAY))  ) ) 
                        { 
                        __context__.SourceCodeLine = 110;
                        _SplusNVRAM.DAYS [ _SplusNVRAM.I] = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 114;
                        _SplusNVRAM.DAYS [ _SplusNVRAM.I] = (ushort) ( 0 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 106;
                    } 
                
                __context__.SourceCodeLine = 117;
                SUN  .Value = (ushort) ( _SplusNVRAM.DAYS[ 0 ] ) ; 
                __context__.SourceCodeLine = 118;
                MON  .Value = (ushort) ( _SplusNVRAM.DAYS[ 1 ] ) ; 
                __context__.SourceCodeLine = 119;
                TUE  .Value = (ushort) ( _SplusNVRAM.DAYS[ 2 ] ) ; 
                __context__.SourceCodeLine = 120;
                WED  .Value = (ushort) ( _SplusNVRAM.DAYS[ 3 ] ) ; 
                __context__.SourceCodeLine = 121;
                THU  .Value = (ushort) ( _SplusNVRAM.DAYS[ 4 ] ) ; 
                __context__.SourceCodeLine = 122;
                FRI  .Value = (ushort) ( _SplusNVRAM.DAYS[ 5 ] ) ; 
                __context__.SourceCodeLine = 123;
                SAT  .Value = (ushort) ( _SplusNVRAM.DAYS[ 6 ] ) ; 
                
                
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
            
            __context__.SourceCodeLine = 138;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 139;
            _SplusNVRAM.CURRDAY = (ushort) ( 0 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        SocketInfo __socketinfo__ = new SocketInfo( 1, this );
        InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
        _SplusNVRAM = new SplusNVRAM( this );
        _SplusNVRAM.DAYS  = new ushort[ 8 ];
        
        UPDATE = new Crestron.Logos.SplusObjects.DigitalInput( UPDATE__DigitalInput__, this );
        m_DigitalInputList.Add( UPDATE__DigitalInput__, UPDATE );
        
        SUN = new Crestron.Logos.SplusObjects.DigitalOutput( SUN__DigitalOutput__, this );
        m_DigitalOutputList.Add( SUN__DigitalOutput__, SUN );
        
        MON = new Crestron.Logos.SplusObjects.DigitalOutput( MON__DigitalOutput__, this );
        m_DigitalOutputList.Add( MON__DigitalOutput__, MON );
        
        TUE = new Crestron.Logos.SplusObjects.DigitalOutput( TUE__DigitalOutput__, this );
        m_DigitalOutputList.Add( TUE__DigitalOutput__, TUE );
        
        WED = new Crestron.Logos.SplusObjects.DigitalOutput( WED__DigitalOutput__, this );
        m_DigitalOutputList.Add( WED__DigitalOutput__, WED );
        
        THU = new Crestron.Logos.SplusObjects.DigitalOutput( THU__DigitalOutput__, this );
        m_DigitalOutputList.Add( THU__DigitalOutput__, THU );
        
        FRI = new Crestron.Logos.SplusObjects.DigitalOutput( FRI__DigitalOutput__, this );
        m_DigitalOutputList.Add( FRI__DigitalOutput__, FRI );
        
        SAT = new Crestron.Logos.SplusObjects.DigitalOutput( SAT__DigitalOutput__, this );
        m_DigitalOutputList.Add( SAT__DigitalOutput__, SAT );
        
        
        UPDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( UPDATE_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_DAYOFWEEK2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint UPDATE__DigitalInput__ = 0;
    const uint SUN__DigitalOutput__ = 0;
    const uint MON__DigitalOutput__ = 1;
    const uint TUE__DigitalOutput__ = 2;
    const uint WED__DigitalOutput__ = 3;
    const uint THU__DigitalOutput__ = 4;
    const uint FRI__DigitalOutput__ = 5;
    const uint SAT__DigitalOutput__ = 6;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        [SplusStructAttribute(0, false, true)]
            public ushort I = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort CURRDAY = 0;
            [SplusStructAttribute(2, false, true)]
            public ushort [] DAYS;
            
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
