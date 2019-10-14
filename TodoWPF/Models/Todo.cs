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
        private string titre;
        private string description;
        private string details;
        private string important;

        public int Id { get => id; set => id = value; }
        public string Echeance { get => echeance; set => echeance = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Description { get => description; set => description = value; }
        public string Details { get => details; set => details = value; }
        public string Important { get => important; set => important = value; }

        public bool Add()
        {
            bool res = false;
            DataBase.Instance.command = new SqlCommand("INSERT INTO todo_wpf (echeance, titre, description, details, important) OUTPUT INSERTED.ID values (@echeance, @titre, @description, @details, @important)", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@echeance", Echeance));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@titre", Titre));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@description", Description));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@details", Details));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@important", Important));
            DataBase.Instance.connection.Open();
            Id = (int)DataBase.Instance.command.ExecuteScalar();
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
            DataBase.Instance.command = new SqlCommand("UPDATE todo_wpf set " +
                "echeance=@echeance, titre = @titre, description = @description, details = @details, important = @important " +
                "WHERE id = @id", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@echeance", Echeance));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@titre", Titre));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@description", Description));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@details", Details));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@important", Important));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@id", Id));
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
            DataBase.Instance.command = new SqlCommand("DELETE FROM todo_wpf where id = @id", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@id", Id));
            DataBase.Instance.connection.Open();
            if (DataBase.Instance.command.ExecuteNonQuery() > 0)
            {
                res = true;
            }
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();
            return res;
        }
        public static ObservableCollection<Todo> GetTodos()
        {
            ObservableCollection<Todo> liste = new ObservableCollection<Todo>();
            DataBase.Instance.command = new SqlCommand("SELECT id, echeance, titre, description, details, important from todo_wpf", DataBase.Instance.connection);

            DataBase.Instance.connection.Open();
            DataBase.Instance.reader = DataBase.Instance.command.ExecuteReader();
            while (DataBase.Instance.reader.Read())
            {
                Todo t = new Todo();
                t.Id = DataBase.Instance.reader.GetInt32(0);
                t.Echeance = DataBase.Instance.reader.GetString(1);
                t.Titre = DataBase.Instance.reader.GetString(2);
                t.Description = DataBase.Instance.reader.GetString(3);
                t.Details = DataBase.Instance.reader.GetString(4);
                t.Important = DataBase.Instance.reader.GetString(5);
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
    public enum Echeance
    {
        Daily,
        Swing,
        Long
    }
}
