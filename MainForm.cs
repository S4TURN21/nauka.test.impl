using Microsoft.EntityFrameworkCore;
using nauka.test.impl.Models;
using System.ComponentModel;

namespace nauka.test.impl
{
    public partial class MainForm : Form
    {
        // Контекст базы данных
        private NaukaDbContext? dbContext;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Создание контекста базы данных
            this.dbContext = new NaukaDbContext();
            this.dbContext.Database.EnsureCreated();

            // Загрузка таблицы сотрудников
            this.dbContext.Users.Load();

            // Установка источника данных для таблицы сотрудников
            this.userBindingSource.DataSource = dbContext.Users.Local.ToBindingList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            dbContext?.Dispose();
            dbContext = null;
        }

        /// <summary>
        /// Сохранение изменений в базе данных
        /// </summary>
        private void btSave_Click(object sender, EventArgs e)
        {
            this.dbContext!.SaveChanges();
            this.dataGridView1.Refresh();
        }
    }
}