#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/playwright/dotnet:v1.27.0-focal AS base
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HTML2PDF/HTML2PDF.csproj", "HTML2PDF/"]
RUN dotnet restore "HTML2PDF/HTML2PDF.csproj"
COPY . .
WORKDIR "/src/HTML2PDF"
RUN dotnet build "HTML2PDF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HTML2PDF.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HTML2PDF.dll"]