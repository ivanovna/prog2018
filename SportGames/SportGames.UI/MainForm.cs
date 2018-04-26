using SportGames;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportGames.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private RequestModel _currentModel = new RequestModel();

        private RequestModel GetModelFromUI()
        {
            _currentModel.Filled = dateTimePicker1.Value;
             
            switch (sportTypeComboBox.SelectedIndex)
            {
                case 0:
                    _currentModel.SportType = Sport.Basketball;
                    break;
                case 1:
                    _currentModel.SportType = Sport.Volleyball;
                    break;
                case 2:
                    _currentModel.SportType = Sport.Handball;
                    break;
                case 3:
                    _currentModel.SportType = Sport.Hockey;
                    break;
            }

            if (radioButtonM.Checked)
                _currentModel.TeamType = TeamType.Mens;
            else if (radioButtonW.Checked)
                _currentModel.TeamType = TeamType.Womens;
            else if (radioButtonMix.Checked)
                _currentModel.TeamType = TeamType.Mixed;

            _currentModel.TeamName = NameBox.Text;
            _currentModel.TeamCaptain = CaptainBox.Text;
            _currentModel.CountCompetitors = (int)numericUpDownCount.Value;
            _currentModel.TeamMembers = listBox1.Items.OfType<TeamMember>().ToList();
            return _currentModel;

        }

        private void SetModelToUI(RequestModel _currentModel)
        {
            dateTimePicker1.Value = _currentModel.Filled;

            switch (_currentModel.SportType)
            {
                case Sport.Basketball:
                    sportTypeComboBox.SelectedIndex = 0;
                    break;
                case Sport.Volleyball:
                    sportTypeComboBox.SelectedIndex = 1;
                    break;
                case Sport.Handball:
                    sportTypeComboBox.SelectedIndex = 2;
                    break;
                case Sport.Hockey:
                    sportTypeComboBox.SelectedIndex = 3;
                    break;
            }

            switch (_currentModel.TeamType)
            {
                case TeamType.Mens:
                    radioButtonM.Checked = true;
                    break;
                case TeamType.Womens:
                    radioButtonW.Checked = true;
                    break;
                case TeamType.Mixed:
                    radioButtonMix.Checked = true;
                    break;
            }
            NameBox.Text = _currentModel.TeamName;
            CaptainBox.Text = _currentModel.TeamCaptain;
            numericUpDownCount.Value = _currentModel.CountCompetitors;
            listBox1.Items.Clear();
            foreach (var e in _currentModel.TeamMembers)
            {
                listBox1.Items.Add(e);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Файлы заявок|*.sprtgms" };
            var result = sfd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = GetModelFromUI();
                SportGamesSerializer.WriteToFile(sfd.FileName, dto);
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Файл заявки| *.sprtgms" };
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = SportGamesSerializer.LoadFromFile(ofd.FileName);
                SetModelToUI(dto);
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            var form = new TeamMemberForm(new TeamMember());
            var res = form.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                listBox1.Items.Add(form.tm);
            }
            numericUpDownCount.Value = listBox1.Items.Count;
           
            save.Enabled = true;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            var tm = (TeamMember)listBox1.SelectedItem;
            listBox1.Items.Remove(listBox1.SelectedItem);
            numericUpDownCount.Value = listBox1.Items.Count;
     
            if (listBox1.Items.Count == 0) save.Enabled = false;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            var tm = listBox1.SelectedItem as TeamMember;
            if (tm == null)
                return;
          
            var form = new TeamMemberForm(tm.Clone());
            var res = form.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                var si = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(si);
                listBox1.Items.Insert(si, form.tm);
            }
            
            numericUpDownCount.Value = listBox1.Items.Count;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDownCount.Value = listBox1.Items.Count;
            if (listBox1.SelectedIndex != -1)
                delete.Enabled = true;
            else
                delete.Enabled = false;
        }

    }
}
