FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ReflectionFeedback.Api.csproj", "./"]
RUN dotnet restore "./ReflectionFeedback.Api.csproj"
COPY . .
RUN dotnet build "ReflectionFeedback.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReflectionFeedback.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReflectionFeedback.Api.dll"]
