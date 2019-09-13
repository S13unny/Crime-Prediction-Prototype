namespace Crime_Preditction_Prototype__With_Form_
{
    partial class Form1
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
            this.analyse_Button = new System.Windows.Forms.Button();
            this.output_Box = new System.Windows.Forms.RichTextBox();
            this.latitude1 = new System.Windows.Forms.TextBox();
            this.longitude1 = new System.Windows.Forms.TextBox();
            this.latitude2 = new System.Windows.Forms.TextBox();
            this.longitude2 = new System.Windows.Forms.TextBox();
            this.latitude1_Label = new System.Windows.Forms.Label();
            this.longitude1_Label = new System.Windows.Forms.Label();
            this.latitude2_Label = new System.Windows.Forms.Label();
            this.longitude2_Label = new System.Windows.Forms.Label();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.longitude3 = new System.Windows.Forms.TextBox();
            this.latitude3 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // analyse_Button
            // 
            this.analyse_Button.Location = new System.Drawing.Point(1116, 475);
            this.analyse_Button.Name = "analyse_Button";
            this.analyse_Button.Size = new System.Drawing.Size(75, 35);
            this.analyse_Button.TabIndex = 0;
            this.analyse_Button.Text = "Analyse";
            this.analyse_Button.UseVisualStyleBackColor = true;
            this.analyse_Button.Click += new System.EventHandler(this.Analyse_Button_Click);
            // 
            // output_Box
            // 
            this.output_Box.Location = new System.Drawing.Point(41, 24);
            this.output_Box.Name = "output_Box";
            this.output_Box.Size = new System.Drawing.Size(858, 107);
            this.output_Box.TabIndex = 1;
            this.output_Box.Text = "";
            // 
            // latitude1
            // 
            this.latitude1.Location = new System.Drawing.Point(953, 21);
            this.latitude1.Name = "latitude1";
            this.latitude1.Size = new System.Drawing.Size(169, 22);
            this.latitude1.TabIndex = 2;
            this.latitude1.TextChanged += new System.EventHandler(this.textBox_Changed);
            // 
            // longitude1
            // 
            this.longitude1.Location = new System.Drawing.Point(953, 49);
            this.longitude1.Name = "longitude1";
            this.longitude1.Size = new System.Drawing.Size(169, 22);
            this.longitude1.TabIndex = 3;
            this.longitude1.TextChanged += new System.EventHandler(this.textBox_Changed);
            // 
            // latitude2
            // 
            this.latitude2.Location = new System.Drawing.Point(953, 115);
            this.latitude2.Name = "latitude2";
            this.latitude2.Size = new System.Drawing.Size(169, 22);
            this.latitude2.TabIndex = 4;
            this.latitude2.TextChanged += new System.EventHandler(this.textBox_Changed);
            // 
            // longitude2
            // 
            this.longitude2.Location = new System.Drawing.Point(953, 143);
            this.longitude2.Name = "longitude2";
            this.longitude2.Size = new System.Drawing.Size(169, 22);
            this.longitude2.TabIndex = 5;
            this.longitude2.TextChanged += new System.EventHandler(this.textBox_Changed);
            // 
            // latitude1_Label
            // 
            this.latitude1_Label.AutoSize = true;
            this.latitude1_Label.Location = new System.Drawing.Point(1132, 20);
            this.latitude1_Label.Name = "latitude1_Label";
            this.latitude1_Label.Size = new System.Drawing.Size(71, 17);
            this.latitude1_Label.TabIndex = 6;
            this.latitude1_Label.Text = "Latitude 1";
            // 
            // longitude1_Label
            // 
            this.longitude1_Label.AutoSize = true;
            this.longitude1_Label.Location = new System.Drawing.Point(1132, 49);
            this.longitude1_Label.Name = "longitude1_Label";
            this.longitude1_Label.Size = new System.Drawing.Size(83, 17);
            this.longitude1_Label.TabIndex = 7;
            this.longitude1_Label.Text = "Longitude 1";
            // 
            // latitude2_Label
            // 
            this.latitude2_Label.AutoSize = true;
            this.latitude2_Label.Location = new System.Drawing.Point(1132, 115);
            this.latitude2_Label.Name = "latitude2_Label";
            this.latitude2_Label.Size = new System.Drawing.Size(71, 17);
            this.latitude2_Label.TabIndex = 8;
            this.latitude2_Label.Text = "Latitude 2";
            // 
            // longitude2_Label
            // 
            this.longitude2_Label.AutoSize = true;
            this.longitude2_Label.Location = new System.Drawing.Point(1132, 143);
            this.longitude2_Label.Name = "longitude2_Label";
            this.longitude2_Label.Size = new System.Drawing.Size(83, 17);
            this.longitude2_Label.TabIndex = 9;
            this.longitude2_Label.Text = "Longitude 2";
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(41, 143);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(858, 386);
            this.gmap.TabIndex = 10;
            this.gmap.Zoom = 4D;
            this.gmap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gm1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1132, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Longitude 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1132, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Latitude 3";
            // 
            // longitude3
            // 
            this.longitude3.Location = new System.Drawing.Point(953, 244);
            this.longitude3.Name = "longitude3";
            this.longitude3.Size = new System.Drawing.Size(169, 22);
            this.longitude3.TabIndex = 12;
            this.longitude3.TextChanged += new System.EventHandler(this.textBox_Changed);
            // 
            // latitude3
            // 
            this.latitude3.Location = new System.Drawing.Point(953, 216);
            this.latitude3.Name = "latitude3";
            this.latitude3.Size = new System.Drawing.Size(169, 22);
            this.latitude3.TabIndex = 11;
            this.latitude3.TextChanged += new System.EventHandler(this.textBox_Changed);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(919, 37);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(17, 16);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(919, 131);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(17, 16);
            this.radioButton2.TabIndex = 16;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(919, 231);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(17, 16);
            this.radioButton3.TabIndex = 17;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(919, 329);
            this.progressBar1.Maximum = 48;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(272, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 561);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.longitude3);
            this.Controls.Add(this.latitude3);
            this.Controls.Add(this.gmap);
            this.Controls.Add(this.longitude2_Label);
            this.Controls.Add(this.latitude2_Label);
            this.Controls.Add(this.longitude1_Label);
            this.Controls.Add(this.latitude1_Label);
            this.Controls.Add(this.longitude2);
            this.Controls.Add(this.latitude2);
            this.Controls.Add(this.longitude1);
            this.Controls.Add(this.latitude1);
            this.Controls.Add(this.output_Box);
            this.Controls.Add(this.analyse_Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button analyse_Button;
        private System.Windows.Forms.RichTextBox output_Box;
        private System.Windows.Forms.TextBox latitude1;
        private System.Windows.Forms.TextBox longitude1;
        private System.Windows.Forms.TextBox latitude2;
        private System.Windows.Forms.TextBox longitude2;
        private System.Windows.Forms.Label latitude1_Label;
        private System.Windows.Forms.Label longitude1_Label;
        private System.Windows.Forms.Label latitude2_Label;
        private System.Windows.Forms.Label longitude2_Label;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox longitude3;
        private System.Windows.Forms.TextBox latitude3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

