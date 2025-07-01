# Start with the full Gitpod workspace image
FROM gitpod/workspace-full

# Install dependencies for .NET SDK with specific versions
USER root

RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    wget=1.21-1ubuntu3 \
    apt-transport-https=2.4.11 && \
    \
    # Add Microsoft package repo
    wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get update && \
    \
    # Install specific .NET SDK version
    apt-get install -y --no-install-recommends dotnet-sdk-7.0=7.0.100-1 && \
    \
    # Cleanup to reduce image size
    apt-get clean && \
    rm -rf /var/lib/apt/lists/* && \
    rm -f packages-microsoft-prod.deb

# Verify the .NET SDK is installed
RUN dotnet --version

# Revert back to Gitpod's default user
USER gitpod
