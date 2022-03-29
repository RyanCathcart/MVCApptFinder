# NJ MVC Appointment Finder

![demo.png](/demo.png)

#### Introduction:
During the heights of COVID-19, I found myself needing to schedule an appointment with the NJ MVC in order to renew my license and obtain a REAL ID. Upon navigating to https://telegov.njportal.com/njmvc, I found out how many other people were in the same boat as me, as the earliest possible appointments to schedule were for dates weeks and in some cases months in advance. In my particular case, I required my new ID in a somewhat timely manner, so I thought of ways to solve my problem with a little programming. (Note: The NJ MVC website did not provide any sort of public API)

#### Description:
This app is made in case you are faced with a similar situation to what I described above. What it does is automatically check the NJ MVC website for each location's earliest appointments, and if they are earlier than the user-set threshold, are printed to the console.

#### How to download and run:
- Make sure you have the .NET 6 SDK installed: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- Make sure you have git installed: https://git-scm.com/download/win
- Clone this repository, open your terminal, and cd into `/nj-mvc-appt-finder/MVCApptFinderConsoleApp/`
- Once in the correct folder, enter the command `dotnet run`

#### Tips for use:
Personally once the program runs, I would set the date threshold by entering the `threshold` command. If you need an appointment before a certain date, set that date as the date threshold. Then I would enter the `run` command to see what the program comes up with. If there are no current options, just re-enter the `run` command at a later time.