using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using System.Linq;
using System.Collections.Generic;
using Android.Widget;
using Restaurant_App.Fragments;
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;

namespace Restaurant_App
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/Icon")]
    public class MainActivity : AppCompatActivity
    {
        private Button NewButton, UpdateButton, DeleteButton;
        private ListView View;
        private EditText Input;
        private List<string> res = new List<string>();
        private ArrayAdapter<string> adapter;
        DB.DB db = new DB.DB();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            db.createTable<Person>();

            NewButton = FindViewById<Button>(Resource.Id.newButton);
            UpdateButton = FindViewById<Button>(Resource.Id.UpdateButton);
            DeleteButton = FindViewById<Button>(Resource.Id.DeleteButton);

            List<buttonAction> Buttons = new List<buttonAction>();

            Buttons.Add(new buttonAction(NewButton, (() =>
            {
                if (Input.Text != "")
                {
                    db.Insert(new Person(4, Input.Text));
                }
            })));

            Buttons.Add(new buttonAction(UpdateButton, (() =>
            {
                string query = "";

                IEnumerable<Person> Lijst;

                if (Input.Text != "")
                {
                    Lijst = db.Select<Person>("SELECT * FROM Person WHERE Name =?", new[] { Input.Text });
                }
                else
                {
                    Lijst = db.Select<Person>("SELECT * FROM Person");
                }

                res.Clear();
                foreach (var Item in Lijst.ToList())
                {
                    res.Add(Item.ToString());
                }

                adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, res);
                View.Adapter = adapter;
            })));

            Buttons.Add(new buttonAction(DeleteButton, (() =>
            {
                if (Input.Text != "")
                {
                    db.Execute("DELETE FROM Person WHERE Name =?", Input.Text);
                }
                else
                {
                    db.Execute("DELETE FROM Person");
                }
            })));

            View = FindViewById<ListView>(Resource.Id.ListView);

            Input = FindViewById<EditText>(Resource.Id.Input);


            foreach (var button in Buttons)
            {
                button.execute();
            }
            DrawerLayout drawerLayout;
        NavigationView navigationView;

        IMenuItem previousItem;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            //Set hamburger items menu
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            //setup navigation view
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            //handle navigation
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                if (previousItem != null)
                    previousItem.SetChecked(false);

                navigationView.SetCheckedItem(e.MenuItem.ItemId);

                previousItem = e.MenuItem;

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_home_1:
                        ListItemClicked(0);
                        break;
                    case Resource.Id.nav_home_2:
                        ListItemClicked(1);
                        break;
                }


                drawerLayout.CloseDrawers();
            };


            //if first time you will want to go ahead and click first item.
            if (savedInstanceState == null)
            {
                navigationView.SetCheckedItem(Resource.Id.nav_home_1);
                ListItemClicked(0);
            }
        }

        int oldPosition = -1;
        private void ListItemClicked(int position)
        {
            //this way we don't load twice, but you might want to modify this a bit.
            if (position == oldPosition)
                return;

            oldPosition = position;

            Android.Support.V4.App.Fragment fragment = null;
            switch (position)
            {
                case 0:
                    fragment = Fragment1.NewInstance();
                    break;
                case 1:
                    fragment = Fragment2.NewInstance();
                    break;
            }

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

