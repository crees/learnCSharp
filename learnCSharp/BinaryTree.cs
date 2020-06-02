using System;

/// <summary>
/// A Binary Tree- we're not going to bother with deletion because it's fiddly.
/// 
/// We could do traversals however... if we fancy having a go.
/// 
/// Don't worry about the T in angle brackets, it just means we can
/// have a BinaryTree of ints, strings or even Persons.  Have a look
/// in Program.cs for how that works.
/// </summary>
public class BinaryTree<T>
{
    BinaryTree<T> left, right;
    T data;

    public BinaryTree(T data)
    {
        this.data = data;
        left = null;
        right = null;
    }

    /// <summary>
    /// We need to work out whether to put it on the left or the right.
    /// 
    /// Of course, if data is *greater* than the current value, it goes on the right, otherwise on the left.  What if it's equal?
    /// 
    /// If data is already there, you'll need to add to that one.  For example, if left != null, then left.Add(data)
    /// </summary>
    /// <param name="data"></param>
    public void Add(T data)
    {

    }

    /// <summary>
    /// This relies on T being an int, string or something that WriteLine can handle.
    /// Don't be surprised if it breaks if you use something that isn't printable!
    /// </summary>
    public void InOrder()
    {
        if (left != null)
        {
            left.InOrder();
        }
        Console.Out.WriteLine(data);
        if (right != null)
        {
            right.InOrder();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns>true if data is in the tree, false if it's not</returns>
    public bool Exists(T data)
    {


    }
}
