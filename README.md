[![](https://img.shields.io/nuget/v/soenneker.ngrok.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.ngrok.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.ngrok.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.ngrok.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.ngrok.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.ngrok.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.ngrok.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.ngrok.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.ngrok.OpenApiClientUtil

Provides a configured ngrok API client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.ngrok.OpenApiClientUtil
```

## Configuration

```json
{
  "ngrok": {
    "ApiKey": "your-api-key"
  }
}
```

## Usage

```csharp
using Soenneker.ngrok.OpenApiClientUtil.Abstract;
using Soenneker.ngrok.OpenApiClientUtil.Registrars;

services.AddngrokOpenApiClientUtilAsSingleton();

IngrokOpenApiClientUtil ngrok = serviceProvider
    .GetRequiredService<IngrokOpenApiClientUtil>();

var client = await ngrok.Get(cancellationToken);
var endpoints = await client.Endpoints.GetAsync(cancellationToken: cancellationToken);
```

The underlying HTTP provider supplies both authentication and the required ngrok API version header.

Use `AddngrokOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The underlying HTTP provider remains shared and is disposed by the service container at shutdown.
