//------------------------------------------------------------------------------
// Generated by the DevExpress.Blazor package.
// To prevent this operation, add the DxExtendStartupHost property to the project and set this property to False.
//
// MediHub.Dashboard.Blazor.csproj:
//
// <Project Sdk="Microsoft.NET.Sdk.Web">
//  <PropertyGroup>
//    <TargetFramework>netcoreapp3.0</TargetFramework>
//    <DxExtendStartupHost>False</DxExtendStartupHost>
//  </PropertyGroup>
//------------------------------------------------------------------------------
using System;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MediHub.Dashboard.Blazor.DevExpressHostingStartup))]

namespace MediHub.Dashboard.Blazor {
    public partial class DevExpressHostingStartup : IHostingStartup {
        void IHostingStartup.Configure(IWebHostBuilder builder) {
            builder.ConfigureServices((serviceCollection) => {
                serviceCollection.AddDevExpressBlazor();
            });
        }
    }
}
