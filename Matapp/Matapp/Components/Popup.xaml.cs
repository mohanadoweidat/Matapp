﻿using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NTI_QRsystem.Components
{
    public enum PopupType { INFO,INPUT }
    public partial class Popup : PopupPage
    {
        public PopupType type;
        private View content;

        public Popup(View content, Page page)
        {
            this.content = content;
            InitializeComponent();
            if(content is PopupComponent)
            {
                type = ((PopupComponent)content).GetPopupType();
            } else
            {
                type = PopupType.INFO;
            }
            if(type == PopupType.INFO)
            {
                AbsoluteLayout.SetLayoutBounds(frame, new Rectangle(0.5, 0.5, 0.8, 0.3));
            } else if(type == PopupType.INPUT)
            {
                AbsoluteLayout.SetLayoutBounds(frame, new Rectangle(0.5, 0.3, 0.8, 0.6));
            }
            if(content is CustomPopup)
            {
                ((CustomPopup)content).ChangeFrame(frame);
                ((CustomPopup)content).ChangeAnimation(an);
            }
            pop.Children.Add(content);
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += (s, e) => {};
            pop.GestureRecognizers.Add(tap);
            TapGestureRecognizer tap1 = new TapGestureRecognizer();
            tap1.Tapped += (s, e) => {
                try
                {
                    Run();
                } catch { }
            };
            abs.GestureRecognizers.Add(tap1);
        }

        private async void Run()
        {
            if (content is PopupComponent)
            {
                ((PopupComponent)content).OnClosed();
            }
            await Navigation.PopPopupAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        protected override void OnAppearingAnimationBegin()
        {
            base.OnAppearingAnimationBegin();
        }

        protected override void OnAppearingAnimationEnd()
        {
            base.OnAppearingAnimationEnd();
        }

        protected override void OnDisappearingAnimationBegin()
        {
            base.OnDisappearingAnimationBegin();
        }

        protected override void OnDisappearingAnimationEnd()
        {
            base.OnDisappearingAnimationEnd();
        }

        protected override Task OnAppearingAnimationBeginAsync()
        {
            return base.OnAppearingAnimationBeginAsync();
        }

        protected override Task OnAppearingAnimationEndAsync()
        {
            return base.OnAppearingAnimationEndAsync();
        }

        protected override Task OnDisappearingAnimationBeginAsync()
        {
            return base.OnDisappearingAnimationBeginAsync();
        }

        protected override Task OnDisappearingAnimationEndAsync()
        {
            return base.OnDisappearingAnimationEndAsync();
        }

        // ### Overrided methods which can prevent closing a popup page ###

        // Invoked when a hardware back button is pressed
        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return base.OnBackButtonPressed();
        }
        
        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return true;
        }

        public async void Show()
        {
            // Open a PopupPage
            await Navigation.PushPopupAsync(this);
        }

    }
}