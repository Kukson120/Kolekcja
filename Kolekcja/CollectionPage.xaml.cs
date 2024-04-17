namespace Kolekcja;

public partial class CollectionPage : ContentPage
{
    private Collection _collection;
    private FileManager _fileManager = new FileManager();

    public CollectionPage(Collection collection)
    {
        InitializeComponent();
        _collection = collection;
        BindingContext = _collection;
        itemsView.ItemsSource = _collection.Items;
    }

    private void OnAddItemClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddEditCollectionPage(_collection, new CollectionItem()));
    }

    private void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            var selectedItem = (CollectionItem)e.CurrentSelection.FirstOrDefault();
            Navigation.PushAsync(new AddEditCollectionPage(_collection, selectedItem));
        }
    }
}
