using System;

namespace C_Sharp_Unit_Test
{
    public class Footballplayer
    {
        private int _id;
        private string _name;
        private int _price;
        private int _shirtnum;

        public Footballplayer()
        {

        }
        public int ID
        {
            get => _id;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _id = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 4) throw new ArgumentOutOfRangeException();
                _name = value;
            }
        }
        public int Price
        {
            get => _price;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException();
                _price = value;
            }
        }
        public int ShirtNum
        {
            get => _shirtnum;
            set
            {
                if (value < 1 || value > 100) throw new ArgumentOutOfRangeException();
                _shirtnum = value;
            }
        }
        //public override string ToString()
        //{
        //    return $"ID: {ID}, Name: {Name}, Price: {Price}, ShirtNumber: {ShirtNum}";
        //}
    }
}
