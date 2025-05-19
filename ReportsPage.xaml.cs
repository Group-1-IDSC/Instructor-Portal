namespace LoginForm;

public partial class ReportsPage : ContentPage
{
    public ReportsPage()
    {
        InitializeComponent();
        StartDateTimeUpdater();
    }



    private void StartDateTimeUpdater()
    {
        Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            // Update the label with current date and time
            dateTimeLabel.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy  hh:mm:ss tt");
            return true; // return true to keep the timer running
        });
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Optional: Add login validation logic here

        // Navigate to  EnrolledStudentPage
        await Navigation.PushAsync(new EnrolledStudentPage());
    }
    private async void OnAssessmentTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AssessmentPage());
    }
    private async void OnClassesScheduleClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClassSchedule());
    }

    private async void OnEnrolledStudentsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EnrolledStudentPage());
    }

    private async void OnReportsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReportsPage());
    }

    private async void OnMakeupClassClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RequestMakeupClassPage());
    }


}



