using MAUI.Canvas.viewmodels;
using ProjectCanvas.Models;

namespace MAUI.Canvas.views;

[QueryProperty(nameof(AssignId), "assignId")]
public partial class SubmitAssignmentView : ContentPage
{

    public int AssignId  //added
    {
        set; get;
    }

    public SubmitAssignmentView()
	{
		InitializeComponent();
        BindingContext = new CreateAssignmentViewModel();
    }

    private void SubmitAssignClicked(object sender, EventArgs e)
    {
        //Submit an assignment yatta yatta yatta
        (BindingContext as CreateAssignmentViewModel)?.AddSubmission();
        Shell.Current.GoToAsync("//StudentAssignment");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("//StudentOption");
        Shell.Current.GoToAsync("//StudentAssignment");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CreateAssignmentViewModel(AssignId);
    }
}