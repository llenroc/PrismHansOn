using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PrismTodo.Service;

namespace PrismTodo.Repositories
{
    public interface ITodoRepository
    {
        ReadOnlyObservableCollection<TodoItem> TodoItems { get; }
        Task LoadAsync();
    }
}