using MyIoTService.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyIoTService.Services
{
    public static class DeviceIntegrationService
    {
        private static readonly string Url = @"https://localhost:44381/api/Device";
        private static readonly string ApiKey = @"pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp";

        public static async Task<DeviceRegisterResponse> GetDevice(int id)
        {
            string targetUrl = string.Format("{0}?id={1}", Url, id);
            var result = new DeviceRegisterResponse();
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("XApiKey", ApiKey);
                    var response = await client.GetStringAsync(targetUrl).ConfigureAwait(false);
                    result = JsonConvert.DeserializeObject<DeviceRegisterResponse>(response);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception Caught: ", ex.Message.ToString());
                }
            }
            return result;
        }
    }
}
