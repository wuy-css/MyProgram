using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfApp4.Models;

namespace WpfApp4.Views
{
    /// <summary>
    /// TreeViewWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class TreeViewWindowView : UserControl
    {
        public TreeViewWindowView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<EmployeeData> employeeDatas = new List<EmployeeData>();
            employeeDatas.Add(new EmployeeData { Name = "员工1" });
            employeeDatas.Add(new EmployeeData { Name = "员工2" });

            List<DempartmentData> departmentDatas = new List<DempartmentData>();
            departmentDatas.Add(new DempartmentData { Name = "部门1", EmployeeDatas = employeeDatas });
            departmentDatas.Add(new DempartmentData { Name = "部门2", EmployeeDatas = employeeDatas });

            List<CompanyData> companyDatas = new List<CompanyData>();
            companyDatas.Add(new CompanyData { Name = "公司1", DempartmentDatas = departmentDatas });
            companyDatas.Add(new CompanyData { Name = "公司2", DempartmentDatas = departmentDatas });

            treeView.ItemsSource = companyDatas;
            //引用了数据类的名称空间 xmlns:da = "clr-namespace:CSDNWpfApp.com.data"
            //DataType指定了HierarchicalDataTemplate模板用哪种数据类型
            //ItemsSource指定下一层显示哪些数据
            //内容指定了一个TextBlock，并绑定了需要显示当前指定类型数据中的属性
        }
    }
}
