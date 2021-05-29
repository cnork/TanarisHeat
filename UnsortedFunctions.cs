using BotTemplate.BO;
using BotTemplate.Constants;
using BotTemplate.Hooks;
using BotTemplate.Managers;
using System; 
using System.Text;

namespace BotTemplate
{
    internal static class UnsortedFunctions
    {
        #region Public Methods

        internal static void AsmTestFunktionDONT_USE()
        {
            uint TestAdress = 0x06D4540;
            String[] asm = new String[] 
            {
                "call " +TestAdress,
                "retn",              
            };

            D3DHook.InjectAndExecuteAsm(asm);
        }

        internal static void TestDummy()
        {
            string[] asm = new string[]
                {
                    "retn",
                };
            D3DHook.InjectAndExecuteAsm(asm);
        }
        
        #endregion
    }
}
