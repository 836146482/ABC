﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18449
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinClient.YellEatClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="YellEatClient.IYellEatService")]
    public interface IYellEatService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IYellEatService/Login", ReplyAction="http://tempuri.org/IYellEatService/LoginResponse")]
        bool Login(string username, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IYellEatServiceChannel : WinClient.YellEatClient.IYellEatService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class YellEatServiceClient : System.ServiceModel.ClientBase<WinClient.YellEatClient.IYellEatService>, WinClient.YellEatClient.IYellEatService {
        
        public YellEatServiceClient() {
        }
        
        public YellEatServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public YellEatServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public YellEatServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public YellEatServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Login(string username, string password) {
            return base.Channel.Login(username, password);
        }
    }
}
