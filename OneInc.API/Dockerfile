FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["OneInc.API/OneInc.API.csproj", "OneInc.API/"]
RUN dotnet restore "OneInc.API/OneInc.API.csproj"
COPY . .

WORKDIR "/src/OneInc.API"
RUN dotnet build "OneInc.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OneInc.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OneInc.API.dll"]
