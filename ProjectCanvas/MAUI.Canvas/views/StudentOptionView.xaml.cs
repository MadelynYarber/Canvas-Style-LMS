using MAUI.Canvas.viewmodels;

namespace MAUI.Canvas.views;

public partial class StudentOptionView : ContentPage
{
	public StudentOptionView()
	{
		InitializeComponent();
        BindingContext = new StudentsViewModel();
    }

    private void SubmitAssignClicked(object sender, EventArgs e)
    {

        ////Shell.Current.GoToAsync("//StudentAssignment")
        var studentId = (BindingContext as StudentsViewModel)?.SelectedStudent?.Id;
        if (studentId != null)
        {
            Shell.Current.GoToAsync($"//StudentAssignment?studentId={studentId}");
        }
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentsViewModel).Refresh();
    }

    private void StudentPickedClicked(object sender, EventArgs e)
    {
        var studentId = (BindingContext as StudentsViewModel)?.SelectedStudent?.Id;
        if (studentId != null)
        {
            Shell.Current.GoToAsync($"//PickedStudentDialog?studentId={studentId}");
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {

    }
}