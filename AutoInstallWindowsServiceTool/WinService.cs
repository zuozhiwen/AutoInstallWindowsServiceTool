using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.ServiceProcess;

/*
    ZuoZhiwen 2016/03/09
*/

namespace System
{
    public class WinService
    {
        private WinService() { }

        public string Caption { get; private set; }

        public string CheckPoint { get; private set; }

        public string CreationClassName { get; private set; }

        public string Description { get; private set; }

        public string DesktopInteract { get; private set; }

        public string DisplayName { get; private set; }

        public string ErrorControl { get; private set; }

        public string ExitCode { get; private set; }

        public string InstallDate { get; private set; }

        public string Name { get; private set; }

        public string PathName { get; private set; }

        public string ProcessId { get; private set; }

        public string ServiceSpecificExitCode { get; private set; }

        public string ServiceType { get; private set; }

        public string Started { get; private set; }

        public string StartMode { get; private set; }

        public string StartName { get; private set; }

        public string State { get; private set; }

        public string Status { get; private set; }

        public string SystemCreationClassName { get; private set; }

        public string SystemName { get; private set; }

        public string TagId { get; private set; }

        public string WaitHint { get; private set; }

        public static List<WinService> GetAllWindowsService()
        {
            var retList = new List<WinService>();

            ManagementClass managementClass = new ManagementClass("Win32_Service");
            var managementObjectList = managementClass.GetInstances();

            foreach(var managementObject in managementObjectList)
            {
                var winService = new WinService
                {
                    Caption = managementObject.GetPropertyValue("Caption") as string,
                    CheckPoint = managementObject.GetPropertyValue("CheckPoint") as string,
                    CreationClassName = managementObject.GetPropertyValue("CreationClassName") as string,
                    Description = managementObject.GetPropertyValue("Description") as string,
                    DesktopInteract = managementObject.GetPropertyValue("DesktopInteract") as string,
                    DisplayName = managementObject.GetPropertyValue("DesktopInteract") as string,
                    ErrorControl = managementObject.GetPropertyValue("ErrorControl") as string,
                    ExitCode = managementObject.GetPropertyValue("ExitCode") as string,
                    InstallDate = managementObject.GetPropertyValue("InstallDate") as string,
                    Name = managementObject.GetPropertyValue("Name") as string,
                    PathName = managementObject.GetPropertyValue("PathName") as string,
                    ProcessId = managementObject.GetPropertyValue("ProcessId") as string,
                    ServiceSpecificExitCode = managementObject.GetPropertyValue("ServiceSpecificExitCode") as string,
                    ServiceType = managementObject.GetPropertyValue("ServiceType") as string,
                    Started = managementObject.GetPropertyValue("Started") as string,
                    StartMode = managementObject.GetPropertyValue("StartMode") as string,
                    StartName = managementObject.GetPropertyValue("StartName") as string,
                    State = managementObject.GetPropertyValue("State") as string,
                    Status = managementObject.GetPropertyValue("Status") as string,
                    SystemCreationClassName = managementObject.GetPropertyValue("SystemCreationClassName") as string,
                    SystemName = managementObject.GetPropertyValue("SystemName") as string,
                    TagId = managementObject.GetPropertyValue("TagId") as string,
                    WaitHint = managementObject.GetPropertyValue("WaitHint") as string
                };
                retList.Add(winService);
            }

            return retList;
        }

        public static WinService GetWinServiceByName(string name)
        {
            var allService = GetAllWindowsService();
            return allService.FirstOrDefault(i => string.Compare(i.Name, name, true) == 0);
        }

        public static WinService GetWinServiceByPathName(string pathName)
        {
            var allService = GetAllWindowsService();
            return allService.FirstOrDefault(i => string.Compare(i.PathName?.Trim('\"'), pathName, true) == 0);
        }

        #region Control Windows Service Status

        public void Start()
        {
            using (var sc = new ServiceController(Name))
            {
                sc.Start();
            }
        }

        public void Stop()
        {
            using (var sc = new ServiceController(Name))
            {
                var processList = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(PathName?.Trim('\"')));
                if(processList != null && processList.Length > 0)
                {
                    var process = processList[0];
                    process.EnableRaisingEvents = true;
                    process.Exited += Process_Exited;
                }

                sc.Stop();
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            ServiceStoped(sender, e);
        }

        public void Refresh()
        {
            using (var sc = new ServiceController(Name))
            {
                sc.Refresh();
            }
        }

        public void Pause()
        {
            using (var sc = new ServiceController(Name))
            {
                sc.Pause();
            }
        }

        public void Continue()
        {
            using (var sc = new ServiceController(Name))
            {
                sc.Continue();
            }
        }

        #endregion

        #region Event

        public event EventHandler ServiceStarted;

        public event EventHandler ServiceStoped;

        #endregion
    }
}
    