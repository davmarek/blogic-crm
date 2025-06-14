
# Use the SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:9.0@sha256:3fcf6f1e809c0553f9feb222369f58749af314af6f063f389cbd2f913b4ad556 AS build


# Create folder /building
WORKDIR /building

# Copy everything from project to the /building directory
COPY . .

# Install packages
RUN dotnet restore

# Publish the app into /building/out directory
RUN dotnet publish -o out

# Now use the Runtime image for running
FROM mcr.microsoft.com/dotnet/aspnet:9.0@sha256:b4bea3a52a0a77317fa93c5bbdb076623f81e3e2f201078d89914da71318b5d8

# Create folder /running
WORKDIR /running

# Copy the build from the building image into the /running folder
COPY --from=build /building/out .

ENV DOTNET_URLS=http://+:8080

EXPOSE 8080

# Run the app
ENTRYPOINT ["dotnet", "BlogicCRM.dll", "migrate"]

# NEXT:
# Build the Docker image
# docker build -t blogic-crm -f Dockerfile . 