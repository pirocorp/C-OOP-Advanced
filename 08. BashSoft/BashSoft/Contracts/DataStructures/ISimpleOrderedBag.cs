﻿namespace BashSoft.Contracts.DataStructures
{
    using System;
    using System.Collections.Generic;

    public interface ISimpleOrderedBag<T> : IEnumerable<T> where T : IComparable<T>
    {
        void Add(T element);

        void AddAll(ICollection<T> collection);

        bool Remove(T element);

        int Size { get; }

        int Capacity { get; }

        string JoinWith(string joiner);
    }
}
