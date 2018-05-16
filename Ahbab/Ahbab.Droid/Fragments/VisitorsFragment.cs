using Asawer.Droid.Helpers;
using Asawer.Entities;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SharedCode;
using System.Collections.Generic;
using Android.Support.Design.Widget;

namespace Asawer.Droid.Fragments
{
    public class VisitorsFragment : Fragment
    {

        private List<User> results;
        private RecyclerView mRecyclerView;
        ImageButton nextBtn;
        ImageButton prevBtn;
        Paginator paginator;
        private int totalPages;
        private int currentPage = 0;
        private string title;

        public VisitorsFragment(List<User> data, string frameTitle)
        {
            this.results = data;
            this.title = frameTitle;
            this.paginator = new Paginator(results);
            this.totalPages = Paginator.LAST_PAGE;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var mView = inflater.Inflate(Resource.Layout.Visitors_List, container, false);
            this.nextBtn = mView.FindViewById<ImageButton>(Resource.Id.nextBtn);
            this.prevBtn = mView.FindViewById<ImageButton>(Resource.Id.prevBtn);
            this.mRecyclerView = mView.FindViewById<RecyclerView>(Resource.Id.recyclerview);
            var titleTextView = mView.FindViewById<TextView>(Resource.Id.frameTitle);
            titleTextView.Text = this.title;

            if (results.Count > 0)
            {
                this.SetUpRecyclerView();
                this.nextBtn.Click += NextButton_Click;
                this.prevBtn.Click += PreviousButton_Click;
                this.ToggleButtons();
            }
            else
            {
                this.nextBtn.Visibility = ViewStates.Gone;
                this.prevBtn.Visibility = ViewStates.Gone;
            }
            return mView;
        }

        void SetUpRecyclerView()
        {
            this.mRecyclerView.SetLayoutManager(new LinearLayoutManager(mRecyclerView.Context));
            this.mRecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(mRecyclerView.Context, paginator.GeneratePage(currentPage), this.Resources));
            this.mRecyclerView.SetItemClickListener((rv, position, view) =>
            {
                var userPosition = this.currentPage * Paginator.ITEMS_PER_PAGE + position;
                var result = AhbabDatabase.UpdateVisits(Ahbab.CurrentUser.ID, results[userPosition].ID);
                //An item has been clicked
                Context context = view.Context;
                Intent intent = new Intent(context, typeof(UserDetailsActivity));
                intent.PutExtra(UserDetailsActivity.EXTRA_MESSAGE, JsonConvert.SerializeObject(results[userPosition]));
                context.StartActivity(intent);
            });
        }

        /**
         * Function used to handle the next button click 
         */
        private void NextButton_Click(object sender, System.EventArgs e)
        {
            this.currentPage++;
            this.mRecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(mRecyclerView.Context, paginator.GeneratePage(currentPage), this.Resources));
            this.ToggleButtons();
        }

        /**
         * Function used to handle the previous button click 
         */
        private void PreviousButton_Click(object sender, System.EventArgs e)
        {
            this.currentPage--;
            this.mRecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(mRecyclerView.Context, paginator.GeneratePage(currentPage), this.Resources));
            this.ToggleButtons();
        }

        /**
         * Function used to enable/disable the previous and next
         * buttons based on the page index
         */
        private void ToggleButtons()
        {
            if (totalPages == 1)
            {
                this.nextBtn.Enabled = false;
                this.prevBtn.Enabled = false;
            }
            else if (currentPage == totalPages - 1)
            {
                this.nextBtn.Enabled = false;
                this.prevBtn.Enabled = true;
            }
            else if (currentPage == 0)
            {
                this.prevBtn.Enabled = false;
                this.nextBtn.Enabled = true;
            }
            else if (currentPage >= 1 && currentPage <= totalPages - 2)
            {
                this.nextBtn.Enabled = true;
                this.prevBtn.Enabled = true;
            }
        }
    }
}