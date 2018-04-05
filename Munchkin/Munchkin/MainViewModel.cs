using System.Collections.ObjectModel;
using Android.Media;

namespace Munchkin {
    public ObservableCollection<CardInfo> CardList {
    get;
    set;
    }
    class MainViewModel
    {
        CardList = new ObservableCollection<CardInfo>
    }
}