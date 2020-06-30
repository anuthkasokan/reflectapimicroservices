FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ReflectUser.API.csproj", "./"]
RUN dotnet restore "./ReflectUser.API.csproj"
COPY . .
RUN dotnet build "ReflectUser.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReflectUser.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReflectUser.API.dll"]
