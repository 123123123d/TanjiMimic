using TanjiMimic.Utilities.Enums;
namespace TanjiMimic.Utilities.Localization
{
    public static class Strings
    {
        #region Form
        public static string FormTitle(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "TanjiMimic - Main";
                    break;
                case TLang.Spanish:
                    Value = "TanjiMimic - Principal";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        #endregion
        #region Buttons
        public static string ClearButton(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Clear";
                    break;
                case TLang.Spanish:
                    Value = "Limpiar";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        #endregion
        #region Labels
        public static string InfoLbl(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = @"Tanji Mimic is a remke of the iconic NovoMimic made by Arachis. It allows users to gather user data and use it to 'mimic' their actions, clothing & speech.

Tanjimimic is Open source and the repository is hosted on GitHub and can be publicly found here:

It should be familiar if you've utilzed NovoMimic or not in the past. The User Interface is highly self explanatory. Report any bugs to DarkBox: ItzUZ






TanjiMimic v0.0.5 [Debug]
                                                                                TanjiMimic by JustDevInc
                                                                          TanjiMimic made possible Arachis";
                    break;
                case TLang.Spanish:
                    Value = @"Tanji Mimic es una nueva versión de la extensión anterior 'NovoMimic' que fue hecha por Arachis. Permite al usuario reunir los datos de la victima, de esta forma poder imitar cualquier acción, ropa y el habla.

TanjiMimic es de código abierto, el repositorio esta publicado en GitHub, usted puede encontrarlo aquí:


Si usted ha utilizado NovoMimic puede sentirse familiarizado con esta nueva versión. Todas las dudas serán aclaradas por si mismas. Usted puede informar de cualquier error en Darkbox: ItzUzi





V0.0.3 TanjiMimic [Depurar]
                                                                                 TanjiMimic por JustDevInc
                                                                                      Tanji por ArachisH";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        #endregion
        #region GroupBoxes
        public static string InformationGrpBx(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Information";
                    break;
                case TLang.Spanish:
                    Value = "Información";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string PlayerInformation(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Player Information";
                    break;
                case TLang.Spanish:
                    Value = "Informacion del Jugador";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string ToolBoxOptionsGrpBx(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Toolbox/Options";
                    break;
                case TLang.Spanish:
                    Value = "Herramientas/Opciones";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        #endregion
        #region CheckBoxes
        public static string AutomaticallyLoadInformation(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Automatically Load Information";
                    break;
                case TLang.Spanish:
                    Value = "Autocargar Informarción";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string AutomaticallyCopyClothesMotto(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Automatically copy Clothes/Motto";
                    break;
                case TLang.Spanish:
                    Value = "Autocopiar Ropa/Misión";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string MimicMessage(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Mimic Message";
                    break;
                case TLang.Spanish:
                    Value = "Imitar Consola";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string MimicSpeech(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Mimic Speech";
                    break;
                case TLang.Spanish:
                    Value = "Imitar Habla";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string MimicMotto(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Mimic Motto";
                    break;
                case TLang.Spanish:
                    Value = "Imitar misión";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string MimicClothes(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Mimic Clothes";
                    break;
                case TLang.Spanish:
                    Value = "Imitar ropa";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string MimicSign(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Mimic Sign";
                    break;
                case TLang.Spanish:
                    Value = "Imitar Signos";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string MimicStance(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Mimic Stance";
                    break;
                case TLang.Spanish:
                    Value = "Imitar Postura";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string MimicDance(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Mimic Dance";
                    break;
                case TLang.Spanish:
                    Value = "Imitar Baile";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string MimicGesture(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Mimic Gesture";
                    break;
                case TLang.Spanish:
                    Value = "ImitarAcciones";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        #endregion
        #region TabPages
        public static string MainTab(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Main";
                    break;
                case TLang.Spanish:
                    Value = "Incio";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string ToolBoxTab(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Toolbox";
                    break;
                case TLang.Spanish:
                    Value = "Herrmientas";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string SettingsTab(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Settings";
                    break;
                case TLang.Spanish:
                    Value = "Configuración";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }

        #endregion
        #region DataGrid
        public static string Category (TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Category";
                    break;
                case TLang.Spanish:
                    Value = "Categoría";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string Value(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Value";
                    break;
                case TLang.Spanish:
                    Value = "Valor";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        #endregion
        public static string TitleFormat(TLang Lang)
        {
            string Format = "";
            switch (Lang)
            {
                case TLang.English:
                    Format = "Select Player - Total: {0}";
                    break;
                case TLang.Spanish:
                    Format = "Seleccionar Jugador - Total {0}";
                    break;
                case TLang.None:
                    Format = "Select Player - Total: {0}";
                    break;
                default:
                    break;
            }
            return Format;
        }
        public static string Name(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Name";
                    break;
                case TLang.Spanish:
                    Value = "Nombre";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string ID(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "ID";
                    break;
                case TLang.Spanish:
                    Value = "ID";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string Tile(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Tile";
                    break;
                case TLang.Spanish:
                    Value = "Caminar";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string Figure(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Figure";
                    break;
                case TLang.Spanish:
                    Value = "Figura";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string Motto(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Motto";
                    break;
                case TLang.Spanish:
                    Value = "Misión";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string Gender(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Gender";
                    break;
                case TLang.Spanish:
                    Value = "Genero";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string Group(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Group";
                    break;
                case TLang.Spanish:
                    Value = "Grupo";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
        public static string Index(TLang Lang)
        {
            string Value = "";
            switch (Lang)
            {
                case TLang.English:
                    Value = "Index";
                    break;
                case TLang.Spanish:
                    Value = "Indice";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            return Value;
        }
    }
}
