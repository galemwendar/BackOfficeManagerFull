using BackOfficeManager.Settings;
using BackOfficeManagerLite.ViewModel;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows;
using System.Windows.Input;

namespace BackOfficeManager.CoreViewModel
{
    public class PathToFolderCommand : CommandBase
    {
        private readonly MainViewModel _viewModel;
        private readonly ISettingsService _settings;

        public PathToFolderCommand(ISettingsService settings,MainViewModel viewModel)
        {
            _viewModel = viewModel;
            _settings = settings;
        }
        public override void Execute(object? parameter)
        {


            CommonOpenFileDialog folderBrowserDialog = new CommonOpenFileDialog();
            folderBrowserDialog.IsFolderPicker = true;
            try
            {
                if (folderBrowserDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    // folderBrowserDialog.FileName; //TODO save this to file
                    _viewModel.PathToFolder = folderBrowserDialog.FileName;
                    _settings.SetSettings(_viewModel.PathToFolder, _viewModel.Login, _viewModel.Password);
                    _viewModel.OutputLog = "Выбран файл " + _viewModel.PathToFolder;
                }
                else
                {
                    _viewModel.OutputLog = "Файл не выбран!";
                }
            }
            catch (Exception ex)
            {

                _viewModel.OutputLog = ex.Message;
            }
        }
    }
}