using System;
using System.Linq;
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

namespace HafezDivan
{
    public class GhazalListViewModel : BaseListViewModel<Ghazal>
    {
        string Filter { get; set; }

        public GhazalListViewModel()
        {
            LazyPopulatingEnabled = false;
        }

        public void Load(string filter)
        {
            if (filter == Filter) return;

            Filter = filter;
            Load();
        }

        void Load()
        {
            var number = 0;
            var isNumber = int.TryParse(Filter, out number);

            Populate(Ghazal.GetAll().Where(a =>
            {
                if (Filter.HasValue() == false) return true;
                if (isNumber)
                {
                    if (a.Index.ToString().Contains(Filter)) return true;
                }
                else
                {
                    if (a.Intro.Contains(Filter)) return true;
                }
                return false;
            }).Take(30));
        }
    }
}
