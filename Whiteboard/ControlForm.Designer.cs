using System;
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
            this.ProcessList = new System.Windows.Forms.ComboBox();
            this.ProcessName = new System.Windows.Forms.Label();
            this.ShelterWidth = new System.Windows.Forms.TextBox();
            this.ShelterWidthLabel = new System.Windows.Forms.Label();
            this.ShelterHeight = new System.Windows.Forms.TextBox();
            this.ShelterHeightLabel = new System.Windows.Forms.Label();
            this.PositionX = new System.Windows.Forms.TextBox();
            this.PositionY = new System.Windows.Forms.TextBox();
            this.PositionXLabel = new System.Windows.Forms.Label();
            this.PositionYLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(74, 253);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(103, 44);
            this.CreateButton.TabIndex = 0;
            this.CreateButton.Text = "创建遮挡";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateClick);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(196, 253);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(92, 44);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "关闭遮挡";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseClick);
            // 
            // ProcessList
            // 
            this.ProcessList.FormattingEnabled = true;
            this.ProcessList.Location = new System.Drawing.Point(180, 39);
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(108, 20);
            this.ProcessList.TabIndex = 2;
            // 
            // ProcessName
            // 
            this.ProcessName.AutoSize = true;
            this.ProcessName.Location = new System.Drawing.Point(72, 42);
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.Size = new System.Drawing.Size(41, 12);
            this.ProcessName.TabIndex = 3;
            this.ProcessName.Text = "进程：";
            // 
            // ShelterWidth
            // 
            this.ShelterWidth.Location = new System.Drawing.Point(180, 84);
            this.ShelterWidth.Name = "ShelterWidth";
            this.ShelterWidth.Size = new System.Drawing.Size(108, 21);
            this.ShelterWidth.TabIndex = 4;
            // 
            // ShelterWidthLabel
            // 
            this.ShelterWidthLabel.AutoSize = true;
            this.ShelterWidthLabel.Location = new System.Drawing.Point(72, 84);
            this.ShelterWidthLabel.Name = "ShelterWidthLabel";
            this.ShelterWidthLabel.Size = new System.Drawing.Size(53, 12);
            this.ShelterWidthLabel.TabIndex = 5;
            this.ShelterWidthLabel.Text = "遮盖宽度";
            // 
            // ShelterHeight
            // 
            this.ShelterHeight.Location = new System.Drawing.Point(180, 124);
            this.ShelterHeight.Name = "ShelterHeight";
            this.ShelterHeight.Size = new System.Drawing.Size(108, 21);
            this.ShelterHeight.TabIndex = 6;
            // 
            // ShelterHeightLabel
            // 
            this.ShelterHeightLabel.AutoSize = true;
            this.ShelterHeightLabel.Location = new System.Drawing.Point(72, 124);
            this.ShelterHeightLabel.Name = "ShelterHeightLabel";
            this.ShelterHeightLabel.Size = new System.Drawing.Size(53, 12);
            this.ShelterHeightLabel.TabIndex = 7;
            this.ShelterHeightLabel.Text = "遮盖高度";
            // 
            // PositionX
            // 
            this.PositionX.Location = new System.Drawing.Point(180, 164);
            this.PositionX.Name = "PositionX";
            this.PositionX.Size = new System.Drawing.Size(108, 21);
            this.PositionX.TabIndex = 8;
            // 
            // PositionY
            // 
            this.PositionY.Location = new System.Drawing.Point(180, 201);
            this.PositionY.Name = "PositionY";
            this.PositionY.Size = new System.Drawing.Size(108, 21);
            this.PositionY.TabIndex = 9;
            // 
            // PositionXLabel
            // 
            this.PositionXLabel.AutoSize = true;
            this.PositionXLabel.Location = new System.Drawing.Point(72, 164);
            this.PositionXLabel.Name = "PositionXLabel";
            this.PositionXLabel.Size = new System.Drawing.Size(59, 12);
            this.PositionXLabel.TabIndex = 10;
            this.PositionXLabel.Text = "遮盖定位X";
            // 
            // PositionYLabel
            // 
            this.PositionYLabel.AutoSize = true;
            this.PositionYLabel.Location = new System.Drawing.Point(72, 201);
            this.PositionYLabel.Name = "PositionYLabel";
            this.PositionYLabel.Size = new System.Drawing.Size(59, 12);
            this.PositionYLabel.TabIndex = 11;
            this.PositionYLabel.Text = "遮盖定位Y";
            // 
            // ControlForm
            // 
            this.ClientSize = new System.Drawing.Size(354, 345);
            this.Controls.Add(this.PositionYLabel);
            this.Controls.Add(this.PositionXLabel);
            this.Controls.Add(this.PositionY);
            this.Controls.Add(this.PositionX);
            this.Controls.Add(this.ShelterHeightLabel);
            this.Controls.Add(this.ShelterHeight);
            this.Controls.Add(this.ShelterWidthLabel);
            this.Controls.Add(this.ShelterWidth);
            this.Controls.Add(this.ProcessName);
            this.Controls.Add(this.ProcessList);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CreateButton);
            this.Name = "ControlForm";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        private Button CreateButton;
        private Button CloseButton;
        private ComboBox ProcessList;
        private Label ProcessName;
        private TextBox ShelterWidth;
        private Label ShelterWidthLabel;
        private TextBox ShelterHeight;
        private Label ShelterHeightLabel;
        private TextBox PositionX;
        private TextBox PositionY;
        private Label PositionXLabel;
        private Label PositionYLabel;
    }
}
