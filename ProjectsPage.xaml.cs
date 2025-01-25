using System.Collections.ObjectModel;
using GTDApp.Models;

namespace gtdmaui;

public partial class ProjectsPage : ContentPage
{
    public ObservableCollection<Item> ProjectItems { get; set; }

    public ProjectsPage()
    {
        InitializeComponent();
        ProjectItems = new ObservableCollection<Item>();
        ProjectsListView.ItemsSource = ProjectItems;
    }

    private async void OnAddProjectClicked(object sender, EventArgs e)
    {
        string title = await DisplayPromptAsync("New Project", "Enter Project Title");
        if (!string.IsNullOrWhiteSpace(title))
        {
            var newItem = new Item
            {
                Title = title,
            };
            ProjectItems.Add(newItem);
        }
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Item selectedItem)
        {
            var project = new Project
            {
                Id = selectedItem.Id
            };
            await Navigation.PushAsync(new ProjectDetailPage(project));
        }
    }
}
