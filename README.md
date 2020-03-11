# Arex388.Kraken
A C# client for the Kraken.io API.

To use, create a new instance of `KrakenClient` and pass in an instance of `HttpClient` and your API access and secret keys. Optionally pass in `true` to debug the responses which will add the raw JSON response to the response object. The original API documentation can be found [here][0]. For more information, please visit [arex388.com][1].

Available as a NuGet package [here][2].

---

#### IMPORTANT

Version 2.0.0 is a breaking change! Mostly just renamed methods and "enum" classes. Look at the change log for more details.

---

Create an instance of the `KrakenClient`.

```c#
var kraken = new KrakenClient(
    httpClient,
    "{accessKey}",
    "{secretKey}",
    // debug
);
```

#### Optimize

Optimize an image asynchronously using a file path or a file blob.

```C#
var response = await kraken.OptimizeAsync(
    "{filePath}"
);
```

#### Optimize Wait

Optimize an image synchronously using a file path or a file blob.

```C#
var response = await kraken.OptimizeWaitAsync(
    "{filePath}"
);
```

#### Download

Download the kraked file.

```C#
var response = await kraken.DownloadAsync(
    "{krakedUrl}"
);
```

#### Status

Get the account's status.

```c#
var response = await kraken.StatusAsync();
```

[0]:https://kraken.io/docs/getting-started
[1]:https://arex388.com
[2]:https://www.nuget.org/packages/Arex388.Kraken