using LiveStore.Data.Interfaces;

namespace LiveStore.Data.Model;

public class LocalDate : IClock
{
    public DateTime GetCurrentDate()
    {
        return DateTime.Now;
    }
}