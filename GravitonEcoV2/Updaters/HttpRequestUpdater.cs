using Newtonsoft.Json;
using NLog;
using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravitonEcoV2.Updaters
{
    public abstract class HttpRequestUpdater
    {
        protected readonly Control controlMaxValue;
        protected readonly Control controlMinValue;
        protected readonly Control controlAvgValue;
        protected readonly string alias;
        protected readonly int interval = 2;
        private int taskDelay = 30000;
        private CancellationTokenSource cancellationTokenSource;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly HttpClient httpClient;
        private readonly string serverUrl = "http://localhost:8001";

        public HttpRequestUpdater(Control controlMaxValue, Control controlMinValue, Control controlAvgValue, string alias)
        {
            this.controlMaxValue = controlMaxValue ?? throw new ArgumentNullException(nameof(controlMaxValue));
            this.controlMinValue = controlMinValue ?? throw new ArgumentNullException(nameof(controlMinValue));
            this.controlAvgValue = controlAvgValue ?? throw new ArgumentNullException(nameof(controlAvgValue));
            this.alias = alias;
            this.cancellationTokenSource = new CancellationTokenSource();
            httpClient = new HttpClient();
            StartUpdating();
        }

        protected abstract Task UpdateAsync();

        protected async Task UpdateControlAsync()
        {
            try
            {
                string requestUrl = $"{serverUrl}/data?alias={alias}&interval={interval}";
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<SensorDataResponse>(jsonResponse);

                    controlMaxValue.Invoke(new Action(() => controlMaxValue.Text = data.MaxValue.ToString()));
                    controlMinValue.Invoke(new Action(() => controlMinValue.Text = data.MinValue.ToString()));
                    controlAvgValue.Invoke(new Action(() => controlAvgValue.Text = data.AverageValue.ToString()));
                }
                else
                {
                    logger.Error($"Error fetching data: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Exception occurred while fetching data: {ex.Message}");
            }

            await Task.Delay(taskDelay, cancellationTokenSource.Token);
        }

        public void StartUpdating()
        {
            cancellationTokenSource = new CancellationTokenSource();
            Task.Run(async () => await UpdateAsync());
        }

        public void StopUpdating()
        {
            cancellationTokenSource.Cancel();
        }
    }

    public class SensorDataResponse
    {
        public string Alias { get; set; }
        public double AverageValue { get; set; }
        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}