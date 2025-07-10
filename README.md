# Web Automation Framework With Selenium

This repository provides a framework for web test automation using Selenium WebDriver, designed to work with [LambdaTest](https://www.lambdatest.com/). It enables efficient cross-browser testing and supports parallel test execution through NUnit.

---

## 🚀 Features

- **Cross-Browser Testing**: Supports Chrome, Safari, Edge, and Firefox.
- **Integration with LambdaTest Cloud**: Run tests on LambdaTest's cloud infrastructure.
- **Parallel Execution**: Leverage NUnit's ParallelScope for concurrent test execution.
- **Page Object Model**: Structured and maintainable design for better scalability.
- **Configurable Test URLs**: Use `appsettings.json` to define test URLs.

---

## 📋 Prerequisites

Before setting up, ensure the following:

1. **LambdaTest Account**:
   - Create a LambdaTest account [here](https://www.lambdatest.com/).
   - Get your **username** and **access key** from the LambdaTest dashboard.

2. **Gitpod Account**:
   - Register at [Gitpod.io](https://gitpod.io/).
   - Gitpod provides a cloud-based development environment for rapid testing.

---

## 🛠 Setup in Gitpod

### Step 1: Fork and Add Repository
1. **Fork the Repository**:
   - Click on "Fork" in the top-right corner of the repository on GitHub.
2. **Add to Gitpod**:
   - Navigate to your [Gitpod Dashboard](https://gitpod.io/workspaces) → **Add Repository**.
   - Add your forked repository.

### Step 2: Configure Environment Variables
Add your LambdaTest credentials as environment variables in Gitpod:

1. Go to **Repository Settings** → **Environment Variables**.
2. Add the following variables:

| Key              | Value                      |
|-------------------|----------------------------|
| `LT_USERNAME`    | Your LambdaTest username   |
| `LT_ACCESS_KEY`  | Your LambdaTest access key |

These credentials are required for connecting to LambdaTest.

### Step 3: Open the Repository in Gitpod
1. Navigate to the forked repository on GitHub.
2. Launch the Gitpod IDE using the "Gitpod" button (or prefix the URL with `https://gitpod.io/#`).

---

## 🚀 Running Tests

### Default Configuration
When the Gitpod workspace is launched:
- **Dependencies Restored**: `dotnet restore` is automatically executed.
- **Project Built**: `dotnet build` command runs.

### Execute Tests
To run tests:
1. Open the terminal in Gitpod.
2. Run the following command:

```bash
dotnet test
