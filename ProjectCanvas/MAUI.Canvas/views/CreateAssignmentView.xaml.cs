using MAUI.Canvas.viewmodels;
using ProjectCanvas.Models;

namespace MAUI.Canvas.views;

[QueryProperty(nameof(AssignId), "assignId")]
public partial class CreateAssignmentView : ContentPage
{

        public int AssignId  //added
        {
            set; get;
        }
        public CreateAssignmentView()
	    {
		InitializeComponent();
        BindingContext = new CreateAssignmentViewModel(0);
        }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorPick");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        
        BindingContext = new CreateAssignmentViewModel(AssignId);
    }

    private void AddAssignClicked(object sender, EventArgs e)
    {
        (BindingContext as CreateAssignmentViewModel)?.AddAssignment();
        Shell.Current.GoToAsync("//View");

    }

    private void ViewClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//View");
    }

    private void ViewSubmissionsClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ViewSubmissions");
    }
}