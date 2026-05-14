using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Simplewebbroswer
{
    public class BrowserBookmark
    {
        public string Name { get; set; }
        public string Url { get; set; }

        // Create a bookmark with a display name and URL
        public BrowserBookmark(string name, string url)
        {
            Name = name;
            Url = url;
        }

        // To display in 1 line as: Name|Url
        public override string ToString()
        {
            return $"{Name}|{Url}";
        }

        // Parse a bookmark from the line format; return null if invalid
        public static BrowserBookmark FromString(string data)
        {
            var parts = data.Split('|');
            if (parts.Length >= 2)
            {
                return new BrowserBookmark(parts[0], parts[1]);
            }
            return null;
        }
    }

    public class BookmarksManager
    {
        // To create list of bookmarks
        private List<BrowserBookmark> bookmarksList = new List<BrowserBookmark>();
        // File where bookmarks are saved
        private readonly string bookmarksFile = "bookmarks.txt";

        // Add a bookmark if the URL is not already saved
        public void AddBookmark(string name, string url)
        {
            TryAddBookmark(name, url, out _);
        }

        // Remove a bookmark by URL
        public void RemoveBookmark(string url)
        {
            bookmarksList.RemoveAll(b => string.Equals(b.Url, url, StringComparison.OrdinalIgnoreCase));
        }

        // Edit a bookmark identified by its current URL
        public void EditBookmark(string oldUrl, string newName, string newUrl)
        {
            var bookmark = bookmarksList.FirstOrDefault(b => string.Equals(b.Url, oldUrl, StringComparison.OrdinalIgnoreCase));
            if (bookmark != null)
            {
                bookmark.Name = newName;
                bookmark.Url = newUrl;
            }
        }

        // Get a copy of the current state of bookmarks list
        public List<BrowserBookmark> GetBookmarks()
        {
            return new List<BrowserBookmark>(bookmarksList);
        }

        // Save bookmarks to a simple text file as a combination of one per line (Name|Url)
        public void SaveBookmarks()
        {
            try
            {
                var lines = bookmarksList.Select(b => b.ToString()).ToArray();
                File.WriteAllLines(bookmarksFile, lines);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving bookmarks: {ex.Message}");
            }
        }

        // Load bookmarks from the text file, if it exists
        public void LoadBookmarks()
        {
            try
            {
                if (File.Exists(bookmarksFile))
                {
                    var lines = File.ReadAllLines(bookmarksFile);
                    bookmarksList = lines.Select(line => BrowserBookmark.FromString(line))
                                     .Where(bookmark => bookmark != null)
                                     .ToList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading bookmarks: {ex.Message}");
                bookmarksList = new List<BrowserBookmark>();
            }
        }

        // Try to add a bookmark which returns true if sucessfully added or false if already present.
        public bool TryAddBookmark(string name, string url, out BrowserBookmark added)
        {
            added = null;
            if (string.IsNullOrWhiteSpace(url)) return false;

            if (bookmarksList.Any(b => string.Equals(b.Url, url, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                name = url;
                try
                {
                    var uri = new Uri(url);
                    name = uri.Host;
                }
                catch { }
            }

            added = new BrowserBookmark(name, url);
            bookmarksList.Add(added);
            return true;
        }
    }
}