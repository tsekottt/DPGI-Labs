using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;

namespace Lab2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Додаємо командні прив'язки
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, execute_Save, canExecute_Save));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, execute_Open, canExecute_Open));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, execute_Close, canExecute_Close));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy, execute_Copy, canExecute_Copy));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, execute_Paste, canExecute_Paste));
        }

        // Команда "Зберегти"
        private void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrWhiteSpace(inputTextBox.Text);
        }

        private void execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            string filePath = "text.txt";
            try
            {
                File.WriteAllText(filePath, inputTextBox.Text);
                MessageBox.Show("Файл збережено як text.txt у теці програми!", "Збереження", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Команда "Відкрити"
        private void canExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                inputTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        // Команда "Очистити"
        private void canExecute_Close(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = inputTextBox.Text.Length > 0;
        }

        private void execute_Close(object sender, ExecutedRoutedEventArgs e)
        {
            inputTextBox.Clear();
        }

        // Команда "Копіювати"
        private void canExecute_Copy(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(inputTextBox.SelectedText);
        }

        private void execute_Copy(object sender, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetText(inputTextBox.SelectedText);
        }

        // Команда "Вставити"
        private void canExecute_Paste(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        private void execute_Paste(object sender, ExecutedRoutedEventArgs e)
        {
            inputTextBox.SelectedText = Clipboard.GetText();
        }
    }
}
