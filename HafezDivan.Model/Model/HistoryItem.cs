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
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.WindowsPhone;

namespace HafezDivan
{
    public class HistoryItem
    {
        public int Index { get; set; }
        public DateTime Date { get; set; }

        public HistoryItem()
        {
            Date = DateTime.Now;
        }

        const int MAX_TO_KEEP = 30;

        public static void Clear()
        {
            HistoryItem.WriteAll(new List<HistoryItem>());
        }

        public static List<HistoryItem> ReadAll()
        {
            return (List<HistoryItem>)IsolatedStorageSettings.ApplicationSettings.TryGet("HistoryItems") ?? new List<HistoryItem>();
        }

        public static void WriteAll(List<HistoryItem> items)
        {
            IsolatedStorageSettings.ApplicationSettings["HistoryItems"] = items.OrderByDescending(a => a.Date).Take(MAX_TO_KEEP).ToList();
            IsolatedStorageSettings.ApplicationSettings.Save();

            //App.HistoryViewModel.IsValid = false;
        }
        public static void AddToHistory(int index)
        {
            WriteAll(ReadAll().Where(a => a.Index != index).Concat(new[] { new HistoryItem { Index = index } }).ToList());
        }
    }
}
