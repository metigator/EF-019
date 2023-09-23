using C01.Interceptors.Data;
using C01.Interceptors.Helpers;

namespace C01.Interceptors
{
    class Program
    {
        public static void Main(string[] args)
        {
            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();

            Console.WriteLine();
            Console.WriteLine("Before Delete");

            DatabaseHelper.ShowBooks();

            using (var context = new AppDbContext())
            {
                var book = context.Books.First();
                context.Books.Remove(book);
                context.SaveChanges();
            }
            Console.WriteLine();
            Console.WriteLine("After Delete Book Id = '1'");

            DatabaseHelper.ShowBooks();

            Console.ReadKey();
        }
    }
}