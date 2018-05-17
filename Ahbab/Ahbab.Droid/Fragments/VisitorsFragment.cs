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
using System;

namespace Asawer.Droid.Fragments
{
    public class VisitorsFragment : Fragment
    {

        private List<User> results;
        private RecyclerView recyclerView;
        private ImageButton nextBtn;
        private ImageButton prevBtn;
        private ImageButton firstPage;
        private ImageButton lastPage;
        private Paginator paginator;
        private int totalPages;
        private int currentPage;
        private string title;

        public ImageButton NextBtn { get => nextBtn; set => nextBtn = value; }
        public ImageButton PrevBtn { get => prevBtn; set => prevBtn = value; }
        public ImageButton FirstPage { get => firstPage; set => firstPage = value; }
        public ImageButton LastPage { get => lastPage; set => lastPage = value; }
        internal Paginator Paginator { get => paginator; set => paginator = value; }
        public int TotalPages { get => totalPages; set => totalPages = value; }
        public int CurrentPage { get => currentPage; set => currentPage = value; }
        public string Title { get => this.title; set => this.title = value; }
        public RecyclerView RecyclerView { get => recyclerView; set => recyclerView = value; }
        public List<User> Results { get => results; set => results = value; }

        public VisitorsFragment(List<User> data, string frameTitle)
        {
            this.Results = data;
            this.title = frameTitle;
            this.paginator = new Paginator(Results);
            this.totalPages = Paginator.LAST_PAGE;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var mView = inflater.Inflate(Resource.Layout.Visitors_List, container, false);
            this.NextBtn = mView.FindViewById<ImageButton>(Resource.Id.nextBtn);
            this.PrevBtn = mView.FindViewById<ImageButton>(Resource.Id.prevBtn);
            this.FirstPage = mView.FindViewById<ImageButton>(Resource.Id.firstPage);
            this.LastPage = mView.FindViewById<ImageButton>(Resource.Id.lastPage);
            this.RecyclerView = mView.FindViewById<RecyclerView>(Resource.Id.recyclerview);
            var titleTextView = mView.FindViewById<TextView>(Resource.Id.frameTitle);
            titleTextView.Text = this.title;

            if (Results.Count > 0)
            {
                this.SetUpRecyclerView();
                this.NextBtn.Click += NextButton_Click;
                this.PrevBtn.Click += PreviousButton_Click;
                this.FirstPage.Click += OnFirstPageButtonClick;
                this.LastPage.Click += OnLastPageButtonClick;
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
            this.RecyclerView.SetLayoutManager(new LinearLayoutManager(RecyclerView.Context));
            this.RecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(RecyclerView.Context, paginator.GeneratePage(currentPage), this.Resources));
            this.RecyclerView.SetItemClickListener((rv, position, view) =>
            {
                var userPosition = this.currentPage * Paginator.ITEMS_PER_PAGE + position;
                var result = AhbabDatabase.UpdateVisits(Ahbab.CurrentUser.ID, Results[userPosition].ID);
                //An item has been clicked
                Context context = view.Context;
                Intent intent = new Intent(context, typeof(UserDetailsActivity));
                intent.PutExtra(UserDetailsActivity.EXTRA_MESSAGE, JsonConvert.SerializeObject(Results[userPosition]));
                context.StartActivity(intent);
            });
        }

        /**
         * Function used to handle the next button click 
         */
        private void NextButton_Click(object sender, EventArgs e)
        {
            this.currentPage++;
            this.RecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(RecyclerView.Context, paginator.GeneratePage(currentPage), this.Resources));
            this.ToggleButtons();
        }

        /**
         * Function used to handle the previous button click 
         */
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            this.currentPage--;
            this.RecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(RecyclerView.Context, paginator.GeneratePage(currentPage), this.Resources));
            this.ToggleButtons();
        }

        private void OnLastPageButtonClick(object sender, EventArgs args)
        {
            this.CurrentPage = this.TotalPages - 1;
            this.RecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(this.RecyclerView.Context, Paginator.GeneratePage(CurrentPage), this.Resources));
            this.ToggleButtons();
        }

        private void OnFirstPageButtonClick(object sender, EventArgs args)
        {
            this.CurrentPage = 0;
            this.RecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(this.RecyclerView.Context, Paginator.GeneratePage(CurrentPage), this.Resources));
            this.ToggleButtons();
        }

        /**
         * Function used to enable/disable the previous and next
         * buttons based on the page index
         */
        private void ToggleButtons()
        {
            if (TotalPages == 1)
            {
                this.NextBtn.Enabled = false;
                this.PrevBtn.Enabled = false;
                this.FirstPage.Enabled = false;
                this.LastPage.Enabled = false;
            }
            else if (CurrentPage == TotalPages - 1)
            {
                this.NextBtn.Enabled = false;
                this.LastPage.Enabled = false;
                this.PrevBtn.Enabled = true;
                this.FirstPage.Enabled = true;
            }
            else if (CurrentPage == 0)
            {
                this.PrevBtn.Enabled = false;
                this.FirstPage.Enabled = false;
                this.NextBtn.Enabled = true;
                this.LastPage.Enabled = true;
            }
            else if (CurrentPage >= 1 && CurrentPage <= TotalPages - 2)
            {
                this.NextBtn.Enabled = true;
                this.PrevBtn.Enabled = true;
                this.FirstPage.Enabled = true;
                this.LastPage.Enabled = true;
            }
        }
    }
}