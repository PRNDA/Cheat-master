﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18063
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSZClient.GameControlServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClientInfo", Namespace="GXService.GameServer")]
    [System.SerializableAttribute()]
    public partial class ClientInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PlayerNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PlayerName {
            get {
                return this.PlayerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PlayerNameField, value) != true)) {
                    this.PlayerNameField = value;
                    this.RaisePropertyChanged("PlayerName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RoomInfo", Namespace="GXService.GameServer")]
    [System.SerializableAttribute()]
    public partial class RoomInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SSZClient.GameControlServiceReference.ClientInfo[] ClientInfosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoomIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SSZClient.GameControlServiceReference.ClientInfo[] ClientInfos {
            get {
                return this.ClientInfosField;
            }
            set {
                if ((object.ReferenceEquals(this.ClientInfosField, value) != true)) {
                    this.ClientInfosField = value;
                    this.RaisePropertyChanged("ClientInfos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RoomId {
            get {
                return this.RoomIdField;
            }
            set {
                if ((object.ReferenceEquals(this.RoomIdField, value) != true)) {
                    this.RoomIdField = value;
                    this.RaisePropertyChanged("RoomId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Command", Namespace="GXService.GameServer")]
    [System.SerializableAttribute()]
    public partial class Command : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CommandTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] DataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CommandType {
            get {
                return this.CommandTypeField;
            }
            set {
                if ((this.CommandTypeField.Equals(value) != true)) {
                    this.CommandTypeField = value;
                    this.RaisePropertyChanged("CommandType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameControlServiceReference.IGameControlService", CallbackContract=typeof(SSZClient.GameControlServiceReference.IGameControlServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IGameControlService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameControlService/Connect")]
        void Connect(SSZClient.GameControlServiceReference.ClientInfo clientInfo);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameControlService/Connect")]
        System.Threading.Tasks.Task ConnectAsync(SSZClient.GameControlServiceReference.ClientInfo clientInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameControlService/CreateRoom", ReplyAction="http://tempuri.org/IGameControlService/CreateRoomResponse")]
        bool CreateRoom();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameControlService/CreateRoom", ReplyAction="http://tempuri.org/IGameControlService/CreateRoomResponse")]
        System.Threading.Tasks.Task<bool> CreateRoomAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameControlService/EnterRoom", ReplyAction="http://tempuri.org/IGameControlService/EnterRoomResponse")]
        bool EnterRoom(string roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameControlService/EnterRoom", ReplyAction="http://tempuri.org/IGameControlService/EnterRoomResponse")]
        System.Threading.Tasks.Task<bool> EnterRoomAsync(string roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameControlService/GetRoomInfos", ReplyAction="http://tempuri.org/IGameControlService/GetRoomInfosResponse")]
        SSZClient.GameControlServiceReference.RoomInfo[] GetRoomInfos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameControlService/GetRoomInfos", ReplyAction="http://tempuri.org/IGameControlService/GetRoomInfosResponse")]
        System.Threading.Tasks.Task<SSZClient.GameControlServiceReference.RoomInfo[]> GetRoomInfosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameControlService/Execute", ReplyAction="http://tempuri.org/IGameControlService/ExecuteResponse")]
        void Execute(SSZClient.GameControlServiceReference.Command cmd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameControlService/Execute", ReplyAction="http://tempuri.org/IGameControlService/ExecuteResponse")]
        System.Threading.Tasks.Task ExecuteAsync(SSZClient.GameControlServiceReference.Command cmd);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IGameControlService/Disconnect")]
        void Disconnect();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IGameControlService/Disconnect")]
        System.Threading.Tasks.Task DisconnectAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameControlServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameControlService/OnDataBroadcast")]
        void OnDataBroadcast(byte[] data);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameControlService/OnStartRecognize")]
        void OnStartRecognize();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameControlServiceChannel : SSZClient.GameControlServiceReference.IGameControlService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameControlServiceClient : System.ServiceModel.DuplexClientBase<SSZClient.GameControlServiceReference.IGameControlService>, SSZClient.GameControlServiceReference.IGameControlService {
        
        public GameControlServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public GameControlServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public GameControlServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameControlServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameControlServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Connect(SSZClient.GameControlServiceReference.ClientInfo clientInfo) {
            base.Channel.Connect(clientInfo);
        }
        
        public System.Threading.Tasks.Task ConnectAsync(SSZClient.GameControlServiceReference.ClientInfo clientInfo) {
            return base.Channel.ConnectAsync(clientInfo);
        }
        
        public bool CreateRoom() {
            return base.Channel.CreateRoom();
        }
        
        public System.Threading.Tasks.Task<bool> CreateRoomAsync() {
            return base.Channel.CreateRoomAsync();
        }
        
        public bool EnterRoom(string roomId) {
            return base.Channel.EnterRoom(roomId);
        }
        
        public System.Threading.Tasks.Task<bool> EnterRoomAsync(string roomId) {
            return base.Channel.EnterRoomAsync(roomId);
        }
        
        public SSZClient.GameControlServiceReference.RoomInfo[] GetRoomInfos() {
            return base.Channel.GetRoomInfos();
        }
        
        public System.Threading.Tasks.Task<SSZClient.GameControlServiceReference.RoomInfo[]> GetRoomInfosAsync() {
            return base.Channel.GetRoomInfosAsync();
        }
        
        public void Execute(SSZClient.GameControlServiceReference.Command cmd) {
            base.Channel.Execute(cmd);
        }
        
        public System.Threading.Tasks.Task ExecuteAsync(SSZClient.GameControlServiceReference.Command cmd) {
            return base.Channel.ExecuteAsync(cmd);
        }
        
        public void Disconnect() {
            base.Channel.Disconnect();
        }
        
        public System.Threading.Tasks.Task DisconnectAsync() {
            return base.Channel.DisconnectAsync();
        }
    }
}