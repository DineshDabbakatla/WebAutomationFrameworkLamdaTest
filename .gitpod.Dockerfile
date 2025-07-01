FROM mcr.microsoft.com/dotnet/sdk:8.0

# Set the workspace directory
WORKDIR /workspace

# Set environment variables for .NET
ENV DOTNET_ROOT=/usr/share/dotnet
ENV PATH="$PATH:/usr/share/dotnet"

# Install basic dependencies
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    curl git && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Verify .NET installation
RUN dotnet --info
