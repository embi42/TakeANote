using System;
using System.IO;
using System.Windows.Forms;

namespace TakeANote
{
    public partial class NoteForm : Form
    {
        private readonly string _filename;

        public NoteForm(string filename)
        {
            _filename = filename;
            InitializeComponent();
        }

        private void btnSelectDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.NotesPath = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEntry();
        }

        private void tbNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                SaveEntry();
            }
        }

        private void SaveEntry()
        {
            var filenameWithExtension = _filename + ".md";
            var file = Path.Combine(Properties.Settings.Default.NotesPath, filenameWithExtension);
            using (var writer = File.AppendText(file))
            {
                writer.WriteLine(DateTime.Now.ToString());
                writer.WriteLine(tbNote.Text);
                writer.WriteLine();
            }
        }

        private void NoteForm_Load(object sender, EventArgs e)
        {
            lblName.Text = _filename;
        }

        private void NoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
