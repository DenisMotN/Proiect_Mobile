using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Proiect_Mobile.Models;



namespace Proiect_Mobile.Data
{
    public class GameListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public GameListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<GameList>().Wait();
            _database.CreateTableAsync<Game>().Wait();
            _database.CreateTableAsync<ListGame>().Wait();
        }
        public Task<List<GameList>> GetGameListsAsync()
        {
            return _database.Table<GameList>().ToListAsync();
        }
        public Task<GameList> GetGameListAsync(int id)
        {
            return _database.Table<GameList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveGameListAsync(GameList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteGameListAsync(GameList slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveGameAsync(Game game)
        {
            if (game.ID != 0)
            {
                return _database.UpdateAsync(game);
            }
            else
            {
                return _database.InsertAsync(game);
            }
        }
        public Task<int> DeleteGameAsync(Game game)
        {
            return _database.DeleteAsync(game);
        }
        public Task<List<Game>> GetGamesAsync()
        {
            return _database.Table<Game>().ToListAsync();
        }
        public Task<int> SaveListGameAsync(ListGame listg)
        {
            if (listg.ID != 0)
            {
                return _database.UpdateAsync(listg);
            }
            else
            {
                return _database.InsertAsync(listg);
            }
        }
        public Task<List<Game>> GetListProductsAsync(int gamelistid)
        {
            return _database.QueryAsync<Game>(
            "select G.ID, G.Description from Game G"
            + " inner join ListGame LG"
            + " on G.ID = LG.GameID where LG.GameListID = ?",
            gamelistid);
        }
    }
}
