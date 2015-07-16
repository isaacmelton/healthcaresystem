using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.model
{
    /// <summary>
    /// Global variable storage.
    /// </summary>
    public sealed class GlobalVars : INotifyPropertyChanged
    {
        private static readonly GlobalVars instance = new GlobalVars();
        private static User currentUser;

        /// <summary>
        /// Private instantiator for singleton.
        /// </summary>
        private GlobalVars()
        {
            CurrentUser = new User();
        }

        /// <summary>
        /// Gets the single instance of the object.
        /// </summary>
        public static GlobalVars Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Sets and gets the current user.
        /// </summary>
        public User CurrentUser
        {
            get { return currentUser; }
            set 
            { 
                currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(Instance, new PropertyChangedEventArgs(name));
        }
    }
}