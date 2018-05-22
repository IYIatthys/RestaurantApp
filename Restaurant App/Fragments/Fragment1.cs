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

            //Fragment fragment = new Filters();
            //FragmentManager fragmentManager = get
            //fragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment).Commit();
        }

        public static Fragment1 NewInstance()
        {
            var frag1 = new Fragment1 { Arguments = new Bundle() };
            return frag1;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.fragment1, null);

        }
    }
}
