using System;
using System.Collections.Generic;
using SQLite;

namespace Munchkin {
    public class Data {

        public Data()
        {
        }

        public static List<Data> SampleData()
        {
					string dbPath = FileAccessHelper.GetLocalFilePath("munchkin.db");
					var db = new SQLiteConnection(dbPath);
			var newDataList = new List<Data>();
			var cardInfos = db.Table<CardInfo>().Where(x => x.Id > 0);
					foreach (var listing in cardInfos) {
				newDataList.Add(new Data(listing.Name, listing.Name));
			}
			return newDataList;
        }

        public Data(string newId = "Temporary Id", string newValue = "Temporary Data")
        {
            Id = newId;
            Value = newValue;
        }

        public string Id { get; set; }
        public string Value { get; set; }
    }
}