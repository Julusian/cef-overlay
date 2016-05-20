# CEF Overlay

A simple project to render a mostly transparent webpage over other applications, without stealing focus or interactions.

Currently windows only, and built with chromium 47.


## Usage
Run the program,  and a new tray icon should appear. This icon gives a settings page, where you can choose the url to display, and gives the ability to hide the overlay, and refresh the page being rendered.

Note: it is advised to ensure the tray icon always stays shown, as the overlay draws on top of the tray popups which can make it hard to close the application if a fullscreen page is shown.

Note: a settings change requires restarting the program to take effect.


## Building
Open the Visual Studio solution file, make sure the nuget dependencies are installed and compile in Release mode.

Both x64 and x86 should work, but x64 has been more thoroughly tested.

