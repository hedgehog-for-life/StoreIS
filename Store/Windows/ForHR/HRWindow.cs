using Store.Controllers;
using Store.DataBase.Context;
using Store.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.Windows.ForHR
{
    public partial class HRWindow : Form
    {
        private BindingList<EmploymentApp> awaitingApps;
        private BindingList<EmploymentApp> hrApps;

        private EmploymentAppController employmentAppController;
        private PersonController personController;

        private Person currUser;

        private Boolean newTaken = false;

        private stuff_shopContext db;

        public HRWindow(string userEmail)
        {
            InitializeComponent();

            db = new stuff_shopContext();

            employmentAppController = new EmploymentAppController(db);
            personController = new PersonController();

            currUser = personController.FindPersonByEmail(userEmail);

            RetrieveDataFromDT();

            saveResumeFileDialog.DefaultExt = "pdf";
            saveResumeFileDialog.Filter = "Resume pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveResumeFileDialog.FilterIndex = 2;
            saveResumeFileDialog.FileName = "resume.pdf";
            saveResumeFileDialog.CheckFileExists = false;
            saveResumeFileDialog.CheckPathExists = true;
            saveResumeFileDialog.RestoreDirectory = true;
            saveResumeFileDialog.InitialDirectory = @"C:\\";
        }

        private void RetrieveDataFromDT()
        {
            awaitingApps = new BindingList<EmploymentApp>(employmentAppController.GetWaitingEmpApps());
            hrApps = new BindingList<EmploymentApp>(employmentAppController.GetAppsForHR(currUser));

            dataGridViewCurrApps.DataSource = awaitingApps;
            dataGridViewHrApps.DataSource = hrApps;

            FactColumnAppStatus.Items.Add("Находится на рассмотрении");
            FactColumnAppStatus.Items.Add("Одобрена");
            FactColumnAppStatus.Items.Add("Отклонена");
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxLogOut_Click(object sender, EventArgs e)
        {
            LoginForm loginWindow = new LoginForm();
            loginWindow.Show();
            this.Hide();
        }

        private void dataGridViewCurrApps_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
         
            awaitingApps = new BindingList<EmploymentApp>(employmentAppController.GetWaitingEmpApps());
            for (int i = 0; i < dataGridViewCurrApps.Rows.Count; i++)
            {
                Person user = personController.GetUser(Convert.ToInt32(dataGridViewCurrApps.Rows[i].Cells[ColumnApplicantId.Index].Value));
                dataGridViewCurrApps.Rows[i].Cells[ColumnApplicantFIO.Index].Value = user.PersonSurname + " " + user.PersonName + " " + user.PersonPatronymic;
                dataGridViewCurrApps.Rows[i].Cells[ColumnApplicantBirthDate.Index].Value = user.BirthDate.ToShortDateString();

            }

        }

        private void dataGridViewCurrApps_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn currColumn = dataGridViewCurrApps.Columns[e.ColumnIndex];
            DataGridViewRow currRow = dataGridViewCurrApps.Rows[e.RowIndex];
            DataGridViewCell currCell = currRow.Cells[e.ColumnIndex];

            if (currColumn.HeaderText == "Взять на рассмотрение")
            {
                if (Convert.ToBoolean(currCell.Value))
                {
                    EmploymentApp employmentApp = awaitingApps.First(emp => emp.Id == Convert.ToInt32(currRow.Cells[ColumnAppId.Index].Value));
                    if (employmentApp != null)
                    {
                        employmentApp.AppStatus = 1;
                        employmentApp.Hr = currUser;

                        employmentAppController.UpdateEmpApp(employmentApp);

                        awaitingApps = new BindingList<EmploymentApp>(employmentAppController.GetWaitingEmpApps());
                        dataGridViewCurrApps.Refresh();

                        dataGridViewCurrApps.Rows.Remove(currRow);

                        hrApps = new BindingList<EmploymentApp>(employmentAppController.GetAppsForHR(currUser));
                        dataGridViewHrApps.DataSource = null;
                        dataGridViewHrApps.DataSource = hrApps;


                        newTaken = true;
                        
                    }
                }
            }
        }

        private void dataGridViewHrApps_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn currColumn = dataGridViewHrApps.Columns[e.ColumnIndex];
            DataGridViewRow currRow = dataGridViewHrApps.Rows[e.RowIndex];
            DataGridViewCell currCell = currRow.Cells[e.ColumnIndex];

            if (currColumn.HeaderText == "Статус заявки")
            {
                    EmploymentApp employmentApp = hrApps.First(emp => emp.Id == Convert.ToInt32(currRow.Cells[FactColumnId.Index].Value));
                    if (employmentApp != null)
                    {
                        switch(currRow.Cells[FactColumnAppStatus.Index].Value)
                        {
                            case "Находится на рассмотрении":
                                employmentApp.AppStatus = 1;
                                break;
                            case "Одобрена":
                                employmentApp.AppStatus = 2;
                                break;
                            case "Отклонена":
                                employmentApp.AppStatus = 3;
                                break;
                        }

                        employmentAppController.UpdateEmpApp(employmentApp);

                        awaitingApps = new BindingList<EmploymentApp>(employmentAppController.GetWaitingEmpApps());
                    dataGridViewHrApps.Refresh();

                    }
                
            }
        }

        private void dataGridViewHrApps_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(newTaken)
            {
                hrApps = new BindingList<EmploymentApp>(employmentAppController.GetAppsForHR(currUser));
                dataGridViewHrApps.Refresh();

                newTaken = false;
            }
          
            for (int i = 0; i < dataGridViewHrApps.Rows.Count; i++)
            {
                EmploymentApp employmentApp = hrApps.First(emp => emp.Id == Convert.ToInt32(dataGridViewHrApps.Rows[i].Cells[FactColumnId.Index].Value));
                dataGridViewHrApps.Rows[i].Cells[FactColumnApplicantFIO.Index].Value = employmentApp.Applicant.PersonSurname + " " + employmentApp.Applicant.PersonName + " " + employmentApp.Applicant.PersonPatronymic;
                dataGridViewHrApps.Rows[i].Cells[FactColumnApplicantDateBirth.Index].Value = employmentApp.Applicant.BirthDate.ToShortDateString();
                dataGridViewHrApps.Rows[i].Cells[FactColumnApplicantPhone.Index].Value = employmentApp.ContactNumber;
                dataGridViewHrApps.Rows[i].Cells[FactColumnApplicantEmail.Index].Value = employmentApp.ContactEmail;

                dataGridViewHrApps.Rows[i].Cells[FactColumnAppStatus.Index].Value = FactColumnAppStatus.Items[employmentApp.AppStatus - 1];
            }
        }

        private void dataGridViewHrApps_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow currRow = e.Row;
            EmploymentApp employmentApp = hrApps.First(emp => emp.Id == Convert.ToInt32(currRow.Cells[FactColumnId.Index].Value));

            employmentAppController.RemoveEmploymentApp(employmentApp.Id);

            hrApps = new BindingList<EmploymentApp>(employmentAppController.GetAppsForHR(currUser));
            dataGridViewHrApps.Refresh();
        }

        private void dataGridViewHrApps_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridViewHrApps.Columns[e.ColumnIndex]; 
            if(column.HeaderText == "Резюме")
            {
                if (saveResumeFileDialog.ShowDialog() == DialogResult.OK)
                {

                    EmploymentApp app = employmentAppController.GetEmploymentApp(
                        Convert.ToInt32(dataGridViewHrApps.Rows[e.RowIndex].Cells[FactColumnId.Index].EditedFormattedValue));
                    System.IO.File.WriteAllBytes(saveResumeFileDialog.FileName, app.Resume);
                }
            }
        }
    }
}
