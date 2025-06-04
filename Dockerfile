
# Stage 1: Build the app using .NET 8 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy the project file and restore dependencies
COPY animomentapi.csproj ./
RUN dotnet restore

# Copy the rest of the source code
COPY . .

# Publish the app to /app/publish in Release mode
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

# Copy published output from build stage
COPY --from=build /app/publish .

# Render requires your app to listen on port 10000
EXPOSE 10000
ENV ASPNETCORE_URLS=http://+:10000

# Start your .NET app
ENTRYPOINT ["dotnet", "animomentapi.dll"]
