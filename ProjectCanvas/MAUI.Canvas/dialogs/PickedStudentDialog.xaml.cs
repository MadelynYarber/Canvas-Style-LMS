using ProjectCanvas.Models;
using MAUI.Canvas.viewmodels;

namespace MAUI.Canvas.dialogs;

[QueryProperty(nameof(StudentId), "studentId")]
public partial class PickedStudentDialog : ContentPage
{
	public PickedStudentDialog()
	{
		InitializeComponent();
        //BindingContext = new StudentDialogViewModel(0);
        //BindingContext = new PickedStudentDialogViewModel(0);
        BindingContext = new PickedStudentDialogViewModel();
    }
    public int StudentId
    {
        set; get;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {

        BindingContext = new PickedStudentDialogViewModel(StudentId);
        //(BindingContext as PickedStudentDialogViewModel)?.Refresh();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentOption");
    }
}