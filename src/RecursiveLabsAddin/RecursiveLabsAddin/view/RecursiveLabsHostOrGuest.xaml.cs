using System;
using System.Windows;
using ININ.Alliances.RecursiveLabsAddin.model;

namespace ININ.Alliances.RecursiveLabsAddin.view
{
    /// <summary>
    /// Interaction logic for RecursiveLabsHostOrGuest.xaml
    /// </summary>
    public partial class RecursiveLabsHostOrGuest
    {
        #region Private Fields



        #endregion



        #region Public Properties

        public delegate void SessionTypeSelectedHandler(RecursiveLabsSessionType sessionType);

        public event SessionTypeSelectedHandler SessionTypeSelected;

        #endregion



        public RecursiveLabsHostOrGuest()
        {
            InitializeComponent();
        }



        #region Private Methods

        private void RaiseSessionTypeSelected(RecursiveLabsSessionType sessionType)
        {
            if (SessionTypeSelected != null) SessionTypeSelected(sessionType);
        }

        #endregion



        #region Public Methods



        #endregion

        private void HostButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseSessionTypeSelected(RecursiveLabsSessionType.Host);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }

        private void ViewButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseSessionTypeSelected(RecursiveLabsSessionType.View);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }
    }
}
