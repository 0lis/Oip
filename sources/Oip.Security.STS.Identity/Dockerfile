FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Skoruba.IdentityServer4.STS.Identity/Skoruba.IdentityServer4.STS.Identity.csproj", "src/Skoruba.IdentityServer4.STS.Identity/"]
COPY ["src/Skoruba.IdentityServer4.Shared.Configuration/Skoruba.IdentityServer4.Shared.Configuration.csproj", "src/Skoruba.IdentityServer4.Shared.Configuration/"]
COPY ["src/Oip.Security.EntityFramework.Shared/Oip.Security.EntityFramework.Shared.csproj", "src/Oip.Security.EntityFramework.Shared/"]
COPY ["src/Oip.Security.EntityFramework.Identity/Oip.Security.EntityFramework.Identity.csproj", "src/Oip.Security.EntityFramework.Identity/"]
COPY ["src/Oip.Security.EntityFramework/Oip.Security.EntityFramework.csproj", "src/Oip.Security.EntityFramework/"]
COPY ["src/Oip.Security.EntityFramework.Extensions/Oip.Security.EntityFramework.Extensions.csproj", "src/Oip.Security.EntityFramework.Extensions/"]
COPY ["src/Oip.Security.EntityFramework.Configuration/Oip.Security.EntityFramework.Configuration.csproj", "src/Oip.Security.EntityFramework.Configuration/"]
COPY ["src/Skoruba.IdentityServer4.Shared/Skoruba.IdentityServer4.Shared.csproj", "src/Skoruba.IdentityServer4.Shared/"]
COPY ["src/Oip.Security.Bl.Identity/Oip.Security.Bl.csproj", "src/Oip.Security.Bl.Identity/"]
COPY ["src/Oip.Security.Bl.Shared/Oip.Security.Bl.Shared.csproj", "src/Oip.Security.Bl.Shared/"]
RUN dotnet restore "src/Skoruba.IdentityServer4.STS.Identity/Skoruba.IdentityServer4.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/Skoruba.IdentityServer4.STS.Identity"
RUN dotnet build "Skoruba.IdentityServer4.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Skoruba.IdentityServer4.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Skoruba.IdentityServer4.STS.Identity.dll"]