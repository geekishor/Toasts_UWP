using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Toasts_in_UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnShowToast_Click(object sender, RoutedEventArgs e)
        {
            var template = ToastTemplateType.ToastText04;
            var xml = ToastNotificationManager.GetTemplateContent(template);
            xml.DocumentElement.SetAttribute("launch", "args");

            var text = xml.CreateTextNode("Hello World! This is toast in Windows 10 Apps.");
            var elements = xml.GetElementsByTagName("text");
            elements[0].AppendChild(text);

            var toastNotification = new ToastNotification(xml);
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            toastNotifier.Show(toastNotification);
        }
    }
}
