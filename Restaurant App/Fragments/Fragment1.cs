using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace Restaurant_App.Fragments
{
    public class Fragment1 : Android.Support.V4.App.Fragment
    {

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            
        }

        public static Fragment1 NewInstance()
        {
            var frag1 = new Fragment1 { Arguments = new Bundle() };
            return frag1;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment1, null);

            Button filterButton = view.FindViewById<Button>(Resource.Id.filterButton);
            filterButton.Click += delegate
            {
                filterButtonClick();
            };

            return view;
        }

        public void filterButtonClick()
        {
            FragmentTransaction trans = FragmentManager.BeginTransaction();
            trans.Replace(Resource.Id.content_frame, new Filters(), "Filters");
            trans.AddToBackStack(null);
            trans.Commit();
        }
    }
}
