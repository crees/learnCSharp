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
public class BinaryTree<T> where T : IComparable
{
    private BinaryTree<T> left, right;
    readonly T data;

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
    /// You have to use the .CompareTo method, as illustrated, as we have a generic method.
    /// 
    /// If data is already there, you'll need to add to that one.  For example, if left != null, then left.Add(data)
    /// </summary>
    /// <param name="data"></param>
    public void Add(T data)
    {
        // If data is greater than this.data
        if (data.CompareTo(this.data) > 0)
        {
            try
            {
                this.right.Add(data);
            }
            catch (NullReferenceException e)
            {
                this.right = new BinaryTree<T>(data);
            }
        } 
        else
        {
            try
            {
                this.left.Add(data);
            }
            catch (NullReferenceException e)
            {
                this.left = new BinaryTree<T>(data);
            }
        }
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

    public void PreOrder()
    {
        Console.Out.WriteLine(data);
        if (left != null)
        {
            left.InOrder();
        }
        if (right != null)
        {
            right.InOrder();
        }

    }

    public void PostOrder()
    {
        if (left != null)
        {
            left.InOrder();
        }
        if (right != null)
        {
            right.InOrder();
        }
        Console.Out.WriteLine(data);
    }

    /// <summary>
    /// You'll need to recurse through the tree; this is a binary search.
    /// </summary>
    /// <param name="data"></param>
    /// <returns>true if data is in the tree, false if it's not</returns>
    public bool Exists(T data)
    {
        // If they're equal
        if (data.CompareTo(this.data) == 0)
        {
            return true;
        }

        if (data.CompareTo(this.data) > 0)
        {
            try
            {
                return this.right.Exists(data);
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        try
        {
            return this.left.Exists(data);
        }
        catch (NullReferenceException)
        {
            return false;
        }
    }
}
