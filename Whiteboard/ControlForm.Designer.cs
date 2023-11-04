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
            this.CurWindowW = new System.Windows.Forms.Label();
            this.CurWindowH = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.Tips = new System.Windows.Forms.Label();
            this.SelectImgBtn = new System.Windows.Forms.Button();
            this.ImgPath = new System.Windows.Forms.TextBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(64, 309);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(103, 44);
            this.CreateButton.TabIndex = 0;
            this.CreateButton.Text = "创建遮挡";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateClick);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(196, 309);
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
            this.ProcessList.Size = new System.Drawing.Size(108, 23);
            this.ProcessList.TabIndex = 2;
            this.ProcessList.SelectionChangeCommitted += new System.EventHandler(this.ProcessSelect);
            this.ProcessList.Click += new System.EventHandler(this.ProcessListClick);
            // 
            // ProcessName
            // 
            this.ProcessName.AutoSize = true;
            this.ProcessName.Location = new System.Drawing.Point(72, 42);
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.Size = new System.Drawing.Size(52, 15);
            this.ProcessName.TabIndex = 3;
            this.ProcessName.Text = "进程：";
            // 
            // ShelterWidth
            // 
            this.ShelterWidth.Location = new System.Drawing.Point(180, 84);
            this.ShelterWidth.Name = "ShelterWidth";
            this.ShelterWidth.Size = new System.Drawing.Size(108, 25);
            this.ShelterWidth.TabIndex = 4;
            // 
            // ShelterWidthLabel
            // 
            this.ShelterWidthLabel.AutoSize = true;
            this.ShelterWidthLabel.Location = new System.Drawing.Point(72, 84);
            this.ShelterWidthLabel.Name = "ShelterWidthLabel";
            this.ShelterWidthLabel.Size = new System.Drawing.Size(67, 15);
            this.ShelterWidthLabel.TabIndex = 5;
            this.ShelterWidthLabel.Text = "遮盖宽度";
            // 
            // ShelterHeight
            // 
            this.ShelterHeight.Location = new System.Drawing.Point(180, 124);
            this.ShelterHeight.Name = "ShelterHeight";
            this.ShelterHeight.Size = new System.Drawing.Size(108, 25);
            this.ShelterHeight.TabIndex = 6;
            // 
            // ShelterHeightLabel
            // 
            this.ShelterHeightLabel.AutoSize = true;
            this.ShelterHeightLabel.Location = new System.Drawing.Point(72, 124);
            this.ShelterHeightLabel.Name = "ShelterHeightLabel";
            this.ShelterHeightLabel.Size = new System.Drawing.Size(67, 15);
            this.ShelterHeightLabel.TabIndex = 7;
            this.ShelterHeightLabel.Text = "遮盖高度";
            // 
            // PositionX
            // 
            this.PositionX.Location = new System.Drawing.Point(180, 164);
            this.PositionX.Name = "PositionX";
            this.PositionX.Size = new System.Drawing.Size(108, 25);
            this.PositionX.TabIndex = 8;
            // 
            // PositionY
            // 
            this.PositionY.Location = new System.Drawing.Point(180, 201);
            this.PositionY.Name = "PositionY";
            this.PositionY.Size = new System.Drawing.Size(108, 25);
            this.PositionY.TabIndex = 9;
            // 
            // PositionXLabel
            // 
            this.PositionXLabel.AutoSize = true;
            this.PositionXLabel.Location = new System.Drawing.Point(72, 164);
            this.PositionXLabel.Name = "PositionXLabel";
            this.PositionXLabel.Size = new System.Drawing.Size(75, 15);
            this.PositionXLabel.TabIndex = 10;
            this.PositionXLabel.Text = "遮盖定位X";
            // 
            // PositionYLabel
            // 
            this.PositionYLabel.AutoSize = true;
            this.PositionYLabel.Location = new System.Drawing.Point(72, 201);
            this.PositionYLabel.Name = "PositionYLabel";
            this.PositionYLabel.Size = new System.Drawing.Size(75, 15);
            this.PositionYLabel.TabIndex = 11;
            this.PositionYLabel.Text = "遮盖定位Y";
            // 
            // CurWindowW
            // 
            this.CurWindowW.AutoSize = true;
            this.CurWindowW.Location = new System.Drawing.Point(60, 9);
            this.CurWindowW.Name = "CurWindowW";
            this.CurWindowW.Size = new System.Drawing.Size(82, 15);
            this.CurWindowW.TabIndex = 12;
            this.CurWindowW.Text = "窗口宽度：";
            // 
            // CurWindowH
            // 
            this.CurWindowH.AutoSize = true;
            this.CurWindowH.Location = new System.Drawing.Point(217, 9);
            this.CurWindowH.Name = "CurWindowH";
            this.CurWindowH.Size = new System.Drawing.Size(82, 15);
            this.CurWindowH.TabIndex = 13;
            this.CurWindowH.Text = "窗口高度：";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(122, 9);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(15, 15);
            this.WidthLabel.TabIndex = 14;
            this.WidthLabel.Text = "0";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(288, 9);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(15, 15);
            this.HeightLabel.TabIndex = 15;
            this.HeightLabel.Text = "0";
            // 
            // Tips
            // 
            this.Tips.AutoSize = true;
            this.Tips.Location = new System.Drawing.Point(21, 379);
            this.Tips.Name = "Tips";
            this.Tips.Size = new System.Drawing.Size(369, 15);
            this.Tips.TabIndex = 16;
            this.Tips.Text = "tip:如果没有填写定位，则以选定进程窗口的定位为准";
            // 
            // SelectImg
            // 
            this.SelectImgBtn.Location = new System.Drawing.Point(64, 252);
            this.SelectImgBtn.Name = "SelectImg";
            this.SelectImgBtn.Size = new System.Drawing.Size(110, 25);
            this.SelectImgBtn.TabIndex = 17;
            this.SelectImgBtn.Text = "选择遮盖图片";
            this.SelectImgBtn.UseVisualStyleBackColor = true;
            this.SelectImgBtn.Click += new EventHandler(OpenDialog);
            // 
            // ImgPath
            // 
            this.ImgPath.Enabled = false;
            this.ImgPath.Location = new System.Drawing.Point(180, 252);
            this.ImgPath.Name = "ImgPath";
            this.ImgPath.Size = new System.Drawing.Size(108, 25);
            this.ImgPath.TabIndex = 18;
            // 
            // openFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog";
            // 
            // ControlForm
            // 
            this.ClientSize = new System.Drawing.Size(366, 415);
            this.Controls.Add(this.ImgPath);
            this.Controls.Add(this.SelectImgBtn);
            this.Controls.Add(this.Tips);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.CurWindowH);
            this.Controls.Add(this.CurWindowW);
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
            this.Text = "zwsznb";
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
        private Label CurWindowW;
        private Label CurWindowH;
        private Label WidthLabel;
        private Label HeightLabel;
        private Label Tips;
        private Button SelectImgBtn;
        private TextBox ImgPath;
        private OpenFileDialog OpenFileDialog;
    }
}
