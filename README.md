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

## 📋 Prerequisites
1. Create LambdaTest Account
Visit [LambdaTest](https://automation.lambdatest.com/build) and create an account.
2. Create Gitpod Account
Visit [Gitpod](https://gitpod.io/login), create an account, and ensure you're logged in.

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
## 🚀 Quick Start in Gitpod
With Gitpod, you can launch this project seamlessly in a fully-configured development environment. Follow the steps below:

1. Fork & Add Repository to Gitpod
- Fork this repository to your GitHub/GitLab account.
- Add the forked repository into your Gitpod workspace. To do this:
- Go to the Gitpod [dashboard](https://gitpod.io/workspaces).
- Go to repository settings
![image](https://github.com/user-attachments/assets/32cac66a-424f-4b1e-bab9-198d1bcf6225)

- Click on "Add Repository" and select the forked repository/ add this repository [url](https://github.com/DineshDabbakatla/WebAutomationFrameworkLamdaTest).
2. Set Environment Variables
Go to the settings for the forked repository on Gitpod by navigating to: Environment variables → Add Variable
![image](https://github.com/user-attachments/assets/87801eb0-26b6-4035-99e5-48871ca75a1e)

Add the following environment variables:
LT_USERNAME: Your LambdaTest username.
LT_ACCESS_KEY: Your LambdaTest access key (available in the profile page of your LambdaTest account).
3. Launch Test On Gitpod
- To launch this project in Gitpod and execute tests:

Open the repository in Gitpod by appending /gitpod to the repository URL in GitHub. Example:


https://gitpod.io/#https://github.com/<your-username>/<your-repo-name>
Gitpod will build the development container using the .gitpod.yml file included in this repository.
Once the container builds, the following commands will execute automatically:
dotnet restore (Restores NuGet dependencies)
dotnet build (Builds the project)
dotnet test (Runs all NUnit tests)
You may also run dotnet test manually in the built Gitpod workspace terminal.
---
## Project Structure
```
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
└── Helpers
    ├── ElementActionHelpers.cs  # Helper methods for interacting with elements
    └── WebDriverExtensions.cs   # Extension methods for WebDriver
```
---
## Configuration
### Test URL Settings
The test URL for LambdaTest’s Selenium Playground is configured in appsettings.json:
```json
{
  "TestUrls":
  {
    "SeleniumPlayground": "https://www.lambdatest.com/selenium-playground"
  }
}
```
### LambdaTest Credentials
Ensure your LambdaTest keys are set as environment variables:

- Example in `.gitpod.yml`:
  ```bash
  env:
  LT_USERNAME: "your-username"
  LT_ACCESS_KEY: "your-access-key"
  ```
---
## Browser Support
This framework supports the following browsers to ensure cross-browser compatibility:
| Browser | Latest Version | Platform |
| :-- | :-- | :-- |
| Chrome | Latest | Windows 11, macOS |
| Safari | Latest | macOS Ventura |
| Edge | Latest | Windows 11 |
| Firefox | Latest | Windows & macOS |
---
## How Tests Work
### WebDriver Initialization
- The WebDriverInitializer class dynamically configures browser settings based on BrowserConfigs.cs and initializes connections with the LambdaTest Selenium Grid.
### Page Objects
- Each test targets Page Object classes (e.g., SimpleFormDemoPage, InputFormSubmitPage) to interact with page elements and abstract complex actions like mouse input or element dragging.
### Test Execution
- Each test verifies expected behavior, such as form validation, slider manipulation, or message display, using NUnit assertions.
- LambdaTest's updates the test status as "passed" or "failed".



