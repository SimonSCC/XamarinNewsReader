using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinNewsReader.Models
{
    public class UserInformation : Common.ObservableBase
    {
        private string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
            set { this.SetProperty(ref this._displayName, value); }
        }

        private string _bioContent;

        public string BioContent
        {
            get { return _bioContent; }
            set { this.SetProperty(ref this._bioContent, value); }
        }

        private string _profileImageUrl;

        public string ProfileImageUrl
        {
            get { return _profileImageUrl; }
            set { this.SetProperty(ref this._profileImageUrl, value); }
        }
    }
}
