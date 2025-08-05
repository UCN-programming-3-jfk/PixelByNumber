using PixelByNumber.ClassLibrary;

namespace PixelByNumber.WindowsApp;

public partial class Form1 : Form
{
    private Bitmap bmp;

    public Bitmap Image
    {
        get => bmp;
        set
        {
            bmp = value; textBox1.Text = Image.ToNumberstring();
            UpdateUi();
        }
    }

    public Form1(string fileToOpen = null)
    {
        InitializeComponent();
        if (!String.IsNullOrWhiteSpace(fileToOpen))
        {
            if (!VerifyFile(fileToOpen))
            { return; }
            switch (Path.GetExtension(fileToOpen).ToUpper())
            {
                case ".PBN": Image = File.ReadAllText(fileToOpen).ToBitmap(); break;
                case ".BMP":
                case ".PNG":
                    var bitmap = (Bitmap)Bitmap.FromFile(fileToOpen);
                    Image = bitmap.ToMonoChrome();
                    break;
            }
        }
        else
        {
            NewBitmap(8, 8);
        }
        pictureBox1.Paint += PictureBox1_Paint;
        pictureBox1.MouseDown += (_, e) => PictureBox1_MouseMove(pictureBox1, e);

        textBox1.Text = Image.ToNumberstring();
        textBox1.Select(0, 0);
        button1.Focus();
    }

    private bool VerifyFile(string fileToOpen)
    {
        if (!File.Exists(fileToOpen))
        {
            MessageBox.Show($"File '{fileToOpen}' does not exist", "File not found", MessageBoxButtons.OK);
            return false;
        }

        if (!".PBN.BMP.PNG".Contains(Path.GetExtension(fileToOpen), StringComparison.InvariantCultureIgnoreCase))
        {
            MessageBox.Show($"'{fileToOpen}' is invalid filetype. Only PBN, BMP and PNG files are supported.", "Invalid filetype", MessageBoxButtons.OK);
            return false;
        }
        return true;
    }

    private void NewBitmap(int width, int height)
    {
        var newBmp = new Bitmap(width, height);
        using Graphics g = Graphics.FromImage(newBmp);
        g.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));
        Image = newBmp;

    }

    private void UpdateUi()
    {
        lblHeightInPixels.Text = $"Height in pixels: {Image.Height}";
        lblWidthInPixels.Text = $"Width in pixels: {Image.Width}";
    }

    private void DrawBitmapWithGridlines(PaintEventArgs e)
    {
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

        e.Graphics.DrawImage(bmp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));

        e.Graphics.DrawRectangle(Pens.Blue, 1, 1, pictureBox1.Width - 1, pictureBox1.Height - 1);
        for (int x = 0; x < Image.Width; x++)
        {
            var pixelPosition = x / (float)Image.Width * pictureBox1.Width;
            e.Graphics.DrawLine(Pens.Blue, pixelPosition, 0, pixelPosition, pictureBox1.Height);
        }

        for (int y = 0; y < Image.Height; y++)
        {
            var pixelPosition = y / (float)Image.Height * pictureBox1.Height;
            e.Graphics.DrawLine(Pens.Blue, 0, pixelPosition, pictureBox1.Width, pixelPosition);
        }
    }

    private bool DrawIfNecessary(MouseEventArgs e)
    {
        var x = (e.X / (float)pictureBox1.Width) * Image.Width;
        var y = (e.Y / (float)pictureBox1.Height) * Image.Height;
        if (x < 0 || y < 0 || x >= Image.Width || y >= Image.Height) { return false; }
        bool paint = false;
        Color color = Color.White;
        if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
        {
            color = Color.Black;
            paint = true;
        }
        else if ((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right)
        {
            color = Color.White;
            paint = true;
        }

        if (paint)
        {
            Image.SetPixel((int)x, (int)y, color);
            textBox1.Text = Image.ToNumberstring();
        }
        pictureBox1.Invalidate();
        return true;
    }

    private void TryConvertTextToBitmap()
    {
        try
        {
            pictureBox1.Image = bmp = textBox1.Text.ToBitmap();
            pictureBox1.Invalidate();
            textBox1.BackColor = Color.White;
            UpdateUi();
        }
        catch (Exception ex)
        {
            textBox1.BackColor = Color.Yellow;
        }
    }

    private void NewBitmap()
    {
        NewBitmapForm newBitmapForm = new NewBitmapForm() { Width = Image.Width, Height = Image.Height };

        if (newBitmapForm.ShowDialog(this) == DialogResult.OK)
        {
            NewBitmap(newBitmapForm.Width, newBitmapForm.Height);
        }
    }

    private void SaveFile()
    {
        if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
        {
            File.WriteAllText(saveFileDialog1.FileName, Image.ToNumberstring());
        }
    }


    private void OpenFile()
    {
        if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
        {
            Image = File.ReadAllText(openFileDialog1.FileName).ToBitmap();
            saveFileDialog1.FileName = openFileDialog1.FileName;
        }
    }

    #region Events
    private void PictureBox1_Paint(object? sender, PaintEventArgs e) => DrawBitmapWithGridlines(e);
    private void OpenpbnFileToolStripMenuItem_Click(object sender, EventArgs e) => OpenFile();
    private void PictureBox1_MouseMove(object sender, MouseEventArgs e) => DrawIfNecessary(e);
    private void TextBox1_TextChanged(object sender, EventArgs e) => TryConvertTextToBitmap();
    private void Button1_Click(object sender, EventArgs e) => NewBitmap();
    private void NewBitmapToolStripMenuItem_Click(object sender, EventArgs e) => NewBitmap();
    private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) => SaveFile();
    private void CloseApplicationToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
    #endregion
}