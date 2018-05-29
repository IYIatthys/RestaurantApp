using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace Restaurant_App.Fragments
{
    public class Fragment2 : Fragment
    {
        private List<string> mItems;
        private ListView mlistview;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            
        }

        public static Fragment2 NewInstance()
        {
            var frag2 = new Fragment2 { Arguments = new Bundle() };
            return frag2;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment2, null);

            mlistview = view.FindViewById<ListView>(Resource.Id.listView1);
            mItems = new List<string>();
            mItems.Add("Restaurant1");
            mItems.Add("Restaurant2");
            mItems.Add("Restaurant3");

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, mItems);
            mlistview.Adapter = adapter;

            return view;
            
        }
    }
}