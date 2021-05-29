using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UserApi;

namespace TeleportPlugin
{
    public partial class TeleForm : Form
    {
        #region Fields

        private static string _locationDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\Teleport\";
        private static string _listFilename = _locationDirectory + @"locations.xml";
        private List<Location> _locations;

        #endregion


        public TeleForm()
        {
            InitializeComponent();
            Initialize();
        }

        #region private methods

        private void Initialize()
        {
            _lwLocations.View = View.Details;
            _lwLocations.MultiSelect = false;
            _lwLocations.FullRowSelect = true;
            _lwLocations.Sorting = SortOrder.Ascending;
            _lwLocations.Columns.Add("Name", -2, HorizontalAlignment.Left);

            LoadLocations();
            RefreshListView();
        }

        private void RefreshListView()
        {
            _lwLocations.Items.Clear();

            foreach (var location in _locations)
            {
                ListViewItem lvi = new ListViewItem(location.Name);
                lvi.Name = location.Name;
                lvi.Text = location.Name;
                lvi.Tag = location;

                _lwLocations.Items.Add(lvi);
            }
        }

        private void LoadLocations()
        {
            Directory.CreateDirectory(_locationDirectory);

            if (File.Exists(_listFilename))
            {
                _locations = UnsortedFunctions.LoadFromXml<List<Location>>(_listFilename);
            }
            else
            {
                _locations = new List<Location>();
            }

        }

        #endregion

        #region event handlers

        private void _lwLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lwLocations.SelectedItems.Count > 0)
            {
                var location = (Location)_lwLocations.SelectedItems[0].Tag;
                _tbName.Text = location.Name;
                _nupX.Value = (decimal)location.Vector.X;
                _nupY.Value = (decimal)location.Vector.Y;
                _nupZ.Value = (decimal)location.Vector.Z;
            }
        }

        private void _btnAdd_Click(object sender, EventArgs e)
        {
            var vec = new Vector3((float)_nupX.Value, (float)_nupY.Value, (float)_nupZ.Value);
            var location = new Location() { Name = _tbName.Text, Vector = vec };
            _locations.Add(location);
            RefreshListView();
        }

        private void _btnTeleport_Click(object sender, EventArgs e)
        { 
            var location = new Vector3((float)_nupX.Value, (float)_nupY.Value, (float)_nupZ.Value);
            //while (WoW.LocalPlayer.Location.CalcDistanceToVector3(location) > 1)
            //{
                WoW.LocalPlayer.TeleportToCords(location, WoW.LocalPlayer.Location.Z - 100);
            //}
        }

        private void _btnDelete_Click(object sender, EventArgs e)
        {
            var location = (Location)_lwLocations.SelectedItems[0].Tag;
            _locations.Remove(location);
            RefreshListView();
        }

        private void _btnCurrentLocation_Click(object sender, EventArgs e)
        {
            _nupX.Value = (decimal)WoW.LocalPlayer.Location.X;
            _nupY.Value = (decimal)WoW.LocalPlayer.Location.Y;
            _nupZ.Value = (decimal)WoW.LocalPlayer.Location.Z;
        }

        private void TeleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnsortedFunctions.SaveToXml(_locations, _listFilename);
        }

        #endregion
    }
}

