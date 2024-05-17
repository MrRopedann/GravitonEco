using NLog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ServerConnectionManager
{
    private static ServerConnectionManager instance;
    private readonly HttpClient httpClient;
    private readonly string serverUrl = "http://localhost:8001"; // URL вашего HTTP сервера
    private readonly Logger logger = LogManager.GetCurrentClassLogger();
    //private readonly object lockObject = new object();

    private ServerConnectionManager()
    {
        httpClient = new HttpClient();
    }

    public static ServerConnectionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ServerConnectionManager();
            }
            return instance;
        }
    }

    public async Task<bool> IsDeviceAvailable()
    {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(serverUrl);
                response.EnsureSuccessStatusCode(); // Проверяем, что запрос был успешным
                logger.Info("Устройство доступно по HTTP.");
                return true;
            }
            catch (HttpRequestException ex)
            {
                logger.Error($"Ошибка при проверке доступности устройства: {ex.Message}");
                return false;
            }
        }
    }
