using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combobox_usercontrol_test
{
    public class Report
    {
        private Dictionary<string, Object> values = new Dictionary<string, object>();
        private ReportView _View;
        public Object this[string index]
        {
            get {
                if (!values.ContainsKey(index))
                    return null;
                return values[index]; }
            set { values[index] = value; }
        }

        public ObservableCollection<TestListItem> ItemsSource { get; set; } = new ObservableCollection<TestListItem>();
        public string ReportName { get; internal set; }
        public ReportView ReportView
        {
            get
            {
                if (_View == null)
                    _View = new ReportView();
                _View.InitializeComponent();
                // r.DataContext = this;
                return _View;
            }
        }
    }
}
