using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Asawer.Droid.Helpers;
using Asawer.Entities;
using Android.Graphics;
using SharedCode;

namespace Asawer.Droid
{
    [Activity(Label = "@string/searchResult", Theme = "@style/Theme.Ahbab")]
    public class SearchResultsActivity : AppCompatActivity
    {
        private List<User> results;
        private RecyclerView recyclerView;
        private DrawerLayout drawerLayout;
        private ImageButton nextBtn;
        private ImageButton prevBtn;
        private ImageButton firstPage;
        private ImageButton lastPage;
        private TextView pageNumber;
        private TextView resultsString;
        private Paginator paginator;
        private int totalPages;
        private int currentPage;

        public RecyclerView RecyclerView { get => this.recyclerView; set => this.recyclerView = value; }
        public DrawerLayout DrawerLayout { get => this.drawerLayout; set => this.drawerLayout = value; }
        public ImageButton NextBtn { get => this.nextBtn; set => this.nextBtn = value; }
        public ImageButton PrevBtn { get => this.prevBtn; set => this.prevBtn = value; }
        public ImageButton FirstPage { get => this.firstPage; set => this.firstPage = value; }
        public ImageButton LastPage { get => this.lastPage; set => this.lastPage = value; }
        internal Paginator Paginator { get => this.paginator; set => this.paginator = value; }
        public int TotalPages { get => this.totalPages; set => this.totalPages = value; }
        public int CurrentPage { get => this.currentPage; set => this.currentPage = value; }
        public List<User> Results { get => this.results; set => this.results = value; }
        public TextView PageNumber { get => pageNumber; set => pageNumber = value; }
        public TextView ResultsString { get => resultsString; set => resultsString = value; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.Results = Ahbab.SearchResults;
            this.Paginator = new Paginator(Results);
            this.TotalPages = Paginator.LAST_PAGE;

            SetContentView(Resource.Layout.SearchResultsActivity);

            var toolbar = FindViewById<SupportToolbar>(Resource.Id.toolBar);

            this.SetSupportActionBar(toolbar);

            this.SupportActionBar.SetHomeButtonEnabled(true);

            this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            this.SupportActionBar.SetDisplayShowHomeEnabled(true);

            this.DrawerLayout = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
            }

            var hView = navigationView.GetHeaderView(0);

            var editAccount = hView.FindViewById<ImageView>(Resource.Id.imgViewHeader);

            if (Ahbab.CurrentUser.ImageBase64 != null && Ahbab.CurrentUser.ImageBytes != null && Ahbab.CurrentUser.ImageBytes.Count > 0 && Ahbab.CurrentUser.ImageBytes[0].Length > 0)
            {
                var bitmap = BitmapFactory.DecodeByteArray(Ahbab.CurrentUser.ImageBytes[0], 0, Ahbab.CurrentUser.ImageBytes[0].Length);
                editAccount.SetImageBitmap(bitmap);
            }

