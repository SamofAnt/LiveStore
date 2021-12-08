using Amazon.Data.Interfaces;

namespace Amazon.Data.Model;

public class UtcDate : IClock
{
    public DateTime GetCurrentDate()
    {
        return DateTime.UtcNow;
    }
}