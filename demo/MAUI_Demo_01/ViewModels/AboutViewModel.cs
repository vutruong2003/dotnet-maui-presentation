namespace MAUI_Demo_01.ViewModels;

public partial class AboutViewModel : BaseViewModel
{
    public ObservableCollection<WorkItemModel> Items { get; set; }

    public AboutViewModel()
    {
        Items = new ObservableCollection<WorkItemModel>()
        {
            new WorkItemModel { Name = ".Net Developer" },
            new WorkItemModel { Name = "Java Developer" },
            new WorkItemModel { Name = "Angular" },
            new WorkItemModel { Name = "React" },
            new WorkItemModel { Name = "Azure Cloud" },
            new WorkItemModel { Name = "AWS Cloud" }
        };
    }

    [ICommand]
    private async Task GoToMap()
    {
        await Shell.Current.Navigation.PushModalAsync(new Pages.Map());
    }

    [ICommand]
    private async Task Logout()
    {
        await Shell.Current.GoToAsync($"//{nameof(Pages.Logout)}");
    }
}