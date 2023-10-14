FROM mcr.microsoft.com/dotnet/aspnet:7.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 5235

ENV ASPNETCORE_URLS=http://+:5235

FROM mcr.microsoft.com/dotnet/sdk:7.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["zooCRUD/zooCRUD.csproj", "zooCRUD/"]
RUN dotnet restore "zooCRUD\zooCRUD.csproj"
COPY . .
WORKDIR "/src/zooCRUD"
RUN dotnet build "zooCRUD.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "zooCRUD.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "zooCRUD.dll"]
