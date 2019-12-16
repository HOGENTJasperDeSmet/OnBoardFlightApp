using OnBoardFlightApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OnBoardFlightApp.Styleselector
{
    public class BerichtStyleSelector : StyleSelector
    {
        public Style SentStyle { get; set; }

        public Style ReceivedStyle { get; set; }

        public Passagier Sender { get; set; }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var message = item as ChatBericht;
            if (message != null)
            {
                return message.passagier.Equals(this.Sender.Voornaam, StringComparison.CurrentCultureIgnoreCase)
                           ? this.SentStyle
                           : this.ReceivedStyle;
            }

            return base.SelectStyleCore(item, container);
        }
    }
}
