using LiveStore.Data.Interfaces;

namespace LiveStore.Data.Model;

public class UtcDate : IClock
{
    public DateTime GetCurrentDate()
    {
        return DateTime.UtcNow;
    }
}