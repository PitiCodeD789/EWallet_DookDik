using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EWallet.Mobile.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EW_ButtonView : ContentView
    {
        public EW_ButtonView()
        {
            InitializeComponent();
        }

        #region CommandButton

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
                    BindableProperty.Create(
                        propertyName: "Command",
                        returnType: typeof(ICommand),
                        declaringType: typeof(EW_ButtonView));

        private void MButton_Clicked(object sender, System.EventArgs e)
        {
            //if (Command != null)
            //{
            //    Command.Execute(null);
            //}
            Command?.Execute(null);
        }

        #endregion

        #region TextButton

        private string textButton;
        public string TextButton
        {
            get { return textButton; }
            set
            {
                textButton = value;
                mButton.Text = textButton;
            }
        }

        #endregion

    }
}