﻿using System.Threading.Tasks;
using PrismTodo.Service;

namespace PrismTodo.Usecases
{
    public interface IManageUserGroup
    {
        bool SelectedUserGroup { get; }
        
        UserGroup UserGroup { get; }

        Task SaveUserGroup(UserGroup userGroup);
    }
}