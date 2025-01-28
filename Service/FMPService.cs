using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Mappers;
using api.Models;
using Newtonsoft.Json;

namespace api.Service;

public class FMPService : IFMPService
{
    private HttpClient _httpClient;
    private IConfiguration _config;

    public FMPService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }
    public async Task<Stock> FindStockBySymbolAsync(string symbol)
    {
        try
        {
            string apiKey = _config["FMPKey"];
            string apiUrl = $"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={apiKey}";
            // Console.WriteLine(JsonConvert.SerializeObject(new { Message = "apiUrl", apiUrl = apiUrl }, Formatting.Indented));

            var result = await _httpClient.GetAsync(apiUrl);
            // Console.WriteLine(JsonConvert.SerializeObject(new { Message = "result", result = result }, Formatting.Indented));

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
                var stock = tasks[0];
                // Console.WriteLine(JsonConvert.SerializeObject(new { Message = "stock", stock = stock }, Formatting.Indented));

                if (stock != null) { return stock.ToStockFromFMP(); }

                return null;
            }
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}

public interface IFMPService
{
    Task<Stock> FindStockBySymbolAsync(string symbol);
}