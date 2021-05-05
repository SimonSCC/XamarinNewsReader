using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinNewsReader.Models;


namespace XamarinNewsReader.Data
{
    public class FavoritesDatabase
    {
        //The database we are going to be working with
        readonly SQLiteAsyncConnection database;

        //Creates a new connection using the path given as parameter (Platform specific storage location)
        public FavoritesDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            //Below is going to drop database if they exist, but wont fail if they dont exist.

            //database.DropTableAsync<Favorite>().Wait();
            database.DropTableAsync<NewsCategory>().Wait();

            //Below is going to create the tables but not overwrite them if they already exist

            database.CreateTableAsync<NewsCategory>().Wait();
            database.CreateTableAsync<Favorite>().Wait();

            database.CreateTableAsync<Filter>().Wait();
        }
        //Filter Handler:
        public Task<List<Filter>> GetAllFilters()
        {
            return database.Table<Filter>().ToListAsync();
        }
        public Task<Filter> GetFilterAsync(int id)
        {            
            return database.Table<Filter>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveFilterAsync(Filter item)
        {
            if (item.Id != 0) //PrimaryKey is generated in the database
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> DeleteFilterAsync(Filter item)
        {
            return database.DeleteAsync(item); //return rows of deleted items
        }








        public Task<List<NewsCategory>> GetCategoriesAsync()
        {
            return database.Table<NewsCategory>().ToListAsync();
        }

        public Task<List<Favorite>> GetItemsAsync()
        {
            return database.Table<Favorite>().ToListAsync();
        }

        public async Task<List<Favorite>> GetItemsAsync(List<NewsCategory> categories)
        {
            var favorites = await database.Table<Favorite>().ToListAsync();

            foreach (var favorite in favorites)
            {
                favorite.Category = categories.Where(w => w.Id == favorite.CategoryId).FirstOrDefault();
            }

            return favorites;
        }

        public Task<List<Favorite>> GetItemsByCategoryAsync(List<NewsCategory> categories)
        {
            if (categories != null && categories.Count > 0)
            {
                return database.QueryAsync<Favorite>($"SELECT * FROM [Favorite] WHERE [CategoryId] = {categories.FirstOrDefault().Id}");
            }
            else
            {
                return null;
            }

        }

        public Task<Favorite> GetItemAsync(int id)
        {
            return database.Table<Favorite>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<NewsCategory> GetCategoryAsync(string title)
        {
            return database.Table<NewsCategory>().Where(i => i.Title.Equals(title)).FirstOrDefaultAsync();
        }

        public Task<int> SaveCategoriesAsync(List<NewsCategory> categories)
        {
            return database.InsertAllAsync(categories);
        }

        public Task<int> SaveCategoryAsync(NewsCategory category)
        {
            if (category.Id != 0)
            {
                return database.UpdateAsync(category);
            }
            else
            {
                return database.InsertAsync(category);
            }
        }

        public Task<int> SaveItemAsync(Favorite item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Favorite item)
        {
            return database.DeleteAsync(item);
        }
    }
}

