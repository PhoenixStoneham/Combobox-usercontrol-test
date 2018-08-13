using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combobox_usercontrol_test
{
    class TestViewModel
    {
        public TestViewModel()
        {
            Reports = new ObservableCollection<Report>();
            Report r = new Report();
            ObservableCollection<TestListItem> i = new ObservableCollection<TestListItem>();
            i.Add(new TestListItem() { Description = "Test", Value = "Test" });
            i.Add(new TestListItem() { Description = "Description", Value = "Value" });

            r.ItemsSource = i;
            r.ReportName = "Test 1";
            Reports.Add(r);
            r = new Report();
            i = new ObservableCollection<TestListItem>();
            i.Add(new TestListItem() { Description = "Test", Value = "Test" });
            i.Add(new TestListItem() { Description = "Description", Value = "Value" });

            r.ItemsSource = i;
            r.ReportName = "Test 2";
            Reports.Add(r);
        }
        public ObservableCollection<Report> Reports { get; set; }
        public Report SelectedReport { get; set; }


    }


}
