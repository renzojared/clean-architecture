﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorthWind.Sales.Backend.UseCases.Resources {
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
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("NorthWind.Sales.Backend.UseCases.Resources.CreateOrderMessages", typeof(CreateOrderMessages).Assembly);
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
        
        internal static string CustomerIdNotFoundError {
            get {
                return ResourceManager.GetString("CustomerIdNotFoundError", resourceCulture);
            }
        }
        
        internal static string CustomerWithBalanceErrorTemplate {
            get {
                return ResourceManager.GetString("CustomerWithBalanceErrorTemplate", resourceCulture);
            }
        }
        
        internal static string ProductIdNotFoundErrorTemplate {
            get {
                return ResourceManager.GetString("ProductIdNotFoundErrorTemplate", resourceCulture);
            }
        }
        
        internal static string UnitsInStockLessThanQuantityErrorTemplate {
            get {
                return ResourceManager.GetString("UnitsInStockLessThanQuantityErrorTemplate", resourceCulture);
            }
        }
    }
}