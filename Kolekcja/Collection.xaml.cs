namespace Kolekcja;

using System.Collections.Generic;

public class Collection
{
    public string Name { get; set; }
    public List<CollectionItem> Items { get; set; } = new List<CollectionItem>();
}
