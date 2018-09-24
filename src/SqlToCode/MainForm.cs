namespace SqlToCode
{
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using Etraining.Sql;
    using SqlToCode.Services;

    public partial class MainForm : Form
    {
        private const string ValidationMessage = @"Make sure that you used:
  * Valid connection string
  * Existing folder path
  * Valid SQL query";

        public MainForm()
        {
            InitializeComponent();
            StickyInput.Stick(this, tbClassname, tbConnectionString, tbOutput, tbSqlQuery);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var connectionString = ConnectionDialog.SqlConnectionDialog.Connect();

            if (connectionString.NotEmpty())
            {
                tbConnectionString.Text = connectionString;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    tbOutput.Text = folderBrowser.SelectedPath;
                }
            }
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            if (DataIsValid())
            {
                var code = CodeGenerator.GenerateCsharpClass(tbConnectionString.Text, tbSqlQuery.Text, tbClassname.Text, chNormalizeColumnNames.Checked);

                tbPreview.Text = code;

                var filepath = Path.Combine(tbOutput.Text, $"{tbClassname.Text}.cs");

                File.WriteAllText(filepath, code, Encoding.UTF8);

                lblFileNote.Text = $"A CSharp file has been made at: {filepath}";

                JSsetTimeout.SetTimeout(() =>
                {
                    lblFileNote.Text = string.Empty;
                }, 5000);
            }
            else
            {
                MessageBox.Show(ValidationMessage);
            }
        }

        private bool DataIsValid()
        {
            return tbConnectionString.Text.NotEmpty() &&
                Directory.Exists(tbOutput.Text) &&
                tbClassname.Text.NotEmpty() &&
                tbSqlQuery.Text.NotEmpty();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            JSsetTimeout.SetTimeout(() =>
            {
                if (tbOutput.Text.IsEmpty())
                {
                    tbOutput.Text = Application.StartupPath;
                }
            }, 500);

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                tbClassname.Focus();
            }
        }
    }
}
