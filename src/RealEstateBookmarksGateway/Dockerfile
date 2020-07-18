#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RealEstateBookmarksGateway/RealEstate.Bookmarks.Gateway.csproj", "RealEstateBookmarksGateway/"]
COPY ["RealEstateSystem/RealEstateCommon.csproj", "RealEstateSystem/"]
RUN dotnet restore "RealEstateBookmarksGateway/RealEstate.Bookmarks.Gateway.csproj"
COPY . .
WORKDIR "/src/RealEstateBookmarksGateway"
RUN dotnet build "RealEstate.Bookmarks.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RealEstate.Bookmarks.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RealEstate.Bookmarks.Gateway.dll"]