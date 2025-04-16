using MAUI.Canvas.viewmodels;
using ProjectCanvas.Models;

namespace MAUI.Canvas.dialogs;

[QueryProperty(nameof(ModuleId), "moduleId")]
public partial class ModuleDialog : ContentPage
{

    public int ModuleId 
    {
        set; get;
    }
    public ModuleDialog()
	{
		InitializeComponent();
        //BindingContext = new ModuleDialogViewModel();
        BindingContext = new ModuleDialogViewModel(0);
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Courses");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        //(BindingContext as ModuleDialogViewModel)?.Refresh();
        //BindingContext = new ModuleDialogViewModel();
        //BindingContext = new ModuleDialogViewModel(CourseId);
        //BindingContext = new ModuleDialogViewModel(0);
        BindingContext = new ModuleDialogViewModel(ModuleId);
    }

    private void AddModuleClicked(object sender, EventArgs e)
    {
        (BindingContext as ModuleDialogViewModel)?.AddModule();
        Shell.Current.GoToAsync("//Courses");
        //(BindingContext as ModuleDialogViewModel)?.Refresh();

    }
}