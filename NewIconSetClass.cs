using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RobloxStudioModder.Content
{
    public class NewIconSetClass
    {
        public static bool SetIcons(string IconSetName, string StudioVersionPath, string IconPath)
        {

            IconPath = Path.GetFullPath(IconPath);

            if (File.Exists(IconPath))
            {
                try
                {

                    FileInfo fileInfo = new FileInfo($@"{StudioVersionPath}\content\textures\ClassImages.png");

                    fileInfo.Delete();

                    string Source = IconPath;
                    string Objetive = $@"{StudioVersionPath}\content\textures\ClassImages.png";

                    File.Copy(Source, Objetive);
 
                    return true;
                }
                catch (Exception e)
                {
                    // creates messagebox
                    MessageBox.Show(e.Message);
                    return false;
                }
            } 
            else
            {
                return false;
            }
        }
    }
}
