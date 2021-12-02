using Amazon.Data.Interfaces;

namespace Amazon.Data.Model;

public class UtcDate : IClock
{
    public DateTime GetCurrentDate() => DateTime.UtcNow;
}