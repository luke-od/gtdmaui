using System.Collections.ObjectModel;
using GTDApp.Models;

namespace gtdmaui;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Item> InboxItems { get; set; }

    public MainPage()
    {
        InitializeComponent();
        InboxItems = new ObservableCollection<Item>();
        InboxListView.ItemsSource = InboxItems;
    }

    private async void OnAddItemClicked(object sender, EventArgs e)
    {
        string title = await DisplayPromptAsync("New Item", "Enter item title");
        if (!string.IsNullOrWhiteSpace(title))
        {
            var newItem = new Item
            {
                Title = title,
                State = ProcessingState.Inbox
            };
            InboxItems.Add(newItem);
        }
    }
}