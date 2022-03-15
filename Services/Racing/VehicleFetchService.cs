using System.Net;
using Domain.DataModels.Racing;
using HtmlAgilityPack;
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
            .SelectNodes("//div/p/span[@style='font-weight: 400;']");
        
        // some don't have spans so fix this

        var descriptionStrings = descriptionElements.Select(
            x => x.GetDirectInnerText()
        );

        var description = string.Join("", descriptionStrings);

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