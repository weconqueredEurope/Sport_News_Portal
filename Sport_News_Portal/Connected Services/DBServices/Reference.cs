﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sport_News_Portal.DBServices {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DBServices.DBServicesSoap")]
    public interface DBServicesSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckLogin", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int CheckLogin(string email, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckLogin", ReplyAction="*")]
        System.Threading.Tasks.Task<int> CheckLoginAsync(string email, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAccount", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetAccount(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAccount", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetAccountAsync(string email);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DBServicesSoapChannel : Sport_News_Portal.DBServices.DBServicesSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DBServicesSoapClient : System.ServiceModel.ClientBase<Sport_News_Portal.DBServices.DBServicesSoap>, Sport_News_Portal.DBServices.DBServicesSoap {
        
        public DBServicesSoapClient() {
        }
        
        public DBServicesSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DBServicesSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DBServicesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DBServicesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync() {
            return base.Channel.HelloWorldAsync();
        }
        
        public int CheckLogin(string email, string pass) {
            return base.Channel.CheckLogin(email, pass);
        }
        
        public System.Threading.Tasks.Task<int> CheckLoginAsync(string email, string pass) {
            return base.Channel.CheckLoginAsync(email, pass);
        }
        
        public System.Data.DataSet GetAccount(string email) {
            return base.Channel.GetAccount(email);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetAccountAsync(string email) {
            return base.Channel.GetAccountAsync(email);
        }
    }
}
