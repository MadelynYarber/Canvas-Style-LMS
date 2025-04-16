namespace MAUI.Canvas
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void StudentViewClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//StudentOption");
        }

        private void InstructorPickViewClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//InstructorPick");
        }

     
    }

}
