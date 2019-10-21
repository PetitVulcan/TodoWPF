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
        //public static ObservableCollection<Todo> ListTodoDaily { get; set; }
        //public static ObservableCollection<Todo> ListTodoSwing { get; set; }
        //public static ObservableCollection<Todo> ListTodoLong { get; set; }
        public dynamic ListeAfficher { get; set; }

        public ICommand ManageCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand AboutCommand { get; set; }
        public ICommand NotClickCommand { get; set; }
        public ICommand EncourageCommand { get; set; }

        private bool checkDaily;
        private bool checkSwing;
        private bool checkLong;
        public bool CheckDaily
        {
            get => checkDaily;
            set
            {
                checkDaily = value;
                if (value)
                {
                    CheckSwing = false;
                    CheckLong = false;
                    ListeAfficher = Todo.GetTodosDaily();
                    RaisePropertyChanged("ListeAfficher");
                }
                RaisePropertyChanged();
            }
        }
        public bool CheckSwing
        {
            get => checkSwing;
            set
            {
                checkSwing = value;
                if (value)
                {
                    CheckDaily = false;
                    CheckLong = false;
                    ListeAfficher = Todo.GetTodosSwing();
                    RaisePropertyChanged("ListeAfficher");
                }
            }
        }
        public bool CheckLong
        {
            get => checkLong;
            set
            {
                checkLong = value;
                if (value)
                {
                    CheckDaily = false;
                    CheckSwing = false;
                    ListeAfficher = Todo.GetTodosLong();
                    RaisePropertyChanged("ListeAfficher");
                }
            }
        }
        
        private Todo todo;
        private int count;
        public MainWindowViewModel()
        {
            count = 0;
            CheckDaily = true;
            ListeAfficher = Todo.GetTodosDaily();

            ManageCommand = new RelayCommand(() =>
            {
                AddTodoWindow w = new AddTodoWindow();
                w.Show();
            });
            NotClickCommand = new RelayCommand(() =>
            {
                count++;
                if(count == 1)
                {
                    MessageBox.Show("1er avertissement ! Y'a quoi que tu ne comprends pas dans DO NOT CLICK ?");                   
                }
                if (count == 2)
                {
                    MessageBox.Show("2eme avertissement ! Do not click... C'est DO NOT CLICK !");
                }
                if (count == 3)
                {
                    MessageBox.Show("Bon, très bien ! Monsieur me prend de haut !");
                    foreach (Window w in Application.Current.Windows)
                    {
                        w.Close();
                    }
                }
            });
            EncourageCommand = new RelayCommand(() =>
            {
                Random rnd = new Random();
                int encourage = rnd.Next(1, 13);
                Encouragement(encourage);
            });
            AboutCommand = new RelayCommand(() =>
            {
                AboutWindow a = new AboutWindow();
                a.Show();
            });
            CloseCommand = new RelayCommand(() =>
            {
                foreach (Window w in Application.Current.Windows)
                {
                    w.Close();
                }
            });
            Messenger.Default.Register<Todo>(this, t =>
            {
                Todo newtodo = new Todo();
                foreach (Todo todoTmp in ListeAfficher)
                {
                    if(todoTmp.Id == t.Id)
                    {
                        newtodo = todoTmp;
                    }
                }
                
                if (todo == null)
                {
                    ListeAfficher.Add(t);
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
        private void Encouragement(int encourage)
        {
            if(encourage==1)
            {
                MessageBox.Show("Allez Nicolas, courrage! Tu vas y arriver :) !");
            }
            if (encourage == 2)
            {
                MessageBox.Show("Tu vas y parvenir, c'est certain! Courrage !");
            }
            if (encourage == 3)
            {
                MessageBox.Show("Force & Robustesse, comme dit une personne très célèbre !");
            }
            if (encourage == 4)
            {
                MessageBox.Show("Respires à fond... et vas y à fond !");
            }
            if (encourage == 5)
            {
                MessageBox.Show("Allé Nico ! ... Allé Nico ... ! Allé Nico !");
            }
            if (encourage == 6)
            {
                MessageBox.Show("Labourrage et pâturage sont les deux mamelles de la France...( tu t'es pas trompé là?");
            }
            if (encourage == 7)
            {
                MessageBox.Show("Je veux un N ! Je veux un I ! Je veux un C ! je veux un O! ALLEZ NICO ! ! !");
            }
            if (encourage == 8)
            {
                MessageBox.Show("Mini Hola pour... TOI ! ALLEZ Nico !");
            }
            if (encourage == 9)
            {
                MessageBox.Show("Allez vas-y tu vas assurer GRAVE ! :) ");
            }
            if (encourage == 10)
            {
                MessageBox.Show("Nicolas? C'est le BHL des marchés financiers !");
            }
            if (encourage == 11)
            {
                MessageBox.Show("Nico! Pouloupoupou! Nico! Pouloupoupou!");
            }
            if (encourage == 12)
            {
                MessageBox.Show("AAAAAAALLLLLLLEEEEEEEEEZZZZZZZZ NICO! :)");
            }

        }
    }
}
