using System.Threading.Tasks;
using PrismTodo.Service;

namespace PrismTodo.Usecases
{
    public interface IManageUserGroup
    {
        bool SelectedUserGroup();

        Task SaveUserGroup(UserGroup userGroup);
    }
}