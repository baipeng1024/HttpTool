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


        public static string GetImgKey(Bitmap img)
        {
            foreach (string key in IMAGES.Images.Keys)
            {
                if (IMAGES.Images[key] == img)
                {
                    return key;
                }
            }
            return null;
        }


    }
}
