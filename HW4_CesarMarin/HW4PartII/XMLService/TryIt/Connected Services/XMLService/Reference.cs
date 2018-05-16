﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TryIt.XMLService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="XMLService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/VerifyXML", ReplyAction="http://tempuri.org/IService1/VerifyXMLResponse")]
        string VerifyXML(string ur_xml, string ur_xsd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/VerifyXML", ReplyAction="http://tempuri.org/IService1/VerifyXMLResponse")]
        System.Threading.Tasks.Task<string> VerifyXMLAsync(string ur_xml, string ur_xsd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/XPathSearch", ReplyAction="http://tempuri.org/IService1/XPathSearchResponse")]
        string XPathSearch(string ur_xml, string xpath_str);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/XPathSearch", ReplyAction="http://tempuri.org/IService1/XPathSearchResponse")]
        System.Threading.Tasks.Task<string> XPathSearchAsync(string ur_xml, string xpath_str);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TryIt.XMLService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TryIt.XMLService.IService1>, TryIt.XMLService.IService1 {
        
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
        
        public string VerifyXML(string ur_xml, string ur_xsd) {
            return base.Channel.VerifyXML(ur_xml, ur_xsd);
        }
        
        public System.Threading.Tasks.Task<string> VerifyXMLAsync(string ur_xml, string ur_xsd) {
            return base.Channel.VerifyXMLAsync(ur_xml, ur_xsd);
        }
        
        public string XPathSearch(string ur_xml, string xpath_str) {
            return base.Channel.XPathSearch(ur_xml, xpath_str);
        }
        
        public System.Threading.Tasks.Task<string> XPathSearchAsync(string ur_xml, string xpath_str) {
            return base.Channel.XPathSearchAsync(ur_xml, xpath_str);
        }
    }
}