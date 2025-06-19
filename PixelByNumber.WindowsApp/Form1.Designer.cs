namespace PixelByNumber.WindowsApp;

partial class Form1
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
        pictureBox1 = new PictureBox();
        textBox1 = new TextBox();
        lblWidthInPixels = new Label();
        lblHeightInPixels = new Label();
        button1 = new Button();
        label1 = new Label();
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        newBitmapToolStripMenuItem = new ToolStripMenuItem();
        openpbnFileToolStripMenuItem = new ToolStripMenuItem();
        saveAsToolStripMenuItem = new ToolStripMenuItem();
        toolStripMenuItem1 = new ToolStripSeparator();
        closeApplicationToolStripMenuItem = new ToolStripMenuItem();
        saveFileDialog1 = new SaveFileDialog();
        openFileDialog1 = new OpenFileDialog();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(12, 27);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(1024, 1024);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        pictureBox1.MouseMove += PictureBox1_MouseMove;
        // 
        // textBox1
        // 
        textBox1.Font = new Font("Segoe UI", 18F);
        textBox1.Location = new Point(1052, 55);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ScrollBars = ScrollBars.Vertical;
        textBox1.Size = new Size(710, 571);
        textBox1.TabIndex = 1;
        textBox1.TextChanged += TextBox1_TextChanged;
        // 
        // lblWidthInPixels
        // 
        lblWidthInPixels.AutoSize = true;
        lblWidthInPixels.Location = new Point(1052, 640);
        lblWidthInPixels.Name = "lblWidthInPixels";
        lblWidthInPixels.Size = new Size(137, 25);
        lblWidthInPixels.TabIndex = 2;
        lblWidthInPixels.Text = "Width in pixels";
        // 
        // lblHeightInPixels
        // 
        lblHeightInPixels.AutoSize = true;
        lblHeightInPixels.Location = new Point(1052, 674);
        lblHeightInPixels.Name = "lblHeightInPixels";
        lblHeightInPixels.Size = new Size(142, 25);
        lblHeightInPixels.TabIndex = 3;
        lblHeightInPixels.Text = "Height in pixels";
        // 
        // button1
        // 
        button1.Location = new Point(1498, 966);
        button1.Name = "button1";
        button1.Size = new Size(264, 85);
        button1.TabIndex = 4;
        button1.Text = "&New bitmap";
        button1.UseVisualStyleBackColor = true;
        button1.Click += Button1_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(1052, 27);
        label1.Name = "label1";
        label1.Size = new Size(280, 25);
        label1.TabIndex = 5;
        label1.Text = "Pixel by number representation:";
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(24, 24);
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1785, 24);
        menuStrip1.TabIndex = 6;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newBitmapToolStripMenuItem, openpbnFileToolStripMenuItem, saveAsToolStripMenuItem, toolStripMenuItem1, closeApplicationToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "&File";
        // 
        // newBitmapToolStripMenuItem
        // 
        newBitmapToolStripMenuItem.Name = "newBitmapToolStripMenuItem";
        newBitmapToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
        newBitmapToolStripMenuItem.Size = new Size(207, 22);
        newBitmapToolStripMenuItem.Text = "&New bitmap";
        newBitmapToolStripMenuItem.Click += NewBitmapToolStripMenuItem_Click;
        // 
        // openpbnFileToolStripMenuItem
        // 
        openpbnFileToolStripMenuItem.Name = "openpbnFileToolStripMenuItem";
        openpbnFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
        openpbnFileToolStripMenuItem.Size = new Size(207, 22);
        openpbnFileToolStripMenuItem.Text = "&Open *.pbn file";
        openpbnFileToolStripMenuItem.Click += OpenpbnFileToolStripMenuItem_Click;
        // 
        // saveAsToolStripMenuItem
        // 
        saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
        saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        saveAsToolStripMenuItem.Size = new Size(207, 22);
        saveAsToolStripMenuItem.Text = "Save as ...";
        saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new Size(204, 6);
        // 
        // closeApplicationToolStripMenuItem
        // 
        closeApplicationToolStripMenuItem.Name = "closeApplicationToolStripMenuItem";
        closeApplicationToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
        closeApplicationToolStripMenuItem.Size = new Size(207, 22);
        closeApplicationToolStripMenuItem.Text = "Close application";
        closeApplicationToolStripMenuItem.Click += CloseApplicationToolStripMenuItem_Click;
        // 
        // saveFileDialog1
        // 
        saveFileDialog1.Filter = "PBN file|*.pnb";
        // 
        // openFileDialog1
        // 
        openFileDialog1.Filter = "PNB files|*.pnb";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(11F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1785, 1117);
        Controls.Add(label1);
        Controls.Add(button1);
        Controls.Add(lblHeightInPixels);
        Controls.Add(lblWidthInPixels);
        Controls.Add(textBox1);
        Controls.Add(pictureBox1);
        Controls.Add(menuStrip1);
        Font = new Font("Segoe UI", 14F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MainMenuStrip = menuStrip1;
        Margin = new Padding(4, 5, 4, 5);
        Name = "Form1";
        Text = "PixelByNumber app";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private TextBox textBox1;
    private Label lblWidthInPixels;
    private Label lblHeightInPixels;
    private Button button1;
    private Label label1;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem openpbnFileToolStripMenuItem;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem newBitmapToolStripMenuItem;
    private ToolStripMenuItem closeApplicationToolStripMenuItem;
    private SaveFileDialog saveFileDialog1;
    private OpenFileDialog openFileDialog1;
}
