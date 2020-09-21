﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client_Transfer_Data.FileServiceClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FileServiceClient.IFileService")]
    public interface IFileService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileService/UploadFile", ReplyAction="http://tempuri.org/IFileService/UploadFileResponse")]
        System.IO.Stream UploadFile(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileService/UploadFile", ReplyAction="http://tempuri.org/IFileService/UploadFileResponse")]
        System.Threading.Tasks.Task<System.IO.Stream> UploadFileAsync(string path);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFileServiceChannel : Client_Transfer_Data.FileServiceClient.IFileService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FileServiceClient : System.ServiceModel.ClientBase<Client_Transfer_Data.FileServiceClient.IFileService>, Client_Transfer_Data.FileServiceClient.IFileService {
        
        public FileServiceClient() {
        }
        
        public FileServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FileServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.IO.Stream UploadFile(string path) {
            return base.Channel.UploadFile(path);
        }
        
        public System.Threading.Tasks.Task<System.IO.Stream> UploadFileAsync(string path) {
            return base.Channel.UploadFileAsync(path);
        }
    }
}
