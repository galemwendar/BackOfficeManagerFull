using BackOfficeManagerLite.ViewModel;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows.Input;

namespace BackOfficeManager.CoreViewModel
{
    public class PathToFolderCommand : CommandBase
    {
        private readonly MainViewModel _viewModel;

        public PathToFolderCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {


            CommonOpenFileDialog folderBrowserDialog = new CommonOpenFileDialog();
            folderBrowserDialog.IsFolderPicker = true;
            if (folderBrowserDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // folderBrowserDialog.FileName; //TODO save this to file
                _viewModel.PathToFolder = folderBrowserDialog.FileName;
            }
            else
            {
                throw new Exception("Файл не выбран!");
            }
        }
    }
}