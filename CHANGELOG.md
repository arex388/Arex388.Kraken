#### 2.0.3 (2020-03-21)

- Targeting .NET Standard 2.0 now.
- Changed all `const string` properties to `static readonly string`.

#### 2.0.2 (2020-03-12)

- Added a new failure response if no file name was provided.

#### 2.0.1 (2020-03-11)

- Changed `Authorization` to be internal.
- Enabled XML documentation to be generated for intellisense.

#### 2.0.0 (2020-03-11)

- Renamed `ChromaSamplingType` to `ChromaSampling`.
- Renamed `CropType` to `CropMode`.
- Renamed `FormatType` to `Format`.
- Renamed `MetadataType` to `Metadata`.
- Renamed `ResizeStrategyType` to `ResizeStrategy`.
- Merged `OptimizeRequest` and `OptimizeWaitRequest`.
- Added `Json` to `ResponseBase` to capture the raw JSON response from the API.
- Added `StatusAsync()` to query for the account's status.
- Renamed `GetOptimizeAsync()` to `OptimizeAsync()`.
- Renamed `GetOptimizeWaitAsync()` to `OptimizeWaitAsync()`.
- Added `debug` parameter to the `KrakenClient` constructor. False by default. When set to true, the raw JSON response will be written to the `Json` property of the response.
- Added preemptive request validation.
- Internal code clean up and rearrangement.