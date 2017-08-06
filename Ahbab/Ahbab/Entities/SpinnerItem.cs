﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahbab.Entities
{
    public class SpinnerItem
    {
        public SpinnerItem(int id, string itemDescriptionEn, string itemDescriptionAr)
        {
            this.ID = id;
			this.DescriptionEN = itemDescriptionEn;
            this.DescriptionAR = itemDescriptionAr;
        }

        public int ID { get; set; }
		public string DescriptionEN { get; set; }
		public string DescriptionAR { get; set; }
	}
}