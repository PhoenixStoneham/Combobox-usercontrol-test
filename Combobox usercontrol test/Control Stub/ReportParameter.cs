using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Combobox_usercontrol_test
{
    public class ReportParameter : FrameworkElement
    {


        public IEnumerable ItemsSource
        {
            get { return (ObservableCollection<TestListItem>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for observableCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(ReportParameter), new PropertyMetadata(null));


        public Object Value
        {
            get { return (Object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(Object), typeof(ReportParameter), new FrameworkPropertyMetadata(null)
            {
                BindsTwoWayByDefault = true,
                DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
            });

        public Object PrivateValue
        {
            get { return Value; }
            set
            {
                if (DataContext == null) return;
                this.Value = value;
            }
        }

        public String Label
        {
            get { return (String)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(String), typeof(ReportParameter), new PropertyMetadata(null));



        public DataTypes DataType
        {
            get { return (DataTypes)GetValue(DataTypeProperty); }
            set { SetValue(DataTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataTypeProperty =
            DependencyProperty.Register("DataType", typeof(DataTypes), typeof(ReportParameter), new PropertyMetadata(DataTypes.String));

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }

    }

    public enum DataTypes
    {
        String
    }

    public class ParameterTemplateSelector : DataTemplateSelector
    {

        public DataTemplate StringTemplate { get; set; }
        public DataTemplate StringComboTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item.GetType() != typeof(ReportParameter))
                return base.SelectTemplate(item, container);
            ReportParameter val = (ReportParameter)item;
            switch (val.DataType)
            {
                case DataTypes.String:
                    if (val.ItemsSource == null)
                    {
                        return StringTemplate;
                    }
                    else
                    {
                        return StringComboTemplate;
                    }
            }
            return base.SelectTemplate(item, container);
        }

    }
}