            this.RecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerview);
            this.NextBtn = FindViewById<ImageButton>(Resource.Id.nextBtn);
            this.PrevBtn = FindViewById<ImageButton>(Resource.Id.prevBtn);
            this.FirstPage = FindViewById<ImageButton>(Resource.Id.firstPage);
            this.LastPage = FindViewById<ImageButton>(Resource.Id.lastPage);
            this.ResultsString = this.FindViewById<TextView>(Resource.Id.resultsNumber);
            this.PageNumber = this.FindViewById<TextView>(Resource.Id.pageNumber);
            this.ToggleButtons();
            this.ResultsString.Text = string.Format("{0} {1}", Constants.UI.SearchResults, this.Results.Count);
            SetUpRecyclerView();
        }

        void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                // If the user click on contact us we open directly the email screen
                if (e.MenuItem.ItemId != Resource.Id.contactUs)
                {
                    // If the user clicks on logout we display the logout popup
                    if (e.MenuItem.ItemId == Resource.Id.logout)
                    {
                        this.Logout();
                    }
                    else
                    {
                        OpenLegalNotesFragment(e.MenuItem);
                        this.DrawerLayout.CloseDrawers();
                    }
                }
                else
                {
                    var email = new Intent(Intent.ActionSend);
                    email.PutExtra(Intent.ExtraEmail, new string[] { "info@ahbaab.com" });
                    email.SetType("message/rfc822");
                    StartActivity(email);
                }
            };
        }

        // Function used to redirect the user to the login activity after clicking in logout
        public void Logout()
        {
            Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
            alert.SetTitle(Constants.UI.LogoutHeader);
            alert.SetMessage(Constants.UI.LogoutMessage);
            alert.SetPositiveButton(Constants.UI.Logout, (senderAlert, args) =>
            {
                Ahbab.CurrentUser = null;
                Intent loginPageIntent = new Intent(this, typeof(MainActivity));
                loginPageIntent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                this.StartActivity(loginPageIntent);
                this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
            });
            alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) => { });
            Android.Support.V7.App.AlertDialog dialog = alert.Create();
            dialog.SetCanceledOnTouchOutside(false);
            dialog.SetCancelable(false);
            dialog.Show();
        }

        public void OpenLegalNotesFragment(IMenuItem item)
        {
            var mybundle = new Bundle();

            mybundle.PutInt("ItemId", item.ItemId);

            var transaction = SupportFragmentManager.BeginTransaction();

            var legalNotesFragment = new LegalNotesFragment
            {
                Arguments = mybundle
            };

            legalNotesFragment.Show(transaction, "dialog_fragment");

            item.SetChecked(false);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                this.OnBackPressed();
            }
            else
            {
                this.DrawerLayout.OpenDrawer((int)GravityFlags.Right);
            }
            return true;
        }

        void SetUpRecyclerView()
        {
            RecyclerView.SetLayoutManager(new LinearLayoutManager(RecyclerView.Context));

            RecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(RecyclerView.Context, Paginator.GeneratePage(this.CurrentPage), this.Resources));

            RecyclerView.SetItemClickListener((rv, position, view) =>
            {
                var userPosition = this.CurrentPage * Paginator.ITEMS_PER_PAGE + position;
                var result = AhbabDatabase.UpdateVisits(Ahbab.CurrentUser.ID, Results[userPosition].ID);
                //An item has been clicked
                Context context = view.Context;
                Intent intent = new Intent(context, typeof(UserDetailsActivity));
                intent.PutExtra(UserDetailsActivity.EXTRA_MESSAGE, JsonConvert.SerializeObject(Results[userPosition]));
                context.StartActivity(intent);
            });
            this.NextBtn.Click += NextButton_Click;
            this.PrevBtn.Click += PreviousButton_Click;
            this.FirstPage.Click += OnFirstPageButtonClick;
            this.LastPage.Click += OnLastPageButtonClick;
        }

        private List<Message> GetRandomSubList(List<Message> items, int amount)
        {
            List<Message> list = new List<Message>();

            Random random = new Random();

            while (list.Count < amount)
            {
                list.Add(items[random.Next(items.Count)]);
            }

            return list;
        }

        /**
         * Function used to handle the next button click 
         */
        private void NextButton_Click(object sender, System.EventArgs e)
        {
            CurrentPage++;
            RecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(RecyclerView.Context, Paginator.GeneratePage(CurrentPage), this.Resources));
            ToggleButtons();
        }

        /**
         * Function used to handle the previous button click 
         */
        private void PreviousButton_Click(object sender, System.EventArgs e)
        {
            CurrentPage--;
            RecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(RecyclerView.Context, Paginator.GeneratePage(CurrentPage), this.Resources));
            ToggleButtons();
        }

        private void OnLastPageButtonClick(object sender, EventArgs args)
        {
            this.CurrentPage = this.TotalPages - 1;
            RecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(RecyclerView.Context, Paginator.GeneratePage(CurrentPage), this.Resources));
            ToggleButtons();
        }

        private void OnFirstPageButtonClick(object sender, EventArgs args)
        {
            this.CurrentPage = 0;
            RecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(RecyclerView.Context, Paginator.GeneratePage(CurrentPage), this.Resources));
            ToggleButtons();
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

            this.PageNumber.Text = (this.CurrentPage + 1).ToString();
        }
    }
}

