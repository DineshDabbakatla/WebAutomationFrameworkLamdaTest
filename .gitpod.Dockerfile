FROM gitpod/workspace-full

# Install .NET SDK 7.0
RUN sudo apt-get update && \
    sudo apt-get install -y apt-transport-https && \
    wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    sudo dpkg -i packages-microsoft-prod.deb && \
    sudo apt-get update && \
    sudo apt-get install -y dotnet-sdk-7.0 && \
    rm packages-microsoft-prod.deb
