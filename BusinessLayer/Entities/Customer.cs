using System.Collections.Generic;
using System.Drawing;

namespace BusinessLayer.Entities
{
    public class Customer : EntityBase
    {
        private static int InstanceCount;

        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private List<Category> _categories;
        private List<Wallet> _wallets;
        private List<Wallet> _accessibleWallets;

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                HasChanges = true;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                HasChanges = true;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                HasChanges = true;
            }
        }
        public List<Category> Categories
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
                HasChanges = true;
            }
        }
        public List<Wallet> Wallets
        {
            get
            {
                return _wallets;
            }
            set
            {
                _wallets = value;
                HasChanges = true;
            }
        }
        public List<Wallet> AccessibleWallets
        {
            get
            {
                return _accessibleWallets;
            }
            private set
            {
                _accessibleWallets = value;
            }
        }

        public Customer()
        {
            IsNew = true;
            InstanceCount += 1;
            _id = InstanceCount;
            _categories = new List<Category>();
            _wallets = new List<Wallet>();
            _accessibleWallets = new List<Wallet>();
        }

        public Customer(string firstName, string lastName, string email) : this()
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
        }

        public void AddWallet(string name, decimal balance, Currency currency, string description)
        {
            Wallet wallet = new Wallet(this, name, balance, currency, description);
        }

        public void RemoveWallet(Wallet wallet)
        {
            _ = _wallets.Remove(wallet);
        }

        public void GrantAccessToWallet(Customer customer, Wallet wallet)
        {
            if (!customer.AccessibleWallets.Contains(wallet))
                customer.AccessibleWallets.Add(wallet);
        }

        public void DenyAccessToWallet(Customer customer, Wallet wallet)
        {
            _ = customer.AccessibleWallets.Remove(wallet);
        }

        //public Category(string name, string description, Color color, string image)
        public void AddCategory(string name, string description, Color color, string image)
        {
            Category category = new Category(name, description, color, image);
        }
        public void AddCategory(string name, string description)
        {
            Category category = new Category(name, description);
        }

        public void RemoveCategory(Category category)
        {
            _ = _categories.Remove(category);
        }

        public override string ToString()
        {
            string wallets = "";
            foreach (Wallet w in Wallets)
            {
                wallets += "    " + w.ToString();
                wallets += "\n";
            }
            string result = $"{Id}: {LastName}, {FirstName}\n{Email}\n{wallets}\n{Categories}";
            return result;
        }

        public string FullName()
        {
            string result = $"{LastName}, {FirstName}";
            return result;
        }

        public override bool Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
