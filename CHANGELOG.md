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