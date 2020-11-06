using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassengerApi.Model
{
    public class Passenger
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class PassengerDataRepository
    {
        public static List<Passenger> GetAll()
        {
            return new List<Passenger>()
            {
                new Passenger() { Id = 101, Name = "test", Address="test address", PhoneNumber = "1234567891" },
                new Passenger() { Id = 102, Name = "test2", Address="test address2", PhoneNumber = "1234567892" },
                new Passenger() { Id = 103, Name = "test3", Address="test address3", PhoneNumber = "1234567893" }
            };
        }

        public static Passenger GetPassengerById(int passengerId)
        {
            return GetAll().FirstOrDefault(x => x.Id == passengerId);
        }
    }
}
