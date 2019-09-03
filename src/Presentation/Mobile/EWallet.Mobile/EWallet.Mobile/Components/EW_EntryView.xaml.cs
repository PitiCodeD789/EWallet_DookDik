using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EWallet.Mobile.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EW_EntryView : ContentView
    {
        public EW_EntryView()
        {
            InitializeComponent();

            mEntry.BindingContext = this;
        }

        #region TextEntry
        public string TextEntry {
            get { return (string)GetValue(TextEntryProperty); }
            set { SetValue(TextEntryProperty, value); }
        }

        public static readonly BindableProperty TextEntryProperty =
                            BindableProperty.Create(
                        propertyName: "TextEntry",
                        returnType: typeof(string),
                        declaringType: typeof(EW_EntryView),
                        defaultBindingMode: BindingMode.TwoWay);
        #endregion

    }
}