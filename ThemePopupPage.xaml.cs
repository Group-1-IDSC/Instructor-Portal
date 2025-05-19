using Microsoft.Maui.Controls.Compatibility;

namespace LoginForm;

public partial class ThemePopupPage : ContentPage
{
	public ThemePopupPage()
	{
		InitializeComponent();
	}

   

    private void ShowThemePopup(object sender, EventArgs e)
    {
        // Check if the theme popup is already visible
        if (ThemeSelectionPopup != null && ThemeSelectionPopup.IsVisible)
        {
            // If visible, hide it
            ThemeSelectionPopup.IsVisible = false;
            return;
        }

        // If not visible or null, create or show it
        if (ThemeSelectionPopup == null)
        {
            // Create theme options
            var lightTheme = new Button { Text = "Light Theme", BackgroundColor = Colors.White, TextColor = Colors.Black };
            var darkTheme = new Button { Text = "Dark Theme", BackgroundColor = Colors.Black, TextColor = Colors.White };
            var systemTheme = new Button { Text = "System Default", BackgroundColor = Colors.LightGray, TextColor = Colors.Black };

            // Set up event handlers for the buttons
            lightTheme.Clicked += (s, args) => ApplyTheme("Light");
            darkTheme.Clicked += (s, args) => ApplyTheme("Dark");
            systemTheme.Clicked += (s, args) => ApplyTheme("System");

            // Create and configure the popup content
            var popupContent = new Microsoft.Maui.Controls.StackLayout
            {
                Padding = new Thickness(20),
                BackgroundColor = Colors.White,
                Children = { new Label { Text = "Select Theme", FontAttributes = FontAttributes.Bold }, lightTheme, darkTheme, systemTheme }
            };

            // Create shadow effect for the popup
            if (DeviceInfo.Platform != DevicePlatform.iOS)
            {
                Microsoft.Maui.Controls.Shadow shadow = new Microsoft.Maui.Controls.Shadow
                {
                    Radius = 10,
                    Opacity = 0.5f,
                    Offset = new Point(5, 5)
                };
                popupContent.Shadow = shadow;
            }

            // Create the popup frame
            ThemeSelectionPopup = new Frame
            {
                Content = popupContent,
                HasShadow = true,
                CornerRadius = 10,
                IsVisible = true,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(0, 50, 20, 0)
            };

            // Get the root layout of the page
            if (Content is Layout<View> rootLayout)
            {
                // Add the popup to the layout
                rootLayout.Children.Add(ThemeSelectionPopup);
            }
            else
            {
                // If there's no appropriate layout container, we need to create one
                var currentContent = Content;
                var grid = new Microsoft.Maui.Controls.Grid();

                // Add the existing content to the grid
                if (currentContent != null)
                {
                    grid.Children.Add(currentContent);
                }

                // Add the popup to the grid
                grid.Children.Add(ThemeSelectionPopup);

                // Set the grid as the new content
                Content = grid;
            }
        }
        else
        {
            // Show the existing popup
            ThemeSelectionPopup.IsVisible = true;
        }
    }

    // Helper method to apply the selected theme
    private void ApplyTheme(string theme)
    {
        switch (theme)
        {
            case "Light":
                Application.Current.UserAppTheme = AppTheme.Light;
                break;
            case "Dark":
                Application.Current.UserAppTheme = AppTheme.Dark;
                break;
            case "System":
                Application.Current.UserAppTheme = AppTheme.Unspecified;
                break;
        }

        // Hide the popup after selection
        if (ThemeSelectionPopup != null)
        {
            ThemeSelectionPopup.IsVisible = false;
        }

        // Save the theme preference
        Preferences.Set("AppTheme", theme);
    }

    // Add this as a class field at the top of your ThemePopupPage class
    private Frame ThemeSelectionPopup;
}