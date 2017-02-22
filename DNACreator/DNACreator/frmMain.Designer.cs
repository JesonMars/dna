namespace DNACreator
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtkuan = new System.Windows.Forms.TextBox();
            this.txtgao = new System.Windows.Forms.TextBox();
            this.gbCity = new System.Windows.Forms.GroupBox();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.btnSelectFoler = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.txtFileSelect = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbCity.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHtml
            // 
            this.txtHtml.Location = new System.Drawing.Point(21, 341);
            this.txtHtml.Multiline = true;
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHtml.Size = new System.Drawing.Size(661, 290);
            this.txtHtml.TabIndex = 0;
            this.txtHtml.Text = resources.GetString("txtHtml.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "宽：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "高：";
            // 
            // txtkuan
            // 
            this.txtkuan.Location = new System.Drawing.Point(43, 45);
            this.txtkuan.Name = "txtkuan";
            this.txtkuan.Size = new System.Drawing.Size(100, 21);
            this.txtkuan.TabIndex = 4;
            // 
            // txtgao
            // 
            this.txtgao.Location = new System.Drawing.Point(43, 84);
            this.txtgao.Name = "txtgao";
            this.txtgao.Size = new System.Drawing.Size(100, 21);
            this.txtgao.TabIndex = 5;
            // 
            // gbCity
            // 
            this.gbCity.Controls.Add(this.btnCreateNew);
            this.gbCity.Controls.Add(this.label3);
            this.gbCity.Controls.Add(this.btnSelectFoler);
            this.gbCity.Controls.Add(this.label4);
            this.gbCity.Controls.Add(this.txtgao);
            this.gbCity.Controls.Add(this.btnSelectFile);
            this.gbCity.Controls.Add(this.txtkuan);
            this.gbCity.Controls.Add(this.txtDestinationFolder);
            this.gbCity.Controls.Add(this.label2);
            this.gbCity.Controls.Add(this.txtFileSelect);
            this.gbCity.Controls.Add(this.label1);
            this.gbCity.Location = new System.Drawing.Point(21, 41);
            this.gbCity.Name = "gbCity";
            this.gbCity.Size = new System.Drawing.Size(677, 243);
            this.gbCity.TabIndex = 6;
            this.gbCity.TabStop = false;
            this.gbCity.Text = "城市初始化";
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Location = new System.Drawing.Point(510, 162);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(100, 60);
            this.btnCreateNew.TabIndex = 9;
            this.btnCreateNew.Text = "生成";
            this.btnCreateNew.UseVisualStyleBackColor = true;
            // 
            // btnSelectFoler
            // 
            this.btnSelectFoler.Location = new System.Drawing.Point(435, 200);
            this.btnSelectFoler.Name = "btnSelectFoler";
            this.btnSelectFoler.Size = new System.Drawing.Size(69, 23);
            this.btnSelectFoler.TabIndex = 8;
            this.btnSelectFoler.Text = "选择";
            this.btnSelectFoler.UseVisualStyleBackColor = true;
            this.btnSelectFoler.Click += new System.EventHandler(this.btnSelectFoler_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(435, 162);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(69, 23);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "选择";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDestinationFolder.Location = new System.Drawing.Point(113, 201);
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.ReadOnly = true;
            this.txtDestinationFolder.Size = new System.Drawing.Size(322, 21);
            this.txtDestinationFolder.TabIndex = 7;
            this.txtDestinationFolder.Text = "选择pdf文件的保存地址";
            // 
            // txtFileSelect
            // 
            this.txtFileSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtFileSelect.Location = new System.Drawing.Point(113, 163);
            this.txtFileSelect.Name = "txtFileSelect";
            this.txtFileSelect.ReadOnly = true;
            this.txtFileSelect.Size = new System.Drawing.Size(322, 21);
            this.txtFileSelect.TabIndex = 0;
            this.txtFileSelect.Text = "请选择dna内容表";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "文件生成路径：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "DNA 内 容 表：";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 320);
            this.Controls.Add(this.txtHtml);
            this.Controls.Add(this.gbCity);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "卡生成器";
            this.gbCity.ResumeLayout(false);
            this.gbCity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHtml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtkuan;
        private System.Windows.Forms.TextBox txtgao;
        private System.Windows.Forms.GroupBox gbCity;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFileSelect;
        private System.Windows.Forms.Button btnSelectFoler;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}