﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginApp.SolarService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SolarService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSolarIndex", ReplyAction="http://tempuri.org/IService1/GetSolarIndexResponse")]
        string GetSolarIndex(int lat, int lon);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSolarIndex", ReplyAction="http://tempuri.org/IService1/GetSolarIndexResponse")]
        System.Threading.Tasks.Task<string> GetSolarIndexAsync(int lat, int lon);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetWindIndex", ReplyAction="http://tempuri.org/IService1/GetWindIndexResponse")]
        string GetWindIndex(int lat, int lon);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetWindIndex", ReplyAction="http://tempuri.org/IService1/GetWindIndexResponse")]
        System.Threading.Tasks.Task<string> GetWindIndexAsync(int lat, int lon);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : LoginApp.SolarService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<LoginApp.SolarService.IService1>, LoginApp.SolarService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetSolarIndex(int lat, int lon) {
            return base.Channel.GetSolarIndex(lat, lon);
        }
        
        public System.Threading.Tasks.Task<string> GetSolarIndexAsync(int lat, int lon) {
            return base.Channel.GetSolarIndexAsync(lat, lon);
        }
        
        public string GetWindIndex(int lat, int lon) {
            return base.Channel.GetWindIndex(lat, lon);
        }
        
        public System.Threading.Tasks.Task<string> GetWindIndexAsync(int lat, int lon) {
            return base.Channel.GetWindIndexAsync(lat, lon);
        }
    }
}
