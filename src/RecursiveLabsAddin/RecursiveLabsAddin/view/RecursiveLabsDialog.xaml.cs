using System;
using System.Windows;
using ININ.Alliances.RecursiveLabsAddin.model;
using ININ.Alliances.RecursiveLabsAddin.viewmodel;
using ININ.IceLib.Interactions;

namespace ININ.Alliances.RecursiveLabsAddin.view
{
    /// <summary>
    /// Interaction logic for RecursiveLabsDialog.xaml
    /// </summary>
    public partial class RecursiveLabsDialog
    {
        private RecursiveLabsSessionViewModel ViewModel { get { return DataContext as RecursiveLabsSessionViewModel; } }

        public RecursiveLabsDialog(Interaction interaction)
        {
            InitializeComponent();

            Initialize(interaction);
        }

        private void Initialize(Interaction interaction)
        {
            try
            {
                // Create new session vm
                var sessionvm = new RecursiveLabsSessionViewModel(interaction);

                // Add urls to VM
                foreach (var url in RecursiveLabsButton.Urls)
                {
                    // Make sure it doesn't think it's selected
                    url.IsSelected = false;

                    // Add to list
                    sessionvm.Urls.Add(url);
                }

                // Set to data context
                DataContext = sessionvm;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }

        private void OnSessionTypeSelected(RecursiveLabsSessionType sessiontype)
        {
            try
            {
                ViewModel.SimpleSessionType = sessiontype == RecursiveLabsSessionType.Host;
                HostOrGuestPanel.Visibility = Visibility.Collapsed;
                SessionViewPanel.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }
    }
}
