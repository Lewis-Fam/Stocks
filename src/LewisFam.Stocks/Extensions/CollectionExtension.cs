using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LewisFam.Stocks.Extensions
{
    public static class CollectionExtension
    {
        public static void ReplaceItem<T>(this Collection<T> col, Func<T, bool> match, T newItem)
        {
            var oldItem = col.FirstOrDefault(match);
            var oldIndex = col.IndexOf(oldItem);
            col[oldIndex] = newItem;

            //var found = col.FirstOrDefault(x=>x == myId);
            //theCollection.Remove(found);
            //theCollection.Add(newObject);
        }

        //public static void ReplaceItem<T>(this Collection<T> col, Func<T, bool> match, T newItem)
        //{
        //    for (var i = 0; i <= col.Count - 1; i++)
        //    {
        //        if (!match(col[i])) continue;
        //        col[i] = newItem;
        //        break;
        //    }
        //}
    }
}
