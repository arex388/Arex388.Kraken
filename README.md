# Arex388.Kraken

A C# client for the Kraken.io API.

To use, create a new instance of `KrakenClient` and pass in an instance of `HttpClient` and your API access and secret keys. Optionally pass in `true` to debug the responses which will add the raw JSON response to the response object. The original API documentation can be found [here](https://kraken.io/docs/getting-started). For more information, please visit [arex388.com](https://arex388.com).

Available as a NuGet package [here](https://www.nuget.org/packages/Arex388.Kraken).



#### No Longer using Kraken.io

As of about May of 2022 I've stopped using Kraken.io for image optimizations. I stopped using them because of a billing issue where the card on file had expired, but the past due balance couldn't manually be paid, and support was unresponsive. Eventually the auto-payment for the month actually processed the past due balance, and after about a month support replied.

It was too late by then as I couldn't wait days or weeks for it to be resolved and I ended up rolling my own image optimizer and I'm much happier now. It basically does the same optimizations, and I think maybe even does a slightly better job, but is also free, relatively speaking.

So, going forward, I'm really not going to be maintaining this library beyond dependency updates so that GitHub's Dependabot leaves me alone about vulnerabilities in referenced packages.



#### v2.0.3

Version 2.0.3 targets .NET Standard 2.0 now. I've decided to do this because in my daily work project, where this implementation was originally extracted from, I was having issues with loading the correct DLLs once deployed and I was getting all kinds of exceptions thrown. This was because the project targets .NET Framework 4.8, but the package was targeting .NET Standard 1.3.

Upgrading to .NET Standard 2.0 resolved the issues I was having with that project, and to be frank there's really no reason to stay on anything below .NET Standard 2.0. To quote Immo Landwerth from his [.NET Standard 2.1 announcement post](https://devblogs.microsoft.com/dotnet/announcing-net-standard-2-1/):

> *Library authors who need to support .NET Framework customers should stay on .NET Standard 2.0.*



#### v2.0.0

Version 2.0.0 is a breaking change! Mostly just renamed methods and "enum" classes. Look at the change log for more details.



#### Usage

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

```c#
var response = await kraken.OptimizeAsync(
    "{filePath}"
);
```

#### Optimize Wait

Optimize an image synchronously using a file path or a file blob.

```c#
var response = await kraken.OptimizeWaitAsync(
    "{filePath}"
);
```

#### Download

Download the kraked file.

```c#
var response = await kraken.DownloadAsync(
    "{krakedUrl}"
);
```

#### Status

Get the account's status.

```c#
var response = await kraken.StatusAsync();
```