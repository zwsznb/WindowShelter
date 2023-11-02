using System.Windows.Forms;

namespace Whiteboard
{
    partial class ControlForm : Form
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.CreateButton.Location = new System.Drawing.Point(129, 290);
            this.CreateButton.Name = "button1";
            this.CreateButton.Size = new System.Drawing.Size(103, 44);
            this.CreateButton.TabIndex = 0;
            this.CreateButton.Text = "创建遮挡";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.Create_Click);
            // 
            // button2
            // 
            this.CloseButton.Location = new System.Drawing.Point(251, 290);
            this.CloseButton.Name = "button2";
            this.CloseButton.Size = new System.Drawing.Size(92, 44);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "关闭遮挡";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.Close_Click);
            // 
            // ControlForm
            // 
            this.ClientSize = new System.Drawing.Size(472, 357);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CreateButton);
            this.Name = "ControlForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button CreateButton;
        private Button CloseButton;
    }
}
