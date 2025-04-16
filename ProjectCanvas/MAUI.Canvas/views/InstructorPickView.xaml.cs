namespace MAUI.Canvas.views;

public partial class InstructorPickView : ContentPage
{
	public InstructorPickView()
	{
		InitializeComponent();
	}

    private void StudentTabClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Students");
    }

    private void CourseTabClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Courses");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AssignmentsClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CreateAssignment?assignId=0");
        //Shell.Current.GoToAsync($"//CourseDetail?courseId=0")
    }
}