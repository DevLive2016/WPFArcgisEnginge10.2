
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using System.Windows.Forms;

namespace AEMapWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        AxMapControl mapControl = null;
        AxTOCControl tocControl = null;
        AxToolbarControl toolbarControl = null;
        public MainWindow()
        {
            InitializeComponent();
            CreateEngineControls();
        }
        //建立AE控件与WindowsFormsHost控件的联系
        private void CreateEngineControls()
        {
            mapControl = new AxMapControl();
            windowsFormsHost3.Child = mapControl;
            tocControl = new AxTOCControl();
            windowsFormsHost2.Child = tocControl;
            toolbarControl = new AxToolbarControl();
            windowsFormsHost1.Child = toolbarControl;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tocControl.SetBuddyControl(mapControl);
            toolbarControl.SetBuddyControl(mapControl);
            ToolbarAddItems();
        } //ToolBar中添加工具
        private void ToolbarAddItems()
        {
            toolbarControl.AddItem(new ControlsOpenDocCommandClass(), -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarControl.AddItem(new ControlsSaveAsDocCommandClass(), -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarControl.AddItem(new ControlsAddDataCommandClass(), -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarControl.AddItem("esriControls.ControlsMapNavigationToolbar");
            toolbarControl.AddItem("esriControls.ControlsMapIdentifyTool");
        }

    }
}
