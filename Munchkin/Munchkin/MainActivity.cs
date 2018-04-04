using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Widget;
using Android.OS;


namespace Munchkin {
	[Activity(Label = "Munchkin", MainLauncher = true)]
	public class MainActivity : Activity {
		
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
            var db = new SQLite.SQLiteConnection("/Assets/Database/Munchkin.db");
            int count = db.Table<CardInfo>().Count();
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
				SetContentView(Resource.Layout.MainListView);

                //			var listView = FindViewById<ListView> (Resource.Id.myListView);
                //			listView.Adapter = new DataAdapter (this, Data.SampleData ());
                //
                //			listView.ItemClick += (sender, e) => {
                //				Console.WriteLine(e.Position.ToString());
                //			};

                var listView = FindViewById<ExpandableListView>(Resource.Id.myExpandableListview);
                listView.SetAdapter(new ExpandableDataAdapter(this, Data.SampleData()));
            };
			imageViewButton.Click += delegate {
				SetContentView(Resource.Layout.MainListView);
			};
		
		}

	}
  
}
