using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotTemplate
{
    public class MyFormControl : Control
    {
        public delegate void WriteToConsole(string text);

        public WriteToConsole myDelegate;
        private Thread myThread;
        private ListBox myListBox;

        public MyFormControl()
        {
            ListBox box = new ListBox();
            Pulse(box);
            myDelegate = WriteToActualConsole;

            myThread = new Thread(Run);
            myThread.Start();
        }

        public void Pulse(Control ctrl)
        {
            //ctrl.Invoke(asdksjkjdf)
        }

        public void WriteToActualConsole(string text)
        {
            String myItem;
            for (int i = 1; i < 6; i++)
            {
                myItem = text + " " + i.ToString();
                Console.WriteLine(myItem);
                Thread.Sleep(300);
            }
        }

        public void Run()
        {
            // Execute the specified delegate on the thread that owns
            // 'myFormControl1' control's underlying window handle.
            Invoke(this.myDelegate);
        }

        private void Invoke(WriteToConsole writeToConsole)
        {
            throw new NotImplementedException();
        }
    }
}
