using CRMapp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRMapp.Views.Agent
{
    class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }  
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as Message;
            if (messageVm == null)
                return null;

            return (messageVm.User == App.user) ? outgoingDataTemplate : incomingDataTemplate;
        }
    }
}
