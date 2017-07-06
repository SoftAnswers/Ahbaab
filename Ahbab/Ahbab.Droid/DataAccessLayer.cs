using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Ahbab.Entities;
using Android.App;
using Android.Widget;
using Newtonsoft.Json;

namespace Ahbab.Droid
{
	public class DataAccessLayer
	{
		public DataAccessLayer()
		{
		}

		public void GetSpinnerItems(Uri functionUri, string tableName, Activity currentActivity,
		                            Spinner currentSpinner, List<SpinnerItem> retVal)
		{
			retVal = new List<SpinnerItem>();

			var mClient = new WebClient();

			NameValueCollection parameters = new NameValueCollection();

			parameters.Add("TableName", tableName);

			mClient.UploadValuesCompleted += (sender, e) =>
			{

				var items = Encoding.UTF8.GetString(e.Result);

				retVal = JsonConvert.DeserializeObject<List<SpinnerItem>>(items);

				var adapter = new CustomSpinnerAdapter(currentActivity, Resource.Drawable.spinnerItem,
													   Resource.Id.item_value, retVal);

				adapter.SetDropDownViewResource(Resource.Drawable.spinnerDropDownItemStyle);

				currentSpinner.Adapter = adapter;
			};

			mClient.UploadValuesAsync(functionUri, parameters);
		}
	}
}


