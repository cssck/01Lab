using System.Drawing;

namespace BusinessLayer.Entities
{
    public class Category : EntityBase
    {
        private static int InstanceCount;

        private int _id;
        private string _name;
        private string _description;
        private Color _color;
        private string _image;

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
        public string Name
        {
            get
            {
                return _name;
            }
            set
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
            set
            {
                _description = value;
                HasChanges = true;
            }
        }
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                HasChanges = true;
            }
        }
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                HasChanges = true;
            }
        }

        public Category()
        {
            IsNew = true;
            InstanceCount += 1;
            _id = InstanceCount;
        }
        public Category(string name, string description) : this()
        {
            _name = name;
            _description = description;
        }

        public Category(string name, string description, Color color, string image) : this()
        {
            _name = name;
            _description = description;
            _color = color;
            _image = image;
        }

        public override bool Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
