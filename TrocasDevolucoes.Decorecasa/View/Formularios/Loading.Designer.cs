namespace GunaUITestes
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            label_contador = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            progress_indicator = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            label_teste = new Guna.UI2.WinForms.Guna2HtmlLabel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 25;
            guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.TargetControl = this;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // label_contador
            // 
            label_contador.AutoSize = true;
            label_contador.BackColor = Color.Transparent;
            label_contador.Font = new Font("Segoe UI", 15F);
            label_contador.ForeColor = SystemColors.ControlLightLight;
            label_contador.Location = new Point(141, 64);
            label_contador.Name = "label_contador";
            label_contador.Size = new Size(23, 28);
            label_contador.TabIndex = 3;
            label_contador.Text = "0";
            // 
            // timer1
            // 
            timer1.Interval = 75;
            timer1.Tick += timer1_Tick;
            // 
            // progress_indicator
            // 
            progress_indicator.Location = new Point(108, 25);
            progress_indicator.Name = "progress_indicator";
            progress_indicator.ProgressColor = Color.FromArgb(161, 161, 161);
            progress_indicator.ShadowDecoration.CustomizableEdges = customizableEdges1;
            progress_indicator.Size = new Size(113, 137);
            progress_indicator.TabIndex = 1;
            // 
            // label_teste
            // 
            label_teste.BackColor = Color.Transparent;
            label_teste.Font = new Font("Segoe UI", 15F);
            label_teste.ForeColor = Color.White;
            label_teste.Location = new Point(45, 267);
            label_teste.Name = "label_teste";
            label_teste.Size = new Size(3, 2);
            label_teste.TabIndex = 5;
            label_teste.Text = " ";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // Loading
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 33, 33);
            ClientSize = new Size(336, 392);
            Controls.Add(label_teste);
            Controls.Add(label_contador);
            Controls.Add(progress_indicator);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Loading";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "x";
            Load += Loading_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Label label_contador;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator progress_indicator;
        private Guna.UI2.WinForms.Guna2HtmlLabel label_teste;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}