using System.Collections.ObjectModel;
using System.Runtime.Serialization;

public interface IStorage<T> where T : ISerializable
{
    public Action OnStorageReady { get; set; }
    public ReadOnlyObservableCollection<T> DataCollection { get; }

    public void Init();
    public void AddItem(T item);
    public void RemoveItem(T item);
}

