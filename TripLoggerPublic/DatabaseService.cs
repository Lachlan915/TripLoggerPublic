using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripLoggerPublic;
public class DatabaseService {
    private readonly SQLiteAsyncConnection _database;

    public DatabaseService(string dbPath) {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<TripLogger>().Wait();
    }

    public Task<List<TripLogger>> GetAllOdometersAsync() {
        return _database.Table<TripLogger>().ToListAsync();
    }

    public Task<TripLogger> GetOdometerAsync(int id) {
        return _database.Table<TripLogger>().Where(i => i.TripID == id).FirstOrDefaultAsync();
    }

    public Task<int> SaveOdometerAsync(TripLogger logger) {
        if (logger.TripID != 0) {
            return _database.UpdateAsync(logger);
        } else {
            return _database.InsertAsync(logger);
        }
    }

    public Task<int> DeleteOdometerAsync(TripLogger logger) {
        return _database.DeleteAsync(logger);
    }

    // Will have to implement total km's into here
    public async Task<List<TripLogger>> SearchTripLogsAsync(int tripNumber, DateTime? startDate, DateTime? endDate, string purpose, int? minDistance, int? maxDistance) {
        // Construct the base query
        string query = "SELECT TripID, Kilometers, Purpose, Date FROM TripLogger WHERE 1 = 1";
        var parameters = new List<object>();

        // Add conditions based on provided criteria
        if (tripNumber != 0) {
            query += " AND TripID = ?";
            parameters.Add(tripNumber.ToString());
        }
        if (startDate.HasValue && endDate.HasValue) {
            query += " AND Date BETWEEN ? AND ?";
            parameters.Add(startDate.Value);
            parameters.Add(endDate.Value);
        } else if (startDate.HasValue) {
            query += " AND Date >= ?";
            parameters.Add(startDate.Value);
        } else if (endDate.HasValue) {
            query += " AND Date <= ?";
            parameters.Add(endDate.Value);
        }
        if (!string.IsNullOrEmpty(purpose)) {
            query += " AND Purpose = ?";
            parameters.Add(purpose);
        }
        if (minDistance.HasValue && maxDistance.HasValue) {
            query += " AND Kilometers BETWEEN ? AND ?";
            parameters.Add(minDistance.Value);
            parameters.Add(maxDistance.Value);
        } else if (minDistance.HasValue) {
            query += " AND Kilometers >= ?";
            parameters.Add(minDistance.Value);
        } else if (maxDistance.HasValue) {
            query += " AND Kilometers <= ?";
            parameters.Add(maxDistance.Value);
        }
        return await _database.QueryAsync<TripLogger>(query, parameters.ToArray());
    }
}
