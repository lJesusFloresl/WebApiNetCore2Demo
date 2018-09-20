FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WebApiNetCore2Demo/WebApiNetCore2Demo.csproj", "WebApiNetCore2Demo/"]
RUN dotnet restore "WebApiNetCore2Demo/WebApiNetCore2Demo.csproj"
COPY . .
WORKDIR "/src/WebApiNetCore2Demo"
RUN dotnet build "WebApiNetCore2Demo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApiNetCore2Demo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApiNetCore2Demo.dll"]