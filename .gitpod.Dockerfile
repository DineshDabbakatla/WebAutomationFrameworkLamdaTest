FROM gitpod/workspace-full

# Install .NET SDK
RUN sudo apt-get update && \
    sudo apt-get install -y apt-transport-https && \
    wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    sudo dpkg -i packages-microsoft-prod.deb && \
    sudo apt-get update && \
    sudo apt-get install -y dotnet-sdk-7.0

# Install Chrome
RUN wget https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb && \
    sudo apt install -y ./google-chrome-stable_current_amd64.deb

# Install ChromeDriver
RUN CHROME_VERSION=$(google-chrome --version | grep -oP '\d+\.\d+\.\d+') && \
    CHROMEDRIVER_VERSION=$(curl -s "https://chromedriver.storage.googleapis.com/LATEST_RELEASE_$CHROME_VERSION") && \
    wget -N https://chromedriver.storage.googleapis.com/$CHROMEDRIVER_VERSION/chromedriver_linux64.zip && \
    unzip chromedriver_linux64.zip && \
    sudo mv chromedriver /usr/local/bin/ && \
    sudo chmod +x /usr/local/bin/chromedriver
