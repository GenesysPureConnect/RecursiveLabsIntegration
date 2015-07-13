using System;
using System.Windows.Forms;
using ININ.Diagnostics;
using ININ.IceLib.Connection;
using ININ.InteractionClient;
using ININ.InteractionClient.AddIn;
using ININ.InteractionClient.Interactions;

namespace ININ.Alliances.RecursiveLabsAddin
{
    public class RecursiveLabsAddin : IAddIn
    {
        public static readonly ITopicTracer AddinTracer = TopicTracerFactory.CreateTopicTracer("ININ.Alliances.RecursiveLabsAddin");

        public void Load(IServiceProvider serviceProvider)
        {
            try
            {
                var session = serviceProvider != null
                    ? serviceProvider.GetService(typeof (Session)) as Session
                    : null;

                if (session == null)
                {
                    throw new Exception("Failed to get session!");
                }

                // Add Recursive Labs button
                var service = ServiceLocator.Current.GetInstance<IClientInteractionButtonService>();
                if (service == null) throw new Exception("Unable to locate IClientInteractionButtonService service.");
                service.Add(new RecursiveLabsButton(session));
                RecursiveLabsAddin.AddinTracer.Always("Recursive Labs addin loaded");
            }
            catch (Exception ex)
            {
                RecursiveLabsAddin.AddinTracer.Exception(ex);
                MessageBox.Show(
                    "Error on load: " + ex.Message + Environment.NewLine + Environment.NewLine +
                    "Please restart the Interaction Client and contact your system administrator if this issue persists.",
                    "Error loading Recursive Labs Addin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Unload()
        {
            
        }
    }
}
