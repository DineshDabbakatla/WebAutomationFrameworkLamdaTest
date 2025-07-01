# Use the .NET 8.0.411 nightly SDK image as the base
FROM mcr.microsoft.com/dotnet/nightly/sdk:8.0.411

# Set up the working directory inside the container
WORKDIR /workspace

# (Optional) Install additional tools or dependencies if needed
# Example: If you need curl, git, or other dependencies
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    git curl && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Verify the .NET SDK installation
RUN dotnet --info

# Expose ASP.NET Core ports (optional, defaults to 5000/5001)
EXPOSE 5000
EXPOSE 5001
