# WebAutomationFramework

## Overview

WebAutomationFramework is a robust Selenium-based automation framework designed to test web applications efficiently across multiple browsers and operating systems. The framework leverages modern development practices like test parallelization, cutting-edge tools (NUnit, Selenium WebDriver), and integrations with cloud-based automation services like LambdaTest for cross-browser testing.

This repository contains automated test examples for validating features like “Simple Form Demo,” “Input Form Submit,” and “Drag & Drop Sliders” using LambdaTest's Selenium Playground as the test application. 

The codebase is designed for extensibility, allowing developers to quickly add new tests and configurations for web automation tasks.

---

## Features

1. **Cross-browser testing**:
    - Perform automated tests across Chrome, Edge, Firefox, and Safari browsers.
    - Cross-platform support for major operating systems like Windows and macOS using LambdaTest.

2. **Cloud Browser Automation**:
    - Integrated with LambdaTest for running tests on a cloud-based Selenium grid.
    - Real-time reporting and test status updates via LambdaTest.

3. **Parallel Test Execution**:
    - Run tests in parallel using NUnit for faster execution.

4. **Reusable Design Patterns**:
    - Page Object Model (POM) ensures clean and maintainable test scripts.

5. **Configurable Environments**:
    - Store test configuration settings such as URLs and environment variables in `.gitpod.yml` and `appsettings.json` files.

---

## Pre-requisites

### Environment Setup
Ensure the following tools and dependencies are available on your machine:
- .NET SDK (6.0 or higher)
- Docker (for Gitpod compatibility)
- Git
- An IDE with C# support (e.g., Visual Studio or VS Code)

### LambdaTest Credentials
Set the following environment variables for LambdaTest integration:
- `LT_USERNAME`: Your LambdaTest username
- `LT_ACCESS_KEY`: Your LambdaTest access key

### Gitpod (Optional)
If using Gitpod for cloud development:
1. Install the Gitpod browser extension.
2. Ensure `DOTNET_SKIP_FIRST_TIME_EXPERIENCE` and `DOTNET_NOLOGO` are set in `.gitpod.yml`.

---

## Getting Started

### Clone the Repository
```bash
git clone https://github.com/your-username/WebAutomationFramework.git
cd WebAutomationFramework
```
### Build and Restore Dependencies
Restore the required NuGet dependencies:
```bash
dotnet restore
dotnet build
```
### Run the Tests
Execute all the tests using the following command:
```bash
dotnet test
```
---
### Gitpod Quick Start
If using Gitpod:

1. Open your Gitpod workspace using:
  ```bash
  gitpod.io/#https://github.com/your-username/WebAutomationFramework
  ```
2. The `.gitpod.yml` file will automatically initialize, build, and test the application.
---
## Project Structure
WebAutomationFramework/
├── Config
│   ├── ConfigReader.cs         # Reads test URLs from 'appsettings.json'
│   └── appsettings.json        # Contains base test URLs
├── Drivers
│   └── WebDriverInitializer.cs # Handles browser initialization and LambdaTest integration
├── Pages
│   ├── BasePage.cs             # Abstract class for shared page functionality
│   ├── SeleniumPlaygroundPage.cs # Navigates to different sections of LambdaTest Playground
│   ├── SimpleFormDemoPage.cs   # Represents Simple Form Demo page actions and states
│   ├── InputFormSubmitPage.cs  # Represents Input Form Submission page actions
│   ├── DragAndDropSliderPage.cs # Represents Drag & Drop Sliders page actions
├── Tests
│   ├── DragAndDropSlidersTest.cs # Tests Drag & Drop Sliders functionality
│   ├── InputFormSubmitTests.cs  # Tests Input Form Submission functionality
│   ├── SimpleFormDemoTests.cs   # Tests Simple Form Demo functionality
│   ├── BrowserConfigs.cs        # Test configurations for supported browsers/platforms
├── Helpers
│   ├── ElementActionHelpers.cs  # Helper methods for interacting with elements
│   └── WebDriverExtensions.cs   # Extension methods for WebDriver
├── .gitpod.yml                  # Gitpod configuration for cloud development
├── .gitpod.Dockerfile           # Dockerfile for Gitpod workspace configuration
└── README.md                    # Project documentation
