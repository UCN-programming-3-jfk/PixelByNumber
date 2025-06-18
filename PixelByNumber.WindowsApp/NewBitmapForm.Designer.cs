namespace PixelByNumber.WindowsApp
{
    partial class NewBitmapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            numWidth = new NumericUpDown();
            numHeight = new NumericUpDown();
            btnAccept = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(91, 38);
            label1.TabIndex = 0;
            label1.Text = "Width";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 87);
            label2.Name = "label2";
            label2.Size = new Size(100, 38);
            label2.TabIndex = 1;
            label2.Text = "Height";
            // 
            // numWidth
            // 
            numWidth.Location = new Point(153, 20);
            numWidth.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            numWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numWidth.Name = "numWidth";
            numWidth.Size = new Size(180, 45);
            numWidth.TabIndex = 2;
            numWidth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numHeight
            // 
            numHeight.Location = new Point(153, 87);
            numHeight.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            numHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numHeight.Name = "numHeight";
            numHeight.Size = new Size(180, 45);
            numHeight.TabIndex = 3;
            numHeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAccept
            // 
            btnAccept.DialogResult = DialogResult.OK;
            btnAccept.Location = new Point(206, 166);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(127, 65);
            btnAccept.TabIndex = 4;
            btnAccept.Text = "&Accept";
            btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(33, 166);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 65);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // NewBitmapForm
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(15F, 38F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(357, 245);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(numHeight);
            Controls.Add(numWidth);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 5, 4, 5);
            Name = "NewBitmapForm";
            Text = "New bitmap";
            ((System.ComponentModel.ISupportInitialize)numWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown numWidth;
        private NumericUpDown numHeight;
        private Button btnAccept;
        private Button btnCancel;
    }
}