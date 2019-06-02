namespace LYLStudio.Core.Structures
{
    //todo
    public static class GroupEnumerable
    {
        //public static IList<INode<T>> BuildTree<T>(this IEnumerable<INode<T>> source, INode<T> root = null)
        //{
        //    var groups = source.GroupBy(i => i.ParentId);
        //    var roots = new List<INode<T>>();

        //    if (root != null)
        //        roots.Add(root);
        //    else
        //        roots.AddRange(groups.FirstOrDefault(g => string.IsNullOrEmpty(g.Key)));

        //    if (roots.Count > 0)
        //    {
        //        var dict = groups.Where(g => !string.IsNullOrEmpty(g.Key)).ToDictionary(g => g.Key, g => g.ToList());
        //        for (int i = 0; i < roots.Count; i++)
        //            AddChildren(roots[i], dict);
        //    }

        //    return roots;
        //}

        //private static void AddChildren<T>(INode<T> node, IDictionary<string, IEnumerable<INode<T>>> source)
        //{
        //    if (source.ContainsKey(node.Id))
        //    {
        //        node.Children = source[node.Id];
        //        for (var i = 0; i < node.Children.Count; i++)
        //            AddChildren(node.Children[i], source);
        //    }
        //    else
        //    {
        //        node.Children = new List<INode<T>>();
        //    }
        //}
    }
}
