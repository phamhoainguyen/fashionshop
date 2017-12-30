using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL.bl_Utilities
{
    public class DynamicProxy : DynamicObject, INotifyPropertyChanged
    {
        #region protected methods 
        protected PropertyInfo GetPropertyInfo(string propertyName)
        {
            return ProxiedObject.GetType().GetProperties().First
            (propertyInfo => propertyInfo.Name == propertyName);
        }

        protected virtual void SetMember(string propertyName, object value)
        {
            GetPropertyInfo(propertyName).SetValue(ProxiedObject, value, null);
            RaisePropertyChanged(propertyName);
        }

        protected virtual object GetMember(string propertyName)
        {
            return GetPropertyInfo(propertyName).GetValue(ProxiedObject, null);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(ProxiedObject, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }
        #endregion

        #region constructor 
        public DynamicProxy() { }
        public DynamicProxy(object proxiedObject)
        {
            ProxiedObject = proxiedObject;
        }
        #endregion

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type == typeof(INotifyPropertyChanged))
            {
                result = this;
                return true;
            }

            if (ProxiedObject != null && binder.Type.IsAssignableFrom(ProxiedObject.GetType()))
            {
                result = ProxiedObject;
                return true;
            }
            else
                return base.TryConvert(binder, out result);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = GetMember(binder.Name);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            SetMember(binder.Name, value);
            return true;
        }

        #region public properties 
        public object ProxiedObject { get; set; }
        #endregion

        #region INotifyPropertyChanged Member 
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }

}
