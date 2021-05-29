using BotTemplate.Helper.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core = BotTemplate;

namespace UserApi
{
    public static class UnsortedFunctions
    {
        #region Methods
    
        public static void AsmTestFunktionDONT_USE()
        {
            Core.UnsortedFunctions.AsmTestFunktionDONT_USE();
        }

        public static void TestDummy()
        {
            Core.UnsortedFunctions.TestDummy();
        }

        public static void SaveToXml(object IClass, string filename)
        {
            XmlSave.SaveData(IClass, filename);
        }

        public static T LoadFromXml<T>(string filename)
        {
            var loader = new XmlLoad<T>();
            return loader.LoadData(filename);
        }

        #endregion
    }
}
