using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Simplewebbroswer;

public class BrowserHistory
{
    private List<string> history = new List<string>();
    private int currentIndex = -1;
    private readonly string historyFile = "history.txt";

    // Delegate for navigation methods returning string URLs
    public delegate string NavigationHandler();

    // Delegate instance to hold current navigation action
    private NavigationHandler navigation;

    // Append a URL to history if it's not a duplicate of the last entry
    public void AddUrl(string url)
    {
        string normalizedUrl;
        if (string.IsNullOrWhiteSpace(url)) 
        return;
        try
        {
            Uri uri = new Uri(url);
            normalizedUrl = uri.GetLeftPart(UriPartial.Path).TrimEnd('/');
        }
        catch
        {
            normalizedUrl = url.Trim().TrimEnd('/');
        }
        if (history.Count == 0 || !string.Equals(history[history.Count - 1], normalizedUrl, StringComparison.OrdinalIgnoreCase))
        {
            history.Add(normalizedUrl);
            currentIndex = history.Count - 1;
        }
    }

    // Move back one step in history and return that URL, if possible
    public string GoBack()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            return history[currentIndex];
        }
        return null;
    }

    // Move forward one step in history and return that URL, if possible
    public string GoForward()
    {
        if (currentIndex < history.Count - 1)
        {
            currentIndex++;
            return history[currentIndex];
        }
        return null;
    }

    // Unified navigation method using delegate and switch
    public string Navigate(string input)
    {
        switch (input.ToLower())
        {
            case "back":
                navigation = GoBack;
                break;
            case "forward":
                navigation = GoForward;
                break;
            default:
                throw new ArgumentException("Invalid navigation direction. Use 'back' or 'forward'.");
        }
        return navigation();
    }

    // Return a copy of the entire history list
    public List<string> GetHistory()
    {
        return new List<string>(history);
    }

    // Clear history and reset the pointer
    public void Clear()
    {
        history.Clear();
        currentIndex = -1;
    }

    //To know the pointer position
    public int CurrentIndex
    {
        get { return currentIndex; }
    }

    // Jump to a specific index in the history and return that URL, if valid
    public string JumpToIndex(int index)
    {
        if (index >= 0 && index < history.Count)
        {
            currentIndex = index;
            return history[currentIndex];
        }
        return null;
    }

    // To save the history to a simple text file
    public void SaveHistory()
    {
        try
        {
            File.WriteAllLines(historyFile, history);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error saving history: {ex.Message}");
        }
    }

    // To load history from txt file if present and set pointer to last item
    public void LoadHistory()
    {
        try
        {
            if (File.Exists(historyFile))
            {
                history = File.ReadAllLines(historyFile).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
                currentIndex = history.Count - 1;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading history: {ex.Message}");
            history = new List<string>();
        }
    }
}