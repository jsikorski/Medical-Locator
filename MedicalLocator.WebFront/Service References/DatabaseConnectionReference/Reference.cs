﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicalLocator.WebFront.DatabaseConnectionReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoginResponse", Namespace="http://schemas.datacontract.org/2004/07/DatabaseConnectionService.Model")]
    [System.SerializableAttribute()]
    public partial class LoginResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSuccessfulField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MedicalLocator.WebFront.DatabaseConnectionReference.MedicalLocatorUserData UserDataField;
        
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
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSuccessful {
            get {
                return this.IsSuccessfulField;
            }
            set {
                if ((this.IsSuccessfulField.Equals(value) != true)) {
                    this.IsSuccessfulField = value;
                    this.RaisePropertyChanged("IsSuccessful");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MedicalLocator.WebFront.DatabaseConnectionReference.MedicalLocatorUserData UserData {
            get {
                return this.UserDataField;
            }
            set {
                if ((object.ReferenceEquals(this.UserDataField, value) != true)) {
                    this.UserDataField = value;
                    this.RaisePropertyChanged("UserData");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="MedicalLocatorUserData", Namespace="http://schemas.datacontract.org/2004/07/DatabaseConnectionService.Model")]
    [System.SerializableAttribute()]
    public partial class MedicalLocatorUserData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MedicalLocator.WebFront.DatabaseConnectionReference.MedicalLocatorUserLastSearch LastSearchField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
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
        public System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MedicalLocator.WebFront.DatabaseConnectionReference.MedicalLocatorUserLastSearch LastSearch {
            get {
                return this.LastSearchField;
            }
            set {
                if ((object.ReferenceEquals(this.LastSearchField, value) != true)) {
                    this.LastSearchField = value;
                    this.RaisePropertyChanged("LastSearch");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="MedicalLocatorUserLastSearch", Namespace="http://schemas.datacontract.org/2004/07/DatabaseConnectionService.Model")]
    [System.SerializableAttribute()]
    public partial class MedicalLocatorUserLastSearch : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MedicalLocator.WebFront.DatabaseConnectionReference.CenterTypeDatabaseService CenterTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LatitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LongitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RangeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MedicalLocator.WebFront.DatabaseConnectionReference.MedicalTypeDatabaseService[] SearchedObjectsField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MedicalLocator.WebFront.DatabaseConnectionReference.CenterTypeDatabaseService CenterType {
            get {
                return this.CenterTypeField;
            }
            set {
                if ((this.CenterTypeField.Equals(value) != true)) {
                    this.CenterTypeField = value;
                    this.RaisePropertyChanged("CenterType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Latitude {
            get {
                return this.LatitudeField;
            }
            set {
                if ((this.LatitudeField.Equals(value) != true)) {
                    this.LatitudeField = value;
                    this.RaisePropertyChanged("Latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Longitude {
            get {
                return this.LongitudeField;
            }
            set {
                if ((this.LongitudeField.Equals(value) != true)) {
                    this.LongitudeField = value;
                    this.RaisePropertyChanged("Longitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Range {
            get {
                return this.RangeField;
            }
            set {
                if ((this.RangeField.Equals(value) != true)) {
                    this.RangeField = value;
                    this.RaisePropertyChanged("Range");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MedicalLocator.WebFront.DatabaseConnectionReference.MedicalTypeDatabaseService[] SearchedObjects {
            get {
                return this.SearchedObjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.SearchedObjectsField, value) != true)) {
                    this.SearchedObjectsField = value;
                    this.RaisePropertyChanged("SearchedObjects");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CenterTypeDatabaseService", Namespace="http://schemas.datacontract.org/2004/07/DatabaseConnectionService.Model")]
    public enum CenterTypeDatabaseService : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MyLocation = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Address = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Coordinates = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MedicalTypeDatabaseService", Namespace="http://schemas.datacontract.org/2004/07/DatabaseConnectionService.Model")]
    public enum MedicalTypeDatabaseService : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Doctor = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Dentist = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Health = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Hospital = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Pharmacy = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Physiotherapist = 5,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RegisterResponse", Namespace="http://schemas.datacontract.org/2004/07/DatabaseConnectionService.Model")]
    [System.SerializableAttribute()]
    public partial class RegisterResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSuccessfulField;
        
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
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSuccessful {
            get {
                return this.IsSuccessfulField;
            }
            set {
                if ((this.IsSuccessfulField.Equals(value) != true)) {
                    this.IsSuccessfulField = value;
                    this.RaisePropertyChanged("IsSuccessful");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="SaveSettingsResponse", Namespace="http://schemas.datacontract.org/2004/07/DatabaseConnectionService.Model")]
    [System.SerializableAttribute()]
    public partial class SaveSettingsResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSuccessfulField;
        
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
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSuccessful {
            get {
                return this.IsSuccessfulField;
            }
            set {
                if ((this.IsSuccessfulField.Equals(value) != true)) {
                    this.IsSuccessfulField = value;
                    this.RaisePropertyChanged("IsSuccessful");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DatabaseConnectionReference.IDatabaseConnectionService")]
    public interface IDatabaseConnectionService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseConnectionService/Login", ReplyAction="http://tempuri.org/IDatabaseConnectionService/LoginResponse")]
        MedicalLocator.WebFront.DatabaseConnectionReference.LoginResponse Login([System.ServiceModel.MessageParameterAttribute(Name="login")] string login1, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseConnectionService/Register", ReplyAction="http://tempuri.org/IDatabaseConnectionService/RegisterResponse")]
        MedicalLocator.WebFront.DatabaseConnectionReference.RegisterResponse Register(bool licenceAgree, string login, string password, string passwordRetype);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseConnectionService/SaveSettings", ReplyAction="http://tempuri.org/IDatabaseConnectionService/SaveSettingsResponse")]
        MedicalLocator.WebFront.DatabaseConnectionReference.SaveSettingsResponse SaveSettings(string login, string password, MedicalLocator.WebFront.DatabaseConnectionReference.MedicalLocatorUserLastSearch lastSearch);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDatabaseConnectionServiceChannel : MedicalLocator.WebFront.DatabaseConnectionReference.IDatabaseConnectionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DatabaseConnectionServiceClient : System.ServiceModel.ClientBase<MedicalLocator.WebFront.DatabaseConnectionReference.IDatabaseConnectionService>, MedicalLocator.WebFront.DatabaseConnectionReference.IDatabaseConnectionService {
        
        public DatabaseConnectionServiceClient() {
        }
        
        public DatabaseConnectionServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DatabaseConnectionServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DatabaseConnectionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DatabaseConnectionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MedicalLocator.WebFront.DatabaseConnectionReference.LoginResponse Login(string login1, string password) {
            return base.Channel.Login(login1, password);
        }
        
        public MedicalLocator.WebFront.DatabaseConnectionReference.RegisterResponse Register(bool licenceAgree, string login, string password, string passwordRetype) {
            return base.Channel.Register(licenceAgree, login, password, passwordRetype);
        }
        
        public MedicalLocator.WebFront.DatabaseConnectionReference.SaveSettingsResponse SaveSettings(string login, string password, MedicalLocator.WebFront.DatabaseConnectionReference.MedicalLocatorUserLastSearch lastSearch) {
            return base.Channel.SaveSettings(login, password, lastSearch);
        }
    }
}
