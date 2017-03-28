namespace Template_Analyser
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lstbox_wildcards = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.AnalysisType_Wildcards = new System.Windows.Forms.RadioButton();
            this.AnalysisType_Products = new System.Windows.Forms.RadioButton();
            this.LoadNode = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Template Location";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(197, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(657, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(879, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstbox_wildcards
            // 
            this.lstbox_wildcards.FormattingEnabled = true;
            this.lstbox_wildcards.Location = new System.Drawing.Point(100, 195);
            this.lstbox_wildcards.Name = "lstbox_wildcards";
            this.lstbox_wildcards.Size = new System.Drawing.Size(264, 303);
            this.lstbox_wildcards.TabIndex = 3;
            this.lstbox_wildcards.SelectedIndexChanged += new System.EventHandler(this.lstbox_wildcards_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Wildcards";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(440, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Analyse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(423, 195);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(752, 457);
            this.treeView1.TabIndex = 7;
            // 
            // AnalysisType_Wildcards
            // 
            this.AnalysisType_Wildcards.AutoSize = true;
            this.AnalysisType_Wildcards.Checked = true;
            this.AnalysisType_Wildcards.Location = new System.Drawing.Point(279, 110);
            this.AnalysisType_Wildcards.Name = "AnalysisType_Wildcards";
            this.AnalysisType_Wildcards.Size = new System.Drawing.Size(72, 17);
            this.AnalysisType_Wildcards.TabIndex = 8;
            this.AnalysisType_Wildcards.TabStop = true;
            this.AnalysisType_Wildcards.Text = "Wildcards";
            this.AnalysisType_Wildcards.UseVisualStyleBackColor = true;
            // 
            // AnalysisType_Products
            // 
            this.AnalysisType_Products.AutoSize = true;
            this.AnalysisType_Products.Location = new System.Drawing.Point(279, 133);
            this.AnalysisType_Products.Name = "AnalysisType_Products";
            this.AnalysisType_Products.Size = new System.Drawing.Size(67, 17);
            this.AnalysisType_Products.TabIndex = 9;
            this.AnalysisType_Products.Text = "Products";
            this.AnalysisType_Products.UseVisualStyleBackColor = true;
            this.AnalysisType_Products.CheckedChanged += new System.EventHandler(this.AnalysisType_Products_CheckedChanged);
            // 
            // LoadNode
            // 
            this.LoadNode.AutoSize = true;
            this.LoadNode.Location = new System.Drawing.Point(654, 122);
            this.LoadNode.Name = "LoadNode";
            this.LoadNode.Size = new System.Drawing.Size(79, 17);
            this.LoadNode.TabIndex = 10;
            this.LoadNode.Text = "Load Node";
            this.LoadNode.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(669, 155);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Export Data to text file";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 675);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.LoadNode);
            this.Controls.Add(this.AnalysisType_Products);
            this.Controls.Add(this.AnalysisType_Wildcards);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstbox_wildcards);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox lstbox_wildcards;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RadioButton AnalysisType_Wildcards;
        private System.Windows.Forms.RadioButton AnalysisType_Products;
        private System.Windows.Forms.CheckBox LoadNode;
        private System.Windows.Forms.Button button3;
    }
}

