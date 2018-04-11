using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Widget;
using Android.OS;

using Java.Sql;
using SQLite;
using System;

namespace Munchkin {
	[Activity(Label = "Munchkin", MainLauncher = true)]
	public class MainActivity : Activity { 
	    private ExpandableListViewAdapter mAdapter;
	    private ExpandableListView expandableListView;
        List<string> group = new List<string>();
        Dictionary<string,List<string>> dicMyMap = new Dictionary<string, List<string>>();
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);
			TextView text1 = FindViewById<TextView>(Resource.Id.textView1);
			TextView text2 = FindViewById<TextView>(Resource.Id.textView2);
			TextView text3 = FindViewById<TextView>(Resource.Id.textView3);
			Button listViewButton = FindViewById<Button>(Resource.Id.listViewButton);
			Button imageViewButton = FindViewById<Button>(Resource.Id.cardViewButton);

			Typeface font = Typeface.CreateFromAsset(Resources.Assets, "quasimodo.ttf");
			text1.Typeface = font;
			text2.Typeface = font;
			text3.Typeface = font;
			listViewButton.Typeface = font;
			listViewButton.Typeface = font;
			imageViewButton.Typeface = font;
			// Set our view from the "main" layout resource

			listViewButton.Click += delegate {
				SetContentView(Resource.Layout.ListView);
				expandableListView = FindViewById<ExpandableListView>(Resource.Id.expandableListView);

				SetData(out mAdapter);
				expandableListView.SetAdapter(mAdapter);
			};
			imageViewButton.Click += delegate {
				SetContentView(Resource.Layout.ListView);
				expandableListView = FindViewById<ExpandableListView>(Resource.Id.expandableListView);

				SetData(out mAdapter);
				expandableListView.SetAdapter(mAdapter);
			};
		
		}

		private void SetData(out ExpandableListViewAdapter mAdapter)
		{
			List<string> groupA = new List<string>();
			List<string> groupB = new List<string>();
			string dbPath = FileAccessHelper.GetLocalFilePath("munchkin.db");
			var db = new SQLiteConnection(dbPath);

			var cardInfos = db.Table<CardInfo>().Where(x => x.Id > 0);
			foreach (var listing in cardInfos){
				group.Add(listing.Name);
			}
			dicMyMap.Add(@group[0], groupA);
			dicMyMap.Add(@group[1], groupB);

			mAdapter = new ExpandableListViewAdapter(this,@group,dicMyMap);

		}
	}
  
}
