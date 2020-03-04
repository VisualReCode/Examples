# Visual ReCode Examples

This repository contains examples of WCF applications that have been migrated to
[ASP.NET Core gRPC](https://docs.microsoft.com/aspnet/core/grpc/?view=aspnetcore-3.1)
using [Visual ReCode](https://visualrecode.com) 1.0

The original WCF applications are taken from Microsoft's own
[WCF Samples](https://docs.microsoft.com/dotnet/framework/wcf/samples/).

## BasicCalculator

A migration of a very simple request/response service, using the Calculator sample
from the `Basic\GettingStarted\GettingStarted\CS\GettingStarted.sln` folder in the WCF Samples.

This solution demonstrates the generation of the `.proto` file from a `ServiceContract`, and the
generated gRPC service implementation that maps to a copy of the original service implementation.

It also includes a generated "client wrapper" that matches the interface of the original WCF-generated
client, which can be used in client applications to make switching to the new gRPC service easier.
