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
    public partial class TeamMemberForm : Form
    {
        public TeamMember tm { get; set; }
        public TeamMemberForm(TeamMember tm)
        {
            this.tm = tm;
            InitializeComponent();
        }

        private void TeamMemberForm_Load(object sender, EventArgs e)
        {
            FullNameBox.Text = tm.FullName;
            switch(tm.Sex)
            {
                case Sex.Male:
                    radioButtonMale.Checked = true;
                    break;
                case Sex.Female:
                    radioButtonFemale.Checked = true;
                    break;
            }
            GroupNumberBox.Text = tm.GroupNumber;
            numericUpDownAge.Value = tm.Age;

            if (tm.UniversityTeam)
                radioButtonYES1.Checked = true;
            else radioButtonNO1.Checked = true;

            if (tm.SportsСategory)
                radioButtonYES2.Checked = true;
            else radioButtonNO2.Checked = true;

            PhoneBox.Text = tm.Contact.PhoneNumber;
            MailBox.Text = tm.Contact.EMail;
        }

        private void saveMember_Click(object sender, EventArgs e)
        {
            tm.FullName = FullNameBox.Text;

            if (radioButtonMale.Checked)
                tm.Sex = Sex.Male;
            else if (radioButtonFemale.Checked)
                tm.Sex = Sex.Female;

            tm.GroupNumber = GroupNumberBox.Text;
            tm.Age = (int)numericUpDownAge.Value;

            if (radioButtonYES1.Checked)
                tm.UniversityTeam = true;
            else if (radioButtonNO1.Checked)
                tm.UniversityTeam = false;
         
            if (radioButtonYES2.Checked)
                tm.SportsСategory = true;
            else if (radioButtonNO2.Checked)
                tm.SportsСategory = false;

            tm.Contact = new ContactDetails
            {
                PhoneNumber = PhoneBox.Text,
                EMail = MailBox.Text
            };
               

                

        }

      
    }
}
