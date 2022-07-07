

using recipes_alexander_ccoa.Shared.Services;



var http = new HttpService(new HttpClient());

var data = await http.Run<API>("https://www.breakingbadapi.com/api/", HttpMethod.Get);

var y = 0;
class API
{
    public string characters { get; set; }
}