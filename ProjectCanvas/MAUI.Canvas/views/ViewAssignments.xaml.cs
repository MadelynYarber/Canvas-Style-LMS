using MAUI.Canvas.viewmodels;

namespace MAUI.Canvas.views;

public partial class ViewAssignments : ContentPage
{
	public ViewAssignments()
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
        (BindingContext as CreateAssignmentViewModel)?.Refresh();
    }

   
}