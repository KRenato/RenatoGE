using System.Collections.ObjectModel;
using Core.Interfaces;

namespace Core
{
    internal class RenderMap : KeyedCollection<Coordinate, IMappable>
    {
        protected override Coordinate GetKeyForItem(IMappable item)
        {
            return item.Coordinate;
        }
    }
}
