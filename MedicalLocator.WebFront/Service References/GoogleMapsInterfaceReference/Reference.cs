﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicalLocator.WebFront.GoogleMapsInterfaceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GooglePlacesApiRequest", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.GooglePlacesAp" +
        "i")]
    [System.SerializableAttribute()]
    public partial class GooglePlacesApiRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool IsGpsUsedField;
        
        private MedicalLocator.WebFront.GoogleMapsInterfaceReference.Location LocationField;
        
        private MedicalLocator.WebFront.GoogleMapsInterfaceReference.MedicalTypeGoogleService[] MedicalTypesField;
        
        private int RadiusField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public bool IsGpsUsed {
            get {
                return this.IsGpsUsedField;
            }
            set {
                if ((this.IsGpsUsedField.Equals(value) != true)) {
                    this.IsGpsUsedField = value;
                    this.RaisePropertyChanged("IsGpsUsed");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public MedicalLocator.WebFront.GoogleMapsInterfaceReference.Location Location {
            get {
                return this.LocationField;
            }
            set {
                if ((object.ReferenceEquals(this.LocationField, value) != true)) {
                    this.LocationField = value;
                    this.RaisePropertyChanged("Location");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public MedicalLocator.WebFront.GoogleMapsInterfaceReference.MedicalTypeGoogleService[] MedicalTypes {
            get {
                return this.MedicalTypesField;
            }
            set {
                if ((object.ReferenceEquals(this.MedicalTypesField, value) != true)) {
                    this.MedicalTypesField = value;
                    this.RaisePropertyChanged("MedicalTypes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public int Radius {
            get {
                return this.RadiusField;
            }
            set {
                if ((this.RadiusField.Equals(value) != true)) {
                    this.RadiusField = value;
                    this.RaisePropertyChanged("Radius");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Location", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.GooglePlacesAp" +
        "i")]
    [System.SerializableAttribute()]
    public partial class Location : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private double LatField;
        
        private double LngField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public double Lat {
            get {
                return this.LatField;
            }
            set {
                if ((this.LatField.Equals(value) != true)) {
                    this.LatField = value;
                    this.RaisePropertyChanged("Lat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public double Lng {
            get {
                return this.LngField;
            }
            set {
                if ((this.LngField.Equals(value) != true)) {
                    this.LngField = value;
                    this.RaisePropertyChanged("Lng");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="MedicalTypeGoogleService", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.Model")]
    public enum MedicalTypeGoogleService : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Doctor = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Dentist = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GooglePlacesWcfResponse", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.GooglePlacesAp" +
        "i")]
    [System.SerializableAttribute()]
    public partial class GooglePlacesWcfResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MedicalLocator.WebFront.GoogleMapsInterfaceReference.GooglePlacesWcfResult[] ResultsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MedicalLocator.WebFront.GoogleMapsInterfaceReference.Status StatusField;
        
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
        public MedicalLocator.WebFront.GoogleMapsInterfaceReference.GooglePlacesWcfResult[] Results {
            get {
                return this.ResultsField;
            }
            set {
                if ((object.ReferenceEquals(this.ResultsField, value) != true)) {
                    this.ResultsField = value;
                    this.RaisePropertyChanged("Results");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MedicalLocator.WebFront.GoogleMapsInterfaceReference.Status Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="GooglePlacesWcfResult", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.GooglePlacesAp" +
        "i")]
    [System.SerializableAttribute()]
    public partial class GooglePlacesWcfResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MedicalLocator.WebFront.GoogleMapsInterfaceReference.Location LocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MedicalLocator.WebFront.GoogleMapsInterfaceReference.MedicalTypeGoogleService TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VicinityField;
        
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
        public MedicalLocator.WebFront.GoogleMapsInterfaceReference.Location Location {
            get {
                return this.LocationField;
            }
            set {
                if ((object.ReferenceEquals(this.LocationField, value) != true)) {
                    this.LocationField = value;
                    this.RaisePropertyChanged("Location");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MedicalLocator.WebFront.GoogleMapsInterfaceReference.MedicalTypeGoogleService Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Vicinity {
            get {
                return this.VicinityField;
            }
            set {
                if ((object.ReferenceEquals(this.VicinityField, value) != true)) {
                    this.VicinityField = value;
                    this.RaisePropertyChanged("Vicinity");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Status", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.GooglePlacesAp" +
        "i")]
    public enum Status : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Ok = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Zero_Results = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Request_Denied = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FaultBase", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.Faults")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(MedicalLocator.WebFront.GoogleMapsInterfaceReference.InvalidResponseFault))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(MedicalLocator.WebFront.GoogleMapsInterfaceReference.RequestDeniedFault))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(MedicalLocator.WebFront.GoogleMapsInterfaceReference.ConnectionFault))]
    public partial class FaultBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
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
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="InvalidResponseFault", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.Faults")]
    [System.SerializableAttribute()]
    public partial class InvalidResponseFault : MedicalLocator.WebFront.GoogleMapsInterfaceReference.FaultBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResponseTextField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ResponseText {
            get {
                return this.ResponseTextField;
            }
            set {
                if ((object.ReferenceEquals(this.ResponseTextField, value) != true)) {
                    this.ResponseTextField = value;
                    this.RaisePropertyChanged("ResponseText");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RequestDeniedFault", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.Faults")]
    [System.SerializableAttribute()]
    public partial class RequestDeniedFault : MedicalLocator.WebFront.GoogleMapsInterfaceReference.FaultBase {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.Faults")]
    [System.SerializableAttribute()]
    public partial class ConnectionFault : MedicalLocator.WebFront.GoogleMapsInterfaceReference.FaultBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OperationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RequestedAddressField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Operation {
            get {
                return this.OperationField;
            }
            set {
                if ((object.ReferenceEquals(this.OperationField, value) != true)) {
                    this.OperationField = value;
                    this.RaisePropertyChanged("Operation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RequestedAddress {
            get {
                return this.RequestedAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.RequestedAddressField, value) != true)) {
                    this.RequestedAddressField = value;
                    this.RaisePropertyChanged("RequestedAddress");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GoogleMapsInterfaceReference.IGoogleMapsInterfaceService")]
    public interface IGoogleMapsInterfaceService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGoogleMapsInterfaceService/SendGooglePlacesApiRequest", ReplyAction="http://tempuri.org/IGoogleMapsInterfaceService/SendGooglePlacesApiRequestResponse" +
            "")]
        [System.ServiceModel.FaultContractAttribute(typeof(MedicalLocator.WebFront.GoogleMapsInterfaceReference.ConnectionFault), Action="http://tempuri.org/IGoogleMapsInterfaceService/SendGooglePlacesApiRequestConnecti" +
            "onFaultFault", Name="ConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.Faults")]
        [System.ServiceModel.FaultContractAttribute(typeof(MedicalLocator.WebFront.GoogleMapsInterfaceReference.InvalidResponseFault), Action="http://tempuri.org/IGoogleMapsInterfaceService/SendGooglePlacesApiRequestInvalidR" +
            "esponseFaultFault", Name="InvalidResponseFault", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.Faults")]
        [System.ServiceModel.FaultContractAttribute(typeof(MedicalLocator.WebFront.GoogleMapsInterfaceReference.RequestDeniedFault), Action="http://tempuri.org/IGoogleMapsInterfaceService/SendGooglePlacesApiRequestRequestD" +
            "eniedFaultFault", Name="RequestDeniedFault", Namespace="http://schemas.datacontract.org/2004/07/GoogleMapsInterfaceService.Faults")]
        MedicalLocator.WebFront.GoogleMapsInterfaceReference.GooglePlacesWcfResponse SendGooglePlacesApiRequest(MedicalLocator.WebFront.GoogleMapsInterfaceReference.GooglePlacesApiRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGoogleMapsInterfaceService/Test", ReplyAction="http://tempuri.org/IGoogleMapsInterfaceService/TestResponse")]
        string Test(string str);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGoogleMapsInterfaceServiceChannel : MedicalLocator.WebFront.GoogleMapsInterfaceReference.IGoogleMapsInterfaceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GoogleMapsInterfaceServiceClient : System.ServiceModel.ClientBase<MedicalLocator.WebFront.GoogleMapsInterfaceReference.IGoogleMapsInterfaceService>, MedicalLocator.WebFront.GoogleMapsInterfaceReference.IGoogleMapsInterfaceService {
        
        public GoogleMapsInterfaceServiceClient() {
        }
        
        public GoogleMapsInterfaceServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GoogleMapsInterfaceServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GoogleMapsInterfaceServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GoogleMapsInterfaceServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MedicalLocator.WebFront.GoogleMapsInterfaceReference.GooglePlacesWcfResponse SendGooglePlacesApiRequest(MedicalLocator.WebFront.GoogleMapsInterfaceReference.GooglePlacesApiRequest request) {
            return base.Channel.SendGooglePlacesApiRequest(request);
        }
        
        public string Test(string str) {
            return base.Channel.Test(str);
        }
    }
}
