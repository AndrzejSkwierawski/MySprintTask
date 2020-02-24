namespace JobApplication
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
			this.StartButton = new System.Windows.Forms.Button();
			this.timeLabel = new System.Windows.Forms.Label();
			this.numberOfThreadsUD = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numberOfThreadsUD)).BeginInit();
			this.SuspendLayout();
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(26, 31);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 0;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// timeLabel
			// 
			this.timeLabel.AutoSize = true;
			this.timeLabel.Location = new System.Drawing.Point(65, 12);
			this.timeLabel.Name = "timeLabel";
			this.timeLabel.Size = new System.Drawing.Size(35, 13);
			this.timeLabel.TabIndex = 1;
			this.timeLabel.Text = "label1";
			// 
			// numberOfThreadsUD
			// 
			this.numberOfThreadsUD.Location = new System.Drawing.Point(108, 33);
			this.numberOfThreadsUD.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.numberOfThreadsUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numberOfThreadsUD.Name = "numberOfThreadsUD";
			this.numberOfThreadsUD.Size = new System.Drawing.Size(77, 20);
			this.numberOfThreadsUD.TabIndex = 2;
			this.numberOfThreadsUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.numberOfThreadsUD);
			this.Controls.Add(this.timeLabel);
			this.Controls.Add(this.StartButton);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.numberOfThreadsUD)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.Label timeLabel;
		private System.Windows.Forms.NumericUpDown numberOfThreadsUD;
	}
}

