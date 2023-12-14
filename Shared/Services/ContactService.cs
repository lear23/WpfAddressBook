
using System.Text.Json;
using Shared.Models;

namespace Shared.Services
{
    public class ContactService
    {
        private List<Customer> _customers = new List<Customer>();
        private readonly string _jsonFilePath;

        public ContactService(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
            LoadDataFromJson();
        }

        public bool Add(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }

            _customers.Add(customer);
            SaveDataToJson();
            return true;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public Customer GetOne(Func<Customer, bool> predicate)
        {
            return _customers.FirstOrDefault(predicate);
        }

        public Customer Update(Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault();
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.Address = customer.Address;
                SaveDataToJson();
                return existingCustomer;
            }
            return null;
        }

        public bool Remove(Customer customer)
        {
            if (!_customers.Contains(customer))
            {
                return false;
            }

            _customers.Remove(customer);
            SaveDataToJson();
            return true;
        }

        public bool Exists(Func<Customer, bool> predicate)
        {
            return _customers.Any(predicate);
        }

        private void LoadDataFromJson()
        {
            if (File.Exists(_jsonFilePath))
            {
                string json = File.ReadAllText(_jsonFilePath);
                _customers = JsonSerializer.Deserialize<List<Customer>>(json) ?? new List<Customer>();
            }
        }

        private void SaveDataToJson()
        {
            string json = JsonSerializer.Serialize(_customers);
            File.WriteAllText(_jsonFilePath, json);
        }
    }
}


























//using Shared.Models;

//namespace Shared.Services;

//public class ContactService
//{
//    private List<Customer> _customer = new List<Customer>();

//    public bool Add(Customer customer)
//    {
//        if(customer == null)
//        {
//            return false;
//        }

//        _customer.Add(customer);
//        return true;
//    }


//    public IEnumerable<Customer> GetAll()
//    {
//        return _customer;
//    }

//    public Customer GetOne(Func<Customer, bool> predicate)
//    {
//        var customer = _customer.FirstOrDefault();
//        return customer ?? null !;
//    }

//    public Customer UpDate(Customer customer)
//    {
//        var existingCustomer = _customer.FirstOrDefault();
//        if (existingCustomer != null)
//        {

//            existingCustomer.FirstName = customer.FirstName;
//            existingCustomer.LastName = customer.LastName;
//            existingCustomer.Email = customer.Email;
//            existingCustomer.Phone = customer.Phone;
//            existingCustomer.Address = customer.Address;
//            return existingCustomer;
//        }
//        return null!;
//    }


//    public bool Remove(Customer customer)
//    {
//        if (!_customer.Contains(customer))
//        {
//            return false;
//        }
//        _customer.Remove(customer);
//        return true;
//    }


//    public bool Exists(Func<Customer, bool> predicate)
//    {
//        return _customer.Any(predicate);
//    }




//}
