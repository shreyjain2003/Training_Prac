using System.Collections.Generic;


namespace LibraryManagementSystem
{
    public interface ILibrarySystem
    {
         void AddBook(IBook book,int quantity);
         void RemoveBook(IBook book,int quantity);
         int CalculateTotal();
         List<(string,int)> CategoryTotalPrice();
         List<(string,int,int)> BooksInfo();
         List<(string,string,int)> CategoryAndAuthorWithCount();        
    }
}