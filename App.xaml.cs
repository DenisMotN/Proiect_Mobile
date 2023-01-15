using Proiect_Mobile.Data;
using System.IO;
using System;

namespace Proiect_Mobile;

public partial class App : Application
{
    static GameListDatabase database;
    public static GameListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               GameListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "GameList.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
