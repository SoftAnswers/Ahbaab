using System;
using System.Collections.Generic;
using UIKit;
using Asawer.Entities;
using Asawer;

namespace Asawer.iOS {
    public partial class PickerCustomCell : UITableViewCell {
        public PickerCustomCell (IntPtr handle) : base (handle) {}

        /**
         * Function used ti initialize and fill the picker items
         */
        public void setPickerView(List<SpinnerItem> data, int rowNb, int dataSelected, RegistrationController.RegistrationDataSource parent) {
            cellPicker.Model = new PickerViewModel(data, parent);
            cellPicker.Tag = rowNb;
            if (dataSelected != 0) {
                this.selectvalue(dataSelected);
            }
        }

        /**
         * Function used to select a value inside the picker
         */ 
        public void selectvalue(int index) {
            cellPicker.Select(index, 0, true);
        }

        public class PickerViewModel : UIPickerViewModel {
            private List<SpinnerItem> myItems;
            RegistrationController.RegistrationDataSource parent;

            public PickerViewModel(List<SpinnerItem> items, RegistrationController.RegistrationDataSource parent) {
                myItems = items;
                this.parent = parent;
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
                if (picker.Tag == 5) {
                    this.parent.user.Status = (int)row;
                } else if (picker.Tag == 6) {
                    this.parent.user.EyesColorId = (int)row;
                } else if (picker.Tag == 7) {
                    this.parent.user.HairColorId = (int)row;
                } else if (picker.Tag == 8) {
                    this.parent.user.HeightId = (int)row;
                } else if (picker.Tag == 9) {
                    this.parent.user.WeightId = (int)row;
                } else if (picker.Tag == 10) {
                    this.parent.user.UsagePurposeId = (int)row;
                } else if (picker.Tag == 11) {
                    this.parent.user.Age = (int)row;
                } else if (picker.Tag == 12) {
                    this.parent.user.EducationLevelID = (int)row;
                } else if (picker.Tag == 13) {
                    this.parent.user.OriginCountryId = (int)row;
                } else if (picker.Tag == 14) {
                    this.parent.user.CurrentCountryId = (int)row;
                } else if (picker.Tag == 15) {
                    this.parent.user.JobId = (int)row;
                }
            }
        }
    }
}