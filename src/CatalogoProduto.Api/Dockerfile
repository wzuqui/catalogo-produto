#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/CatalogoProduto.Api/CatalogoProduto.Api.csproj", "src/CatalogoProduto.Api/"]
COPY ["src/CatalogoProduto.Infra/CatalogoProduto.Infra.csproj", "src/CatalogoProduto.Infra/"]
COPY ["src/CatalogoProduto.Domain/CatalogoProduto.Domain.csproj", "src/CatalogoProduto.Domain/"]
COPY ["src/CatalogoProduto.Domain.Core/CatalogoProduto.Domain.Core.csproj", "src/CatalogoProduto.Domain.Core/"]
RUN dotnet restore "src/CatalogoProduto.Api/CatalogoProduto.Api.csproj"
COPY . .
WORKDIR "/src/src/CatalogoProduto.Api"
RUN dotnet build "CatalogoProduto.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CatalogoProduto.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogoProduto.Api.dll"]