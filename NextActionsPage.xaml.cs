using System.Collections.ObjectModel;
using GTDApp.Models;

namespace gtdmaui;

public partial class NextActionsPage : ContentPage
{
    public ObservableCollection<Item> NextActionItems { get; set; }

    public NextActionsPage()
    {
        InitializeComponent();
        NextActionItems = new ObservableCollection<Item>();
        NextActionsListView.ItemsSource = NextActionItems;
    }

    private async void OnAddNextActionClicked(object sender, EventArgs e)
    {
        string title = await DisplayPromptAsync("New Next Action", "Enter Action Title");
        if (!string.IsNullOrWhiteSpace(title))
        {
            var newItem = new Item
            {
                Title = title,
                State = ProcessingState.NextAction
            };
            NextActionItems.Add(newItem);
        }
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Item selectedItem)
        {
            await Navigation.PushAsync(new ItemEditPage(selectedItem));
        }
    }
}