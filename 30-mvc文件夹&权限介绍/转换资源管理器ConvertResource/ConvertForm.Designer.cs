namespace ConvertResource
{
    partial class ConvertForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertForm));
            this.txtResources = new System.Windows.Forms.TextBox();
            this.labResources = new System.Windows.Forms.Label();
            this.btnResources = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResources
            // 
            this.txtResources.Location = new System.Drawing.Point(155, 26);
            this.txtResources.Name = "txtResources";
            this.txtResources.Size = new System.Drawing.Size(343, 21);
            this.txtResources.TabIndex = 2;
            // 
            // labResources
            // 
            this.labResources.AutoSize = true;
            this.labResources.Location = new System.Drawing.Point(21, 32);
            this.labResources.Name = "labResources";
            this.labResources.Size = new System.Drawing.Size(131, 12);
            this.labResources.TabIndex = 1;
            this.labResources.Text = "选择 Resources 文件：";
            // 
            // btnResources
            // 
            this.btnResources.Location = new System.Drawing.Point(498, 26);
            this.btnResources.Name = "btnResources";
            this.btnResources.Size = new System.Drawing.Size(21, 21);
            this.btnResources.TabIndex = 3;
            this.btnResources.Text = "…";
            this.btnResources.UseVisualStyleBackColor = true;
            this.btnResources.Click += new System.EventHandler(this.btnResources_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(192, 98);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(337, 98);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 178);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnResources);
            this.Controls.Add(this.labResources);
            this.Controls.Add(this.txtResources);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConvertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "资源文件转换工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResources;
        private System.Windows.Forms.Label labResources;
        private System.Windows.Forms.Button btnResources;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnClose;
    }
}

