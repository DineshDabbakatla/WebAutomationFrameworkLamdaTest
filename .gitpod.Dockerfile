FROM gitpod/workspace-dotnet

# Optional: Set working directory
WORKDIR /workspace

# Optional: Install additional tools
RUN apt-get update && \
    apt-get install -y curl git && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*
