﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.17929
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionInmobiliaria.SOAPServices.Tests.UsuarioWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Usuario", Namespace="http://schemas.datacontract.org/2004/07/GestionInmobiliaria.BusinessEntity")]
    [System.SerializableAttribute()]
    public partial class Usuario : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.Rol RolField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool adminField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string claveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string loginField;
        
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
        public GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.Rol Rol {
            get {
                return this.RolField;
            }
            set {
                if ((object.ReferenceEquals(this.RolField, value) != true)) {
                    this.RolField = value;
                    this.RaisePropertyChanged("Rol");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool admin {
            get {
                return this.adminField;
            }
            set {
                if ((this.adminField.Equals(value) != true)) {
                    this.adminField = value;
                    this.RaisePropertyChanged("admin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string clave {
            get {
                return this.claveField;
            }
            set {
                if ((object.ReferenceEquals(this.claveField, value) != true)) {
                    this.claveField = value;
                    this.RaisePropertyChanged("clave");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string login {
            get {
                return this.loginField;
            }
            set {
                if ((object.ReferenceEquals(this.loginField, value) != true)) {
                    this.loginField = value;
                    this.RaisePropertyChanged("login");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Rol", Namespace="http://schemas.datacontract.org/2004/07/GestionInmobiliaria.BusinessEntity")]
    [System.SerializableAttribute()]
    public partial class Rol : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool aud_anuladoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int estadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
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
        public bool aud_anulado {
            get {
                return this.aud_anuladoField;
            }
            set {
                if ((this.aud_anuladoField.Equals(value) != true)) {
                    this.aud_anuladoField = value;
                    this.RaisePropertyChanged("aud_anulado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string descripcion {
            get {
                return this.descripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.descripcionField, value) != true)) {
                    this.descripcionField = value;
                    this.RaisePropertyChanged("descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int estado {
            get {
                return this.estadoField;
            }
            set {
                if ((this.estadoField.Equals(value) != true)) {
                    this.estadoField = value;
                    this.RaisePropertyChanged("estado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UsuarioWS.IUsuarioService")]
    public interface IUsuarioService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/Listar", ReplyAction="http://tempuri.org/IUsuarioService/ListarResponse")]
        GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.Usuario[] Listar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/Obtener", ReplyAction="http://tempuri.org/IUsuarioService/ObtenerResponse")]
        GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.Usuario Obtener(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/Agregar", ReplyAction="http://tempuri.org/IUsuarioService/AgregarResponse")]
        int Agregar(GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/Modificar", ReplyAction="http://tempuri.org/IUsuarioService/ModificarResponse")]
        bool Modificar(GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/Eliminar", ReplyAction="http://tempuri.org/IUsuarioService/EliminarResponse")]
        bool Eliminar(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsuarioServiceChannel : GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.IUsuarioService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsuarioServiceClient : System.ServiceModel.ClientBase<GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.IUsuarioService>, GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.IUsuarioService {
        
        public UsuarioServiceClient() {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.Usuario[] Listar() {
            return base.Channel.Listar();
        }
        
        public GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.Usuario Obtener(int id) {
            return base.Channel.Obtener(id);
        }
        
        public int Agregar(GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.Usuario usuario) {
            return base.Channel.Agregar(usuario);
        }
        
        public bool Modificar(GestionInmobiliaria.SOAPServices.Tests.UsuarioWS.Usuario usuario) {
            return base.Channel.Modificar(usuario);
        }
        
        public bool Eliminar(int id) {
            return base.Channel.Eliminar(id);
        }
    }
}
