# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and project files
COPY Travels.slnx .
COPY Travels.WebApi/Travels.WebApi.csproj Travels.WebApi/
COPY Travels.BLL/Travels.BLL.csproj Travels.BLL/
COPY Travels.DAL/Travels.DAL.csproj Travels.DAL/
COPY Travels.Models/Travels.Models.csproj Travels.Models/

# Restore dependencies
RUN dotnet restore Travels.WebApi/Travels.WebApi.csproj

# Copy the rest of the source code
COPY Travels.WebApi/ Travels.WebApi/
COPY Travels.BLL/ Travels.BLL/
COPY Travels.DAL/ Travels.DAL/
COPY Travels.Models/ Travels.Models/

# Build the application
WORKDIR /src/Travels.WebApi
RUN dotnet build -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Copy published files
COPY --from=publish /app/publish .

# Expose port
EXPOSE 8080

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Run the application
ENTRYPOINT ["dotnet", "Travels.WebApi.dll"]
