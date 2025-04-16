using MAUI.Canvas.viewmodels;
using ProjectCanvas.Models;

namespace MAUI.Canvas.views;

public partial class CourseView : ContentPage
{
	public CourseView()
	{
		InitializeComponent();
        BindingContext = new CourseViewModel();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorPick");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//CourseDetail?courseId=0");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as CourseViewModel)?.Refresh();
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseViewModel)?.Remove();
    }

    private void UpdateClicked(object sender, EventArgs e)
    {
        var courseId = (BindingContext as CourseViewModel)?.SelectedCourse?.Id;
        if (courseId != null)
        {
            Shell.Current.GoToAsync($"//CourseDetail?courseId={courseId}");
        }
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseViewModel).Refresh();
    }

    private void ModuleClicked(object sender, EventArgs e)
    {
        //var courseId = (BindingContext as CourseViewModel)?.SelectedCourse?.Id;
        //if (courseId != null)
        //{
        //    Shell.Current.GoToAsync($"//ModuleDialog?courseId={courseId}");
        //}
        Shell.Current.GoToAsync($"//ModuleDialog?moduleId=0");
        
        //Shell.Current.GoToAsync($"//ModuleDialog");
        //Shell.Current.GoToAsync($"//ModuleDialog?courseId={courseId}");
    }

    private void ViewCourseClicked(object sender, EventArgs e)
    {
        
       var courseId = (BindingContext as CourseViewModel)?.SelectedCourse?.Id;
       if (courseId != null)
       {
          Shell.Current.GoToAsync($"//ViewCourse?courseId={courseId}");
       }
        
    }
}