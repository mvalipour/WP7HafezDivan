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

namespace HafezDivan._UnitTests
{
    public static class _Assert_Ext
    {
        public static void AreIdentical<T>(this AsyncAsserter asserter, IEnumerable<T> list1, IEnumerable<T> list2)
        {
            asserter.AreEqual(list1.Count(), list2.Count());

            for (int i = 0; i < list2.Count(); i++)
            {
                asserter.AreEqual(list2.ElementAt(i), list1.ElementAt(i));
            }
        }
    }

    public class HistoryBehaviour
    {
        UnitTestContext Context { get; set; }

        public HistoryBehaviour(UnitTestContext context)
        {
            Context = context;
        }

        public void Given_User_Has_Not_Yet_Visited_Any_Item()
        {
            HistoryItem.Clear();
        }

        public void When_User_Views_Item_Number_(int num)
        {
            var viewModel = new GhazalViewModel();
            viewModel.Load(num);
        }

        public void Then_History_List_Should_Be(params int[] num)
        {
            var historyIndices = HistoryItem.ReadAll().Select(a => a.Index).ToArray();

            Context.Assert.AreIdentical(num, historyIndices);
        }

        internal void When_User_Clears_History()
        {
            HistoryItem.Clear();
        }
    }

    [TestClass]
    public class HistoryScenarios : TestBase
    {
        [TestMethod]
        public void User_Visits_The_First_Item()
        {
            using (var cx = GetContext())
            {
                var behaviour = new HistoryBehaviour(cx);

                behaviour.Given_User_Has_Not_Yet_Visited_Any_Item();
                behaviour.When_User_Views_Item_Number_(100);
                behaviour.Then_History_List_Should_Be(100);

                cx.Assert.Success();
            }
        }

        [TestMethod]
        public void User_Visits_A_Sequence_Of_Items()
        {
            using (var cx = GetContext())
            {
                var behaviour = new HistoryBehaviour(cx);

                behaviour.Given_User_Has_Not_Yet_Visited_Any_Item();
                behaviour.When_User_Views_Item_Number_(100);
                behaviour.When_User_Views_Item_Number_(80);
                behaviour.When_User_Views_Item_Number_(90);
                behaviour.Then_History_List_Should_Be(90, 80, 100);

                cx.Assert.Success();
            }
        }

        [TestMethod]
        public void User_Visits_Back_An_Item()
        {
            using (var cx = GetContext())
            {
                var behaviour = new HistoryBehaviour(cx);

                behaviour.Given_User_Has_Not_Yet_Visited_Any_Item();
                behaviour.When_User_Views_Item_Number_(100);
                behaviour.When_User_Views_Item_Number_(90);
                behaviour.When_User_Views_Item_Number_(80);
                behaviour.When_User_Views_Item_Number_(100);
                behaviour.Then_History_List_Should_Be(100, 80, 90);

                cx.Assert.Success();
            }
        }

        [TestMethod]
        public void User_Visits_Some_Items_Then_Clears_History()
        {
            using (var cx = GetContext())
            {
                var behaviour = new HistoryBehaviour(cx);

                behaviour.Given_User_Has_Not_Yet_Visited_Any_Item();
                behaviour.When_User_Views_Item_Number_(100);
                behaviour.When_User_Views_Item_Number_(90);
                behaviour.When_User_Views_Item_Number_(80);
                behaviour.When_User_Clears_History();
                behaviour.Then_History_List_Should_Be();

                cx.Assert.Success();
            }
        }

    }
}
