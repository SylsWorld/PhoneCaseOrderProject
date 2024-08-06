# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file and restore any dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build the Blazor WebAssembly application
RUN dotnet publish -c Release -o out

# Stage 2: Serve the application using Nginx
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the build output from the previous stage
COPY --from=build /app/out/ .

ENTRYPOINT ["dotnet", "BlazorWebAssebly.dll"]


