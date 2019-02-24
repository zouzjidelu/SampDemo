namespace IvyVSIXProject
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for IvyToolWindowControl.
    /// </summary>
    public partial class IvyToolWindowControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IvyToolWindowControl"/> class.
        /// </summary>
        public IvyToolWindowControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //AppDomain.CurrentDomain.Load()
            Assembly assembly = Assembly.Load(@"G:\Ef+MVC搭建框架【零度】\代码\CSWeFramework\CSWeFramework\CSWeFramework.Core\bin\Debug\CSWeFramework.Core.dll");

            var types = assembly.GetTypes();
            StringBuilder str = new StringBuilder();
            foreach (var type in types)
            {
                if (type.Name.Equals("Car"))
                {
                    str.Append("{" + type.Name + ":{");
                    foreach (var prop in type.GetProperties())
                    {
                        if (prop.PropertyType.GetInterface("IEnumerable", false) != null)
                        {
                            
                        }
                    }

                    str.Append("}");
                }

            }
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "IvyToolWindow");
        }
    }
}