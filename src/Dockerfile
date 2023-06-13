FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SPA-stocks/SPA-stocks.csproj", "SPA-stocks/"]
RUN dotnet restore "SPA-stocks/SPA-stocks.csproj"
COPY . .
WORKDIR "/src/SPA-stocks"
RUN dotnet build "SPA-stocks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SPA-stocks.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SPA-stocks.dll"]
