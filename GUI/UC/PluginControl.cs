using BotTemplate.Helper.Xml;
using BotTemplate.Managers;
using UserApi;
using UserApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BotTemplate.GUI.UC
{
    internal partial class PluginControl : UserControl
    {
        #region Fields

        private List<IPlugin> _plugins = PluginManager.Plugins;

        #endregion

        #region Constructors

        public PluginControl()
        {
            InitializeComponent();
            Initialize();
        }
      
        #endregion

        #region Public Methods

        internal void Refresh()
        {
            RefreshListView();
        }

        #endregion

        #region Private Methpods

        private void Initialize()
        {
            InitializeListView();
            LoadWidgets();
            _btnReload.PerformClick();
        }

        private void InitializeListView()
        {
            _lwPlugins.View = View.Details;
            _lwPlugins.GridLines = true;
            _lwPlugins.CheckBoxes = true;
            _lwPlugins.MultiSelect = false;
            _lwPlugins.FullRowSelect = true;
            _lwPlugins.Sorting = SortOrder.Ascending;

            _lwPlugins.Columns.Add("Name", -2, HorizontalAlignment.Left);
            _lwPlugins.Columns.Add("Version", -2, HorizontalAlignment.Left);
        }

        private void LoadWidgets()
        {
            _cbCartegories.DataSource = Enum.GetValues(typeof(Enums.PluginType));
        }

        private void RefreshListView()
        {
            _lwPlugins.Items.Clear();

            foreach(IPlugin p in _plugins)
            {
                Enums.PluginType pType;
                Enum.TryParse<Enums.PluginType>(_cbCartegories.SelectedValue.ToString(), out pType);
                if (pType == Enums.PluginType.All || p.PluginType == pType)
                {
                    ListViewItem lvi = new ListViewItem(p.Name);
                    lvi.Name = p.Name;
                    lvi.SubItems.Add(p.Version);
                    lvi.Tag = p;
                    lvi.Text = p.Name;
                    lvi.BackColor = GetColor(lvi);

                    _lwPlugins.Items.Add(lvi);
                }
            }

            SetRecentlyUsedPlugins();
        }

        private Color GetColor(ListViewItem lvi)
        {
            IPlugin p = (IPlugin)lvi.Tag;
            switch(p.PluginType)
            {
                case UserApi.Enums.PluginType.DeathKnigh:
                    return Color.FromArgb(196, 30, 59);
                case UserApi.Enums.PluginType.Druid:
                    return Color.FromArgb(255, 125, 10);
                case UserApi.Enums.PluginType.Hunter:
                    return Color.FromArgb(171, 212, 115);
                case UserApi.Enums.PluginType.Mage:
                    return Color.FromArgb(105, 204, 240);
                case UserApi.Enums.PluginType.Paladin:
                    return Color.FromArgb(245, 140, 186);
                case UserApi.Enums.PluginType.Priest:
                    return Color.FromArgb(255, 255, 255);
                case UserApi.Enums.PluginType.Rogue:
                    return Color.FromArgb(255, 245, 105);
                case UserApi.Enums.PluginType.Shaman:
                    return Color.FromArgb(0, 112, 222);
                case UserApi.Enums.PluginType.Warlock:
                    return Color.FromArgb(148, 130, 210);
                case UserApi.Enums.PluginType.Warrior:
                    return Color.FromArgb(199, 156, 110);
                case UserApi.Enums.PluginType.Utility:
                    return Color.LightGray;
                default:
                    return Color.White;
            }
        }

        private void SetRecentlyUsedPlugins()
        {
            foreach (ListViewItem lvi in _lwPlugins.Items)
            {
                IPlugin p = (IPlugin)lvi.Tag;
                if (Bot.Settings.UsedPlugins.Contains(p.Name))
                    lvi.Checked = true;
            }
        }

        #endregion
        
        #region Event Handler Methods

        private void _btnReload_Click(object sender, EventArgs e)
        {
            PluginManager.LoadPlugins();
            RefreshListView();
        }

        private void _btnSettings_Click(object sender, EventArgs e)
        {
            if (_lwPlugins.SelectedItems.Count == 1)
            {
                IPlugin p = (IPlugin)_lwPlugins.SelectedItems[0].Tag;
                p.OpenForm();            
            }
        }

        private void _lwPlugins_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var p = (IPlugin)_lwPlugins.Items[e.Index].Tag;
            if (e.NewValue == CheckState.Checked)
            {
                PluginManager.EnablePlugin(p);
                if (!Bot.Settings.UsedPlugins.Contains(p.Name))
                    Bot.Settings.UsedPlugins.Add(p.Name);
            }
            else
            {
                PluginManager.DisablePlugin(p);
                if (Bot.Settings.UsedPlugins.Contains(p.Name))
                    Bot.Settings.UsedPlugins.Remove(p.Name);
            }

            Bot.SaveSettings();
        }

        private void _lwPlugins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 0x0D) && _lwPlugins.SelectedItems.Count == 1)
            {
                if (_lwPlugins.SelectedItems[0].Checked)
                    _lwPlugins.SelectedItems[0].Checked = false;
                else
                    _lwPlugins.SelectedItems[0].Checked = true;
            }
        }

        private void _lwPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lwPlugins.SelectedItems.Count == 1)
            {
                IPlugin p = (IPlugin)_lwPlugins.SelectedItems[0].Tag;
                _tbDescription.Text = p.Description;  
            }
        }

        private void _cbCartegories_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListView();
        }

        #endregion
       
    }
}
