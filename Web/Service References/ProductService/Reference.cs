﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.ProductService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/AService.DAL.Model")]
    [System.SerializableAttribute()]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int InventoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal UnitPriceField;
        
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
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Inventory {
            get {
                return this.InventoryField;
            }
            set {
                if ((this.InventoryField.Equals(value) != true)) {
                    this.InventoryField = value;
                    this.RaisePropertyChanged("Inventory");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductName {
            get {
                return this.ProductNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductNameField, value) != true)) {
                    this.ProductNameField = value;
                    this.RaisePropertyChanged("ProductName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal UnitPrice {
            get {
                return this.UnitPriceField;
            }
            set {
                if ((this.UnitPriceField.Equals(value) != true)) {
                    this.UnitPriceField = value;
                    this.RaisePropertyChanged("UnitPrice");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductService.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProductInventory", ReplyAction="http://tempuri.org/IProductService/GetProductInventoryResponse")]
        int GetProductInventory(string productCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProductInventory", ReplyAction="http://tempuri.org/IProductService/GetProductInventoryResponse")]
        System.Threading.Tasks.Task<int> GetProductInventoryAsync(string productCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProducts", ReplyAction="http://tempuri.org/IProductService/GetProductsResponse")]
        Web.ProductService.Product[] GetProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProducts", ReplyAction="http://tempuri.org/IProductService/GetProductsResponse")]
        System.Threading.Tasks.Task<Web.ProductService.Product[]> GetProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/CreateProduct", ReplyAction="http://tempuri.org/IProductService/CreateProductResponse")]
        void CreateProduct(Web.ProductService.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/CreateProduct", ReplyAction="http://tempuri.org/IProductService/CreateProductResponse")]
        System.Threading.Tasks.Task CreateProductAsync(Web.ProductService.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/UpdateProduct", ReplyAction="http://tempuri.org/IProductService/UpdateProductResponse")]
        void UpdateProduct(Web.ProductService.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/UpdateProduct", ReplyAction="http://tempuri.org/IProductService/UpdateProductResponse")]
        System.Threading.Tasks.Task UpdateProductAsync(Web.ProductService.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/DeleteProduct", ReplyAction="http://tempuri.org/IProductService/DeleteProductResponse")]
        void DeleteProduct(string productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/DeleteProduct", ReplyAction="http://tempuri.org/IProductService/DeleteProductResponse")]
        System.Threading.Tasks.Task DeleteProductAsync(string productId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : Web.ProductService.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<Web.ProductService.IProductService>, Web.ProductService.IProductService {
        
        public ProductServiceClient() {
        }
        
        public ProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetProductInventory(string productCode) {
            return base.Channel.GetProductInventory(productCode);
        }
        
        public System.Threading.Tasks.Task<int> GetProductInventoryAsync(string productCode) {
            return base.Channel.GetProductInventoryAsync(productCode);
        }
        
        public Web.ProductService.Product[] GetProducts() {
            return base.Channel.GetProducts();
        }
        
        public System.Threading.Tasks.Task<Web.ProductService.Product[]> GetProductsAsync() {
            return base.Channel.GetProductsAsync();
        }
        
        public void CreateProduct(Web.ProductService.Product product) {
            base.Channel.CreateProduct(product);
        }
        
        public System.Threading.Tasks.Task CreateProductAsync(Web.ProductService.Product product) {
            return base.Channel.CreateProductAsync(product);
        }
        
        public void UpdateProduct(Web.ProductService.Product product) {
            base.Channel.UpdateProduct(product);
        }
        
        public System.Threading.Tasks.Task UpdateProductAsync(Web.ProductService.Product product) {
            return base.Channel.UpdateProductAsync(product);
        }
        
        public void DeleteProduct(string productId) {
            base.Channel.DeleteProduct(productId);
        }
        
        public System.Threading.Tasks.Task DeleteProductAsync(string productId) {
            return base.Channel.DeleteProductAsync(productId);
        }
    }
}
