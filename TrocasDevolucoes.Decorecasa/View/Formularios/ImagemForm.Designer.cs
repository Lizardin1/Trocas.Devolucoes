namespace TrocasDevolucoes.Decorecasa.View.Formularios
{
    partial class ImagemForm
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            pb_img1 = new Guna.UI2.WinForms.Guna2PictureBox();
            pb_img2 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_img1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_img2).BeginInit();
            SuspendLayout();
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.CustomizableEdges = customizableEdges1;
            guna2ControlBox1.FillColor = Color.FromArgb(33, 33, 33);
            guna2ControlBox1.IconColor = Color.FromArgb(161, 161, 161);
            guna2ControlBox1.Location = new Point(855, -1);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ControlBox1.Size = new Size(45, 29);
            guna2ControlBox1.TabIndex = 0;
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.TargetControl = this;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // pb_img1
            // 
            pb_img1.BorderStyle = BorderStyle.FixedSingle;
            pb_img1.CustomizableEdges = customizableEdges5;
            pb_img1.FillColor = Color.FromArgb(33, 33, 33);
            pb_img1.ImageRotate = 0F;
            pb_img1.Location = new Point(12, 12);
            pb_img1.Name = "pb_img1";
            pb_img1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pb_img1.Size = new Size(412, 412);
            pb_img1.SizeMode = PictureBoxSizeMode.Zoom;
            pb_img1.TabIndex = 1;
            pb_img1.TabStop = false;
            // 
            // pb_img2
            // 
            pb_img2.BorderStyle = BorderStyle.FixedSingle;
            pb_img2.CustomizableEdges = customizableEdges3;
            pb_img2.FillColor = Color.FromArgb(33, 33, 33);
            pb_img2.ImageRotate = 0F;
            pb_img2.Location = new Point(440, 12);
            pb_img2.Name = "pb_img2";
            pb_img2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pb_img2.Size = new Size(412, 412);
            pb_img2.SizeMode = PictureBoxSizeMode.Zoom;
            pb_img2.TabIndex = 2;
            pb_img2.TabStop = false;
            // 
            // ImagemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 33, 33);
            ClientSize = new Size(898, 437);
            Controls.Add(pb_img2);
            Controls.Add(pb_img1);
            Controls.Add(guna2ControlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ImagemForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ImagemForm";
            ((System.ComponentModel.ISupportInitialize)pb_img1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_img2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2PictureBox pb_img2;
        private Guna.UI2.WinForms.Guna2PictureBox pb_img1;
    }
}