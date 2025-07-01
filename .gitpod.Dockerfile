# Start with the full Gitpod workspace image
FROM gitpod/workspace-full

# Install dependencies for .NET SDK
USER root

RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    wget \
    apt-transport-https && \
    \
    # Add Microsoft package repo
    wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get update && \
    \
    # Install .NET SDK
    apt-get install -y --no-install-recommends dotnet-sdk-7.0 && \
    \
    # Cleanup to reduce image size
    apt-get clean && \
    rm -rf /var/lib/apt/lists/* && \
    rm -f packages-microsoft-prod.deb

# Export PATH to include .NET SDK
ENV DOTNET_ROOT=/usr/share/dotnet
ENV PATH="$PATH:/usr/share/dotnet"

# Verify installation of .NET SDK
RUN dotnet --version

# Revert back to the default Gitpod user
USER gitpod
