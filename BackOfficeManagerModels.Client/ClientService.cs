using BackOfficeManager.Settings;
using BackOfficeManagerModels.Core;
using System.Diagnostics;

namespace BackOfficeManagerModels.Client
{
    public class ClientService : IClientService
    {
        public string FindClientApplication(ServerProperties props,ISettingsService settingsService)
        {
            string[] files = Directory.GetFiles(settingsService.GetSettingsByName("PathToFolder").ToString(), "BackOffice.exe", SearchOption.AllDirectories);
            string result = String.Empty;

            foreach (var file in files)
            {
                var chainMarker = Directory.GetParent(file).GetFiles("ChainSessions.dll", SearchOption.AllDirectories);
                if (FileVersionInfo.GetVersionInfo(file).FileVersion.ToString() == props.Version.ToString()
                    && props.Edition == "chain" && chainMarker.Length > 0)
                {
                    result = file;
                }

                else if (FileVersionInfo.GetVersionInfo(file).FileVersion.ToString() == props.Version.ToString()
                    && props.Edition == "default" && chainMarker.Length == 0)
                {
                    result = file;
                }

            }
            if (result == String.Empty)
            {
                throw new Exception("Файл не найден");
            }
            return result;
        }

        public void RunClient(string filepath)
        {
            using (Process myProcess = new Process())
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = filepath;
                myProcess.Start();

            }
        }

        public void CloseAllClients()
        {
            Process[] processes = Process.GetProcessesByName("BackOffice");
            foreach (Process process in processes)
            {
                process.Kill();
            }

        }
    }
}