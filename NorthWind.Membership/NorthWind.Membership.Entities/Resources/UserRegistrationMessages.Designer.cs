﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorthWind.Membership.Entities.Resources {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class UserRegistrationMessages {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UserRegistrationMessages() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("NorthWind.Membership.Entities.Resources.UserRegistrationMessages", typeof(UserRegistrationMessages).Assembly);
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
        
        internal static string RequiredFirstNameErrorMessage {
            get {
                return ResourceManager.GetString("RequiredFirstNameErrorMessage", resourceCulture);
            }
        }
        
        internal static string RequiresLastNameErrorMessage {
            get {
                return ResourceManager.GetString("RequiresLastNameErrorMessage", resourceCulture);
            }
        }
        
        internal static string RequiredEmailErrorMessage {
            get {
                return ResourceManager.GetString("RequiredEmailErrorMessage", resourceCulture);
            }
        }
        
        internal static string InvalidEmailErrorMessage {
            get {
                return ResourceManager.GetString("InvalidEmailErrorMessage", resourceCulture);
            }
        }
        
        internal static string RequiredPasswordErrorMessage {
            get {
                return ResourceManager.GetString("RequiredPasswordErrorMessage", resourceCulture);
            }
        }
        
        internal static string PasswordTooShortErrorMessage {
            get {
                return ResourceManager.GetString("PasswordTooShortErrorMessage", resourceCulture);
            }
        }
        
        internal static string PasswordRequiresLowerErrorMessage {
            get {
                return ResourceManager.GetString("PasswordRequiresLowerErrorMessage", resourceCulture);
            }
        }
        
        internal static string PasswordRequiresUpperErrorMessage {
            get {
                return ResourceManager.GetString("PasswordRequiresUpperErrorMessage", resourceCulture);
            }
        }
        
        internal static string PasswordRequiresDigitErrorMessage {
            get {
                return ResourceManager.GetString("PasswordRequiresDigitErrorMessage", resourceCulture);
            }
        }
        
        internal static string PasswordRequiresNonAlphanumericErrorMessage {
            get {
                return ResourceManager.GetString("PasswordRequiresNonAlphanumericErrorMessage", resourceCulture);
            }
        }
    }
}
