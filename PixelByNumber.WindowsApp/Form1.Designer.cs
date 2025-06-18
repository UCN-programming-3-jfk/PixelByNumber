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
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(12, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(1024, 1024);
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        pictureBox1.MouseMove += pictureBox1_MouseMove;
        // 
        // textBox1
        // 
        textBox1.Font = new Font("Segoe UI", 18F);
        textBox1.Location = new Point(1061, 50);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ScrollBars = ScrollBars.Vertical;
        textBox1.Size = new Size(710, 571);
        textBox1.TabIndex = 1;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // lblWidthInPixels
        // 
        lblWidthInPixels.AutoSize = true;
        lblWidthInPixels.Location = new Point(1061, 653);
        lblWidthInPixels.Name = "lblWidthInPixels";
        lblWidthInPixels.Size = new Size(200, 38);
        lblWidthInPixels.TabIndex = 2;
        lblWidthInPixels.Text = "Width in pixels";
        // 
        // lblHeightInPixels
        // 
        lblHeightInPixels.AutoSize = true;
        lblHeightInPixels.Location = new Point(1061, 703);
        lblHeightInPixels.Name = "lblHeightInPixels";
        lblHeightInPixels.Size = new Size(209, 38);
        lblHeightInPixels.TabIndex = 3;
        lblHeightInPixels.Text = "Height in pixels";
        // 
        // button1
        // 
        button1.Location = new Point(1507, 951);
        button1.Name = "button1";
        button1.Size = new Size(264, 85);
        button1.TabIndex = 4;
        button1.Text = "&New bitmap";
        button1.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(1061, 9);
        label1.Name = "label1";
        label1.Size = new Size(412, 38);
        label1.TabIndex = 5;
        label1.Text = "Pixel by number representation:";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(15F, 38F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1785, 1048);
        Controls.Add(label1);
        Controls.Add(button1);
        Controls.Add(lblHeightInPixels);
        Controls.Add(lblWidthInPixels);
        Controls.Add(textBox1);
        Controls.Add(pictureBox1);
        Font = new Font("Segoe UI", 14F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(4, 5, 4, 5);
        Name = "Form1";
        Text = "PixelByNumber app";
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
}
