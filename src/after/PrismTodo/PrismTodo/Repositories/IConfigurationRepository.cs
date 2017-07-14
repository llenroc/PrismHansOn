using System.Threading.Tasks;
using PrismTodo.Service;

namespace PrismTodo.Repositories
{
    public interface IConfigurationRepository
    {
        bool SelectedUserGroup { get; }
        UserGroup UserGroup { get; set; }

        Task SaveAsync();
    }
}