using SQLite;

namespace TripLoggerPublic;
public class TripLogger {
    [PrimaryKey, AutoIncrement]
    public int TripID { get; set; }

    [NotNull]
    public int StartOdometer { get; set; }

    [NotNull]
    public int EndOdometer { get; set; }

    [NotNull]
    public DateTime Date { get; set; }

    [NotNull]
    public int Kilometers { get; set; }

    [NotNull]
    public string Purpose { get; set; }
}
