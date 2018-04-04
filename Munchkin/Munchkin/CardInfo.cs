using SQLite;

namespace Munchkin
{
    internal class CardInfo
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public string Name { get; set; }
        public int Faction { get; set; }
    }
}