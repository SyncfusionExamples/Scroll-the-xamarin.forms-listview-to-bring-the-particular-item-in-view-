using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AutoFitSample
{
   public class Behavior : Behavior<SfListView>
    {
        SfListView ListView;
        protected override void OnAttachedTo(SfListView bindable)
        {
            ListView = bindable;
            ListView.PropertyChanged += ListView_PropertyChanged;
            ListView.DataSource.GroupDescriptors.Add(new GroupDescriptor() { PropertyName = "BookName" });
            base.OnAttachedTo(bindable);
        }

        private void ListView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedItem" && ListView != null)
            {
                var selectedItemIndex = ListView.DataSource.DisplayItems.IndexOf(ListView.SelectedItem);
                selectedItemIndex += (ListView.HeaderTemplate != null && !ListView.IsStickyHeader || !ListView.IsStickyGroupHeader) ? 1 : 0;
                selectedItemIndex -= (ListView.GroupHeaderTemplate != null && ListView.IsStickyGroupHeader) ? 1 : 0;
                (ListView.LayoutManager as LinearLayout).ScrollToRowIndex(selectedItemIndex);
            }
        }
    }
}
