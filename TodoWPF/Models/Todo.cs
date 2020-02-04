using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWPF.Tools;

namespace TodoWPF.Models
{
    public class Todo
    {
        private int id;
        private string echeance;
        private DateTime dateCreation;
        private string titre;
        private string description;
        private string details;
        private string important;

        public int Id { get => id; set => id = value; }
        public string Echeance { get => echeance; set => echeance = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Description { get => description; set => description = value; }
        public string Details { get => details; set => details = value; }
        public string Important { get => important; set => important = value; }


        public bool Add()
        {
            bool res = false;
            DataBase.Instance.command = new MySqlCommand("INSERT INTO todo_wpf (echeance, date_creation, titre, description, details, important) values (@echeance, @dateCreation, @titre, @description, @details, @important)", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@echeance", Echeance));
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@dateCreation", DateCreation));
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@titre", Titre));
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@description", Description));
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@details", Details));
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@important", Important));
            DataBase.Instance.connection.Open();
            Id = (int)DataBase.Instance.command.ExecuteNonQuery();
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();
            if (Id > 0)
            {
                res = true;
            }
            return res;
        }

        public bool Update()
        {
            bool res = false;
            DataBase.Instance.command = new MySqlCommand("UPDATE todo_wpf set " +
                "echeance=@echeance,date_creation=@dateCreation, titre = @titre, description = @description, details = @details, important = @important " +
                "WHERE id = @id", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@echeance", Echeance));
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@dateCreation", DateCreation));
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@titre", Titre));
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@description", Description));
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@details", Details));
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@important", Important));
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@id", Id));
            DataBase.Instance.connection.Open();
            if (DataBase.Instance.command.ExecuteNonQuery() > 0)
            {
                res = true;
            }
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();
            return res;
        }

        public bool Delete()
        {
            bool res = false;
            DataBase.Instance.command = new MySqlCommand("DELETE FROM todo_wpf where id = @id", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@id", Id));
            DataBase.Instance.connection.Open();
            if (DataBase.Instance.command.ExecuteNonQuery() > 0)
            {
                res = true;
            }
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();
            return res;
        }
        public static Todo GetTodo(string Titre)
        {
            Todo t = new Todo();
            DataBase.Instance.command = new MySqlCommand("SELECT id, echeance, date_creation, titre, description, details, important from todo_wpf WHERE titre=@titre", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new MySqlParameter("@titre", Titre));
            DataBase.Instance.connection.Open();
            DataBase.Instance.reader = DataBase.Instance.command.ExecuteReader();
            while (DataBase.Instance.reader.Read())
            {
                t.Id = DataBase.Instance.reader.GetInt32(0);
                t.Echeance = DataBase.Instance.reader.GetString(1);
                t.DateCreation = DataBase.Instance.reader.GetDateTime(2);
                t.Titre = DataBase.Instance.reader.GetString(3);
                t.Description = DataBase.Instance.reader.GetString(4);
                t.Details = DataBase.Instance.reader.GetString(5);
                t.Important = DataBase.Instance.reader.GetString(6);
            }
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();
            return t;
        }
        public static ObservableCollection<Todo> GetTodos()
        {
            ObservableCollection<Todo> liste = new ObservableCollection<Todo>();
            DataBase.Instance.command = new MySqlCommand("SELECT id, echeance, date_creation, titre, description, details, important from todo_wpf", DataBase.Instance.connection);

            DataBase.Instance.connection.Open();
            DataBase.Instance.reader = DataBase.Instance.command.ExecuteReader();
            while (DataBase.Instance.reader.Read())
            {
                Todo t = new Todo();
                t.Id = DataBase.Instance.reader.GetInt32(0);
                t.Echeance = DataBase.Instance.reader.GetString(1);
                t.DateCreation = DataBase.Instance.reader.GetDateTime(2);
                t.Titre = DataBase.Instance.reader.GetString(3);
                t.Description = DataBase.Instance.reader.GetString(4);
                t.Details = DataBase.Instance.reader.GetString(5);
                t.Important = DataBase.Instance.reader.GetString(6);
                liste.Add(t);
            }
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();

            return liste;
        }
        public static ObservableCollection<Todo> GetTodosDaily()
        {
            ObservableCollection<Todo> liste = GetTodos();
            ObservableCollection<Todo> TodosDaily = new ObservableCollection<Todo>();
            foreach (Todo t in liste)
            {
                if (t.Echeance == "Daily")
                {
                    TodosDaily.Add(t);
                }
            }
            return TodosDaily;
        }
        public static ObservableCollection<Todo> GetTodosSwing()
        {
            ObservableCollection<Todo> liste = GetTodos();
            ObservableCollection<Todo> TodosSwing = new ObservableCollection<Todo>();
            foreach (Todo t in liste)
            {
                if (t.Echeance == "Swing")
                {
                    TodosSwing.Add(t);
                }
            }
            return TodosSwing;
        }
        public static ObservableCollection<Todo> GetTodosLong()
        {
            ObservableCollection<Todo> liste = GetTodos();
            ObservableCollection<Todo> TodosLong = new ObservableCollection<Todo>();
            foreach (Todo t in liste)
            {
                if (t.Echeance == "Long")
                {
                    TodosLong.Add(t);
                }
            }
            return TodosLong;
        }
    }
}
