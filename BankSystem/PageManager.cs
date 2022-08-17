using System.Windows.Controls;
using Utils.Utils;

namespace BankSystem
{
    public class PageManager: Singleton<PageManager>
    {
        /// <summary>
        /// Frame instance
        /// </summary>
        public Frame Frame;

        protected override void Init() {}

        /// <summary>
        /// Go to a page
        /// </summary>
        /// <param name="dataContext">Context type to set to a page</param>
        /// <typeparam name="T">Page type to create</typeparam>
        public void Load<T>(PageDataContext dataContext)
            where T: Page, new()
        {
            Page page = new T
            {
                DataContext = dataContext
            };
            
            Frame.NavigationService.Navigate(page);
        }
    }
}