using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp4.Command;

namespace WpfApp4.ViewModels
{
    public class TabControlViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyChanged([CallerMemberName] string displayName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(displayName));
        }

        private string mAC1;
        public string MAC1
        {
            get { return mAC1; }
            set { mAC1 = value; NotifyChanged(); }
        }

        private string mAC2;
        public string MAC2
        {
            get { return mAC2; }
            set { mAC2 = value; NotifyChanged(); }
        }

        public ICommand ReplayCommand { get; set; }
        public TabControlViewModel()
        {
            ReplayCommand = new MyCommand(Send, SetBool);
        }

        private void Send(object parm)
        {

            MAC1 = "";
            MAC2 = "";

            Task.Run(() =>
             {
                 Thread.Sleep(1);
                 MAC1 = GetSerial();
                 MAC2 = GetSystemDiskNo();
             });
        }

        private bool SetBool(object parm)
        {
            return true;
        }

        public static string GetSerial()
        {
            try
            {
                GetListDisk();
                var mc = new ManagementClass("Win32_DiskDrive");
                var moc = mc.GetInstances();
                var res = string.Empty;
                var resList = new List<string>(moc.Count);

                foreach (ManagementObject mo in moc)
                {
                    try
                    {
                        if (mo["InterfaceType"].ToString().Replace(" ", string.Empty) == "USB")
                        {
                            continue;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        res = mo["SerialNumber"].ToString().Replace(" ", string.Empty);
                        resList.Add(res);
                        if (mo["DeviceID"].ToString().Replace(" ", string.Empty).Contains("0"))
                        {
                            if (!string.IsNullOrWhiteSpace(res))
                            {
                                return res;
                            }
                        }
                    }
                    catch
                    {
                    }
                }

                res = resList[0];
                if (!string.IsNullOrWhiteSpace(res))
                {
                    return res;
                }
            }
            catch (Exception ex)
            {

            }

            return "NA";

        }

        private static string GetSystemDiskNo()
        {
            string result = "NA";
            try
            {
                ManagementObjectCollection instances = new ManagementClass("Win32_PhysicalMedia").GetInstances();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (ManagementBaseObject managementBaseObject in instances)
                {
                    ManagementObject managementObject = (ManagementObject)managementBaseObject;
                    string key = managementObject.Properties["Tag"].Value.ToString().ToLower().Trim();
                    string text = ((string)managementObject.Properties["SerialNumber"].Value) ?? string.Empty;
                    text = text.Trim();
                    dictionary.Add(key, text);
                }
                ManagementObjectCollection instances2 = new ManagementClass("Win32_OperatingSystem").GetInstances();
                string currentSysRunDisk = string.Empty;
                foreach (ManagementBaseObject managementBaseObject2 in instances2)
                {
                    ManagementObject managementObject2 = (ManagementObject)managementBaseObject2;
                    currentSysRunDisk = Regex.Match(managementObject2.Properties["Name"].Value.ToString().ToLower(), "harddisk\\d+").Value;
                }
                IEnumerable<KeyValuePair<string, string>> source = from x in dictionary
                                                                   where Regex.IsMatch(x.Key, "physicaldrive" + Regex.Match(currentSysRunDisk, "\\d+$").Value)
                                                                   select x;
                if (source.Any<KeyValuePair<string, string>>())
                {
                    result = source.ElementAt(0).Value;
                }
            }
            catch (Exception arg)
            {

            }
            return result;
        }


        public static List<string> GetListDisk()
        {
            List<string> lstDisk = new List<string>();
            ManagementClass mgtCls = new ManagementClass("Win32_DiskDrive");
            Dictionary<string, ManagementObject> dics = new Dictionary<string, ManagementObject>();
            var disks = mgtCls.GetInstances();
            foreach (ManagementObject mo in disks)
            {

                foreach (ManagementObject diskPartition in mo.GetRelated("Win32_DiskPartition"))
                {
                    foreach (ManagementBaseObject disk in diskPartition.GetRelated("Win32_LogicalDisk"))
                    {
                        lstDisk.Add(disk.Properties["Name"].Value.ToString());
                        dics.Add(disk.Properties["Name"].Value.ToString(), mo);
                    }
                }

                //Console.WriteLine("-------------------------------------------------------------------------------------------");
            }
            return lstDisk;
        }
    }
}
