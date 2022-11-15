using EjercicioA2_2.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EjercicioA2._2
{
    public partial class App : Application
    {

        static bd db;


        public static bd DBase
        {
            get
            {
                if (db == null)
                {
                    String folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "signature.db3");

                    db = new bd(folderPath);
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

