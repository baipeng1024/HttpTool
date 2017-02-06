using HttpTool.Core.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window.tool
{


    public class ResourcesHelper
    {
        

        public static ImageList IMAGES = new ImageList();

        public const string IMG_EXPORT_KEY = "export";
        public const string IMG_FLOW_KEY = "flow";
        public const string IMG_FOLDER_CLOSE_KEY = "folder_close";
        public const string IMG_FOLDER_OPEN_KEY = "folder_open";
        public const string IMG_FULL_SCREEN_KEY = "full_screen";
        public const string IMG_HTTP_KEY = "http";
        public const string IMG_IMPORT_KEY = "import";
        public const string IMG_JS_KEY = "js";
        public const string IMG_SABER_KEY = "saber";
         

        static ResourcesHelper()
        {
            Init();
        }

        private static void Init()
        {
            PropertyInfo[] props = typeof(Resource).GetProperties(BindingFlags.Static | BindingFlags.NonPublic);
            foreach (PropertyInfo prop in props)
            {
                if (prop.PropertyType == typeof(Bitmap))
                {
                    IMAGES.Images.Add(prop.Name, (Bitmap)Resource.ResourceManager.GetObject(prop.Name, Resource.Culture));
                }
            }

        }

    }
}
