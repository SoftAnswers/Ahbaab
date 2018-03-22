using System;
using System.Collections.Generic;
using Asawer.Entities;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Asawer.Droid
{
    public class SearchResultsRecyclerViewAdapter : RecyclerView.Adapter
    {
        private readonly TypedValue mTypedValue = new TypedValue();
        private int mBackground;
        private List<User> mValues;
        Resources mResource;
        private Dictionary<int, int> mCalculatedSizes;

        public SearchResultsRecyclerViewAdapter(Context context, List<User> items, Resources res)
        {
            context.Theme.ResolveAttribute(Resource.Attribute.selectableItemBackground, mTypedValue, true);
            mBackground = mTypedValue.ResourceId;
            mValues = items;
            mResource = res;

            mCalculatedSizes = new Dictionary<int, int>();
        }

        public override int ItemCount
        {
            get
            {
                return mValues.Count;
            }
        }

        public override async void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var simpleHolder = holder as SearchSimpleViewHolder;

            simpleHolder.mBoundString = !string.IsNullOrEmpty(mValues[position].Name) ?
                mValues[position].Name :
                mValues[position].UserName;
            simpleHolder.mTxtView.Text = !string.IsNullOrEmpty(mValues[position].Name) ?
                mValues[position].Name :
                mValues[position].UserName;

            Bitmap bitMap = null;

            int drawableID = Messages.RandomMessagesDrawable;

            BitmapFactory.Options options = new BitmapFactory.Options();

            if (mValues[position].ImageBytes != null && mValues[position].ImageBytes[0].Length > 0)
            {
                bitMap = await BitmapFactory.DecodeByteArrayAsync(mValues[position].ImageBytes[0], 0, mValues[position].ImageBytes[0].Length);
            }
            else
            {
                if (mCalculatedSizes.ContainsKey(drawableID))
                {
                    options.InSampleSize = mCalculatedSizes[drawableID];
                }
                else
                {
                    options.InJustDecodeBounds = true;

                    BitmapFactory.DecodeResource(mResource, drawableID, options);

                    options.InSampleSize = Messages.CalculateInSampleSize(options, 100, 100);
                    options.InJustDecodeBounds = false;

                    mCalculatedSizes.Add(drawableID, options.InSampleSize);
                }
                bitMap = await BitmapFactory.DecodeResourceAsync(mResource, drawableID, options);
            }
            simpleHolder.mImageView.SetImageBitmap(bitMap);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.List_Item, parent, false);
            view.SetBackgroundResource(mBackground);

            return new SearchSimpleViewHolder(view);
        }
    }

    public class SearchSimpleViewHolder : RecyclerView.ViewHolder
    {
        public string mBoundString;
        public readonly View mView;
        public readonly ImageView mImageView;
        public readonly TextView mTxtView;

        public SearchSimpleViewHolder(View view) : base(view)
        {
            mView = view;
            mImageView = view.FindViewById<ImageView>(Resource.Id.avatar);
            mTxtView = view.FindViewById<TextView>(Resource.Id.text1);
        }

        public override string ToString()
        {
            return base.ToString() + " '" + mTxtView.Text;
        }
    }
}

