[![](https://img.shields.io/nuget/v/soenneker.healthsherpa.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.healthsherpa.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.healthsherpa.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.healthsherpa.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.healthsherpa.openapiclient/build-and-test.yml?style=for-the-badge&label=build)](https://github.com/soenneker/soenneker.healthsherpa.openapiclient/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.healthsherpa.openapiclient/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.healthsherpa.openapiclient/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.healthsherpa.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.healthsherpa.openapiclient/)

# Soenneker.HealthSherpa.OpenApiClient

A strongly typed, Kiota-generated .NET client for HealthSherpa's API. It includes models and request builders for quotes, enrollment sessions, enrollments, policy status, reference data, and health checks.

## Installation

```bash
dotnet add package Soenneker.HealthSherpa.OpenApiClient
```

## Create the client directly

```csharp
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.HealthSherpa.OpenApiClient;

using var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);

var authentication = new AnonymousAuthenticationProvider();
using var adapter = new HttpClientRequestAdapter(authentication, httpClient: httpClient);
var client = new HealthSherpaOpenApiClient(adapter);
```

The generated client defaults to `https://api.one.healthsherpa.com`. Set `adapter.BaseUrl` before constructing `HealthSherpaOpenApiClient` when targeting another environment.

## Call an endpoint

```csharp
using Soenneker.HealthSherpa.OpenApiClient.Models;

PingResponse? response = await client.V1.Ping.GetAsync(
    cancellationToken: cancellationToken);
```

Endpoints follow Kiota's request-builder hierarchy. For example, quotes are posted through `client.V1.Quotes`, enrollments are under `client.V1.Enrollments`, and county/provider/issuer data is under `client.V1.Reference`.

For application registration, configuration-based authentication, and managed HTTP-client reuse, use `Soenneker.HealthSherpa.OpenApiClientUtil`, which composes this generated client with `Soenneker.HealthSherpa.HttpClients`.

This repository contains generated source. Put application-specific behavior in wrapper services or separate partial-class files because regeneration can replace generated files.
