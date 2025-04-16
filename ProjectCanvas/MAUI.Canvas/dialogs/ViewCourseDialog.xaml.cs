using MAUI.Canvas.viewmodels;
using ProjectCanvas.Models;
using ProjectCanvas.Services;

namespace MAUI.Canvas.dialogs;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class ViewCourseDialog : ContentPage
{
	public ViewCourseDialog()
	{
		InitializeComponent();
        BindingContext = new ViewCourseDialogViewModel();
    }

    
    public int CourseId
    {
        set; get;
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ViewCourseDialogViewModel(CourseId);
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Courses");
    }
}