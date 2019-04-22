using Mtf.Core;
using Mtf.Languages;
using Mtf.Persistence.Entities;
using Mtf.Persistence.Repositories;
using Mtf.Settings;
using System;
using System.ComponentModel.Composition;
using System.Security.Permissions;
using System.Windows.Forms;

namespace HighLevelDesigner
{
    public partial class MainForm : Form
    {
        private readonly Settings settings;
        private User currentUser;

        [Import]
        private RolesRepository rolesRepository;

        [Import]
        private UsersRepository usersRepository;

        [Import]
        private UserRolesRepository userRolesRepository;

        [Import]
        private OptionsRepository optionsRepository;

        public MainForm()
        {
            InitializeComponent();
            settings = SettingsProvider.Get();

            var mefLoader = MefLoader.Get();
            var container = mefLoader.GetCompositionContainerr("Mtf.Persistence");
            rolesRepository = container.GetExportedValue<RolesRepository>();
            usersRepository = container.GetExportedValue<UsersRepository>();
            userRolesRepository = container.GetExportedValue<UserRolesRepository>();
            optionsRepository = container.GetExportedValue<OptionsRepository>();

            currentUser = usersRepository.GetOrCreate(Environment.UserName);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "AbleToExit")]
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void About_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.SetWindowProperties(settings);
            LoadLanguageElements();
        }

        private void LoadLanguageElements()
        {
            Lng.LoadLanguageElements(
                (MainMenu, "Menu"),
                (File, "File"),
                (Help, "Help"),
                (About, "About"),
                (Exit, "Exit"));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ModifySettings(settings);
            SettingsProvider.SaveSettings(settings);
        }
    }
}
