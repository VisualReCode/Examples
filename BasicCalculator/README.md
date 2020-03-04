# BasicCalculator

A migration of a very simple request/response service, using the Calculator sample
from the `Basic\GettingStarted\GettingStarted\CS\GettingStarted.sln` folder in the
[WCF Samples](https://docs.microsoft.com/dotnet/framework/wcf/samples/).

This solution demonstrates the generation of the `.proto` file from a `ServiceContract`, and the
generated gRPC service implementation that maps to a copy of the original service implementation.

It also includes a generated "client wrapper" that matches the interface of the original WCF-generated
client, which can be used in client applications to make switching to the new gRPC service easier.
The client library targets both .NET 4.5 and .NET Standard 2.1, so you can use it in legacy .NET Framework
applications as well as with Windows Forms or WPF apps you've upgraded to .NET Core 3.1. For brand new
.NET Core 3.1 apps, of course, we recommend using the `.proto` file directly to generate your own client.
