FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["CognizantReflect.Api.csproj", "./"]
RUN dotnet restore "./CognizantReflect.Api.csproj"
COPY . .
RUN dotnet build "CognizantReflect.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CognizantReflect.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CognizantReflect.Api.dll"]