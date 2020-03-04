# BasicCalculator

A migration of a very simple request/response service, using the Calculator sample
from the `Basic\GettingStarted\GettingStarted\CS\GettingStarted.sln` folder in the WCF Samples.

This solution demonstrates the generation of the `.proto` file from a `ServiceContract`, and the
generated gRPC service implementation that maps to a copy of the original service implementation.

It also includes a generated "client wrapper" that matches the interface of the original WCF-generated
client, which can be used in client applications to make switching to the new gRPC service easier.
