#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RealEstateNewsLetter/RealEstateNewsLetter.csproj", "RealEstateNewsLetter/"]
COPY ["RealEstateSystem/RealEstateCommon.csproj", "RealEstateSystem/"]
RUN dotnet restore "RealEstateNewsLetter/RealEstateNewsLetter.csproj"
COPY . .
WORKDIR "/src/RealEstateNewsLetter"
RUN dotnet build "RealEstateNewsLetter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RealEstateNewsLetter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RealEstateNewsLetter.dll"]