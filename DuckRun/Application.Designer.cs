﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DuckRun {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.1.0.0")]
    internal sealed partial class Application : global::System.Configuration.ApplicationSettingsBase {
        
        private static Application defaultInstance = ((Application)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Application())));
        
        public static Application Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://testducks.us-west-2.elasticbeanstalk.com/api/Schedule/Run")]
        public string runUrl {
            get {
                return ((string)(this["runUrl"]));
            }
        }
    }
}