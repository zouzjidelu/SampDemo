namespace FirstWindow
{
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;
    using System.Web.Script.Serialization;
    using System.Windows;
    using System.Windows.Controls;
    using Dapper;
    using DapperExtensions;

    /// <summary>
    /// Interaction logic for ToolWindow1Control.
    /// </summary>
    public partial class ToolWindow1Control : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindow1Control"/> class.
        /// </summary>
        public ToolWindow1Control()
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
            string path = TxtFilePath.Text;

            Assembly assembly = Assembly.LoadFile(@"E:\project\20180314\MallService\Mall.Model\bin\Debug\Mall.Model.dll");
            Type type = assembly.GetTypes().ToList().FirstOrDefault(m => m.Name.Equals(path));
            if (type == null)
            {
                MessageBox.Show($"没有找到{path}类", "ToolWindow1");
                return;
            }

            var props=type.GetProperties();
           
            object obj = Activator.CreateInstance(type);
            JavaScriptSerializer js = new JavaScriptSerializer();
           
            string jsonStr = string.Empty;

            jsonStr = js.Serialize(obj);
            string ss = JsonConvert.SerializeObject(obj);
            TxtJsonData.Text = jsonStr;

            //MessageBox.Show($"{jsonStr}", "ToolWindow1");

            //string jsonStr= JsonConvert.SerializeObject(obj);

            //string jsonData = TxtJsonData.Text= jsonStr;
            //MessageBox.Show($"{jsonData}", "ToolWindow1");

            //MessageBox.Show(
            //    string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
            //    "ToolWindow1");
        }
    }
}