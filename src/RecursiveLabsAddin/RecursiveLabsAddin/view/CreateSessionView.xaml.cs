using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ININ.Alliances.RecursiveLabsAddin.viewmodel;

namespace ININ.Alliances.RecursiveLabsAddin.view
{
    /// <summary>
    /// Interaction logic for CreateSessionView.xaml
    /// </summary>
    public partial class CreateSessionView : UserControl
    {
        public RecursiveLabsSessionViewModel RecursiveLabsSession
        {
            get { return DataContext as RecursiveLabsSessionViewModel; }
        }

        public CreateSessionView()
        {
            InitializeComponent();
        }

        private void StartSession_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                RecursiveLabsSession.StartSession();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Window.GetWindow(this).Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }

        private void CopyGuestLink_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText(RecursiveLabsSession.GuestLink);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }

        private void OpenGuestLink_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(RecursiveLabsSession.GuestLink);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }

        private void CopyHostLink_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText(RecursiveLabsSession.HostLink);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }

        private void OpenHostLink_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(RecursiveLabsSession.HostLink);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }
    }
}
