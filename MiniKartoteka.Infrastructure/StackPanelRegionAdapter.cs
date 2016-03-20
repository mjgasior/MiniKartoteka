using Prism.Regions;
using System.Windows.Controls;
using System.Collections.Specialized;
using System.Windows;

namespace MiniKartoteka.Infrastructure
{
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement item in e.NewItems)
                    {
                        regionTarget.Children.Add(item);
                    }
                }
                // handle remove
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
