using MAUI.Canvas.viewmodels;
using ProjectCanvas.Models;

namespace MAUI.Canvas.views;

[QueryProperty(nameof(StudentId), "studentId")]
public partial class LinkStudentView : ContentPage
{

    public int StudentId
    {
        set; get;
    }

    public LinkStudentView()
	{
		InitializeComponent();
        BindingContext = new LinkStudentViewModel(0);
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new LinkStudentViewModel(0);
    }

    private void LinkedClicked(object sender, EventArgs e)
    {
        (BindingContext as LinkStudentViewModel)?.AddEnrollment();
        Shell.Current.GoToAsync("//Students");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Students");
    }
}
