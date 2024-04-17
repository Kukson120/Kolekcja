namespace Kolekcja;

using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

public class FileManager
{
    private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "collections.txt");

    public FileManager()
    {
        Debug.WriteLine($"Data Path: {_filePath}");
    }

    public List<Collection> LoadCollections()
    {
        var collections = new List<Collection>();
        if (File.Exists(_filePath))
        {
            Collection currentCollection = null;
            foreach (var line in File.ReadAllLines(_filePath))
            {
                if (line.StartsWith("Collection:"))
                {
                    currentCollection = new Collection { Name = line.Substring(11).Trim() };
                    collections.Add(currentCollection);
                }
                else if (line.StartsWith("Item:"))
                {
                    var parts = line.Substring(5).Split('|');
                    currentCollection?.Items.Add(new CollectionItem { Name = parts[0], Details = parts[1] });
                }
            }
        }
        return collections;
    }

    public void SaveCollections(List<Collection> collections)
    {
        using (var writer = new StreamWriter(_filePath, false))
        {
            foreach (var collection in collections)
            {
                writer.WriteLine($"Collection: {collection.Name}");
                foreach (var item in collection.Items)
                {
                    writer.WriteLine($"Item: {item.Name}|{item.Details}");
                }
            }
        }
    }
}