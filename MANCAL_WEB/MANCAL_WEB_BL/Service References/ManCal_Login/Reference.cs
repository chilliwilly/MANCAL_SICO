﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18444
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MANCAL_WEB_BL.ManCal_Login {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Usuario", Namespace="http://schemas.datacontract.org/2004/07/MANCAL_WCF")]
    [System.SerializableAttribute()]
    public partial class Usuario : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsrNomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UsrPerfilField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsrPwdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UsrStaField;
        
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
        public string UsrNom {
            get {
                return this.UsrNomField;
            }
            set {
                if ((object.ReferenceEquals(this.UsrNomField, value) != true)) {
                    this.UsrNomField = value;
                    this.RaisePropertyChanged("UsrNom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UsrPerfil {
            get {
                return this.UsrPerfilField;
            }
            set {
                if ((this.UsrPerfilField.Equals(value) != true)) {
                    this.UsrPerfilField = value;
                    this.RaisePropertyChanged("UsrPerfil");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UsrPwd {
            get {
                return this.UsrPwdField;
            }
            set {
                if ((object.ReferenceEquals(this.UsrPwdField, value) != true)) {
                    this.UsrPwdField = value;
                    this.RaisePropertyChanged("UsrPwd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UsrSta {
            get {
                return this.UsrStaField;
            }
            set {
                if ((this.UsrStaField.Equals(value) != true)) {
                    this.UsrStaField = value;
                    this.RaisePropertyChanged("UsrSta");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Menu", Namespace="http://schemas.datacontract.org/2004/07/MANCAL_WCF")]
    [System.SerializableAttribute()]
    public partial class Menu : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MenuGrpField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MenuIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MenuNomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MenuUrlField;
        
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
        public int MenuGrp {
            get {
                return this.MenuGrpField;
            }
            set {
                if ((this.MenuGrpField.Equals(value) != true)) {
                    this.MenuGrpField = value;
                    this.RaisePropertyChanged("MenuGrp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MenuId {
            get {
                return this.MenuIdField;
            }
            set {
                if ((this.MenuIdField.Equals(value) != true)) {
                    this.MenuIdField = value;
                    this.RaisePropertyChanged("MenuId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MenuNom {
            get {
                return this.MenuNomField;
            }
            set {
                if ((object.ReferenceEquals(this.MenuNomField, value) != true)) {
                    this.MenuNomField = value;
                    this.RaisePropertyChanged("MenuNom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MenuUrl {
            get {
                return this.MenuUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.MenuUrlField, value) != true)) {
                    this.MenuUrlField = value;
                    this.RaisePropertyChanged("MenuUrl");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ManCal_Login.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/listaUsuario", ReplyAction="http://tempuri.org/IService/listaUsuarioResponse")]
        MANCAL_WEB_BL.ManCal_Login.Usuario[] listaUsuario();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/listaMenu", ReplyAction="http://tempuri.org/IService/listaMenuResponse")]
        MANCAL_WEB_BL.ManCal_Login.Menu[] listaMenu(int nro_perfil);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/updateUsrPassword", ReplyAction="http://tempuri.org/IService/updateUsrPasswordResponse")]
        void updateUsrPassword(string usr_pwd, string new_pwd);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : MANCAL_WEB_BL.ManCal_Login.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<MANCAL_WEB_BL.ManCal_Login.IService>, MANCAL_WEB_BL.ManCal_Login.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MANCAL_WEB_BL.ManCal_Login.Usuario[] listaUsuario() {
            return base.Channel.listaUsuario();
        }
        
        public MANCAL_WEB_BL.ManCal_Login.Menu[] listaMenu(int nro_perfil) {
            return base.Channel.listaMenu(nro_perfil);
        }
        
        public void updateUsrPassword(string usr_pwd, string new_pwd) {
            base.Channel.updateUsrPassword(usr_pwd, new_pwd);
        }
    }
}