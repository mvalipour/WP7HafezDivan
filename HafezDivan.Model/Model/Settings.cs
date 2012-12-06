﻿using System;
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
using System.IO.IsolatedStorage;
using System.WindowsPhone;
using System.Xml.Serialization;

namespace HafezDivan
{
    public class Settings
    {
        public string ArticleTheme { get; set; } // Default, Dark, Light, Paper

        public Settings()
        {
            ArticleTheme = "Default";
        }

        static Settings _Current;
        static public Settings Current
        {
            get
            {
                if (_Current == null)
                {
                    using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        if (isf.FileExists("Settings.xml"))
                        {
                            _Current = Serializer.DeserializeXml<Settings>(isf.ReadAllText("Settings.xml"));
                        }
                        else
                        {
                            _Current = new Settings();
                        }
                    }
                }
                return _Current;
            }
        }

        public void Persist()
        {
            using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                isf.WriteAllText("Settings.xml", Serializer.SerializeXml(this));
            }

            // OnSaved!
            //App.MyApp.SetupArticleThemeResources();
        }
    }
}
