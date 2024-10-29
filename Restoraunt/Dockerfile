FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Restoraunt/Restoraunt.csproj", "Restoraunt/"]
RUN dotnet restore "Restoraunt/Restoraunt.csproj"
COPY . .
WORKDIR "/src/Restoraunt"
RUN dotnet build "Restoraunt.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Restoraunt.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Restoraunt.dll"]
