using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window.tool
{
    public enum EIcons
    {
        folder_open = 0,
    }

    public class ResourcesHelper
    {
        public static ImageList ICONS = new ImageList();
        private const string ICON_PATH = "resources/icons/";

        static ResourcesHelper()
        {
            Init();
        }
        private static void Init()
        {

            string[] icons = Enum.GetNames(typeof(EIcons));
            foreach (string icon in icons)
            {
                try
                {
                    ICONS.Images.Add(Image.FromFile(ICON_PATH + icon + ".png"));
                }
                catch (Exception)
                {

                }
            }
        }

    }
}
