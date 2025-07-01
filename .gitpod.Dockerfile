# Start with the full Gitpod workspace image
FROM gitpod/workspace-full

# Install dependencies and .NET SDK
USER root

RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    wget \
    apt-transport-https && \
    \
    # Add Microsoft package repository and install .NET SDK
    wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y --no-install-recommends dotnet-sdk-7.0 && \
    \
    # Cleanup to reduce image size
    apt-get clean && \
    rm -rf /var/lib/apt/lists/* && \
    rm -f packages-microsoft-prod.deb

# Verify the .NET SDK is installed
RUN dotnet --version

# Revert to Gitpod's default user
USER gitpod
