using GTDApp.Models;

namespace gtdmaui;

public partial class ProjectDetailPage : ContentPage
{
    public Project CurrentProject { get; set; }

    public ProjectDetailPage(Project project)
    {
        CurrentProject = project;
        BindingContext = CurrentProject;
    }
}