﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsumerApplication.refRatesWeb {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Role", Namespace="http://schemas.datacontract.org/2004/07/WebLibrary.Entities")]
    [System.SerializableAttribute()]
    public partial class Role : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsumerApplication.refRatesWeb.Employee[] EmployeesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsumerApplication.refRatesWeb.Rate RateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RateIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RoleIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoleNameField;
        
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
        public ConsumerApplication.refRatesWeb.Employee[] Employees {
            get {
                return this.EmployeesField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeesField, value) != true)) {
                    this.EmployeesField = value;
                    this.RaisePropertyChanged("Employees");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsumerApplication.refRatesWeb.Rate Rate {
            get {
                return this.RateField;
            }
            set {
                if ((object.ReferenceEquals(this.RateField, value) != true)) {
                    this.RateField = value;
                    this.RaisePropertyChanged("Rate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RateID {
            get {
                return this.RateIDField;
            }
            set {
                if ((this.RateIDField.Equals(value) != true)) {
                    this.RateIDField = value;
                    this.RaisePropertyChanged("RateID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RoleID {
            get {
                return this.RoleIDField;
            }
            set {
                if ((this.RoleIDField.Equals(value) != true)) {
                    this.RoleIDField = value;
                    this.RaisePropertyChanged("RoleID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RoleName {
            get {
                return this.RoleNameField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleNameField, value) != true)) {
                    this.RoleNameField = value;
                    this.RaisePropertyChanged("RoleName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Rate", Namespace="http://schemas.datacontract.org/2004/07/WebLibrary.Entities")]
    [System.SerializableAttribute()]
    public partial class Rate : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RateDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RateIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsumerApplication.refRatesWeb.Role[] RolesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal ValueField;
        
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
        public string RateDescription {
            get {
                return this.RateDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.RateDescriptionField, value) != true)) {
                    this.RateDescriptionField = value;
                    this.RaisePropertyChanged("RateDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RateID {
            get {
                return this.RateIDField;
            }
            set {
                if ((this.RateIDField.Equals(value) != true)) {
                    this.RateIDField = value;
                    this.RaisePropertyChanged("RateID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsumerApplication.refRatesWeb.Role[] Roles {
            get {
                return this.RolesField;
            }
            set {
                if ((object.ReferenceEquals(this.RolesField, value) != true)) {
                    this.RolesField = value;
                    this.RaisePropertyChanged("Roles");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/WebLibrary.Entities")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EmployeeIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmployeeNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmployeeNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmployeeSurnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsumerApplication.refRatesWeb.Role RoleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RoleIDField;
        
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
        public int EmployeeID {
            get {
                return this.EmployeeIDField;
            }
            set {
                if ((this.EmployeeIDField.Equals(value) != true)) {
                    this.EmployeeIDField = value;
                    this.RaisePropertyChanged("EmployeeID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmployeeName {
            get {
                return this.EmployeeNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeeNameField, value) != true)) {
                    this.EmployeeNameField = value;
                    this.RaisePropertyChanged("EmployeeName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmployeeNumber {
            get {
                return this.EmployeeNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeeNumberField, value) != true)) {
                    this.EmployeeNumberField = value;
                    this.RaisePropertyChanged("EmployeeNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmployeeSurname {
            get {
                return this.EmployeeSurnameField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeeSurnameField, value) != true)) {
                    this.EmployeeSurnameField = value;
                    this.RaisePropertyChanged("EmployeeSurname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsumerApplication.refRatesWeb.Role Role {
            get {
                return this.RoleField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleField, value) != true)) {
                    this.RoleField = value;
                    this.RaisePropertyChanged("Role");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RoleID {
            get {
                return this.RoleIDField;
            }
            set {
                if ((this.RoleIDField.Equals(value) != true)) {
                    this.RoleIDField = value;
                    this.RaisePropertyChanged("RoleID");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://mycompany.com/rates", ConfigurationName="refRatesWeb.IRateSys")]
    public interface IRateSys {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/Roles", ReplyAction="http://mycompany.com/rates/IRateSys/RolesResponse")]
        ConsumerApplication.refRatesWeb.Role[] Roles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/Roles", ReplyAction="http://mycompany.com/rates/IRateSys/RolesResponse")]
        System.Threading.Tasks.Task<ConsumerApplication.refRatesWeb.Role[]> RolesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/Rates", ReplyAction="http://mycompany.com/rates/IRateSys/RatesResponse")]
        ConsumerApplication.refRatesWeb.Rate[] Rates();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/Rates", ReplyAction="http://mycompany.com/rates/IRateSys/RatesResponse")]
        System.Threading.Tasks.Task<ConsumerApplication.refRatesWeb.Rate[]> RatesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/Employees", ReplyAction="http://mycompany.com/rates/IRateSys/EmployeesResponse")]
        ConsumerApplication.refRatesWeb.Employee[] Employees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/Employees", ReplyAction="http://mycompany.com/rates/IRateSys/EmployeesResponse")]
        System.Threading.Tasks.Task<ConsumerApplication.refRatesWeb.Employee[]> EmployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/AddEmployee", ReplyAction="http://mycompany.com/rates/IRateSys/AddEmployeeResponse")]
        bool AddEmployee(ConsumerApplication.refRatesWeb.Employee emp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/AddEmployee", ReplyAction="http://mycompany.com/rates/IRateSys/AddEmployeeResponse")]
        System.Threading.Tasks.Task<bool> AddEmployeeAsync(ConsumerApplication.refRatesWeb.Employee emp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/AddRate", ReplyAction="http://mycompany.com/rates/IRateSys/AddRateResponse")]
        bool AddRate(ConsumerApplication.refRatesWeb.Rate rate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/AddRate", ReplyAction="http://mycompany.com/rates/IRateSys/AddRateResponse")]
        System.Threading.Tasks.Task<bool> AddRateAsync(ConsumerApplication.refRatesWeb.Rate rate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/AddRole", ReplyAction="http://mycompany.com/rates/IRateSys/AddRoleResponse")]
        bool AddRole(ConsumerApplication.refRatesWeb.Role role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/AddRole", ReplyAction="http://mycompany.com/rates/IRateSys/AddRoleResponse")]
        System.Threading.Tasks.Task<bool> AddRoleAsync(ConsumerApplication.refRatesWeb.Role role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/UpdateEmployee", ReplyAction="http://mycompany.com/rates/IRateSys/UpdateEmployeeResponse")]
        bool UpdateEmployee(ConsumerApplication.refRatesWeb.Employee emp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/UpdateEmployee", ReplyAction="http://mycompany.com/rates/IRateSys/UpdateEmployeeResponse")]
        System.Threading.Tasks.Task<bool> UpdateEmployeeAsync(ConsumerApplication.refRatesWeb.Employee emp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/UpdateRate", ReplyAction="http://mycompany.com/rates/IRateSys/UpdateRateResponse")]
        bool UpdateRate(ConsumerApplication.refRatesWeb.Rate rate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/UpdateRate", ReplyAction="http://mycompany.com/rates/IRateSys/UpdateRateResponse")]
        System.Threading.Tasks.Task<bool> UpdateRateAsync(ConsumerApplication.refRatesWeb.Rate rate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/UpdateRole", ReplyAction="http://mycompany.com/rates/IRateSys/UpdateRoleResponse")]
        bool UpdateRole(ConsumerApplication.refRatesWeb.Role role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://mycompany.com/rates/IRateSys/UpdateRole", ReplyAction="http://mycompany.com/rates/IRateSys/UpdateRoleResponse")]
        System.Threading.Tasks.Task<bool> UpdateRoleAsync(ConsumerApplication.refRatesWeb.Role role);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRateSysChannel : ConsumerApplication.refRatesWeb.IRateSys, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RateSysClient : System.ServiceModel.ClientBase<ConsumerApplication.refRatesWeb.IRateSys>, ConsumerApplication.refRatesWeb.IRateSys {
        
        public RateSysClient() {
        }
        
        public RateSysClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RateSysClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RateSysClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RateSysClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ConsumerApplication.refRatesWeb.Role[] Roles() {
            return base.Channel.Roles();
        }
        
        public System.Threading.Tasks.Task<ConsumerApplication.refRatesWeb.Role[]> RolesAsync() {
            return base.Channel.RolesAsync();
        }
        
        public ConsumerApplication.refRatesWeb.Rate[] Rates() {
            return base.Channel.Rates();
        }
        
        public System.Threading.Tasks.Task<ConsumerApplication.refRatesWeb.Rate[]> RatesAsync() {
            return base.Channel.RatesAsync();
        }
        
        public ConsumerApplication.refRatesWeb.Employee[] Employees() {
            return base.Channel.Employees();
        }
        
        public System.Threading.Tasks.Task<ConsumerApplication.refRatesWeb.Employee[]> EmployeesAsync() {
            return base.Channel.EmployeesAsync();
        }
        
        public bool AddEmployee(ConsumerApplication.refRatesWeb.Employee emp) {
            return base.Channel.AddEmployee(emp);
        }
        
        public System.Threading.Tasks.Task<bool> AddEmployeeAsync(ConsumerApplication.refRatesWeb.Employee emp) {
            return base.Channel.AddEmployeeAsync(emp);
        }
        
        public bool AddRate(ConsumerApplication.refRatesWeb.Rate rate) {
            return base.Channel.AddRate(rate);
        }
        
        public System.Threading.Tasks.Task<bool> AddRateAsync(ConsumerApplication.refRatesWeb.Rate rate) {
            return base.Channel.AddRateAsync(rate);
        }
        
        public bool AddRole(ConsumerApplication.refRatesWeb.Role role) {
            return base.Channel.AddRole(role);
        }
        
        public System.Threading.Tasks.Task<bool> AddRoleAsync(ConsumerApplication.refRatesWeb.Role role) {
            return base.Channel.AddRoleAsync(role);
        }
        
        public bool UpdateEmployee(ConsumerApplication.refRatesWeb.Employee emp) {
            return base.Channel.UpdateEmployee(emp);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateEmployeeAsync(ConsumerApplication.refRatesWeb.Employee emp) {
            return base.Channel.UpdateEmployeeAsync(emp);
        }
        
        public bool UpdateRate(ConsumerApplication.refRatesWeb.Rate rate) {
            return base.Channel.UpdateRate(rate);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateRateAsync(ConsumerApplication.refRatesWeb.Rate rate) {
            return base.Channel.UpdateRateAsync(rate);
        }
        
        public bool UpdateRole(ConsumerApplication.refRatesWeb.Role role) {
            return base.Channel.UpdateRole(role);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateRoleAsync(ConsumerApplication.refRatesWeb.Role role) {
            return base.Channel.UpdateRoleAsync(role);
        }
    }
}
