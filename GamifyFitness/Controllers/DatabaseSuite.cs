using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GamifyFitness.Controllers
{
    public class DatabaseSuite
    {
        private SQLiteConnection connection;
        private String TableName = "UserDetails";

        public void CreateDatabase()
        {
            //SQLiteConnection.CreateFile("Database.sqlite");
        }

        public void OpenConnection()
        {
            connection = new SQLiteConnection("Data Source=Database.sqlite;Version=3;");
            connection.Open();

        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void CreateTable()
        {
            string query = "CREATE TABLE "+TableName+ " (userId VARCHAR(20), name VARCHAR(20), age INT, lifetimeCalories INT, currStoredCalories INT, friends VARCHAR(300))";
            SQLiteCommand command = new SQLiteCommand(query,connection);
            command.ExecuteNonQuery();
        }

        public void AddUser(String User, String Name,int age, int lifetimeCalories, int currCalories, List<String> friends)
        {
            string query = "INSERT INTO " + TableName + " (userId , name, age, lifetimeCalories, currStoredCalories, friends) VALUES ('"+User+"', '"+Name+"', "+age+", "+lifetimeCalories+", "+currCalories+", '"+CreateFriendString(friends)+"')";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void UpdateUserCalories(String UserId,int lifeCals, int currCals)
        {
            string query = "UPDATE " + TableName + " SET lifetimeCalories = " + lifeCals+ ",currStoredCalories = "+currCals+" where userId = '"+UserId+ "'";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void UpdateUserFriends(String UserId, List<String> friends)
        {
            string query = "UPDATE " + TableName + " SET friends = '" + CreateFriendString(friends)  + "' where userId = '" + UserId+"'";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void ReadTable()
        {
            string query = "select * from " + TableName + " order by age desc";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("UserId: "+reader["userId"]+"\tName: " + reader["name"] + "\tAge: " + reader["age"] + "\tLifetime calories: " + reader["lifetimeCalories"] + "\tCurrent calories: " + reader["currStoredCalories"] + "\tFriends: " + reader["friends"]);
        }

        //You need to use reader.Read() to pull out info from the reader. See above for example
        public SQLiteDataReader GetUserData(String userId)
        {
            string query = "select * from " + TableName + " Where userId = '" + userId + "' order by age desc";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

        public String CreateFriendString(List<String> friendsList)
        {
            String friendString = "";
            foreach(String friend in friendsList)
            {
                friendString += friend;
                friendString += ",";
            }
            friendString.Remove(friendString.Length-1);
            return friendString;
        }
    }
}
