using Newtonsoft.Json;
using System;
namespace Asawer
{
	public class ContactWay
	{
		public ContactWay()
		{
		}
        
        [JsonProperty(PropertyName = "way_id")]
		public int ID
		{
			get;
			set;
		}

        [JsonProperty(PropertyName = "way_value")]
        public string Value
		{
			get;
			set;
		}
	}
}
