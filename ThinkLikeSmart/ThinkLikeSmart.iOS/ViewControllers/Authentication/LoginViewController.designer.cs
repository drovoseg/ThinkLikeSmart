// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Drawing;
using UIKit;

namespace Tls.ThinkLikeSmart.iOS.ViewControllers.Authentication
{
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField accountNameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView countyControlsContainerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton forgetPasswordButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton loginButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl loginMethodSegmentedControl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField passwordTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton registrationButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton rememberPasswordButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (accountNameTextField != null) {
                accountNameTextField.Dispose ();
                accountNameTextField = null;
            }

            if (countyControlsContainerView != null) {
                countyControlsContainerView.Dispose ();
                countyControlsContainerView = null;
            }

            if (forgetPasswordButton != null) {
                forgetPasswordButton.Dispose ();
                forgetPasswordButton = null;
            }

            if (loginButton != null) {
                loginButton.Dispose ();
                loginButton = null;
            }

            if (loginMethodSegmentedControl != null) {
                loginMethodSegmentedControl.Dispose ();
                loginMethodSegmentedControl = null;
            }

            if (passwordTextField != null) {
                passwordTextField.Dispose ();
                passwordTextField = null;
            }

            if (registrationButton != null) {
                registrationButton.Dispose ();
                registrationButton = null;
            }

            if (rememberPasswordButton != null) {
                rememberPasswordButton.Dispose ();
                rememberPasswordButton = null;
            }
        }
    }
}