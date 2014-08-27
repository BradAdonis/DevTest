using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerApplication.Binding
{
    public class BindingItem
    {
        public int ID { get; set; }
        public string DisplayName { get; set; }
    }

    public class BindableItems: ObservableCollection<BindingItem>
    {
        public BindableItems() { }

        public void AddItems(List<BindingItem> Items)
        {
            if (Items != null)
            {
                if (Items.Count > 0)
                {
                    foreach (BindingItem i in Items)
                    {
                        try
                        {
                            this.Add(i);
                        }

                        catch { }

                    }
                }
            }
        }
    }
}
