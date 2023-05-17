using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoConversorMonetario
{

    public enum TipeConvert : byte {  Eur_Dollar, Dollar_Eur }
    public static class Controller
    {

        private enum MainMenu : byte { Exit, ChangeValues, ConvertMoney}
        public static void MainController()
        {
            MainMenu menu = MainMenu.Exit; //Inicializamos la enum del menu para poder usarla

            //Comprobamos que el fichero exista
            Files.CheckFile();

            do
            {
                menu = (MainMenu)Interface.MainMenuOption((byte)MainMenu.ConvertMoney);

                switch (menu)
                {
                    case MainMenu.ChangeValues:
                        ChangeValues(); 
                        break; 
                        case MainMenu.ConvertMoney:
                        ConvertMoney(); 
                        break;
                }

            } while (menu != MainMenu.Exit); 
        }
        private enum MenuConvert : byte { Exit , Eur_Dollar, Dollar_Eur }
        private static void ConvertMoney()
        {
            MenuConvert tipe = MenuConvert.Exit;
            double valueFromFile;
            double valueByUser;
            double result;

            do
            {
                tipe = (MenuConvert)Interface.ConvertMenuOption((byte)MenuConvert.Dollar_Eur);

                switch (tipe)
                {
                    case MenuConvert.Eur_Dollar:
                        valueFromFile = Files.ObtainValueFromFile((byte)TipeConvert.Eur_Dollar);
                        valueByUser = Interface.UserValue();
                        result = valueFromFile * valueByUser;
                        Interface.ShowResults(result);
                        break;



                    case MenuConvert.Dollar_Eur:
                        valueFromFile = Files.ObtainValueFromFile((byte)TipeConvert.Dollar_Eur);
                        valueByUser = Interface.UserValue();
                        result = valueFromFile * valueByUser;
                        Interface.ShowResults(result); 
                        break;
                }
            } while (tipe != MenuConvert.Exit);

            

        }

        private static void ChangeValues()
        {
            StreamWriter writer = null;

            string confirmation = ""; 
            double eur = 0;
            double doll = 0; 

            do
            {

                eur = Interface.EurValue();
                doll = Interface.DollValue();

                Files.CreateFile(eur, doll);


                confirmation = Interface.ExitConfirmation();

            } while (confirmation.ToLower() == "N");
        }
    }
}
