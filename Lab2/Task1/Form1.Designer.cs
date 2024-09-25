namespace Task1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColorButton = new System.Windows.Forms.Button();
            this.ActionBox = new System.Windows.Forms.ComboBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.LoadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LoadPatternDialog = new System.Windows.Forms.OpenFileDialog();
            this.LoadPatternButton = new System.Windows.Forms.Button();
            this.pictureBoxPattern = new System.Windows.Forms.PictureBox();
            this.NewCanvasButton = new System.Windows.Forms.Button();
            this.NewCanvasY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NewCanvasX = new System.Windows.Forms.TextBox();
            this.PenSizeBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPattern)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(960, 540);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            // 
            // ColorButton
            // 
            this.ColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorButton.BackColor = System.Drawing.Color.Black;
            this.ColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorButton.Location = new System.Drawing.Point(978, 39);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(120, 23);
            this.ColorButton.TabIndex = 1;
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // ActionBox
            // 
            this.ActionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ActionBox.FormattingEnabled = true;
            this.ActionBox.Items.AddRange(new object[] {
            "Draw",
            "FillColor",
            "FillImage",
            "DrawBorder"});
            this.ActionBox.Location = new System.Drawing.Point(978, 12);
            this.ActionBox.Name = "ActionBox";
            this.ActionBox.Size = new System.Drawing.Size(120, 21);
            this.ActionBox.TabIndex = 2;
            this.ActionBox.Text = "Draw";
            this.ActionBox.SelectedIndexChanged += new System.EventHandler(this.ActionBox_SelectedIndexChanged);
            // 
            // LoadButton
            // 
            this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadButton.Location = new System.Drawing.Point(979, 528);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(119, 23);
            this.LoadButton.TabIndex = 3;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // LoadFileDialog
            // 
            this.LoadFileDialog.FileName = "openFileDialog1";
            // 
            // LoadPatternDialog
            // 
            this.LoadPatternDialog.FileName = "openFileDialog2";
            // 
            // LoadPatternButton
            // 
            this.LoadPatternButton.Enabled = false;
            this.LoadPatternButton.Location = new System.Drawing.Point(978, 39);
            this.LoadPatternButton.Name = "LoadPatternButton";
            this.LoadPatternButton.Size = new System.Drawing.Size(120, 23);
            this.LoadPatternButton.TabIndex = 4;
            this.LoadPatternButton.Text = "Load Pattern";
            this.LoadPatternButton.UseVisualStyleBackColor = true;
            this.LoadPatternButton.Visible = false;
            this.LoadPatternButton.Click += new System.EventHandler(this.LoadPatternButton_Click);
            // 
            // pictureBoxPattern
            // 
            this.pictureBoxPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPattern.Enabled = false;
            this.pictureBoxPattern.Location = new System.Drawing.Point(979, 68);
            this.pictureBoxPattern.Name = "pictureBoxPattern";
            this.pictureBoxPattern.Size = new System.Drawing.Size(119, 67);
            this.pictureBoxPattern.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPattern.TabIndex = 5;
            this.pictureBoxPattern.TabStop = false;
            this.pictureBoxPattern.Visible = false;
            // 
            // NewCanvasButton
            // 
            this.NewCanvasButton.Location = new System.Drawing.Point(979, 499);
            this.NewCanvasButton.Name = "NewCanvasButton";
            this.NewCanvasButton.Size = new System.Drawing.Size(119, 23);
            this.NewCanvasButton.TabIndex = 6;
            this.NewCanvasButton.Text = "New canvas";
            this.NewCanvasButton.UseVisualStyleBackColor = true;
            this.NewCanvasButton.Click += new System.EventHandler(this.NewCanvasButton_Click);
            // 
            // NewCanvasY
            // 
            this.NewCanvasY.Location = new System.Drawing.Point(997, 473);
            this.NewCanvasY.Name = "NewCanvasY";
            this.NewCanvasY.Size = new System.Drawing.Size(101, 20);
            this.NewCanvasY.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(978, 476);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(978, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "X";
            // 
            // NewCanvasX
            // 
            this.NewCanvasX.Location = new System.Drawing.Point(997, 447);
            this.NewCanvasX.Name = "NewCanvasX";
            this.NewCanvasX.Size = new System.Drawing.Size(101, 20);
            this.NewCanvasX.TabIndex = 9;
            // 
            // PenSizeBox
            // 
            this.PenSizeBox.Location = new System.Drawing.Point(979, 68);
            this.PenSizeBox.Name = "PenSizeBox";
            this.PenSizeBox.Size = new System.Drawing.Size(100, 20);
            this.PenSizeBox.TabIndex = 11;
            this.PenSizeBox.Text = "1";
            this.PenSizeBox.TextChanged += new System.EventHandler(this.PenSizeBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 564);
            this.Controls.Add(this.PenSizeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NewCanvasX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewCanvasY);
            this.Controls.Add(this.NewCanvasButton);
            this.Controls.Add(this.pictureBoxPattern);
            this.Controls.Add(this.LoadPatternButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.ActionBox);
            this.Controls.Add(this.ColorButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPattern)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.ComboBox ActionBox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.OpenFileDialog LoadFileDialog;
        private System.Windows.Forms.OpenFileDialog LoadPatternDialog;
        private System.Windows.Forms.Button LoadPatternButton;
        private System.Windows.Forms.PictureBox pictureBoxPattern;
        private System.Windows.Forms.Button NewCanvasButton;
        private System.Windows.Forms.TextBox NewCanvasY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NewCanvasX;
        private System.Windows.Forms.TextBox PenSizeBox;
    }
}

