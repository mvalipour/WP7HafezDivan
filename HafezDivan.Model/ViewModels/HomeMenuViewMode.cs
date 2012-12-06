using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.WindowsPhone.UI;
using System.WindowsPhone;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace HafezDivan
{
    public class HomeMenuItem
    {
        public string Title { get; set; }
        public string Icon { get { return "/Images/Home/{0}.PNG".FormatWith(Key); } }
        public BitmapImage IconSource { get { return new BitmapImage(new Uri(Icon, UriKind.Relative)); } }
        public string Key { get; set; }

    }
    public class HomeMenuViewModel : BaseListViewModel<HomeMenuItem>
    {
        public HomeMenuViewModel()
        {
            LazyPopulatingEnabled = false;
        }

        internal void Load()
        {
            if (DataLoaded) return;

            DataLoaded = true;

            var res = new List<HomeMenuItem>();

            res.Add(new HomeMenuItem
            {
                Title = "فال حافظ",
                Key = "RANDOM",
            });
            res.Add(new HomeMenuItem
            {
                Title = "تنظیمات",
                Key = "SETTINGS",
            });

            //if (App.ADVERTISEMENT_ENABLED)
            //{
            //    res.Add(new HomeMenuItem
            //    {
            //        Title = "نسخه ی بدون تبلیغات",
            //        Key = "GETADFREE",
            //    });
            //}
            res.Add(new HomeMenuItem
            {
                Title = "درباره",
                Key = "ABOUT",
            });
            res.Add(new HomeMenuItem
            {
                Title = "صفحه ی فیسبوک",
                Key = "FACEBOOK",
            });

            Populate(res);
        }
    }
}
