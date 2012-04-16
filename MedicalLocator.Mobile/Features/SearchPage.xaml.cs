﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MedicalLocator.Mobile.Features
{
    public partial class SearchPage : PhoneApplicationPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private void MainPage_BindingValidationError(object sender, ValidationErrorEventArgs e)
        {
	        var state = e.Action == ValidationErrorEventAction.Added ? "Invalid" : "Valid";

	        VisualStateManager.GoToState((Control)e.OriginalSource, state, false);
        }

    }
}