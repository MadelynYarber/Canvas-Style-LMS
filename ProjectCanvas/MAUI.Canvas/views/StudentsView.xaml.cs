using MAUI.Canvas.viewmodels;
using ProjectCanvas.Models;

namespace MAUI.Canvas.views;

public partial class StudentsView : ContentPage
{
	public StudentsView()
	{
		InitializeComponent();
		BindingContext = new StudentsViewModel();
	}

   
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorPick");
    }

    private void AddStudentClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//StudentDetail?studentId=0");
        //(BindingContext as StudentsViewModel)?.AddStudent();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as StudentsViewModel)?.Refresh();
    }

    private void RemoveStudentClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentsViewModel)?.Remove();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var studentId = (BindingContext as StudentsViewModel)?.SelectedStudent?.Id;
        if(studentId != null)
        {
            Shell.Current.GoToAsync($"//StudentDetail?studentId={studentId}");
        }
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentsViewModel).Refresh();
    }

    private void LinkStudentClicked(object sender, EventArgs e)
    {
        var studentId = (BindingContext as StudentsViewModel)?.SelectedStudent?.Id;
        if (studentId != null)
        {
            Shell.Current.GoToAsync($"//LinkStudent?studentId={studentId}");
        }
        //Shell.Current.GoToAsync($"//LinkStudent");
    }
}

