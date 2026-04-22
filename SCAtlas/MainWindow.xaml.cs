using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace SCAtlas
{
    public partial class MainWindow : Window
    {
        private string? _liveFolderPath;
        private string? _targetLocalizationFolderPath;

        public MainWindow()
        {
            InitializeComponent();
            UpdateInstallButtonState();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string? selectedFolder = PickFolder();

                if (string.IsNullOrWhiteSpace(selectedFolder))
                {
                    SetStatus("Sélection annulée.");
                    return;
                }

                GamePathTextBox.Text = selectedFolder;

                string? liveFolder = GetLiveFolder(selectedFolder);

                if (liveFolder is not null)
                {
                    _liveFolderPath = liveFolder;
                    _targetLocalizationFolderPath = GetTargetLocalizationFolder(_liveFolderPath);

                    Directory.CreateDirectory(_targetLocalizationFolderPath);

                    TargetPathTextBox.Text = _targetLocalizationFolderPath;

                    SetStatus(
                        "Structure Star Citizen détectée.\n" +
                        $"Dossier LIVE : {_liveFolderPath}\n" +
                        $"Chemin cible : {_targetLocalizationFolderPath}");
                }
                else
                {
                    _liveFolderPath = null;
                    _targetLocalizationFolderPath = null;
                    TargetPathTextBox.Text = "Aucun chemin cible déterminé";
                    SetStatus("Dossier sélectionné, mais impossible de trouver le dossier LIVE.");
                }

                UpdateInstallButtonState();
            }
            catch (Exception ex)
            {
                _liveFolderPath = null;
                _targetLocalizationFolderPath = null;
                TargetPathTextBox.Text = "Aucun chemin cible déterminé";
                UpdateInstallButtonState();
                SetStatus($"Erreur : {ex.Message}");
            }
        }

        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_targetLocalizationFolderPath))
                {
                    SetStatus("Impossible d’installer : aucun chemin cible valide.");
                    return;
                }

                string sourceFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "global.ini");

                if (!File.Exists(sourceFilePath))
                {
                    SetStatus($"Fichier source introuvable : {sourceFilePath}");
                    return;
                }

                Directory.CreateDirectory(_targetLocalizationFolderPath);

                string destinationFilePath = Path.Combine(_targetLocalizationFolderPath, "global.ini");
                string backupFilePath = Path.Combine(_targetLocalizationFolderPath, "global.ini.bak");

                if (File.Exists(destinationFilePath))
                {
                    File.Copy(destinationFilePath, backupFilePath, true);
                }

                File.Copy(sourceFilePath, destinationFilePath, true);

                SetStatus(
                    "Traduction installée avec succès.\n" +
                    $"Fichier installé : {destinationFilePath}\n" +
                    $"Sauvegarde : {backupFilePath}");
            }
            catch (Exception ex)
            {
                SetStatus($"Erreur pendant l’installation : {ex.Message}");
            }
        }

        private static string? PickFolder()
        {
            var dialog = new OpenFolderDialog
            {
                Title = "Sélectionnez le dossier de Star Citizen"
            };

            bool? result = dialog.ShowDialog();
            return result == true ? dialog.FolderName : null;
        }

        private static string? GetLiveFolder(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                return null;
            }

            if (Directory.Exists(Path.Combine(folderPath, "data")))
            {
                return folderPath;
            }

            string directLivePath = Path.Combine(folderPath, "LIVE");
            if (Directory.Exists(directLivePath))
            {
                return directLivePath;
            }

            string[] liveDirectories = Directory.GetDirectories(folderPath, "LIVE", SearchOption.AllDirectories);
            if (liveDirectories.Length > 0)
            {
                return liveDirectories[0];
            }

            return null;
        }

        private static string GetTargetLocalizationFolder(string liveFolderPath)
        {
            return Path.Combine(
                liveFolderPath,
                "data",
                "Localization",
                "french_(france)");
        }

        private void UpdateInstallButtonState()
        {
            InstallButton.IsEnabled = !string.IsNullOrWhiteSpace(_targetLocalizationFolderPath);
        }

        private void SetStatus(string message)
        {
            StatusTextBlock.Text = message;
        }
    }
}