using GTDApp.Models;

namespace gtdmaui;

public partial class ItemEditPage : ContentPage
{
    public Item CurrentItem { get; set; }

    public ItemEditPage(Item item = null)
    {
        InitializeComponent();
        CurrentItem = item ?? new Item { State = ProcessingState.Inbox };
        BindingContext = CurrentItem;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // Here you'd typically save to a repository or service
        // For now, we'll just navigate back
        await Navigation.PopAsync();
    }
}