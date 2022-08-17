using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BankSystem
{
    /// <summary>
    /// Base class for page data contexts
    /// </summary>
    public abstract class PageDataContext: INotifyPropertyChanged
    {
        /// <summary>
        /// Link to a bank system
        /// </summary>
        public BankSystemCore BankSystem => BankSystemCore.I;
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}