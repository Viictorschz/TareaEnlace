using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Prueba
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }

    public class ViewModel : BaseViewModel
    {
        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged(nameof(Nombre));
                OnPropertyChanged(nameof(CanSave));
            }
        }

        private string _telefono;
        public string Telefono
        {
            get => _telefono;
            set
            {
                _telefono = value;
                OnPropertyChanged(nameof(Telefono));
                OnPropertyChanged(nameof(CanSave));
            }
        }

        public ICommand SaveCommand { get; set; }

        public bool CanSave => !string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Telefono);

        public ViewModel()
        {
            SaveCommand = new RelayCommand(SaveData, () => CanSave);
        }

        private void SaveData()
        {
            var data = new Datos { Nombre = Nombre, Telefono = Telefono };

            XmlSerializer serializer = new XmlSerializer(typeof(Datos));
            using (TextWriter writer = new StreamWriter("datos.xml"))
            {
                serializer.Serialize(writer, data);
            }
            MessageBox.Show("Datos guardados en datos.xml");

            // Limpiar los campos después de guardar
            Nombre = string.Empty;
            Telefono = string.Empty;
        }
    }

    public class Datos
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => canExecute == null || canExecute();

        public void Execute(object parameter) => execute();
    }
}