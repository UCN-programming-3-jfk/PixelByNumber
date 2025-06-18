using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixelByNumber.WindowsApp;
public partial class NewBitmapForm : Form
{
    public NewBitmapForm()
    {
        InitializeComponent();
    }

    public int Width {
        set { numWidth.Value = value; }
        get { return (int)numWidth.Value; }
    }

    public int Height
    {
        set { numHeight.Value = value; }
        get { return (int)numHeight.Value; }
    }
}