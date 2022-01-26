﻿using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightStarterConsoleApp
{
  class Program
  {
    static async Task Main()
    {
      using var playwright = await Playwright.CreateAsync();
      await using var browser = await playwright.Chromium.LaunchAsync();
      var page = await browser.NewPageAsync();
      await page.GotoAsync("https://playwright.dev/dotnet");
      await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot.png" });
    }
  }
}
