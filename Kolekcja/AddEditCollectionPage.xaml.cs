namespace Kolekcja;

public partial class AddEditCollectionPage : ContentPage
{
    private Collection _collection;
    private CollectionItem _item;

    public AddEditCollectionPage(Collection collection, CollectionItem item)
    {
        InitializeComponent();
        _collection = collection;
        _item = item;

        nameEntry.Text = item.Name;
        detailsEditor.Text = item.Details;
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        _item.Name = nameEntry.Text;
        _item.Details = detailsEditor.Text;

        if (!_collection.Items.Contains(_item))
        {
            _collection.Items.Add(_item);
        }

        FileManager fileManager = new FileManager();
        fileManager.SaveCollections(new List<Collection> { _collection });

        Navigation.PopAsync();
    }
}
