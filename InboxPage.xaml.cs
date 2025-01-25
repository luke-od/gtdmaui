using System.Collections.ObjectModel;
using GTDApp.Models;

namespace gtdmaui;

public partial class InboxPage : ContentPage
{
    public ObservableCollection<Item> InboxItems { get; set; }

    public InboxPage()
    {
        InitializeComponent();
        InboxItems = new ObservableCollection<Item>();
        InboxListView.ItemsSource = InboxItems;
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Item selectedItem)
        {
            await Navigation.PushAsync(new ItemEditPage(selectedItem));
        }
    }
}