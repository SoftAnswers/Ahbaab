using Ahbab.Droid.Helpers;
using Ahbab.Entities;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SharedCode;
using System.Collections.Generic;

namespace Ahbab.Droid.Fragments {
    public class VisitorsFragment : Fragment {

        private List<User> results;
        private RecyclerView mRecyclerView;
        Button nextBtn, prevBtn;
        Paginator paginator;
        private int totalPages;
        private int currentPage = 0;

        public VisitorsFragment(List<User> data) {
            results = data;
            paginator = new Paginator(results);
            totalPages = Paginator.LAST_PAGE;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            var mView = inflater.Inflate(Resource.Layout.Visitors_List, container, false);
            mRecyclerView = mView.FindViewById<RecyclerView>(Resource.Id.recyclerview);
            nextBtn = mView.FindViewById<Button>(Resource.Id.nextBtn);
            prevBtn = mView.FindViewById<Button>(Resource.Id.prevBtn);
            prevBtn.Enabled = false;

            SetUpRecyclerView();
            return mView;
        }

        void SetUpRecyclerView() {
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(mRecyclerView.Context));
            mRecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(mRecyclerView.Context, paginator.generatePage(currentPage), this.Resources));
            mRecyclerView.SetItemClickListener((rv, position, view) => {
                var userPosition = this.currentPage * Paginator.ITEMS_PER_PAGE + position;
                var result = AhbabDatabase.updateVisits(Ahbab.CurrentUser.ID, results[userPosition].ID);
                //An item has been clicked
                Context context = view.Context;
                Intent intent = new Intent(context, typeof(UserDetailsActivity));
                intent.PutExtra(UserDetailsActivity.EXTRA_MESSAGE, JsonConvert.SerializeObject(results[userPosition]));
                context.StartActivity(intent);
            });
            nextBtn.Click += NextButton_Click;
            prevBtn.Click += PreviousButton_Click;
        }

        /**
         * Function used to handle the next button click 
         */
        private void NextButton_Click(object sender, System.EventArgs e) {
            currentPage++;
            mRecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(mRecyclerView.Context, paginator.generatePage(currentPage), this.Resources));
            toggleButtons();
        }

        /**
         * Function used to handle the previous button click 
         */
        private void PreviousButton_Click(object sender, System.EventArgs e) {
            currentPage--;
            mRecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(mRecyclerView.Context, paginator.generatePage(currentPage), this.Resources));
            toggleButtons();
        }

        /**
         * Function used to enable/disable the previous and next
         * buttons based on the page index
         */
        private void toggleButtons() {
            if (currentPage == totalPages - 1) {
                nextBtn.Enabled = false;
                prevBtn.Enabled = true;
            } else if (currentPage == 0) {
                prevBtn.Enabled = false;
                nextBtn.Enabled = true;
            } else if (currentPage >= 1 && currentPage <= totalPages - 2) {
                nextBtn.Enabled = true;
                prevBtn.Enabled = true;
            }
        }
    }
}