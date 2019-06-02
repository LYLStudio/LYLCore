namespace LYLStudio.Core.Structures
{
    //todo

    public interface INode<T>
    {
        string Id { get; set; }
        string ParentId { get; set; }
        T Data { get; set; }
        bool HasChildren { get; }
        int Count { get; }

        INode<T> FindNode(string id);
    }

    //public class Node<T> : INode<T>
    //{
    //    public delegate bool TraversalNodeDelegate(INode<T> node);

    //    private IList<INode<T>> _children { get; }


    //    public string Id { get; set; }
    //    public string ParentId { get; set; }
    //    public T Data { get; set; }
    //    public bool HasChildren => _children.Count > 0;
    //    public int Count => _children.Count;

    //    public Node(T data = default(T))
    //    {
    //        _children = new List<INode<T>>();
    //        Data = data;
    //    }


    //}
}
