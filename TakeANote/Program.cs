using System;
using System.Windows.Forms;

namespace TakeANote
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var filename = "Journal";
            if (args.Length == 1)
            {
                filename = args[0];
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NoteForm(filename));
        }
    }
}
