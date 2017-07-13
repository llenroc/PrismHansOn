using System.Collections.ObjectModel;
using PrismTodo.Service;

namespace PrismTodo.Usecases
{
    public interface IManageTodo
    {
        ReadOnlyObservableCollection<TodoItem> TodoItems { get; }
    }
}