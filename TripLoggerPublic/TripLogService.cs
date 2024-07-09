using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripLoggerPublic;
public class TripLogService {
    private static readonly Lazy<TripLogService> lazy = new Lazy<TripLogService>(() => new TripLogService());

    public static TripLogService Instance => lazy.Value;

    private IEnumerable<TripLogger> tripLogs;

    private TripLogService() { }

    public IEnumerable<TripLogger> TripLogs { 
        get => tripLogs;
        set => tripLogs = value;
    }

    public TripLogger GetTripLogByTripID(int tripID) {
        return tripLogs.FirstOrDefault(t => t.TripID == tripID);
    }
}
