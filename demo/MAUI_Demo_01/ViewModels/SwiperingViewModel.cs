namespace MAUI_Demo_01.ViewModels;

public partial class SwiperingViewModel : BaseViewModel
{
    public IList<IntroducingItemModel> Items { get; set; }

    [ObservableProperty]
    private bool isNextButtonVisible;

    public CarouselView Slider { get; set; }

    public IndicatorView Indicator { get; set; }

    public SwiperingViewModel()
    {
        Items = new ObservableCollection<IntroducingItemModel>();
    }

    protected override Task OnModelAppearing()
    {
        Items.Clear();

        Items.Add(new()
        {
            Title = "Manage your works",
            Description = "Manage your daily tasks",
            ImageUrl = "gettingstarted_01.png",
            Index = 1
        });

        Items.Add(new()
        {
            Title = "Manage your works 2",
            Description = "Manage your daily tasks",
            ImageUrl = "gettingstarted_02.png",
            Index = 2
        });

        Items.Add(new()
        {
            Title = "Manage your works 3",
            Description = "Manage your daily tasks",
            ImageUrl = "gettingstarted_03.png",
            Index = 3
        });

        isNextButtonVisible = false;

        return base.OnModelAppearing();
    }

    [ICommand]
    private void MoveToNextItem()
    {
        if (Slider is null || Indicator is null)
        {
            return;
        }

        if (Slider.CurrentItem is IntroducingItemModel item)
        {
            var index = item.Index;
            if (index < 3)
            {
                Slider.CurrentItem = Items.ElementAt(index);
                Indicator.Position = index;
            }
        }

        IsNextButtonVisible = IsEndOfCollection();
    }

    [ICommand]
    private void SliderItemChange()
    {
        IsNextButtonVisible = IsEndOfCollection();
    }

    [ICommand]
    private void GotoNextPage()
    {
        MessagingCenter.Instance.Send(this, ViewConsts.Event_AppIntroduced);
    }

    private bool IsEndOfCollection()
    {
        return Indicator is not null && Indicator.Position == Items.Count - 1;
    }
}
