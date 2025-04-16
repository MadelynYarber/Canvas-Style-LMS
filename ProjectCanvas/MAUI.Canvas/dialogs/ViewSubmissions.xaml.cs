using MAUI.Canvas.viewmodels;

namespace MAUI.Canvas.dialogs;

public partial class ViewSubmissions : ContentPage
{
	public ViewSubmissions()
	{
		InitializeComponent();
        BindingContext = new CreateAssignmentViewModel();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CreateAssignment");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        //BindingContext = new CreateAssignmentViewModel();
        (BindingContext as CreateAssignmentViewModel)?.Refresh();
    }

    private void GradeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Students");
    }
}