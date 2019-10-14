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
using TodoWPF.Views;

namespace TodoWPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static ObservableCollection<Todo> ListTodoDaily { get; set; }
        public static ObservableCollection<Todo> ListTodoSwing { get; set; }
        public static ObservableCollection<Todo> ListTodoLong { get; set; }

        public ICommand ManageCommand { get; set; }
        public bool CheckDaily
        {
            get => viewDaily == Visibility.Visible;
            set
            {
                if (value)
                {
                    viewDaily = Visibility.Visible;
                    viewSwing = Visibility.Hidden;
                    viewLong = Visibility.Hidden;
                    RaiseAllRadioproperties();
                }
            }
        }
        public bool CheckSwing
        {
            get => viewSwing == Visibility.Visible;
            set
            {
                if (value)
                {
                    viewDaily = Visibility.Hidden;
                    viewSwing = Visibility.Visible;
                    viewLong = Visibility.Hidden;
                    RaiseAllRadioproperties();
                }
            }
        }
        public bool CheckLong
        {
            get => viewLong == Visibility.Visible;
            set
            {
                if (value)
                {
                    viewDaily = Visibility.Hidden;
                    viewSwing = Visibility.Hidden;
                    viewLong = Visibility.Visible;
                    RaiseAllRadioproperties();
                }
            }
        }
        private Visibility viewDaily;
        public Visibility ViewDaily
        {
            get => viewDaily;
        }
        private Visibility viewSwing;
        public Visibility ViewSwing
        {
            get => viewSwing;
        }
        private Visibility viewLong;
        public Visibility ViewLong
        {
            get => viewLong;
        }
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
        public MainWindowViewModel()
        {
            ListTodoDaily = Todo.GetTodosDaily();
            ListTodoSwing = Todo.GetTodosSwing();
            ListTodoLong = Todo.GetTodosLong();
            todo = new Todo();
            CheckDaily = true;
            RaiseAllRadioproperties();
            ManageCommand = new RelayCommand(() =>
            {
                AddTodoWindow w = new AddTodoWindow();
                w.Show();
            });
            Messenger.Default.Register<Todo>(this, t =>
            {
                Todo todo = ListTodoDaily.FirstOrDefault((x => x.Id == t.Id));
                if (todo == null)
                {
                    ListTodoDaily.Add(t);
                    RaiseAllRadioproperties();
                }
                else
                {
                    todo.Id = t.Id;
                    todo.Echeance = t.Echeance;
                    todo.DateCreation = t.DateCreation;
                    todo.Titre = t.Titre;
                    todo.Description = t.Description;
                    todo.Details = t.Details;
                    todo.Important = t.Important;
                    RaiseAllRadioproperties();
                }
            });
        }
        private void RaiseAllRadioproperties()
        {
            RaisePropertyChanged("Echeance");
            RaisePropertyChanged("DateCreation");
            RaisePropertyChanged("titre");
            RaisePropertyChanged("Description");
            RaisePropertyChanged("Details");
            RaisePropertyChanged("Important");
            RaisePropertyChanged("viewDaily");
            RaisePropertyChanged("viewSwing");
            RaisePropertyChanged("viewLong");
        }
    }
}
