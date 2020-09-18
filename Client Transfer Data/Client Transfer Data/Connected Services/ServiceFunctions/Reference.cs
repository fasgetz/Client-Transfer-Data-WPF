﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client_Transfer_Data.ServiceFunctions {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceFunctions.IService", CallbackContract=typeof(Client_Transfer_Data.ServiceFunctions.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ConnectOnServer", ReplyAction="http://tempuri.org/IService/ConnectOnServerResponse")]
        int ConnectOnServer(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ConnectOnServer", ReplyAction="http://tempuri.org/IService/ConnectOnServerResponse")]
        System.Threading.Tasks.Task<int> ConnectOnServerAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/GetOnlineUsers")]
        void GetOnlineUsers();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/GetOnlineUsers")]
        System.Threading.Tasks.Task GetOnlineUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Disconnect", ReplyAction="http://tempuri.org/IService/DisconnectResponse")]
        void Disconnect(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Disconnect", ReplyAction="http://tempuri.org/IService/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/SendMessage")]
        void SendMessage(string Message, int UserID);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(string Message, int UserID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/MsgCallback")]
        void MsgCallback(string msg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/UserConnected")]
        void UserConnected(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/HasOnline", ReplyAction="http://tempuri.org/IService/HasOnlineResponse")]
        bool HasOnline();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/GetUsersOnline")]
        void GetUsersOnline(string usersOnlineJson);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Client_Transfer_Data.ServiceFunctions.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<Client_Transfer_Data.ServiceFunctions.IService>, Client_Transfer_Data.ServiceFunctions.IService {
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public int ConnectOnServer(string name) {
            return base.Channel.ConnectOnServer(name);
        }
        
        public System.Threading.Tasks.Task<int> ConnectOnServerAsync(string name) {
            return base.Channel.ConnectOnServerAsync(name);
        }
        
        public void GetOnlineUsers() {
            base.Channel.GetOnlineUsers();
        }
        
        public System.Threading.Tasks.Task GetOnlineUsersAsync() {
            return base.Channel.GetOnlineUsersAsync();
        }
        
        public void Disconnect(int id) {
            base.Channel.Disconnect(id);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(int id) {
            return base.Channel.DisconnectAsync(id);
        }
        
        public void SendMessage(string Message, int UserID) {
            base.Channel.SendMessage(Message, UserID);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(string Message, int UserID) {
            return base.Channel.SendMessageAsync(Message, UserID);
        }
    }
}