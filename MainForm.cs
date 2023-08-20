using Microsoft.EntityFrameworkCore;
using nauka.test.impl.Models;
using System.ComponentModel;

namespace nauka.test.impl
{
    public partial class MainForm : Form
    {
        private NaukaDbContext? dbContext;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.dbContext = new NaukaDbContext();
            this.dbContext.Database.EnsureCreated();

            this.dbContext.Users.Load();

            this.userBindingSource.DataSource = dbContext.Users.Local.ToBindingList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            dbContext?.Dispose();
            dbContext = null;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            this.dbContext!.SaveChanges();
            this.dataGridView1.Refresh();
        }
    }
}