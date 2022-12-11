using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibraryNETFramework;
using TrackerLibraryNETFramework.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        // TODO - use dictionary instead of infinity if/else
        // TODO - don't use code behind add commands
        // TODO - remove all duplicate code
        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel teamMember = new PersonModel()
                {
                    FirstName = firstNameValueTextBox.Text,
                    LastName = lastNameValueTextBox.Text,
                    EmailAddress = emailValueTextBox.Text,
                    CellphoneNumber = cellphoneValueTextBox.Text
                };

                GlobalConfig.Connection.CreateTeamMember(teamMember);

                firstNameValueTextBox.Text = "";
                lastNameValueTextBox.Text = "";
                emailValueTextBox.Text = "";
                cellphoneValueTextBox.Text = "";

            }
            else
            {
                MessageBox.Show("Try again, idiot.");
            }
        }

        private bool ValidateForm()
        {
            // TODO - add validation to the form

            if (firstNameValueTextBox.Text.Length == 0) 
            {
                return false;
            }

            if (lastNameValueTextBox.Text.Length == 0)
            {
                return false;
            }

            if (lastNameValueTextBox.Text.Length == 0)
            {
                return false;
            }

            if (lastNameValueTextBox.Text.Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
