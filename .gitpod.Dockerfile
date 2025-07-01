FROM mcr.microsoft.com/dotnet/nightly/sdk:8.0.411

# Set the workspace directory
WORKDIR /workspace

# Ensure the correct environment variables for .NET are set
ENV DOTNET_ROOT=/usr/share/dotnet
ENV PATH="$PATH:/usr/share/dotnet"

# Install basic dependencies (optional for debugging or other tools)
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    curl git && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Verify the installation
RUN dotnet --info
