using System.Collections.Generic;
using System.Threading.Tasks;
using CatanChallenge.Model;
using SQLite;

namespace CatanChallenge.Data
{
    public class PlayerDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public PlayerDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Player>().Wait();
        }

        public Task<List<Player>> GetPlayersAsync()
        {
            //Get all players.
            return _database.Table<Player>().ToListAsync();
        }

        public Task<Player> GetPlayerAsync(int id)
        {
            // Get a specific player.
            return _database.Table<Player>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePlayerAsync(Player player)
        {
            if (player.Id != 0)
            {
                // Update an existing player.
                return _database.UpdateAsync(player);
            }
            else
            {
                // Save a new player.
                return _database.InsertAsync(player);
            }
        }

        public Task<int> DeleteNoteAsync(Player player)
        {
            // Delete a player.
            return _database.DeleteAsync(player);
        }
    }
}