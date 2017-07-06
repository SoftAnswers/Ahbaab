using System;
using System.Collections.Generic;
using Ahbab.Entities;
using Android.App;
using Android.Views;
using Android.Widget;

namespace Ahbab.Droid
{
	public class CustomSpinnerAdapter : ArrayAdapter<SpinnerItem>
	{
		private readonly Activity _Context;
		private readonly List<SpinnerItem> _Data;
		private readonly IList<View> _views = new List<View>();

		public CustomSpinnerAdapter(Activity context, int resource, int textViewResourceId, List<SpinnerItem> data)
			: base(context, resource, textViewResourceId, data)
		{
			this._Context = context;
			this._Data = data;
		}

		public SpinnerItem GetItemAtPosition(int position)
		{
			return _Data[position];
		}

		public override long GetItemId(int id)
		{
			return id;
		}

		public override int GetPosition(Java.Lang.Object item)
		{
			return base.GetPosition(item);
		}

		public override int Count
		{
			get
			{
				return _Data == null ? 0 : _Data.Count;
			}
		}

		public override View GetDropDownView(int position, View convertView, ViewGroup parent)
		{
			return GetCustomView(position, convertView, parent, true);
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			return GetCustomView(position, convertView, parent, false);
		}

		private View GetCustomView(int position, View convertView, ViewGroup parent, bool dropdown)
		{
			var item = _Data[position];

			var inflater = LayoutInflater.From(_Context);
			var view = convertView ?? inflater.Inflate((dropdown ? Resource.Drawable.spinnerItem :
														Resource.Drawable.spinnerDropDownItemStyle), parent, false);

			if (item != null)
			{
				// Parse the data from each object and set it.
				TextView ItemId = (TextView)view.FindViewById(Resource.Id.item_id);

				TextView ItemName = (TextView)view.FindViewById(Resource.Id.item_value);

				if (ItemId != null)
				{
					ItemId.Text = item.ID.ToString();
				}
				if (ItemName != null)
				{
					ItemName.Text = !string.IsNullOrEmpty(item.DescriptionAR) ?
						item.DescriptionAR : item.DescriptionEN;
				}
			}

			if (!_views.Contains(view))
				_views.Add(view);

			return view;
		}

		private void ClearViews()
		{
			foreach (var view in _views)
			{
				view.Dispose();
			}
			_views.Clear();
		}

		protected override void Dispose(bool disposing)
		{
			ClearViews();
			base.Dispose(disposing);
		}
	}
}

