using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Kolekcja
{

public partial class MainPage : ContentPage
{
    private FileManager _fileManager = new FileManager();
    public ObservableCollection<Collection> Collections { get; } = new ObservableCollection<Collection>();

    public MainPage()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        var collections = _fileManager.LoadCollections();
        foreach (var collection in collections)
        {
            Collections.Add(collection);
        }
        collectionsView.ItemsSource = Collections;
    }

    private void OnAddNewCollectionClicked(object sender, EventArgs e)
    {
        // Navigate to AddEditCollectionPage
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Navigate to CollectionPage with selected collection
    }
}
}
