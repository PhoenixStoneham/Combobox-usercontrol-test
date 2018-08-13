using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Combobox_usercontrol_test
{
    /// <summary>man
    /// Interaction logic for Test_Usercontrol.xaml
    /// </summary>
    public partial class ReportControl : UserControl
    {
        public ReportControl()
        {
            InitializeComponent();
            ((FrameworkElement)Content).DataContext = this;
            Parameters = new ObservableCollection<ReportParameter>();
            Parameters.CollectionChanged += ParamAdded;
        }

        private void ParamAdded(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                foreach (ReportParameter x in e.NewItems)
                    x.DataContext = DataContext;
        }

        public ObservableCollection<ReportParameter> Parameters
        {
            get;set;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == DataContextProperty)
                foreach (ReportParameter x in Parameters)
                    x.DataContext = e.NewValue;
        }
    }
}
