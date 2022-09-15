using Backend.Services.EF;
using BackEnd.DDD.Models;

namespace Fronend.WinForms.Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(new CustomerService(new BackEnd.DDD.AccessDbContext()), new Customers()));
        }
    }
}