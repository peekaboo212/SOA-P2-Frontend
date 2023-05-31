#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SOA-P2-Backend/SOA-P2-Backend.csproj", "SOA-P2-Backend/"]
COPY ["Service/Service.csproj", "Service/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Repository/Repository.csproj", "Repository/"]
RUN dotnet restore "SOA-P2-Backend/SOA-P2-Backend.csproj"
COPY . .
WORKDIR "/src/SOA-P2-Backend"
RUN dotnet build "SOA-P2-Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SOA-P2-Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SOA-P2-Backend.dll"]