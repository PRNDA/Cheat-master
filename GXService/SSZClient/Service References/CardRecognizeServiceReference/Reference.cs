﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18063
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSZClient.CardRecognizeServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RecoginizeData", Namespace="http://schemas.datacontract.org/2004/07/GXService.CardRecognize.Contract")]
    [System.SerializableAttribute()]
    public partial class RecoginizeData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] CardsBitmapField;
        
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
        public byte[] CardsBitmap {
            get {
                return this.CardsBitmapField;
            }
            set {
                if ((object.ReferenceEquals(this.CardsBitmapField, value) != true)) {
                    this.CardsBitmapField = value;
                    this.RaisePropertyChanged("CardsBitmap");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="RecognizeResult", Namespace="http://schemas.datacontract.org/2004/07/GXService.CardRecognize.Contract")]
    [System.SerializableAttribute()]
    public partial class RecognizeResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SSZClient.CardRecognizeServiceReference.Card[] ResultField;
        
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
        public SSZClient.CardRecognizeServiceReference.Card[] Result {
            get {
                return this.ResultField;
            }
            set {
                if ((object.ReferenceEquals(this.ResultField, value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Card", Namespace="GXService.CardRecognize.Contract")]
    [System.SerializableAttribute()]
    public partial class Card : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SSZClient.CardRecognizeServiceReference.CardColor ColorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SSZClient.CardRecognizeServiceReference.CardNum NumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Drawing.Rectangle RectField;
        
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
        public SSZClient.CardRecognizeServiceReference.CardColor Color {
            get {
                return this.ColorField;
            }
            set {
                if ((this.ColorField.Equals(value) != true)) {
                    this.ColorField = value;
                    this.RaisePropertyChanged("Color");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SSZClient.CardRecognizeServiceReference.CardNum Num {
            get {
                return this.NumField;
            }
            set {
                if ((this.NumField.Equals(value) != true)) {
                    this.NumField = value;
                    this.RaisePropertyChanged("Num");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Drawing.Rectangle Rect {
            get {
                return this.RectField;
            }
            set {
                if ((this.RectField.Equals(value) != true)) {
                    this.RectField = value;
                    this.RaisePropertyChanged("Rect");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CardColor", Namespace="http://schemas.datacontract.org/2004/07/GXService.CardRecognize.Contract")]
    public enum CardColor : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        未知 = -1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        方块 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        梅花 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        红桃 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        黑桃 = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CardNum", Namespace="http://schemas.datacontract.org/2004/07/GXService.CardRecognize.Contract")]
    public enum CardNum : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        未知 = -1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _2 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _3 = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _4 = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _5 = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _6 = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _7 = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _8 = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _9 = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _10 = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _J = 11,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _Q = 12,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _K = 13,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _A = 14,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _Joke = 15,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _BigJoke = 16,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        _Any = 17,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CardRecognizeServiceReference.ICardsRecognizer", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ICardsRecognizer {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICardsRecognizer/Start")]
        void Start();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICardsRecognizer/Start")]
        System.Threading.Tasks.Task StartAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICardsRecognizer/Match", ReplyAction="http://tempuri.org/ICardsRecognizer/MatchResponse")]
        System.Drawing.Rectangle Match(byte[] captureBmpData, byte[] tmplBmpData, float similarityThreshold);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICardsRecognizer/Match", ReplyAction="http://tempuri.org/ICardsRecognizer/MatchResponse")]
        System.Threading.Tasks.Task<System.Drawing.Rectangle> MatchAsync(byte[] captureBmpData, byte[] tmplBmpData, float similarityThreshold);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICardsRecognizer/Recognize", ReplyAction="http://tempuri.org/ICardsRecognizer/RecognizeResponse")]
        SSZClient.CardRecognizeServiceReference.RecognizeResult Recognize(SSZClient.CardRecognizeServiceReference.RecoginizeData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICardsRecognizer/Recognize", ReplyAction="http://tempuri.org/ICardsRecognizer/RecognizeResponse")]
        System.Threading.Tasks.Task<SSZClient.CardRecognizeServiceReference.RecognizeResult> RecognizeAsync(SSZClient.CardRecognizeServiceReference.RecoginizeData data);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/ICardsRecognizer/Stop")]
        void Stop();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/ICardsRecognizer/Stop")]
        System.Threading.Tasks.Task StopAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICardsRecognizerChannel : SSZClient.CardRecognizeServiceReference.ICardsRecognizer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CardsRecognizerClient : System.ServiceModel.ClientBase<SSZClient.CardRecognizeServiceReference.ICardsRecognizer>, SSZClient.CardRecognizeServiceReference.ICardsRecognizer {
        
        public CardsRecognizerClient() {
        }
        
        public CardsRecognizerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CardsRecognizerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CardsRecognizerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CardsRecognizerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Start() {
            base.Channel.Start();
        }
        
        public System.Threading.Tasks.Task StartAsync() {
            return base.Channel.StartAsync();
        }
        
        public System.Drawing.Rectangle Match(byte[] captureBmpData, byte[] tmplBmpData, float similarityThreshold) {
            return base.Channel.Match(captureBmpData, tmplBmpData, similarityThreshold);
        }
        
        public System.Threading.Tasks.Task<System.Drawing.Rectangle> MatchAsync(byte[] captureBmpData, byte[] tmplBmpData, float similarityThreshold) {
            return base.Channel.MatchAsync(captureBmpData, tmplBmpData, similarityThreshold);
        }
        
        public SSZClient.CardRecognizeServiceReference.RecognizeResult Recognize(SSZClient.CardRecognizeServiceReference.RecoginizeData data) {
            return base.Channel.Recognize(data);
        }
        
        public System.Threading.Tasks.Task<SSZClient.CardRecognizeServiceReference.RecognizeResult> RecognizeAsync(SSZClient.CardRecognizeServiceReference.RecoginizeData data) {
            return base.Channel.RecognizeAsync(data);
        }
        
        public void Stop() {
            base.Channel.Stop();
        }
        
        public System.Threading.Tasks.Task StopAsync() {
            return base.Channel.StopAsync();
        }
    }
}
