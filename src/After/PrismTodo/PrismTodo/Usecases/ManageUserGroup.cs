using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prism.AppModel;
using PrismTodo.Repositories;
using PrismTodo.Service;

namespace PrismTodo.Usecases
{
    public class ManageUserGroup : IManageUserGroup
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ManageUserGroup(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public bool SelectedUserGroup => _configurationRepository.SelectedUserGroup;

        public UserGroup UserGroup => _configurationRepository.UserGroup;

        public Task SaveUserGroup(UserGroup userGroup)
        {
            _configurationRepository.UserGroup = userGroup;
            return _configurationRepository.SaveAsync();
        }
    }
}
