﻿using System;
using System.Collections.Generic;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Asawer.Droid
{
	public class MessageRecycleViewAdapter : RecyclerView.Adapter
	{
		private readonly TypedValue mTypedValue = new TypedValue();
		private int mBackground;
		private List<Message> mValues;
		Resources mResource;
		private Dictionary<int, int> mCalculatedSizes;

		public MessageRecycleViewAdapter(Context context, List<Message> items, Resources res)
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

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var simpleHolder = holder as SimpleViewHolder;

            var currentMessage = mValues[position];

			simpleHolder.mBoundString = currentMessage.Subject;
			simpleHolder.mTxtView.Text = currentMessage.Subject;
            simpleHolder.dateTextView.Text = currentMessage.MessageDate;

            if (currentMessage.MessageRead=="N")
            {
                simpleHolder.mTxtView.Typeface = Typeface.DefaultBold;
                simpleHolder.dateTextView.Typeface = Typeface.DefaultBold;
            }

			//int drawableID = Messages.RandomMessagesDrawable;
			//BitmapFactory.Options options = new BitmapFactory.Options();

			//if (mCalculatedSizes.ContainsKey(drawableID))
			//{
			//	options.InSampleSize = mCalculatedSizes[drawableID];
			//}

			//else
			//{
			//	options.InJustDecodeBounds = true;

			//	BitmapFactory.DecodeResource(mResource, drawableID, options);

			//	options.InSampleSize = Messages.CalculateInSampleSize(options, 100, 100);
			//	options.InJustDecodeBounds = false;

			//	mCalculatedSizes.Add(drawableID, options.InSampleSize);
			//}


			//var bitMap = await BitmapFactory.DecodeResourceAsync(mResource, drawableID, options);

			//simpleHolder.mImageView.SetImageBitmap(bitMap);
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.List_Item, parent, false);
			view.SetBackgroundResource(mBackground);

			return new SimpleViewHolder(view);
		}
	}

	public class SimpleViewHolder : RecyclerView.ViewHolder
	{
		public string mBoundString;
		public readonly View mView;
		public readonly ImageView mImageView;
		public readonly TextView mTxtView;
		public readonly TextView dateTextView;

        public SimpleViewHolder(View view) : base(view)
		{
			mView = view;
			mImageView = view.FindViewById<ImageView>(Resource.Id.avatar);
			mTxtView = view.FindViewById<TextView>(Resource.Id.text1);
			dateTextView = view.FindViewById<TextView>(Resource.Id.date);
            dateTextView.Visibility = ViewStates.Visible;
            mImageView.Visibility = ViewStates.Gone;
		}

		public override string ToString()
		{
			return base.ToString() + " '" + mTxtView.Text;
		}
	}
	}


