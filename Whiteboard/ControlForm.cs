using System;
using System.Windows.Forms;
using static Whiteboard.Common;

namespace Whiteboard
{
    public partial class ControlForm
    {
        private Form1 form = null;
        public ControlForm()
        {
            InitializeComponent();
        }

        private void CreateClick(object sender, EventArgs e)
        {
            if (form == null)
            {

                try
                {
                    var processName = ProcessList.SelectedItem as string;
                    if (processName.Length == 0) throw new Exception();
                    var width = Convert.ToInt32(ShelterWidth.Text);
                    var height = Convert.ToInt32(ShelterHeight.Text);
                    int positionX;
                    int positionY;
                    if (PositionX.Text.Length == 0)
                        positionX = 0;
                    else
                        positionX = Convert.ToInt32(PositionX.Text);
                    if (PositionY.Text.Length == 0)
                        positionY = 0;
                    else
                        positionY = Convert.ToInt32(PositionX.Text);
                    form = new Form1(processName, width, height, positionX, positionY);
                    form.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据格式不正确,请正确填写");
                    FormClose();
                }
            }
        }
        private void ProcessSelect(object sender, EventArgs e)
        {
            var processName = ProcessList.SelectedItem as string;
            if (processName.Length == 0) return;
            var rect = GetWindowRect(processName);
            var winInfo = new ShelterWinInfo(rect);
            WidthLabel.Text = winInfo.Width.ToString();
            HeightLabel.Text = winInfo.Height.ToString();
        }

        private void CloseClick(object sender, EventArgs e)
        {
            FormClose();
        }
        private void FormClose()
        {
            if (form != null)
            {
                form.Close();
                form = null;
            }
        }
        private void FormLoad(object sender, EventArgs e)
        {
            //this.ProcessList.Items.AddRange(Common.GetProcessNameList().ToArray());
        }

        private void ProcessListClick(object sender, EventArgs e)
        {
            this.ProcessList.Items.Clear();
            this.ProcessList.Items.AddRange(Common.GetProcessNameList().ToArray());
        }
    }
}
