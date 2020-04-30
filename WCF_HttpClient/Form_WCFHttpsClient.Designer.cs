namespace WCF_HttpsClient {
    partial class Form_WCFHttpsClient {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.btn_Call = new System.Windows.Forms.Button();
            this.btnRestClient = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Call
            // 
            this.btn_Call.Location = new System.Drawing.Point(256, 109);
            this.btn_Call.Name = "btn_Call";
            this.btn_Call.Size = new System.Drawing.Size(267, 79);
            this.btn_Call.TabIndex = 0;
            this.btn_Call.Text = "Call WCF_HttpsWinService";
            this.btn_Call.UseVisualStyleBackColor = true;
            this.btn_Call.Click += new System.EventHandler(this.btn_Call_Click);
            // 
            // btnRestClient
            // 
            this.btnRestClient.Location = new System.Drawing.Point(256, 209);
            this.btnRestClient.Name = "btnRestClient";
            this.btnRestClient.Size = new System.Drawing.Size(214, 79);
            this.btnRestClient.TabIndex = 1;
            this.btnRestClient.Text = "RestClient";
            this.btnRestClient.UseVisualStyleBackColor = true;
            this.btnRestClient.Click += new System.EventHandler(this.btnRestClient_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(584, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_WCFHttpsClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRestClient);
            this.Controls.Add(this.btn_Call);
            this.Name = "Form_WCFHttpsClient";
            this.Text = "Form_WCFHttpsClient";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Call;
        private System.Windows.Forms.Button btnRestClient;
        private System.Windows.Forms.Button button1;
    }
}

