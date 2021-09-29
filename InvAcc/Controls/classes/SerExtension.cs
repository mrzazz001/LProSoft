using System;
using System.Linq;
using System.Collections.Generic;

//<summary>
//Summary description for Enumerable
//</summary>
public static class EnumerableExtension
{
    private static TSerializableEntity ToTSerializableEntity<TEntity, TSerializableEntity>(TEntity entity)
        where TEntity : class, new()
        where TSerializableEntity : SerializableEntity<TEntity>, new()
    {
        TSerializableEntity serializable = new TSerializableEntity();
        serializable.Entity = entity;
        return serializable;
    }

    // Summary:
    //     Returns the input typed as System.Collections.Generic.IEnumerable<T>.

    // Parameters:
    //   source:
    //     The sequence to type as System.Collections.Generic.IEnumerable<T>.

    // Type parameters:
    //   TSource:
    //     The type of the elements of source.

    // Returns:
    //     The input sequence typed as System.Collections.Generic.IEnumerable<T>.
    public static IEnumerable<TSerializableEntity> AsEnumerable<TSource, TSerializableEntity>(this IEnumerable<TSource> source)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return source.ToList<TSource, TSerializableEntity>() as IEnumerable<TSerializableEntity>;
    }

    //
    // Summary:
    //     Returns the element at a specified index in a sequence.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to return an element from.
    //
    //   index:
    //     The zero-based index of the element to retrieve.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     The element at the specified position in the source sequence.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source is null.
    //
    //   System.ArgumentOutOfRangeException:
    //     index is less than 0 or greater than or equal to the number of elements in
    //     source.
    public static TSerializableEntity ElementAt<TSource, TSerializableEntity>(this IEnumerable<TSource> source, int index)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.ElementAt<TSource>(index));
    }

    //
    // Summary:
    //     Returns the element at a specified index in a sequence or a default value
    //     if the index is out of range.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to return an element from.
    //
    //   index:
    //     The zero-based index of the element to retrieve.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     default(TSource) if the index is outside the bounds of the source sequence;
    //     otherwise, the element at the specified position in the source sequence.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source is null.
    public static TSerializableEntity ElementAtOrDefault<TSource, TSerializableEntity>(this IEnumerable<TSource> source, int index)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.ElementAtOrDefault<TSource>(index));
    }

    //
    // Summary:
    //     Returns the first element of a sequence.
    //
    // Parameters:
    //   source:
    //     The System.Collections.Generic.IEnumerable<T> to return the first element
    //     of.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     The first element in the specified sequence.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source is null.
    //
    //   System.InvalidOperationException:
    //     The source sequence is empty.
    public static TSerializableEntity First<TSource, TSerializableEntity>(this IEnumerable<TSource> source)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.First<TSource>());
    }

    //
    // Summary:
    //     Returns the first element in a sequence that satisfies a specified condition.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to return an element from.
    //
    //   predicate:
    //     A function to test each element for a condition.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     The first element in the sequence that passes the test in the specified predicate
    //     function.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source or predicate is null.
    //
    //   System.InvalidOperationException:
    //     No element satisfies the condition in predicate.-or-The source sequence is
    //     empty.
    public static TSerializableEntity First<TSource, TSerializableEntity>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.First<TSource>(predicate));
    }

    //
    // Summary:
    //     Returns the first element of a sequence, or a default value if the sequence
    //     contains no elements.
    //
    // Parameters:
    //   source:
    //     The System.Collections.Generic.IEnumerable<T> to return the first element
    //     of.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     default(TSource) if source is empty; otherwise, the first element in source.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source is null.
    public static TSerializableEntity FirstOrDefault<TSource, TSerializableEntity>(this IEnumerable<TSource> source)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.FirstOrDefault<TSource>());
    }

    //
    // Summary:
    //     Returns the first element of the sequence that satisfies a condition or a
    //     default value if no such element is found.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to return an element from.
    //
    //   predicate:
    //     A function to test each element for a condition.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     default(TSource) if source is empty or if no element passes the test specified
    //     by predicate; otherwise, the first element in source that passes the test
    //     specified by predicate.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source or predicate is null.
    public static TSerializableEntity FirstOrDefault<TSource, TSerializableEntity>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.FirstOrDefault<TSource>(predicate));
    }

    //
    // Summary:
    //     Returns the last element of a sequence.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to return the last element of.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     The value at the last position in the source sequence.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source is null.
    //
    //   System.InvalidOperationException:
    //     The source sequence is empty.
    public static TSerializableEntity Last<TSource, TSerializableEntity>(this IEnumerable<TSource> source)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.Last<TSource>());
    }

    //
    // Summary:
    //     Returns the last element of a sequence that satisfies a specified condition.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to return an element from.
    //
    //   predicate:
    //     A function to test each element for a condition.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     The last element in the sequence that passes the test in the specified predicate
    //     function.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source or predicate is null.
    //
    //   System.InvalidOperationException:
    //     No element satisfies the condition in predicate.-or-The source sequence is
    //     empty.
    public static TSerializableEntity Last<TSource, TSerializableEntity>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.Last<TSource>(predicate));
    }

    //
    // Summary:
    //     Returns the last element of a sequence, or a default value if the sequence
    //     contains no elements.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to return the last element of.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     default(TSource) if the source sequence is empty; otherwise, the last element
    //     in the System.Collections.Generic.IEnumerable<T>.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source is null.
    public static TSerializableEntity LastOrDefault<TSource, TSerializableEntity>(this IEnumerable<TSource> source)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.LastOrDefault<TSource>());
    }

    //
    // Summary:
    //     Returns the last element of a sequence that satisfies a condition or a default
    //     value if no such element is found.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to return an element from.
    //
    //   predicate:
    //     A function to test each element for a condition.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     default(TSource) if the sequence is empty or if no elements pass the test
    //     in the predicate function; otherwise, the last element that passes the test
    //     in the predicate function.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source or predicate is null.
    public static TSerializableEntity LastOrDefault<TSource, TSerializableEntity>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.LastOrDefault<TSource>(predicate));
    }

    //
    // Summary:
    //     Inverts the order of the elements in a sequence.
    //
    // Parameters:
    //   source:
    //     A sequence of values to reverse.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     A sequence whose elements correspond to those of the input sequence in reverse
    //     order.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source is null.
    public static List<TSerializableEntity> Reverse<TSource, TSerializableEntity>(this IEnumerable<TSource> source)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return source.Reverse<TSource>().ToList<TSource, TSerializableEntity>();
    }

    //
    // Summary:
    //     Returns the only element of a sequence, and throws an exception if there
    //     is not exactly one element in the sequence.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to return the single element
    //     of.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     The single element of the input sequence.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source is null.
    //
    //   System.InvalidOperationException:
    //     The input sequence contains more than one element.-or-The input sequence
    //     is empty.
    public static TSerializableEntity Single<TSource, TSerializableEntity>(this IEnumerable<TSource> source)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.Single<TSource>());
    }

    //
    // Summary:
    //     Returns the only element of a sequence that satisfies a specified condition,
    //     and throws an exception if more than one such element exists.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to return a single element from.
    //
    //   predicate:
    //     A function to test an element for a condition.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     The single element of the input sequence that satisfies a condition.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source or predicate is null.
    //
    //   System.InvalidOperationException:
    //     No element satisfies the condition in predicate.-or-More than one element
    //     satisfies the condition in predicate.-or-The source sequence is empty.
    public static TSerializableEntity Single<TSource, TSerializableEntity>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.Single<TSource>(predicate));
    }

    //
    // Summary:
    //     Returns the only element of a sequence, or a default value if the sequence
    //     is empty; this method throws an exception if there is more than one element
    //     in the sequence.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to return the single element
    //     of.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     The single element of the input sequence, or default(TSource) if the sequence
    //     contains no elements.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source is null.
    //
    //   System.InvalidOperationException:
    //     The input sequence contains more than one element.
    public static TSerializableEntity SingleOrDefault<TSource, TSerializableEntity>(this IEnumerable<TSource> source)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.SingleOrDefault<TSource>());
    }

    //
    // Summary:
    //     Returns the only element of a sequence that satisfies a specified condition
    //     or a default value if no such element exists; this method throws an exception
    //     if more than one element satisfies the condition.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to return a single element from.
    //
    //   predicate:
    //     A function to test an element for a condition.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     The single element of the input sequence that satisfies the condition, or
    //     default(TSource) if no such element is found.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source or predicate is null.
    //
    //   System.InvalidOperationException:
    //     More than one element satisfies the condition in predicate.
    public static TSerializableEntity SingleOrDefault<TSource, TSerializableEntity>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return ToTSerializableEntity<TSource, TSerializableEntity>(source.SingleOrDefault<TSource>(predicate));
    }

    //
    // Summary:
    //     Creates an array from a System.Collections.Generic.IEnumerable<T>.
    //
    // Parameters:
    //   source:
    //     An System.Collections.Generic.IEnumerable<T> to create an array from.
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of source.
    //
    // Returns:
    //     An array that contains the elements from the input sequence.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     source is null.
    public static TSerializableEntity[] ToArray<TSource, TSerializableEntity>(this IEnumerable<TSource> source)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        return source.ToList<TSource, TSerializableEntity>().ToArray();
    }

    //Summary:
    //    Creates a System.Collections.Generic.List<T> from an System.Collections.Generic.IEnumerable<T>.

    //Parameters:
    //  source:
    //    The System.Collections.Generic.IEnumerable<T> to create a System.Collections.Generic.List<T>
    //    from.

    //Type parameters:
    //  TSource:
    //    The type of the elements of source.

    //Returns:
    //    A System.Collections.Generic.List<T> that contains elements from the input
    //    sequence.

    //Exceptions:
    //  System.ArgumentNullException:
    //    source is null.
    public static List<TSerializableEntity> ToList<TSource, TSerializableEntity>(this IEnumerable<TSource> source)
        where TSource : class, new()
        where TSerializableEntity : SerializableEntity<TSource>, new()
    {
        List<TSerializableEntity> list = new List<TSerializableEntity>();

        foreach (TSource entity in source)
        {
            list.Add(ToTSerializableEntity<TSource, TSerializableEntity>(entity));
        }
        return list;
    }
}
