using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousDemo;

internal class HttpClientDemo
{
    public void CallTo_WebService()
    {
        var url = "https://www.google.com/";

        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        using var response = client.Send(request);
        using var stream = new MemoryStream();

        response.Content.CopyTo(stream, null, default);
        stream.Flush();
    }

    public async Task CallTo_WebServiceAsync()
    {
        var url = "https://www.google.com/";

        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        using var response = await client.SendAsync(request);

        await using var stream = new MemoryStream();

        await response.Content.CopyToAsync(stream);
        await stream.FlushAsync();
    }

}
