﻿using Foundation;
using System;
using UIKit;

namespace Asawer.iOS {
    public partial class MainPageTabController : UITabBarController {
        public MainPageTabController (IntPtr handle) : base (handle) {}

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            this.NavigationItem.SetHidesBackButton(true, false);
        }
    }
}