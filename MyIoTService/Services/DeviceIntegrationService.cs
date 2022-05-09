using MyIoTService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyIoTService.Services
{
    public class DeviceIntegrationService : IDeviceIntegrationService
    {
        private readonly string Url = @"https://localhost:44381/api/Device";
        private readonly string ApiKey = @"pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp";

        public async Task<DeviceRegisterResponse> AddDevice(DeviceRegisterRequest device)
        {
            string targetUrl = Url;
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("XApiKey", ApiKey);

                    var content = JsonConvert.SerializeObject(device);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = await client.PostAsync(targetUrl, byteContent);
                    response.EnsureSuccessStatusCode();
                    return JsonConvert.DeserializeObject<DeviceRegisterResponse>(await response.Content.ReadAsStringAsync());
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<DeviceRegisterResponse> DeleteDevice(int id)
        {
            string targetUrl = string.Format("{0}?id={1}", Url, id);
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("XApiKey", ApiKey);
                    var response = await client.DeleteAsync(targetUrl);
                    response.EnsureSuccessStatusCode();
                    return JsonConvert.DeserializeObject<DeviceRegisterResponse>(await response.Content.ReadAsStringAsync());
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<DeviceRegisterResponse>> GetAllDevices()
        {
            string targetUrl = string.Format("{0}/getall", Url);
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("XApiKey", ApiKey);
                    var response = await client.GetAsync(targetUrl);
                    response.EnsureSuccessStatusCode();
                    return JsonConvert.DeserializeObject<IEnumerable<DeviceRegisterResponse>>(await response.Content.ReadAsStringAsync());
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<DeviceRegisterResponse> GetDevice(int id)
        {
            string targetUrl = string.Format("{0}?id={1}", Url, id);
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("XApiKey", ApiKey);
                    var response = await client.GetAsync(targetUrl);
                    response.EnsureSuccessStatusCode();
                    return JsonConvert.DeserializeObject<DeviceRegisterResponse>(await response.Content.ReadAsStringAsync());
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<DeviceRegisterResponse> UpdateDevice(DeviceRegisterRequest device)
        {
            string targetUrl = Url;
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("XApiKey", ApiKey);

                    var content = JsonConvert.SerializeObject(device);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = await client.PutAsync(targetUrl, byteContent);
                    response.EnsureSuccessStatusCode();
                    return JsonConvert.DeserializeObject<DeviceRegisterResponse>(await response.Content.ReadAsStringAsync());
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
