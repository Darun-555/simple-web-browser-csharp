namespace Simplewebbroswer
{
    partial class BrowserUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserUI));
            urlTextBox = new TextBox();
            searchButton = new Button();
            backButton = new Button();
            frontButton = new Button();
            splitContainer1 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            contentPanel = new Panel();
            contentTextBox = new TextBox();
            pageLinkPanel = new Panel();
            linkListBox = new ListBox();
            linksLabel = new Label();
            splitContainer2 = new SplitContainer();
            bookmarkPanel = new Panel();
            bookmarksListBox = new ListBox();
            bookmarksControl = new Panel();
            bookmarksLabel = new Label();
            editButton = new Button();
            deleteButton = new Button();
            panel1 = new Panel();
            bookmarkLinkTextBox = new TextBox();
            addButton = new Button();
            historyPanel = new Panel();
            historyListBox = new ListBox();
            clearHistory = new Button();
            historyLabel = new Label();
            label1 = new Label();
            statusPanel = new Panel();
            responseCodeLabel = new Label();
            statusLabel = new Label();
            homePageButton = new Button();
            reloadButton = new Button();
            setButton = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            contentPanel.SuspendLayout();
            pageLinkPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            bookmarkPanel.SuspendLayout();
            bookmarksControl.SuspendLayout();
            panel1.SuspendLayout();
            historyPanel.SuspendLayout();
            statusPanel.SuspendLayout();
            SuspendLayout();
            // 
            // urlTextBox
            // 
            urlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            urlTextBox.Location = new Point(211, 12);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Size = new Size(1136, 27);
            urlTextBox.TabIndex = 0;
            urlTextBox.Text = "https://";
            // 
            // searchButton
            // 
            searchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchButton.Location = new Point(1353, 11);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(63, 29);
            searchButton.TabIndex = 1;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // backButton
            // 
            backButton.Image = (Image)resources.GetObject("backButton.Image");
            backButton.Location = new Point(12, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(27, 29);
            backButton.TabIndex = 2;
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // frontButton
            // 
            frontButton.Image = (Image)resources.GetObject("frontButton.Image");
            frontButton.Location = new Point(45, 12);
            frontButton.Name = "frontButton";
            frontButton.Size = new Size(24, 29);
            frontButton.TabIndex = 2;
            frontButton.UseVisualStyleBackColor = true;
            frontButton.Click += frontButton_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 97);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1500, 714);
            splitContainer1.SplitterDistance = 876;
            splitContainer1.TabIndex = 6;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(contentPanel);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(pageLinkPanel);
            splitContainer3.Size = new Size(876, 714);
            splitContainer3.SplitterDistance = 529;
            splitContainer3.TabIndex = 14;
            // 
            // contentPanel
            // 
            contentPanel.Controls.Add(contentTextBox);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(529, 714);
            contentPanel.TabIndex = 13;
            // 
            // contentTextBox
            // 
            contentTextBox.Dock = DockStyle.Fill;
            contentTextBox.Location = new Point(0, 0);
            contentTextBox.Multiline = true;
            contentTextBox.Name = "contentTextBox";
            contentTextBox.ReadOnly = true;
            contentTextBox.ScrollBars = ScrollBars.Both;
            contentTextBox.Size = new Size(529, 714);
            contentTextBox.TabIndex = 0;
            contentTextBox.WordWrap = false;
            // 
            // pageLinkPanel
            // 
            pageLinkPanel.Controls.Add(linkListBox);
            pageLinkPanel.Controls.Add(linksLabel);
            pageLinkPanel.Dock = DockStyle.Fill;
            pageLinkPanel.Location = new Point(0, 0);
            pageLinkPanel.Name = "pageLinkPanel";
            pageLinkPanel.Size = new Size(343, 714);
            pageLinkPanel.TabIndex = 12;
            // 
            // linkListBox
            // 
            linkListBox.Dock = DockStyle.Fill;
            linkListBox.FormattingEnabled = true;
            linkListBox.HorizontalScrollbar = true;
            linkListBox.Location = new Point(0, 37);
            linkListBox.Name = "linkListBox";
            linkListBox.Size = new Size(343, 677);
            linkListBox.TabIndex = 14;
            linkListBox.Click += linkListBox_Click;
            // 
            // linksLabel
            // 
            linksLabel.Dock = DockStyle.Top;
            linksLabel.ImageAlign = ContentAlignment.MiddleRight;
            linksLabel.Location = new Point(0, 0);
            linksLabel.Name = "linksLabel";
            linksLabel.Size = new Size(343, 37);
            linksLabel.TabIndex = 13;
            linksLabel.Text = "Page Links";
            linksLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(bookmarkPanel);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(historyPanel);
            splitContainer2.Size = new Size(620, 714);
            splitContainer2.SplitterDistance = 334;
            splitContainer2.TabIndex = 0;
            // 
            // bookmarkPanel
            // 
            bookmarkPanel.Controls.Add(bookmarksListBox);
            bookmarkPanel.Controls.Add(bookmarksControl);
            bookmarkPanel.Controls.Add(panel1);
            bookmarkPanel.Dock = DockStyle.Fill;
            bookmarkPanel.Location = new Point(0, 0);
            bookmarkPanel.Name = "bookmarkPanel";
            bookmarkPanel.Size = new Size(620, 334);
            bookmarkPanel.TabIndex = 0;
            // 
            // bookmarksListBox
            // 
            bookmarksListBox.Dock = DockStyle.Fill;
            bookmarksListBox.FormattingEnabled = true;
            bookmarksListBox.Location = new Point(0, 37);
            bookmarksListBox.Name = "bookmarksListBox";
            bookmarksListBox.Size = new Size(620, 269);
            bookmarksListBox.TabIndex = 2;
            // 
            // bookmarksControl
            // 
            bookmarksControl.Controls.Add(bookmarksLabel);
            bookmarksControl.Controls.Add(editButton);
            bookmarksControl.Controls.Add(deleteButton);
            bookmarksControl.Dock = DockStyle.Top;
            bookmarksControl.Location = new Point(0, 0);
            bookmarksControl.Name = "bookmarksControl";
            bookmarksControl.Size = new Size(620, 37);
            bookmarksControl.TabIndex = 12;
            // 
            // bookmarksLabel
            // 
            bookmarksLabel.Dock = DockStyle.Top;
            bookmarksLabel.Location = new Point(0, 0);
            bookmarksLabel.Name = "bookmarksLabel";
            bookmarksLabel.Size = new Size(468, 37);
            bookmarksLabel.TabIndex = 12;
            bookmarksLabel.Text = "Bookmarks";
            bookmarksLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // editButton
            // 
            editButton.Dock = DockStyle.Right;
            editButton.Location = new Point(468, 0);
            editButton.Name = "editButton";
            editButton.Size = new Size(76, 37);
            editButton.TabIndex = 12;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Dock = DockStyle.Right;
            deleteButton.Location = new Point(544, 0);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(76, 37);
            deleteButton.TabIndex = 14;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(bookmarkLinkTextBox);
            panel1.Controls.Add(addButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 306);
            panel1.Name = "panel1";
            panel1.Size = new Size(620, 28);
            panel1.TabIndex = 13;
            // 
            // bookmarkLinkTextBox
            // 
            bookmarkLinkTextBox.Dock = DockStyle.Fill;
            bookmarkLinkTextBox.Location = new Point(0, 0);
            bookmarkLinkTextBox.Name = "bookmarkLinkTextBox";
            bookmarkLinkTextBox.Size = new Size(568, 27);
            bookmarkLinkTextBox.TabIndex = 4;
            // 
            // addButton
            // 
            addButton.Dock = DockStyle.Right;
            addButton.Location = new Point(568, 0);
            addButton.Name = "addButton";
            addButton.Size = new Size(52, 28);
            addButton.TabIndex = 4;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // historyPanel
            // 
            historyPanel.Controls.Add(historyListBox);
            historyPanel.Controls.Add(clearHistory);
            historyPanel.Controls.Add(historyLabel);
            historyPanel.Dock = DockStyle.Fill;
            historyPanel.Location = new Point(0, 0);
            historyPanel.Name = "historyPanel";
            historyPanel.Size = new Size(620, 376);
            historyPanel.TabIndex = 0;
            // 
            // historyListBox
            // 
            historyListBox.Dock = DockStyle.Fill;
            historyListBox.FormattingEnabled = true;
            historyListBox.Location = new Point(0, 20);
            historyListBox.Name = "historyListBox";
            historyListBox.Size = new Size(620, 326);
            historyListBox.TabIndex = 2;
            historyListBox.DoubleClick += historyListBox_DoubleClick;
            // 
            // clearHistory
            // 
            clearHistory.Dock = DockStyle.Bottom;
            clearHistory.Location = new Point(0, 346);
            clearHistory.Name = "clearHistory";
            clearHistory.Size = new Size(620, 30);
            clearHistory.TabIndex = 3;
            clearHistory.Text = "Clear History";
            clearHistory.UseVisualStyleBackColor = true;
            clearHistory.Click += clearHistory_Click;
            // 
            // historyLabel
            // 
            historyLabel.AutoSize = true;
            historyLabel.Dock = DockStyle.Top;
            historyLabel.Location = new Point(0, 0);
            historyLabel.Name = "historyLabel";
            historyLabel.Size = new Size(56, 20);
            historyLabel.TabIndex = 1;
            historyLabel.Text = "History";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(405, 46);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 7;
            // 
            // statusPanel
            // 
            statusPanel.Controls.Add(responseCodeLabel);
            statusPanel.Controls.Add(statusLabel);
            statusPanel.Location = new Point(12, 45);
            statusPanel.Name = "statusPanel";
            statusPanel.Size = new Size(205, 38);
            statusPanel.TabIndex = 8;
            // 
            // responseCodeLabel
            // 
            responseCodeLabel.Dock = DockStyle.Fill;
            responseCodeLabel.Location = new Point(0, 0);
            responseCodeLabel.Name = "responseCodeLabel";
            responseCodeLabel.Size = new Size(205, 38);
            responseCodeLabel.TabIndex = 10;
            responseCodeLabel.Text = "Ready";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Dock = DockStyle.Fill;
            statusLabel.Location = new Point(0, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(119, 20);
            statusLabel.TabIndex = 9;
            statusLabel.Text = "Status: Loading...";
            // 
            // homePageButton
            // 
            homePageButton.Location = new Point(75, 13);
            homePageButton.Name = "homePageButton";
            homePageButton.Size = new Size(60, 29);
            homePageButton.TabIndex = 9;
            homePageButton.Text = "Home";
            homePageButton.UseVisualStyleBackColor = true;
            homePageButton.Click += homePageButton_Click;
            // 
            // reloadButton
            // 
            reloadButton.Location = new Point(141, 13);
            reloadButton.Name = "reloadButton";
            reloadButton.Size = new Size(64, 29);
            reloadButton.TabIndex = 10;
            reloadButton.Text = "Reload";
            reloadButton.UseVisualStyleBackColor = true;
            reloadButton.Click += reloadButton_Click;
            // 
            // setButton
            // 
            setButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            setButton.AutoSize = true;
            setButton.Location = new Point(1422, 10);
            setButton.Name = "setButton";
            setButton.Size = new Size(63, 30);
            setButton.TabIndex = 11;
            setButton.Text = "Set";
            setButton.UseVisualStyleBackColor = true;
            setButton.Click += setButton_Click;
            // 
            // BrowserUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 811);
            Controls.Add(setButton);
            Controls.Add(reloadButton);
            Controls.Add(homePageButton);
            Controls.Add(statusPanel);
            Controls.Add(label1);
            Controls.Add(splitContainer1);
            Controls.Add(frontButton);
            Controls.Add(backButton);
            Controls.Add(searchButton);
            Controls.Add(urlTextBox);
            Name = "BrowserUI";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            pageLinkPanel.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            bookmarkPanel.ResumeLayout(false);
            bookmarksControl.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            historyPanel.ResumeLayout(false);
            historyPanel.PerformLayout();
            statusPanel.ResumeLayout(false);
            statusPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox urlTextBox;
        private Button searchButton;
        private Button backButton;
        private Button frontButton;
        private SplitContainer splitContainer1;
        private Label label1;
        private Panel statusPanel;
        private Label responseCodeLabel;
        private Label statusLabel;
        private SplitContainer splitContainer2;
        private Panel historyPanel;
        private Button clearHistory;
        private ListBox historyListBox;
        private Label historyLabel;
        private Button homePageButton;
        private Button reloadButton;
        private Button setButton;
        private ListBox linkListBox;
        private Label linksLabel;
        private Panel pageLinkPanel;
        private Panel bookmarkPanel;
        private ListBox bookmarksListBox;
        private Label bookmarksLabel;
        private Panel contentPanel;
        private TextBox contentTextBox;
        private SplitContainer splitContainer3;
        private Button addButton;
        private TextBox bookmarkLinkTextBox;
        private Panel panel1;
        private Button deleteButton;
        private Button editButton;
        private Panel bookmarksControl;
    }
}
