using MAUI.Canvas.viewmodels;
using ProjectCanvas.Models;

namespace MAUI.Canvas.views;

[QueryProperty(nameof(StudentId), "studentId")]
public partial class StudentAssignmentView : ContentPage
{
    public StudentAssignmentView()
    {
        InitializeComponent();
        BindingContext = new CreateAssignmentViewModel();
    }

    private void SubmitClicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("//SubmitAssign");
        var assignId = (BindingContext as CreateAssignmentViewModel)?.SelectedAssignment?.AssignId;
        if (assignId != null)
        {
            Shell.Current.GoToAsync($"//SubmitAssign?assignId={assignId}");
        }
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentOption");
    }

    public int StudentId
    {
        set; get;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CreateAssignmentViewModel(StudentId);
    }
}