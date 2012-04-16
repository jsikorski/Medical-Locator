﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace MedicalLocator.Mobile.DatabaseConnectionReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoginResponse", Namespace="http://schemas.datacontract.org/2004/07/DatabaseConnectionService.Model")]
    public partial class LoginResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool IsAnonymousField;
        
        private bool IsValidField;
        
        private MedicalLocator.Mobile.DatabaseConnectionReference.MedicalLocatorUser UserField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsAnonymous {
            get {
                return this.IsAnonymousField;
            }
            set {
                if ((this.IsAnonymousField.Equals(value) != true)) {
                    this.IsAnonymousField = value;
                    this.RaisePropertyChanged("IsAnonymous");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsValid {
            get {
                return this.IsValidField;
            }
            set {
                if ((this.IsValidField.Equals(value) != true)) {
                    this.IsValidField = value;
                    this.RaisePropertyChanged("IsValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MedicalLocator.Mobile.DatabaseConnectionReference.MedicalLocatorUser User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="MedicalLocatorUser", Namespace="http://schemas.datacontract.org/2004/07/DatabaseConnectionService.Model")]
    public partial class MedicalLocatorUser : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int IdField;
        
        private MedicalLocator.Mobile.DatabaseConnectionReference.MedicalLocatorUserLastSearch LastSearchField;
        
        private string LoginField;
        
        private string PasswordField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
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
        public MedicalLocator.Mobile.DatabaseConnectionReference.MedicalLocatorUserLastSearch LastSearch {
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
    public partial class MedicalLocatorUserLastSearch : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string AddressField;
        
        private MedicalLocator.Mobile.DatabaseConnectionReference.CenterType CenterTypeField;
        
        private bool DentistField;
        
        private bool DoctorField;
        
        private double LatitudeField;
        
        private double LongitudeField;
        
        private int RangeField;
        
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
        public MedicalLocator.Mobile.DatabaseConnectionReference.CenterType CenterType {
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
        public bool Dentist {
            get {
                return this.DentistField;
            }
            set {
                if ((this.DentistField.Equals(value) != true)) {
                    this.DentistField = value;
                    this.RaisePropertyChanged("Dentist");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Doctor {
            get {
                return this.DoctorField;
            }
            set {
                if ((this.DoctorField.Equals(value) != true)) {
                    this.DoctorField = value;
                    this.RaisePropertyChanged("Doctor");
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CenterType", Namespace="http://schemas.datacontract.org/2004/07/Common.Enums")]
    public enum CenterType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MyLocation = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Address = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Coordinates = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RegisterStatus", Namespace="http://schemas.datacontract.org/2004/07/DatabaseConnectionService.Model")]
    public partial class RegisterStatus : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool IsSuccessfulField;
        
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
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IDatabaseConnectionService/Login", ReplyAction="http://tempuri.org/IDatabaseConnectionService/LoginResponse")]
        System.IAsyncResult BeginLogin(string login, string password, System.AsyncCallback callback, object asyncState);
        
        MedicalLocator.Mobile.DatabaseConnectionReference.LoginResponse EndLogin(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IDatabaseConnectionService/Register", ReplyAction="http://tempuri.org/IDatabaseConnectionService/RegisterResponse")]
        System.IAsyncResult BeginRegister(string login, string password, System.AsyncCallback callback, object asyncState);
        
        MedicalLocator.Mobile.DatabaseConnectionReference.RegisterStatus EndRegister(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IDatabaseConnectionService/SaveUserSettings", ReplyAction="http://tempuri.org/IDatabaseConnectionService/SaveUserSettingsResponse")]
        System.IAsyncResult BeginSaveUserSettings(string login, MedicalLocator.Mobile.DatabaseConnectionReference.MedicalLocatorUserLastSearch lastSearch, System.AsyncCallback callback, object asyncState);
        
        bool EndSaveUserSettings(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDatabaseConnectionServiceChannel : MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public LoginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public MedicalLocator.Mobile.DatabaseConnectionReference.LoginResponse Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((MedicalLocator.Mobile.DatabaseConnectionReference.LoginResponse)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegisterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public RegisterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public MedicalLocator.Mobile.DatabaseConnectionReference.RegisterStatus Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((MedicalLocator.Mobile.DatabaseConnectionReference.RegisterStatus)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SaveUserSettingsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SaveUserSettingsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DatabaseConnectionServiceClient : System.ServiceModel.ClientBase<MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService>, MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService {
        
        private BeginOperationDelegate onBeginLoginDelegate;
        
        private EndOperationDelegate onEndLoginDelegate;
        
        private System.Threading.SendOrPostCallback onLoginCompletedDelegate;
        
        private BeginOperationDelegate onBeginRegisterDelegate;
        
        private EndOperationDelegate onEndRegisterDelegate;
        
        private System.Threading.SendOrPostCallback onRegisterCompletedDelegate;
        
        private BeginOperationDelegate onBeginSaveUserSettingsDelegate;
        
        private EndOperationDelegate onEndSaveUserSettingsDelegate;
        
        private System.Threading.SendOrPostCallback onSaveUserSettingsCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
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
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<LoginCompletedEventArgs> LoginCompleted;
        
        public event System.EventHandler<RegisterCompletedEventArgs> RegisterCompleted;
        
        public event System.EventHandler<SaveUserSettingsCompletedEventArgs> SaveUserSettingsCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService.BeginLogin(string login, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginLogin(login, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MedicalLocator.Mobile.DatabaseConnectionReference.LoginResponse MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService.EndLogin(System.IAsyncResult result) {
            return base.Channel.EndLogin(result);
        }
        
        private System.IAsyncResult OnBeginLogin(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string login = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return ((MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService)(this)).BeginLogin(login, password, callback, asyncState);
        }
        
        private object[] OnEndLogin(System.IAsyncResult result) {
            MedicalLocator.Mobile.DatabaseConnectionReference.LoginResponse retVal = ((MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService)(this)).EndLogin(result);
            return new object[] {
                    retVal};
        }
        
        private void OnLoginCompleted(object state) {
            if ((this.LoginCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.LoginCompleted(this, new LoginCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void LoginAsync(string login, string password) {
            this.LoginAsync(login, password, null);
        }
        
        public void LoginAsync(string login, string password, object userState) {
            if ((this.onBeginLoginDelegate == null)) {
                this.onBeginLoginDelegate = new BeginOperationDelegate(this.OnBeginLogin);
            }
            if ((this.onEndLoginDelegate == null)) {
                this.onEndLoginDelegate = new EndOperationDelegate(this.OnEndLogin);
            }
            if ((this.onLoginCompletedDelegate == null)) {
                this.onLoginCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnLoginCompleted);
            }
            base.InvokeAsync(this.onBeginLoginDelegate, new object[] {
                        login,
                        password}, this.onEndLoginDelegate, this.onLoginCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService.BeginRegister(string login, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginRegister(login, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MedicalLocator.Mobile.DatabaseConnectionReference.RegisterStatus MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService.EndRegister(System.IAsyncResult result) {
            return base.Channel.EndRegister(result);
        }
        
        private System.IAsyncResult OnBeginRegister(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string login = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return ((MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService)(this)).BeginRegister(login, password, callback, asyncState);
        }
        
        private object[] OnEndRegister(System.IAsyncResult result) {
            MedicalLocator.Mobile.DatabaseConnectionReference.RegisterStatus retVal = ((MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService)(this)).EndRegister(result);
            return new object[] {
                    retVal};
        }
        
        private void OnRegisterCompleted(object state) {
            if ((this.RegisterCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.RegisterCompleted(this, new RegisterCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void RegisterAsync(string login, string password) {
            this.RegisterAsync(login, password, null);
        }
        
        public void RegisterAsync(string login, string password, object userState) {
            if ((this.onBeginRegisterDelegate == null)) {
                this.onBeginRegisterDelegate = new BeginOperationDelegate(this.OnBeginRegister);
            }
            if ((this.onEndRegisterDelegate == null)) {
                this.onEndRegisterDelegate = new EndOperationDelegate(this.OnEndRegister);
            }
            if ((this.onRegisterCompletedDelegate == null)) {
                this.onRegisterCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRegisterCompleted);
            }
            base.InvokeAsync(this.onBeginRegisterDelegate, new object[] {
                        login,
                        password}, this.onEndRegisterDelegate, this.onRegisterCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService.BeginSaveUserSettings(string login, MedicalLocator.Mobile.DatabaseConnectionReference.MedicalLocatorUserLastSearch lastSearch, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSaveUserSettings(login, lastSearch, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService.EndSaveUserSettings(System.IAsyncResult result) {
            return base.Channel.EndSaveUserSettings(result);
        }
        
        private System.IAsyncResult OnBeginSaveUserSettings(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string login = ((string)(inValues[0]));
            MedicalLocator.Mobile.DatabaseConnectionReference.MedicalLocatorUserLastSearch lastSearch = ((MedicalLocator.Mobile.DatabaseConnectionReference.MedicalLocatorUserLastSearch)(inValues[1]));
            return ((MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService)(this)).BeginSaveUserSettings(login, lastSearch, callback, asyncState);
        }
        
        private object[] OnEndSaveUserSettings(System.IAsyncResult result) {
            bool retVal = ((MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService)(this)).EndSaveUserSettings(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSaveUserSettingsCompleted(object state) {
            if ((this.SaveUserSettingsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SaveUserSettingsCompleted(this, new SaveUserSettingsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SaveUserSettingsAsync(string login, MedicalLocator.Mobile.DatabaseConnectionReference.MedicalLocatorUserLastSearch lastSearch) {
            this.SaveUserSettingsAsync(login, lastSearch, null);
        }
        
        public void SaveUserSettingsAsync(string login, MedicalLocator.Mobile.DatabaseConnectionReference.MedicalLocatorUserLastSearch lastSearch, object userState) {
            if ((this.onBeginSaveUserSettingsDelegate == null)) {
                this.onBeginSaveUserSettingsDelegate = new BeginOperationDelegate(this.OnBeginSaveUserSettings);
            }
            if ((this.onEndSaveUserSettingsDelegate == null)) {
                this.onEndSaveUserSettingsDelegate = new EndOperationDelegate(this.OnEndSaveUserSettings);
            }
            if ((this.onSaveUserSettingsCompletedDelegate == null)) {
                this.onSaveUserSettingsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSaveUserSettingsCompleted);
            }
            base.InvokeAsync(this.onBeginSaveUserSettingsDelegate, new object[] {
                        login,
                        lastSearch}, this.onEndSaveUserSettingsDelegate, this.onSaveUserSettingsCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService CreateChannel() {
            return new DatabaseConnectionServiceClientChannel(this);
        }
        
        private class DatabaseConnectionServiceClientChannel : ChannelBase<MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService>, MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService {
            
            public DatabaseConnectionServiceClientChannel(System.ServiceModel.ClientBase<MedicalLocator.Mobile.DatabaseConnectionReference.IDatabaseConnectionService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginLogin(string login, string password, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = login;
                _args[1] = password;
                System.IAsyncResult _result = base.BeginInvoke("Login", _args, callback, asyncState);
                return _result;
            }
            
            public MedicalLocator.Mobile.DatabaseConnectionReference.LoginResponse EndLogin(System.IAsyncResult result) {
                object[] _args = new object[0];
                MedicalLocator.Mobile.DatabaseConnectionReference.LoginResponse _result = ((MedicalLocator.Mobile.DatabaseConnectionReference.LoginResponse)(base.EndInvoke("Login", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginRegister(string login, string password, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = login;
                _args[1] = password;
                System.IAsyncResult _result = base.BeginInvoke("Register", _args, callback, asyncState);
                return _result;
            }
            
            public MedicalLocator.Mobile.DatabaseConnectionReference.RegisterStatus EndRegister(System.IAsyncResult result) {
                object[] _args = new object[0];
                MedicalLocator.Mobile.DatabaseConnectionReference.RegisterStatus _result = ((MedicalLocator.Mobile.DatabaseConnectionReference.RegisterStatus)(base.EndInvoke("Register", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginSaveUserSettings(string login, MedicalLocator.Mobile.DatabaseConnectionReference.MedicalLocatorUserLastSearch lastSearch, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = login;
                _args[1] = lastSearch;
                System.IAsyncResult _result = base.BeginInvoke("SaveUserSettings", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndSaveUserSettings(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("SaveUserSettings", _args, result)));
                return _result;
            }
        }
    }
}
