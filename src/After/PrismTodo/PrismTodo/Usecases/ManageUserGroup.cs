using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prism.AppModel;
using PrismTodo.Service;

namespace PrismTodo.Usecases
{
    public class ManageUserGroup : IManageUserGroup
    {
        private readonly IApplicationStore _applicationStore;

        public ManageUserGroup(IApplicationStore applicationStore)
        {
            _applicationStore = applicationStore;
        }

        public bool SelectedUserGroup()
        {
            return _applicationStore.Properties.ContainsKey(nameof(UserGroup));
        }

        public UserGroup GetUserGroup()
        {
            var value = _applicationStore.Properties[nameof(UserGroup)];
            return (UserGroup) Enum.ToObject(typeof(UserGroup), value);
        }

        public Task SaveUserGroup(UserGroup userGroup)
        {
            _applicationStore.Properties[nameof(UserGroup)] = userGroup.ToString();
            return _applicationStore.SavePropertiesAsync();
        }
    }
}
