using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Prism.AppModel;
using PrismTodo.Service;

namespace PrismTodo.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly IApplicationStore _applicationStore;

        public ConfigurationRepository(IApplicationStore applicationStore)
        {
            _applicationStore = applicationStore;
        }

        public bool SelectedUserGroup => Contains<UserGroup>();

        public UserGroup UserGroup
        {
            get => GetValue<UserGroup>();
            set => SetValue(value);
        }

        private bool Contains<T>()
        {
            return _applicationStore.Properties.ContainsKey(typeof(T).FullName);
        }
        
        private T GetValue<T>()
        {
            var value = _applicationStore.Properties[typeof(T).FullName];
            var typeInfo = typeof(T).GetTypeInfo();
            if (typeInfo.IsEnum)
            {
                return (T)Enum.ToObject(typeof(T), value);
            }
            else
            {
                return (T)value;
            }
        }

        private void SetValue<T>(T value)
        {
            object storedValue;
            var typeInfo = typeof(T).GetTypeInfo();
            if (typeInfo.IsEnum)
            {
                storedValue = value.ToString();
            }
            else
            {
                storedValue = value;
            }
            _applicationStore.Properties[typeof(T).FullName] = storedValue;
        }

        public Task SaveAsync()
        {
            return _applicationStore.SavePropertiesAsync();
        }
    }
}
