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
    public class HistoryViewModel : BaseListViewModel<Ghazal>
    {
        public bool IsValid { get; set; }
        public void Load()
        {
            if (!IsValid)
            {
                IsValid = true;

                Populate(HistoryItem.ReadAll().OrderByDescending(a => a.Date).Select(a => new Ghazal { Index = a.Index }));
            }
        }
    }
}
