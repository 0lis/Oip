FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Oip.Security/Oip.Security.csproj", "src/Oip.Security/"]
COPY ["src/Oip.Security.EntityFramework.MySql/Oip.Security.EntityFramework.MySql.csproj", "src/Oip.Security.EntityFramework.MySql/"]
COPY ["src/Oip.Security.EntityFramework.Identity/Oip.Security.EntityFramework.Identity.csproj", "src/Oip.Security.EntityFramework.Identity/"]
COPY ["src/Oip.Security.EntityFramework/Oip.Security.EntityFramework.csproj", "src/Oip.Security.EntityFramework/"]
COPY ["src/Oip.Security.EntityFramework.Extensions/Oip.Security.EntityFramework.Extensions.csproj", "src/Oip.Security.EntityFramework.Extensions/"]
COPY ["src/Oip.Security.EntityFramework.Shared/Oip.Security.EntityFramework.Shared.csproj", "src/Oip.Security.EntityFramework.Shared/"]
COPY ["src/Oip.Security.EntityFramework.Configuration/Oip.Security.EntityFramework.Configuration.csproj", "src/Oip.Security.EntityFramework.Configuration/"]
COPY ["src/Oip.Security.BusinessLogic/Oip.Security.BusinessLogic.csproj", "src/Oip.Security.BusinessLogic/"]
COPY ["src/Oip.Security.BusinessLogic.Shared/Oip.Security.BusinessLogic.Shared.csproj", "src/Oip.Security.BusinessLogic.Shared/"]
COPY ["src/Oip.Security.EntityFramework.PostgreSQL/Oip.Security.EntityFramework.PostgreSQL.csproj", "src/Oip.Security.EntityFramework.PostgreSQL/"]
COPY ["src/Oip.Security.BusinessLogic.Identity/Oip.Security.BusinessLogic.Identity.csproj", "src/Oip.Security.BusinessLogic.Identity/"]
COPY ["src/Oip.Security.UI/Oip.Security.UI.csproj", "src/Oip.Security.UI/"]
COPY ["src/Skoruba.IdentityServer4.Shared.Configuration/Skoruba.IdentityServer4.Shared.Configuration.csproj", "src/Skoruba.IdentityServer4.Shared.Configuration/"]
COPY ["src/Skoruba.IdentityServer4.Shared/Skoruba.IdentityServer4.Shared.csproj", "src/Skoruba.IdentityServer4.Shared/"]
COPY ["src/Oip.Security.EntityFramework.SqlServer/Oip.Security.EntityFramework.SqlServer.csproj", "src/Oip.Security.EntityFramework.SqlServer/"]
RUN dotnet restore "src/Oip.Security/Oip.Security.csproj"
COPY . .
WORKDIR "/src/src/Oip.Security"
RUN dotnet build "Oip.Security.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Oip.Security.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Oip.Security.dll"]