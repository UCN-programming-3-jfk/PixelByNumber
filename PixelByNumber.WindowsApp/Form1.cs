using Microsoft.VisualBasic.Devices;
using PixelByNumber.ClassLibrary;

namespace PixelByNumber.WindowsApp;

public partial class Form1 : Form
{
    Bitmap bmp = new Bitmap(8, 8);
    public Form1()
    {
        InitializeComponent();

        using Graphics g = Graphics.FromImage(bmp);
        g.FillRectangle(Brushes.White, new Rectangle(0, 0, 8, 8));

        pictureBox1.Paint += PictureBox1_Paint;
        pictureBox1.MouseDown += pictureBox1_MouseMove;
        UpdateUi();
        textBox1.Text = bmp.ToNumberstring();
        textBox1.Select(0, 0);
        button1.Focus();
    }

    private void UpdateUi()
    {
        lblHeightInPixels.Text = $"Height in pixels: {bmp.Height}";
        lblWidthInPixels.Text = $"Width in pixels: {bmp.Width}";
       
    }

    private void PictureBox1_Paint(object? sender, PaintEventArgs e)
    {
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

        e.Graphics.DrawImage(bmp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
        var verticalLineInterval = pictureBox1.Width / bmp.Width; ;
        var horizontalLineInterval = pictureBox1.Width / bmp.Width;
        for (int x = 0; x < bmp.Width; x++)
        {
            e.Graphics.DrawLine(Pens.Blue, verticalLineInterval * x, 0, verticalLineInterval * x, pictureBox1.Height);
        }

        for (int y = 0; y < bmp.Height; y++)
        {
            e.Graphics.DrawLine(Pens.Blue, 0, horizontalLineInterval * y, pictureBox1.Width, horizontalLineInterval * y);
        }
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        var x = (e.X / (float)pictureBox1.Width) * bmp.Width;
        var y = (e.Y / (float)pictureBox1.Height) * bmp.Height;
        if (x < 0 || y < 0 || x >= bmp.Width || y >= bmp.Height) { return; }
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
            bmp.SetPixel((int)x, (int)y, color);
            textBox1.Text = bmp.ToNumberstring();
        }
        pictureBox1.Invalidate();
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
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
            textBox1.BackColor= Color.Yellow;
        }
    }
}
