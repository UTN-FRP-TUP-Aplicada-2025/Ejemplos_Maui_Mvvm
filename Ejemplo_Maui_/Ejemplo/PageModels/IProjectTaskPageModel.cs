using CommunityToolkit.Mvvm.Input;
using Ejemplo.Models;

namespace Ejemplo.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}