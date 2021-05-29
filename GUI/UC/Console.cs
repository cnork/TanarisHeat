using BotTemplate.Helper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BotTemplate.GUI.UC
{
    public partial class Console : UserControl
    {
        #region Fields

        private Graphics _graphics;

        #endregion

        #region Constructors

        public Console()
        {
            InitializeComponent();
            Subscribe();

            //_graphics = _lbConsole.CreateGraphics();
        }

        #endregion

        #region Private Methods

        private void Subscribe()
        {
            Logger.Instance.WriteToConsoleEvent += new Logger.WriteToConsoleHandler(WriteHandler);
        }

        //private bool WillFit(string str)
        //{
        //    var size = _graphics.MeasureString(str, _lbConsole.Font).ToPointF();
        //    return (size.X <= _lbConsole.Width);
        //}

        //private string SplitFittingPartOfString(ref string str)
        //{
        //    var cWidth = _lbConsole.Width - 20;
        //    var tolerance = 5;

        //    var divider = 2;
        //    var sub = str;
        //    var subSize = _graphics.MeasureString(sub, _lbConsole.Font);

        //    while (subSize.Width > cWidth)
        //    {
        //        sub = str.Substring(0, (sub.Length / 2));
        //        subSize = _graphics.MeasureString(sub, _lbConsole.Font);
        //    }

        //    var diff = Math.Abs(subSize.Width - (cWidth));
        //    while (diff > tolerance)
        //    {
        //        if (subSize.Width > (cWidth))
        //        {
        //            sub = str.Substring(0, (sub.Length - (sub.Length / divider)));
        //        }
        //        else
        //        {
        //            sub = str.Substring(0, (sub.Length + (sub.Length / divider)));
        //        }

        //        divider *= 2;
        //        if ((sub.Length / divider) < 1)
        //            divider = sub.Length;

        //        subSize =_graphics.MeasureString(sub, _lbConsole.Font);
        //        diff = Math.Abs(subSize.Width - (cWidth));
        //    }

        //    str = str.Remove(0, sub.Length);
        //    return sub;
        //}

        #endregion

        #region Event Methods

        private void WriteHandler(string message)
        {
            _tbConsole.Text = message;

            //List<string> itemsToAdd = new List<string>();

            ////while (!WillFit(message))
            ////{
            ////    itemsToAdd.Add(SplitFittingPartOfString(ref message));
            ////}

            ////itemsToAdd.Add(message);

            ////for (int i = itemsToAdd.Count; i > 0; i--)
            ////    _lbConsole.Items.Insert(0, itemsToAdd[i - 1]);

            ////while (_lbConsole.Items.Count > 1000)
            ////{
            ////    _lbConsole.Items.RemoveAt(_lbConsole.Items.Count - 1);
            ////}
        }
     
        #endregion
    }
}
