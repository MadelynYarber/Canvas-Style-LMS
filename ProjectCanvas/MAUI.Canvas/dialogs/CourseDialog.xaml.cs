using MAUI.Canvas.viewmodels;
using ProjectCanvas.Models;

namespace MAUI.Canvas.dialogs;
[QueryProperty(nameof(CourseId), "courseId")]
public partial class CourseDialog : ContentPage
{
    public int CourseId  //added
    {
        set; get;
    }
    public CourseDialog()
    {
        InitializeComponent();
        //BindingContext = new CourseDialogViewModel();
        BindingContext = new CourseDialogViewModel(0);
    }

    private void AddingCourseClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.AddCourse();
        Shell.Current.GoToAsync("//Courses");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        //BindingContext = new CourseDialogViewModel();
        BindingContext = new CourseDialogViewModel(CourseId);
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Courses");
    }
}