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
using UnitDriven;
using System.Collections;
using System.Collections.Generic;

namespace HafezDivan.Test._UnitTests
{
    public class SettingsBehaviour
    {
        UnitTestContext Context { get; set; }

        public SettingsBehaviour(UnitTestContext context)
        {
            Context = context;
        }


        public void Given_User_Opens_For_The_First_Time()
        {
        }

        public void When_User_Changes_Theme_To_(string theme)
        {
            Settings.Current.ArticleTheme = theme;
        }

        public void When_User_Hits_Save()
        {
            Settings.Current.Persist();
        }

    }

    [TestClass]
    public class SettingsScenarios : TestBase
    {

    }
}
