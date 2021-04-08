using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinNewsReader.Data;
using XamarinNewsReader.Helpers;

namespace XamarinNewsReader.Models
{
    public class FavoritesCollection : ObservableCollection<FavoriteInformation>
    {
        public async Task<int> AddAsync(FavoriteInformation article)
        {
            int id = 0;

            await FavoritesHelper.EnsureCategoriesAsync();

            var category = await App.Database.GetCategoryAsync(article.CategoryTitle);

            if (category != null)
            {
                id = await App.Database.SaveItemAsync(new Favorite()
                {
                    ArticleDate = article.ArticleDate,
                    Category = category,
                    CategoryId = category.Id,
                    Description = article.Description,
                    ImageUrl = article.ImageUrl,
                    Title = article.Title,
                });
            }

            article.Id = id;
            this.Add(article);

            return id;

        }
        public async Task<int> RemoveAsync(int id)
        {
            var favorite = await App.Database.GetItemAsync(id);

            id = await App.Database.DeleteItemAsync(favorite);

            return id;
        }

    }


    public class FavoriteInformation : Common.ObservableBase
    {
        private int _id;
        public int Id
        {
            get { return this._id; }
            set { this.SetProperty(ref this._id, value); }
        }

        private string _title;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private string _categoryTitle;
        public string CategoryTitle
        {
            get { return this._categoryTitle; }
            set { this.SetProperty(ref this._categoryTitle, value); }
        }

        private string _description;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return this._imageUrl; }
            set { this.SetProperty(ref this._imageUrl, value); }
        }

        private DateTime _articleDate;
        public DateTime ArticleDate
        {
            get { return this._articleDate; }
            set { this.SetProperty(ref this._articleDate, value); }
        }


    }
}
