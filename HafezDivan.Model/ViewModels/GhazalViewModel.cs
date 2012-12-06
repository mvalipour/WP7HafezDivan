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
using System.Collections.Generic;

namespace HafezDivan
{
    public class GhazalPart
    {
        public string Part1 { get; set; }
        public string Part2 { get; set; }
    }
    public class GhazalViewModel : BaseListViewModel<GhazalPart>
    {
        public int Index { get; private set; }
        public string Title { get { return "غزل " + Index; } }

        public void Load(int index)
        {
            if (index == Index) return;

            Index = index;
            HistoryItem.AddToHistory(index);

            Items.Clear();

            NotifyPropertyChanged("Title");

            var lines = ResourceHelper.ReadAllTextLines("Ghazals/{0}.txt".FormatWith(Index)).ToList();
            if (lines.Count % 2 == 1) lines.Add(" ");

            var res = new List<GhazalPart>();

            for (int i = 0; i < lines.Count; i+=2)
            {
                res.Add(new GhazalPart
                    {
                        Part1 = lines[i],
                        Part2 = lines[i + 1]
                    });
            }

            Populate(res);
        }
    }
}
