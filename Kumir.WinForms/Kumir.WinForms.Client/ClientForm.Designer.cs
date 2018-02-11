namespace Kumir.WinForms
{
    partial class ClientForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.connect = new System.Windows.Forms.Button();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.ping = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(67, 101);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(150, 60);
            this.connect.TabIndex = 1;
            this.connect.Text = "Подключение";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(286, 63);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(100, 20);
            this.nameTB.TabIndex = 2;
            // 
            // ping
            // 
            this.ping.Location = new System.Drawing.Point(300, 185);
            this.ping.Name = "ping";
            this.ping.Size = new System.Drawing.Size(75, 23);
            this.ping.TabIndex = 3;
            this.ping.Text = "ping";
            this.ping.UseVisualStyleBackColor = true;
            this.ping.Click += new System.EventHandler(this.ping_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 262);
            this.Controls.Add(this.ping);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.connect);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Button ping;
    }
}

