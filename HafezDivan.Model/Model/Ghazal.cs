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
using System.IO;

namespace HafezDivan
{
    public static class ResourceHelper
    {
        public static string[] ReadAllTextLines(string name)
        {
            var ResrouceStream = Application.GetResourceStream(new Uri(name, UriKind.Relative));

            if (ResrouceStream != null)
            {
                var myFileStream = ResrouceStream.Stream;
                if (myFileStream.CanRead)
                {
                    var myStreamReader = new StreamReader(myFileStream);

                    //read the content here
                    return myStreamReader.ReadToEnd().Split(Environment.NewLine).Where(a => a.HasValue()).ToArray();
                }

            }

            return new string[0];
        }
    }
    public class Ghazal
    {
        public int Index { get; set; }
        public string Title { get { return "غزل " + Index; } }
        public string Intro { get { return AllIntros[Index - 1]; } }
        public string AudioUrl { get { return "http://naghsheh.info/hafezaudio/{0}.mp3".FormatWith(Index); } }

        public static IEnumerable<Ghazal> GetAll()
        {
            return Enumerable.Range(1, AllIntros.Count).Select(a => new Ghazal { Index = a });
        }

        static List<string> _AllIntros;
        public static List<string> AllIntros
        {
            get
            {
                if (_AllIntros == null) _AllIntros = ResourceHelper.ReadAllTextLines("Ghazals/Index.txt").ToList();
                return _AllIntros;
            }
        }
    }
}
