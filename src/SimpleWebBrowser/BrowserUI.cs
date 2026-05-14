using HtmlAgilityPack;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Simplewebbroswer
{

    public partial class BrowserUI : Form
    {
        private HttpClient httpClient;
        private BrowserHistory history;
        private BookmarksManager bookmarks;
        private readonly string homepagefile = "homepage.txt";
        private string currentUrl;
        private string homePageUrl = "https://www.hw.ac.uk";
        private bool isNavigatingHistory;

        public BrowserUI()
        {
            InitializeComponent();
            InitializeBrowser();
        }

        // Set up HTTP client, load history/bookmarks, and navigate to start page
        private void InitializeBrowser()
        {
            // Initialize HTTP client
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");

            // Initialize managers
            history = new BrowserHistory();
            history.LoadHistory();
            bookmarks = new BookmarksManager();
            bookmarks.LoadBookmarks();

            // Populate lists
            UpdateHistoryList();
            UpdateBookmarksList();
            LoadHomePage();

            // Navigate to home page
            NavigateToUrl(homePageUrl, true);
        }

        // To load the hoempage URL from the text file
        public void LoadHomePage()
        {
            try
            {
                if (File.Exists(homepagefile))
                {
                    var text = File.ReadAllText(homepagefile);
                    homePageUrl = text;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading homepage: {ex.Message}");
            }
        }



        // Searches the URL, display the html content, update status, and optionally add to history
        private async void NavigateToUrl(string url, bool addToHistory = true)
        {
            try
            {
                statusLabel.Text = "Status: Loading...";
                responseCodeLabel.Text = "Loading...";

                // Ensure URL has protocol
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }

                currentUrl = url;
                urlTextBox.Text = url;

                // Send HTTP request
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // To update the title of windows forms with status code.
                this.Text = $"Status {(int)response.StatusCode} {response.StatusCode} - Simple Web Browser";

                // Update status
                responseCodeLabel.Text = $"Status: {(int)response.StatusCode} {response.StatusCode}";

                // Handle different status codes
                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = GetErrorMessage(response.StatusCode);
                    contentTextBox.Text = $"HTTP Error {(int)response.StatusCode}: {response.StatusCode}\n\n{errorMessage}";
                    statusLabel.Text = $"Error: {response.StatusCode}";
                    return;
                }

                // Get response content
                string content = await response.Content.ReadAsStringAsync();
                contentTextBox.Text = content;

                // Add to history
                if (addToHistory && !isNavigatingHistory)
                {
                    history.AddUrl(url);
                    UpdateHistoryList();
                    historyListBox.SelectedIndex = history.GetHistory().Count - 1;
                    history.SaveHistory();
                }


                string title = PageTitle(content);
                this.Text = $"{responseCodeLabel.Text}  {title} - Simple Web Browser";

                // Harvest URLs
                HarvestUrls(content);

            }
            catch (Exception ex)
            {
                contentTextBox.Text = $"Error: {ex.Message}";
                statusLabel.Text = "Error loading page";
                responseCodeLabel.Text = "Status: Error";
                this.Text = $"Error ({ex.GetType().Name}) - Simple Web Browser";
            }
        }

        // Return a friendly error description for common HTTP status codes
        private string GetErrorMessage(System.Net.HttpStatusCode statusCode)
        {
            return statusCode switch
            {
                System.Net.HttpStatusCode.BadRequest => "400 Bad Request: The server cannot process the request due to client error.",
                System.Net.HttpStatusCode.Forbidden => "403 Forbidden: You don't have permission to access this resource.",
                System.Net.HttpStatusCode.NotFound => "404 Not Found: The requested resource was not found on the server.",
                _ => $"HTTP Error {(int)statusCode}: {statusCode}"
            };
        }

        // Refresh the UI list with current browsing history
        private void UpdateHistoryList()
        {
            historyListBox.Items.Clear();
            foreach (var item in history.GetHistory())
            {
                historyListBox.Items.Add(item);
            }
        }

        // Handle Search button click function to search the URL entered in the textbox
        private void searchButton_Click(object sender, EventArgs e)
        {
            NavigateToUrl(urlTextBox.Text, true);
        }

        // Form load: wire runtime events (non-designer)
        private void Form1_Load(object sender, EventArgs e)
        {
            // Wire runtime-only events
            bookmarksListBox.DoubleClick += bookmarksListBox_DoubleClick;
        }

        // Clear history list and save
        private void clearHistory_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(this, $"Delete all history ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            history.Clear();
            UpdateHistoryList();
            history.SaveHistory();
        }

        // Go Back in history if possible
        private void backButton_Click(object sender, EventArgs e)
        {
            var backUrl = history.Navigate("back");
            if (backUrl != null)
            {
                isNavigatingHistory = true;
                NavigateToUrl(backUrl, false);
                // Keep UI selection aligned with current history index
                var id = history.CurrentIndex;
                if (id >= 0 && id < historyListBox.Items.Count)
                {
                    historyListBox.SelectedIndex = id;
                }
                isNavigatingHistory = false;
            }
        }

        // Go Forward in history if possible
        private void frontButton_Click(object sender, EventArgs e)
        {
            var fwdUrl = history.Navigate("forward");
            if (fwdUrl != null)
            {
                isNavigatingHistory = true;
                NavigateToUrl(fwdUrl, false);
                // To keep UI selection aligned with current history index
                var id = history.CurrentIndex;
                if (id >= 0 && id < historyListBox.Items.Count)
                {
                    historyListBox.SelectedIndex = id;
                }
                isNavigatingHistory = false;
            }
        }

        // Navigate to the double-clicked Url in the history list
        private void historyListBox_DoubleClick(object sender, EventArgs e)
        {
            var index = historyListBox.SelectedIndex;
            if (index >= 0)
            {
                var targetUrl = history.JumpToIndex(index);
                if (!string.IsNullOrEmpty(targetUrl))
                {
                    isNavigatingHistory = true;
                    NavigateToUrl(targetUrl, false);
                    isNavigatingHistory = false;
                }
            }
        }

        // On close saves the history and bookmarks
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            history.SaveHistory();
            bookmarks.SaveBookmarks();
            SaveHomePage();

        }


        //To save the homepage file
        public void SaveHomePage()
        {
            try
            {
                File.WriteAllText( homepagefile, homePageUrl);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving homepage: {ex.Message}");
            }
        }



        // Open home page settings dialog and update the home URL
        private void setButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new HomepageReset())
            {
                dialog.HomePageUrlSetter = homePageUrl;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    var newUrl = dialog.HomePageUrlSetter;
                    if (!string.IsNullOrWhiteSpace(newUrl))
                    {
                        homePageUrl = newUrl;
                    }
                    NavigateToUrl(homePageUrl, true);
                }
            }
        }


        // Reload the current page
        private void reloadButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentUrl))
            {
                NavigateToUrl(currentUrl);
            }
        }

        // Navigates to the set home page
        private void homePageButton_Click(object sender, EventArgs e)
        {
            NavigateToUrl(homePageUrl, true);
        }

        // To extract title using <title> tag content from the HTML code
        private string PageTitle(string html)
        {
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(html);

        var titleNode = doc.DocumentNode.SelectSingleNode("//title");
        return titleNode != null ? titleNode.InnerText.Trim() : "Untitled Page";
        }



        // Extracts 5 absolute/relative links from HTML and show in listbox
        private void HarvestUrls(string htmlContent)
        {
            linkListBox.Items.Clear();

            try
            {
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(htmlContent);

                // Select the first five <a> tags that have an href attribute
                var anchorNodes = htmlDoc.DocumentNode.SelectNodes("//a[@href]")
                                        ?.Take(5);

                if (anchorNodes == null)
                    return;

                foreach (var node in anchorNodes)
                {
                    string href = node.GetAttributeValue("href", "");

                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Convert relative URLs to absolute ones
                    if (href.StartsWith("/"))
                    {
                        try
                        {
                            Uri baseUri = new Uri(currentUrl);
                            Uri fullUri = new Uri(baseUri, href);
                            href = fullUri.ToString();
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    // Only add valid HTTP/HTTPS URLs
                    if (href.StartsWith("http://") || href.StartsWith("https://"))
                    {
                        linkListBox.Items.Add(href);
                    }
                }
            }
            catch (Exception ex)
            {
                linkListBox.Items.Add($"Error parsing links: {ex.Message}");
            }
        }



        // Navigate to a link when clicked in the links list
        private void linkListBox_Click(object sender, EventArgs e)
            {
                if (linkListBox.SelectedItem != null)
                {
                    string url = linkListBox.SelectedItem.ToString();
                    NavigateToUrl(url);
                }
            }


        // Add a bookmark using textbox and save
        private void addButton_Click(object sender, EventArgs e)
        {
            // To assign the target URL from the text if entered, otherwise uses current page URL
            var url = bookmarkLinkTextBox.Text;
            if (string.IsNullOrWhiteSpace(url))
            {
                url = currentUrl;
            }

            if (string.IsNullOrWhiteSpace(url))
            {
                statusLabel.Text = "No URL to bookmark";
                return;
            }

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }

            // Generate a simple name from host
            string name = url;
            try
            {
                var uri = new Uri(url);
                name = uri.Host;
            }
            catch { }

            bookmarks.AddBookmark(name, url);
            UpdateBookmarksList();
            bookmarks.SaveBookmarks();
            bookmarkLinkTextBox.Clear();
            statusLabel.Text = "Bookmark added";
        }

        // Updates the listbox in the UI with current bookmarks
        private void UpdateBookmarksList()
        {
            bookmarksListBox.Items.Clear();
            foreach (var bm in bookmarks.GetBookmarks())
            {
                bookmarksListBox.Items.Add(bm.ToString());
            }
        }

        // Double-clicking a bookmark navigates to its URL
        private void bookmarksListBox_DoubleClick(object sender, EventArgs e)
        {
            if (bookmarksListBox.SelectedItem == null) return;
            var data = bookmarksListBox.SelectedItem.ToString();
            var bm = BrowserBookmark.FromString(data);
            if (bm != null && !string.IsNullOrWhiteSpace(bm.Url))
            {
                NavigateToUrl(bm.Url);
            }
        }

        // Deleting a bookmark
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (bookmarksListBox.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a bookmark to delete.", "Delete Bookmark", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var data = bookmarksListBox.SelectedItem.ToString();
            var bm = BrowserBookmark.FromString(data);
            if (bm == null || string.IsNullOrWhiteSpace(bm.Url))
            {
                MessageBox.Show(this, "Invalid bookmark selection.", "Delete Bookmark", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(this, $"Delete bookmark '{bm.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            bookmarks.RemoveBookmark(bm.Url);
            UpdateBookmarksList();
            bookmarks.SaveBookmarks();
            statusLabel.Text = "Bookmark deleted";
        }

        // Editing the selected bookmark through the BookmarkEdit dialog and save it
        private void editButton_Click(object sender, EventArgs e)
        {
            if (bookmarksListBox.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a bookmark to edit.", "Edit Bookmark", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var data = bookmarksListBox.SelectedItem.ToString();
            var bm = BrowserBookmark.FromString(data);
            if (bm == null)
            {
                MessageBox.Show(this, "Invalid bookmark format.", "Edit Bookmark", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dlg = new BookmarkEdit())
            {
                dlg.SetBookmark(bm.Name, bm.Url);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    bookmarks.EditBookmark(bm.Url, dlg.EditedName, dlg.EditedUrl);
                    UpdateBookmarksList();
                    bookmarks.SaveBookmarks();
                    statusLabel.Text = "Bookmark updated";
                }
            }
        }
    }
}






