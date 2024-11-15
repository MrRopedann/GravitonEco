using GravitonEcoWeb.Model.DataBaseModel;
using GravitonEcoWeb.Services;
using System.Text.Json;

public class StatisticsService
{
    private readonly SqliteDbContext _dbContext;
    private TimeSpan _pollingPeriod;
    private DatabaseConfig _databaseConfig;

    public StatisticsService(SqliteDbContext dbContext)
    {
        _dbContext = dbContext;
        _databaseConfig = DatabaseConfig.LoadDatabaseConfig(); // Load the configuration
        _pollingPeriod = ParsePollingPeriod(_databaseConfig.PeriodUpdate);
    }

    private TimeSpan ParsePollingPeriod(string period)
    {
        return period switch
        {
            "Период наблюдений" => TimeSpan.FromMinutes(1),
            "1m" => TimeSpan.FromMinutes(1),
            "5m" => TimeSpan.FromMinutes(5),
            "10m" => TimeSpan.FromMinutes(10),
            "20m" => TimeSpan.FromMinutes(20),
            "30m" => TimeSpan.FromMinutes(30),
            "1h" => TimeSpan.FromHours(1),
            "3h" => TimeSpan.FromHours(3),
            "6h" => TimeSpan.FromHours(6),
            "12h" => TimeSpan.FromHours(12),
            "1d" => TimeSpan.FromDays(1),
            "2d" => TimeSpan.FromDays(2),
            "1w" => TimeSpan.FromDays(7),
            "1mo" => TimeSpan.FromDays(30),
            "3mo" => TimeSpan.FromDays(90),
            "6mo" => TimeSpan.FromDays(180),
            "1y" => TimeSpan.FromDays(365),
            "3y" => TimeSpan.FromDays(365 * 3),
            _ => TimeSpan.FromMinutes(1) // Default value if no match
        };
    }

    public TimeSpan GetPollingPeriod()
    {
        return ParsePollingPeriod(_databaseConfig.PeriodUpdate);
    }

    public string GetPollingPeriodSelector()
    {
        return _databaseConfig.PeriodUpdate;
    }

    public void SetPollingInterval(string period)
    {
        var newPollingPeriod = ParsePollingPeriod(period);
        if (_pollingPeriod != newPollingPeriod)
        {
            _pollingPeriod = newPollingPeriod;
            _databaseConfig.PeriodUpdate = period; // Update the config property
            SaveDatabaseConfig(_databaseConfig); // Save the new configuration
        }
    }

    private void SaveDatabaseConfig(DatabaseConfig config)
    {
        var configPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/config/DataBaseConnection.json");
        var jsonString = JsonSerializer.Serialize(new List<DatabaseConfig> { config });
        File.WriteAllText(configPath, jsonString);
    }

    // Methods to calculate min, max, and average
    public double CalculateMinForLastHour(int deviceId)
    {
        var startTime = DateTime.UtcNow - _pollingPeriod;
        var min = _dbContext.ModbusParameters
            .Where(p => p.DeviceId == deviceId && p.GlobalDateTime >= startTime)
            .Min(p => (double?)p.DeviceParametr);

        return min ?? 0; // Return 0 if no data
    }

    public double CalculateMaxForLastHour(int deviceId)
    {
        var startTime = DateTime.UtcNow - _pollingPeriod;
        var max = _dbContext.ModbusParameters
            .Where(p => p.DeviceId == deviceId && p.GlobalDateTime >= startTime)
            .Max(p => (double?)p.DeviceParametr);

        return max ?? 0; // Return 0 if no data
    }

    public double CalculateAverageForLastHour(int deviceId)
    {
        var startTime = DateTime.UtcNow - _pollingPeriod;
        var average = _dbContext.ModbusParameters
            .Where(p => p.DeviceId == deviceId && p.GlobalDateTime >= startTime)
            .Average(p => (double?)p.DeviceParametr);

        return average ?? 0; // Return 0 if no data
    }
}
