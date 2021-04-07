using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinNewsReader.Interfaces;

namespace XamarinNewsReader.Helpers
{
    public static class StorageHelper
    {
        public static List<string> GetSpecialFolders()
        {
            return Xamarin.Forms.DependencyService.Get<IFileHelper>().GetSpecialFolders();
        }

        public static string GetLocalFolderPath()
        {
            return Xamarin.Forms.DependencyService.Get<IFileHelper>().GetLocalFilePath("paperboy.db3");
        }
    }
}
