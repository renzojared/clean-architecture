﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorthWind.Sales.Validators.Entities.Resources {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CreateOrderMessages {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CreateOrderMessages() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("NorthWind.Sales.Validators.Entities.Resources.CreateOrderMessages", typeof(CreateOrderMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string ProductIdGreaterThanZero {
            get {
                return ResourceManager.GetString("ProductIdGreaterThanZero", resourceCulture);
            }
        }
        
        internal static string QuantityGreaterThanZero {
            get {
                return ResourceManager.GetString("QuantityGreaterThanZero", resourceCulture);
            }
        }
        
        internal static string UnitPriceGreaterThanZero {
            get {
                return ResourceManager.GetString("UnitPriceGreaterThanZero", resourceCulture);
            }
        }
        
        internal static string CustomerIdRequiredLength {
            get {
                return ResourceManager.GetString("CustomerIdRequiredLength", resourceCulture);
            }
        }
        
        internal static string ShipAddressRequired {
            get {
                return ResourceManager.GetString("ShipAddressRequired", resourceCulture);
            }
        }
        
        internal static string CustomerIdRequired {
            get {
                return ResourceManager.GetString("CustomerIdRequired", resourceCulture);
            }
        }
        
        internal static string ShipAddressMaximumLength {
            get {
                return ResourceManager.GetString("ShipAddressMaximumLength", resourceCulture);
            }
        }
        
        internal static string ShipCityRequired {
            get {
                return ResourceManager.GetString("ShipCityRequired", resourceCulture);
            }
        }
        
        internal static string ShipCityMinimumLength {
            get {
                return ResourceManager.GetString("ShipCityMinimumLength", resourceCulture);
            }
        }
        
        internal static string ShipCityMaximumLength {
            get {
                return ResourceManager.GetString("ShipCityMaximumLength", resourceCulture);
            }
        }
        
        internal static string ShipCountryRequired {
            get {
                return ResourceManager.GetString("ShipCountryRequired", resourceCulture);
            }
        }
        
        internal static string ShipCountryMinimumLength {
            get {
                return ResourceManager.GetString("ShipCountryMinimumLength", resourceCulture);
            }
        }
        
        internal static string ShipCountryMaximumLength {
            get {
                return ResourceManager.GetString("ShipCountryMaximumLength", resourceCulture);
            }
        }
        
        internal static string ShipPostalCodeMaximumLength {
            get {
                return ResourceManager.GetString("ShipPostalCodeMaximumLength", resourceCulture);
            }
        }
        
        internal static string OrderDetailsRequired {
            get {
                return ResourceManager.GetString("OrderDetailsRequired", resourceCulture);
            }
        }
        
        internal static string OrderDetailsNotEmpty {
            get {
                return ResourceManager.GetString("OrderDetailsNotEmpty", resourceCulture);
            }
        }
    }
}
