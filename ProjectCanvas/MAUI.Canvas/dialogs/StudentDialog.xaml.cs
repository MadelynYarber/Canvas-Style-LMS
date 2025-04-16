using MAUI.Canvas.viewmodels;
using ProjectCanvas.Models;
using ProjectCanvas.Services;

namespace MAUI.Canvas.dialogs;
[QueryProperty(nameof(StudentId), "studentId")] //added
public partial class StudentDialog : ContentPage
{

    public int StudentId  //added
    {
        set; get;
    }
    public StudentDialog()
    {
        InitializeComponent();
        BindingContext = new StudentDialogViewModel(0);
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Students");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentDialogViewModel)?.AddStudent();
        Shell.Current.GoToAsync("//Students");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentDialogViewModel(StudentId);
    }
}