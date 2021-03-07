using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Wallet : Money
    {
        private static int InstanceCount;

        private int _id;
        private Customer _owner;
        private string _name;

        private string _description;
        private List<Transaction> _transactions;
        private List<Category> _excludedCategories;

        //public decimal? Amount { get; private set; }
        //public Currency Currency { get; private set; }

        // private set
        public int Id
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }

        // private set
        public Customer Owner
        {
            get
            {
                return _owner;
            }
            private set
            {
                _owner = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
                HasChanges = true;
            }
        }


        public string Description
        {
            get
            {
                return _description;
            }
            private set
            {
                _description = value;
                HasChanges = true;
            }
        }
        public List<Category> ExcludedCategories
        {
            get
            {
                return _excludedCategories;
            }
        }


        public Wallet(Customer owner, string name, decimal balance, Currency currency, string description)
        {
            IsNew = true;
            InstanceCount += 1;
            _id = InstanceCount;

            _transactions = new List<Transaction>();
            _excludedCategories = new List<Category>();
            _owner = owner;
            _name = name;
            Amount = balance;
            Currency = currency;
            _description = description;

            owner.Wallets.Add(this);
        }

        public void ExcludeCategory(Customer customer, Category category)
        {
            if (customer.Equals(this.Owner))
                _excludedCategories.Add(category);
        }

        public void AllowCategory(Customer customer, Category category)
        {
            if (customer.Equals(this.Owner))
                _excludedCategories.Remove(category);
        }

        public void EditWalletName(Customer customer, string name)
        {
            if (customer.Equals(this.Owner))
                this.Name = name;
        }
        public void EditWalletOwner(Customer customer, Customer target)
        {
            if (customer.Equals(this.Owner))
            {
                this.Owner = target;
                target.AccessibleWallets.Remove(this);
            }
        }
        public void EditWalletDescription(Customer customer, string description)
        {
            if (customer.Equals(this.Owner))
                this.Description = description;
        }

        public Transaction AddTransaction(Customer sender, Wallet senderWallet, decimal amount, Currency currency, Category category, string description)
        {
            Transaction transaction = null;
            if (Owner.Equals(sender))
            {
                transaction = DoTransaction(sender, senderWallet, amount, currency, category, description);
            }
            else
            {
                if (sender.AccessibleWallets.Contains(this))
                {
                    transaction = DoTransaction(sender, senderWallet, amount, currency, category, description);
                }
            }

            return transaction;
        }

        private Transaction DoTransaction(Customer sender, Wallet senderWallet, decimal amount, Currency currency, Category category, string description)
        {
            Transaction t = new(amount, currency, category, description);
            this._transactions.Add(t);
            Transaction convertedTransaction = new(amount, currency, category, description);
            convertedTransaction.ConvertTo(this.Currency);

            this.Amount += convertedTransaction.Amount;
            senderWallet.Amount -= convertedTransaction.Amount;
            return t;
        }

        public override bool Validate()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Name}, {Owner.FullName()}, {Amount}{Currency}, {Description}";
        }
    }
}
