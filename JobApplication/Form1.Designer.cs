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
			this.QtyLabel = new System.Windows.Forms.Label();
			this.QtyYearLabel = new System.Windows.Forms.Label();
			this.QtyCatLabel = new System.Windows.Forms.Label();
			this.timerUD = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.pathSelector = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.numberOfThreadsUD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timerUD)).BeginInit();
			this.SuspendLayout();
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(235, 25);
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
			this.timeLabel.Location = new System.Drawing.Point(26, 51);
			this.timeLabel.Name = "timeLabel";
			this.timeLabel.Size = new System.Drawing.Size(39, 13);
			this.timeLabel.TabIndex = 1;
			this.timeLabel.Text = "Cycle: ";
			// 
			// numberOfThreadsUD
			// 
			this.numberOfThreadsUD.Location = new System.Drawing.Point(126, 25);
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
			// QtyLabel
			// 
			this.QtyLabel.AutoSize = true;
			this.QtyLabel.Location = new System.Drawing.Point(26, 77);
			this.QtyLabel.Name = "QtyLabel";
			this.QtyLabel.Size = new System.Drawing.Size(72, 13);
			this.QtyLabel.TabIndex = 3;
			this.QtyLabel.Text = "Summary Qty:";
			// 
			// QtyYearLabel
			// 
			this.QtyYearLabel.AutoSize = true;
			this.QtyYearLabel.Location = new System.Drawing.Point(26, 105);
			this.QtyYearLabel.Name = "QtyYearLabel";
			this.QtyYearLabel.Size = new System.Drawing.Size(63, 13);
			this.QtyYearLabel.TabIndex = 4;
			this.QtyYearLabel.Text = "Qty by year:";
			// 
			// QtyCatLabel
			// 
			this.QtyCatLabel.AutoSize = true;
			this.QtyCatLabel.Location = new System.Drawing.Point(168, 105);
			this.QtyCatLabel.Name = "QtyCatLabel";
			this.QtyCatLabel.Size = new System.Drawing.Size(84, 13);
			this.QtyCatLabel.TabIndex = 5;
			this.QtyCatLabel.Text = "Qty by category:";
			// 
			// timerUD
			// 
			this.timerUD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.timerUD.Location = new System.Drawing.Point(21, 25);
			this.timerUD.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
			this.timerUD.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.timerUD.Name = "timerUD";
			this.timerUD.Size = new System.Drawing.Size(77, 20);
			this.timerUD.TabIndex = 6;
			this.timerUD.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(193, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Update cycle [s]:    Number of Threads:";
			// 
			// pathSelector
			// 
			this.pathSelector.FormattingEnabled = true;
			this.pathSelector.Items.AddRange(new object[] {
            "TEMP_CSV_1",
            "TEMP_CSV_2"});
			this.pathSelector.Location = new System.Drawing.Point(331, 25);
			this.pathSelector.Name = "pathSelector";
			this.pathSelector.Size = new System.Drawing.Size(121, 21);
			this.pathSelector.TabIndex = 8;
			this.pathSelector.Text = "TEMP_CSV_1";
			this.pathSelector.SelectedIndexChanged += new System.EventHandler(this.pathSelector_SelectedIndexChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(464, 451);
			this.Controls.Add(this.pathSelector);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.timerUD);
			this.Controls.Add(this.QtyCatLabel);
			this.Controls.Add(this.QtyYearLabel);
			this.Controls.Add(this.QtyLabel);
			this.Controls.Add(this.numberOfThreadsUD);
			this.Controls.Add(this.timeLabel);
			this.Controls.Add(this.StartButton);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.numberOfThreadsUD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timerUD)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.Label timeLabel;
		private System.Windows.Forms.NumericUpDown numberOfThreadsUD;
		private System.Windows.Forms.Label QtyLabel;
		private System.Windows.Forms.Label QtyYearLabel;
		private System.Windows.Forms.Label QtyCatLabel;
		private System.Windows.Forms.NumericUpDown timerUD;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox pathSelector;
	}
}

