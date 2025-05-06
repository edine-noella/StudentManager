namespace StudentManager.Services;

public class TimeService : ITimeService
{
    //service implimentation
    public string GetCurrentTime()
    {
        return DateTime.Now.ToString("hh:mm:ss tt");
    }
}