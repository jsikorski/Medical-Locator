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
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Shell;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace MedicalLocator.Mobile
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PushpinTap(object sender, GestureEventArgs e)
        {
            OpenPushpinTooltip(sender as Pushpin);
        }

        private void OpenPushpinTooltip(Pushpin pushpin)
        {
            ContextMenu contextMenu = ContextMenuService.GetContextMenu(pushpin);
            contextMenu.IsOpen = true;
        }
    }
}