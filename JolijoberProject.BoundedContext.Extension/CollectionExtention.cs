using System;
using System.Collections.Generic;
using System.Linq;
using JolijoberProject.Shared.SharedKernal.SharedModel;

namespace JolijoberProject.BoundedContext.Extension
{
    public static class CollectionExtention
    {
        public static long HierarchyCount(this IEnumerable<Comment> list)
        {
            long iterator = 0;

            foreach (var item in list)
            {
                iterator++;
                iterator+= item.ChildComments.Count()==0?0:HierarchyCount(item.ChildComments);
            }
            return iterator;
        }


        public static long HierarchyCount(this Comment[] list)
        {
            long iterator = 0;

            foreach (var item in list)
            {
                iterator++;
                iterator += HierarchyCount(item.ChildComments);
            }
            return iterator;
        }



        //static int RecursiveChildrenCount<T>(T obj)
        //{
        //    if (obj.Children.Count == 0)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return obj.Children.Count + obj.Children.Aggregate(0,
        //          (count, asset) => count += RecursiveChildrenCount(asset));
        //    }

        //}

    }
}
