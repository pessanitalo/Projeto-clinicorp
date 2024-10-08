#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CliniCorp/CliniCorp.csproj", "CliniCorp/"]
COPY ["CliniCorp.Data/CliniCorp.Data.csproj", "CliniCorp.Data/"]
COPY ["CliniCorp.Business/CliniCorp.Business.csproj", "CliniCorp.Business/"]
RUN dotnet restore "CliniCorp/CliniCorp.csproj"
COPY . .
WORKDIR "/src/CliniCorp"
RUN dotnet build "CliniCorp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CliniCorp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CliniCorp.dll"]