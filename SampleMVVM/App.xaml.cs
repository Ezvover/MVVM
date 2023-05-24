using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using SampleMVVM.Models;
using SampleMVVM.ViewModels;
using SampleMVVM.Views;

namespace SampleMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            string connectionString = @"Data Source=.;Initial Catalog=Courses;Integrated Security=True";
            string query = "SELECT id, name, hours, author, amount FROM Course";
            List<Course> books = new List<Course>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Course course = new Course();
                            course.Id = Convert.ToInt32(reader["id"]);
                            course.Name = reader["name"].ToString();
                            course.Hours = Convert.ToInt32(reader["hours"]);
                            course.Author = reader["author"].ToString();
                            course.Amount = Convert.ToInt32(reader["amount"]);

                            books.Add(course);
                        }
                    }
                }
            }

            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new ViewModels.MainViewModel(books); // Создали ViewModel
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }
    }
}
