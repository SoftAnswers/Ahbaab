using Android.Support.V4.App;
using System.Collections.Generic;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;

namespace Asawer.Droid
{
    public class TabAdapter : FragmentPagerAdapter
    {
        public List<SupportFragment> Fragments { get; set; }
        public List<string> FragmentsNames { get; set; }

        public TabAdapter(SupportFragmentManager sfm)
            : base(sfm)
        {
            this.Fragments = new List<SupportFragment>();
            this.FragmentsNames = new List<string>();
        }

        public void AddFragment(SupportFragment fragment, string name)
        {
            this.Fragments.Add(fragment);
            this.FragmentsNames.Add(name);
        }

        public override int Count
        {
            get
            {
                return this.Fragments.Count;
            }
        }

        public override SupportFragment GetItem(int position)
        {
            return this.Fragments[position];
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(this.FragmentsNames[position]);
        }
    }
}