# Arex388.Kraken
Kraken.io API Implementation in C#

To use, create a new instance of `KrakenClient` and pass in an instance of `HttpClient` and your API access and secret keys. The original API documentation can be found [here][0]. For more information, please visit [arex388.com][1].

    var kraken = new KrakenClient(httpClient, "{accessKey}", "{secretKey}");

**Optimize**

    var optimize = await kraken.GetOptimizeAsync("{filePath}");

**Optimize Wait**

    var optimizeWait = await kraken.GetOptimizeWaitAsync("{filePath}");

**Download**

    var download = await kraken.DownloadAsync("{krakedUrl}");

[0]:https://kraken.io/docs/getting-started
[1]:https://arex388.com