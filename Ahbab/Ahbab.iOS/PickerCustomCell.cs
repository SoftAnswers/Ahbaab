using System;
using System.Collections.Generic;
using UIKit;
using Ahbab.Entities;

namespace Ahbab.iOS {
    public partial class PickerCustomCell : UITableViewCell {
        public PickerCustomCell (IntPtr handle) : base (handle) {}

        public void setPickerView(List<SpinnerItem> data) {
            cellPicker.Model = new PickerViewModel(data);
        }

        public class PickerViewModel : UIPickerViewModel {
            private List<SpinnerItem> myItems;
            protected int selectedIndex = 0;

            public PickerViewModel(List<SpinnerItem> items) {
                myItems = items;
            }

            public string SelectedItem {
                get { return myItems[selectedIndex].DescriptionAR; }
            }

            public override nint GetComponentCount(UIPickerView picker) {
                return 1;
            }

            public override nint GetRowsInComponent(UIPickerView picker, nint component) {
                return myItems.Count;
            }

            public override string GetTitle(UIPickerView picker, nint row, nint component) {
                if (myItems[0].DescriptionAR.Equals(Constants.DefaultValues.Age) || myItems[0].DescriptionAR.Equals(Constants.DefaultValues.ContactTime) || myItems[0].DescriptionAR.Equals(Constants.DefaultValues.TimeZone)) {
                    if (row == 0) {
                        return myItems[(int)row].DescriptionAR;
                    } else {
                        return myItems[(int)row].DescriptionEN;
                    }
                } else {
                    return myItems[(int)row].DescriptionAR;
                }
 
            }

            public override void Selected(UIPickerView picker, nint row, nint component) {
                selectedIndex = (int)row;
            }
        }

    }
}