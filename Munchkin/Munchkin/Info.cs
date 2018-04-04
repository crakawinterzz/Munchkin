
using SQLite;

namespace Munchkin {
	[Table("CardInfo")]
	public class CardInfo {
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Faction { get; set; }
		public int Type { get; set; }
		public int SubType { get; set; }
		public int Rarity { get; set; }
		public int GoldCost { get; set; }
		public int RankCost { get; set; }
		public int Power { get; set; }
		public int Defense { get; set; }
		public int Life { get; set; }
		public string Text { get; set; }
	}
	[Table("Rarity")]
	public class Rarity {
		[PrimaryKey, AutoIncrement, Column("Id")]
		public int Id { get; set; }
		[MaxLength(250), Unique, Column("Name")]
		public string Name { get; set; }
	}
}