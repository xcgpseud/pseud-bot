using System.Net;
using Domain.DataModels.Racing;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using Services.Interfaces.Racing;

namespace Services.Racing;

public class VehicleFetchService : IVehicleFetchService
{
    private const string VehiclesUrlPrefix = "https://www.iracing.com/cars/";

    public Vehicle FetchVehicle(string vehicleUid)
    {
        var url = $"{VehiclesUrlPrefix}{vehicleUid}";
        var response = CallUrl(url).Result;

        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(response);

        var vehicleTitle = GetVehicleName(htmlDocument);
        var vehicleDescription = GetVehicleDescription(htmlDocument);

        return new Vehicle
        {
            Uid = vehicleUid,
            Name = vehicleTitle,
            Description = vehicleDescription,
        };
    }

    private string GetVehicleName(HtmlDocument htmlDocument)
    {
        // #page>div>div.page-header>h1>a .innerText
        var title = htmlDocument
            .GetElementbyId("page")
            .SelectSingleNode("//div/div[@class='page-header']/h1/a")
            .GetDirectInnerText();

        return title;
    }

    private string GetVehicleDescription(HtmlDocument htmlDocument)
    {
        // #page>div>p(foreach)[span[text]]
        var descriptionElements = htmlDocument
            .GetElementbyId("page")
            .CssSelect("div > p")
            .ToList();

        // We remove the last 2 as they are persistent ad-based text entries
        descriptionElements.RemoveAt(descriptionElements.Count - 1);
        descriptionElements.RemoveAt(descriptionElements.Count - 1);

        var description = "";

        foreach (var descriptionElement in descriptionElements)
        {
            var innerText = descriptionElement.GetDirectInnerText();

            if (string.IsNullOrEmpty(innerText))
            {
                innerText = descriptionElement.CssSelect("span").FirstOrDefault()?.GetDirectInnerText();
            }

            description += innerText;
        }

        return description;
    }

    private async Task<string> CallUrl(string url)
    {
        var client = new HttpClient();
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
        client.DefaultRequestHeaders.Accept.Clear();

        return await client.GetStringAsync(url);
    }
}