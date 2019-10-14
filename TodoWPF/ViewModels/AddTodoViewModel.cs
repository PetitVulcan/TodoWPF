using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TodoWPF.Models;

namespace TodoWPF.ViewModels
{
    class AddTodoViewModel : ViewModelBase
    {
        private Todo todo;

        public string Echeance
        {
            get => todo.Echeance;
            set
            {
                todo.Echeance = value;
                RaisePropertyChanged();
            }
        }
        public string Titre
        {
            get => todo.Titre;
            set
            {
                todo.Titre = value;
                RaisePropertyChanged();
            }
        }
        public string Description
        {
            get => todo.Description;
            set
            {
                todo.Description = value;
                RaisePropertyChanged();
            }
        }
        public string Details
        {
            get => todo.Details;
            set
            {
                todo.Details = value;
                RaisePropertyChanged();
            }
        }
        public string Important
        {
            get => todo.Important;
            set
            {
                todo.Important = value;
                RaisePropertyChanged();
            }
        }
        public DateTime DateCreation
        {
            get => todo.DateCreation;
            set
            {
                todo.DateCreation = value;
                RaisePropertyChanged();
            }
        }

        public bool EcheanceDaily
        {
            get => todo.Echeance == "Daily";

            set
            {
                if (value)
                    todo.Echeance = "Daily";
                RaisePropertyChanged();
            }
        }

        public bool EcheanceSwing
        {
            get => todo.Echeance == "Swing";

            set
            {
                if (value)
                    todo.Echeance = "Swing";
                RaisePropertyChanged();
            }
        }
        public bool EcheanceLong
        {
            get => todo.Echeance == "Long";

            set
            {
                if (value)
                    todo.Echeance = "Long";
                RaisePropertyChanged();
            }
        }
        public bool ImportantTrue
        {
            get => todo.Important == "true";

            set
            {
                if (value)
                    todo.Important = "true";
                RaisePropertyChanged();
            }
        }
        public bool ImportantFalse
        {
            get => todo.Important == "false";

            set
            {
                if (value)
                    todo.Important = "false";
                RaisePropertyChanged();
            }
        }
        public ICommand NewCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public static ObservableCollection<Todo> ListTodoDaily { get; set; }
        public static ObservableCollection<Todo> ListTodoSwing { get; set; }
        public static ObservableCollection<Todo> ListTodoLong { get; set; }

        public AddTodoViewModel()
        {
            NewTodo();
            NewCommand = new RelayCommand(NewTodo);
            AddCommand = new RelayCommand(AddTodo);
            EditCommand = new RelayCommand(UpdateTodo);
            DeleteCommand = new RelayCommand(DeletePatient);
            SearchCommand = new RelayCommand(SearchTodo);
            CloseCommand = new RelayCommand(()=>
            {
                Application.Current.Windows.Cast<Window>().FirstOrDefault(x => x.IsActive).Close();
            });
        }
        private void NewTodo()
        {
            todo = new Todo();
            Echeance = default;
            DateCreation = DateTime.Now;
            Titre = default;
            Description = default;
            Details = default;
            ImportantTrue = false;
            ImportantFalse = false;
            EcheanceDaily = false;
            EcheanceSwing = false;
            EcheanceLong = false;
        }
        private void AddTodo()
        {
            if (todo.Add())
            {
                MessageBox.Show("Todo ajoutée avec numéro : " + todo.Id);
                Messenger.Default.Send<Todo>(todo);
                NewTodo();
            }
            else
            {
                MessageBox.Show("Erreur d'insertion");
            }
        }
        private void SearchTodo()
        {
            todo = Todo.GetTodo(Titre);
            if (todo == null)
            {
                MessageBox.Show("Aucun patient");
                NewTodo();
            }
            else
            {
                RaiseAllProperties();
            }
        }

        private void UpdateTodo()
        {

            if (todo.Id > 0)
            {
                if (todo.Update())
                {
                    Messenger.Default.Send<Todo>(todo);
                    MessageBox.Show("Todo mise à jour");                    
                }
                else
                {
                    MessageBox.Show("Erreur serveur");
                }
            }
            else
            {
                MessageBox.Show("Merci de rechercher une Todo");
            }
        }

        private void DeletePatient()
        {

            if (todo.Id > 0)
            {
                if (todo.Delete())
                {
                    Messenger.Default.Send<Todo>(todo);
                    MessageBox.Show("Todo supprimée");                    
                    NewTodo();
                    RaiseAllProperties();
                }
                else
                {
                    MessageBox.Show("Erreur serveur");
                }
            }
            else
            {
                MessageBox.Show("Merci de rechercher un patient");
            }
        }

        private void RaiseAllProperties()
        {
            RaisePropertyChanged("Echeance");
            RaisePropertyChanged("DateCreation");
            RaisePropertyChanged("Titre");
            RaisePropertyChanged("Description");
            RaisePropertyChanged("Details");
            RaisePropertyChanged("Important");
        }
    }
}
