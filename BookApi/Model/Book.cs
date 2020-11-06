using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Model
{
    public class Book
    {
        public string Number { get; set; }
        public string Destribtion { get; set; }


    }

    public class BookDataRepository
    {
        public static List<Book> GetAll()
        {
            return new List<Book>()
            {
                new Book() { Number = "101", Destribtion = "Destribtion1111111" },
                new Book() { Number = "102", Destribtion = "Destribtion2222222" },
                new Book() { Number = "103", Destribtion = "Destribtion3333333" }
            };
        }

        public static Book GetBookingByNumber(string number)
        {
            return GetAll().FirstOrDefault(x => x.Number == number);
        }
    }
}
