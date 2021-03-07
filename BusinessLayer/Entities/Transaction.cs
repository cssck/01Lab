using System;
using System.IO;

namespace BusinessLayer.Entities
{
    public class Transaction : Money
    {
        private static int InstanceCount;

        private int _id;
        public decimal? Amount
        {
            get; private set;
        }
        public Currency Currency 
        {
            get; private set;
        }

        private Category _category;
        private string _description;
        private DateTime? _date;
        private string _file;

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
        public Category Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                HasChanges = true;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                HasChanges = true;
            }
        }
        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                HasChanges = true;
            }
        }
        public string File
        {
            get
            {
                return _file;
            }
            set
            {
                _file = value;
                HasChanges = true;
            }
        }


        public Transaction(decimal amount, Currency currency, Category category, string description)
        {
            IsNew = true;
            InstanceCount += 1;
            _id = InstanceCount;

            Amount = amount;
            Currency = currency;
            Category = category;
            Description = description;
            Date = DateTime.Now;
        }
        public Transaction(decimal amount, Currency currency, Category category, string description, DateTime date) : this(amount, currency, category, description)
        {
            Date = date;
        }
        public Transaction(decimal amount, Currency currency, Category category, string description, DateTime date, string file) : this(amount, currency, category, description, date)
        {
            File = file;
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
