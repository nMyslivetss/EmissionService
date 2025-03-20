# Emission Service

This project is a web service that provides emission data through an API. The service includes endpoints for retrieving emission information, with versions 1 and 2 of the API. The data is fetched from a background API and processed for the main API to return the results to the user.

## Features

- **API Versioning**: Supports version 1 (`/v1/emissions`) and version 2 (`/v2/emissions`) of the emissions API.
- **Data Retrieval**: Fetches emission data from a background API and returns structured responses.
- **Filtering**: Allows users to filter data based on parameters such as `CustomerName`, `CustomerId`, `FacilityId`, `FacilityCode`, `PeriodStart`, and `PeriodEnd`.
- **Background API**: The background API will serve as the data source for emissions data.
