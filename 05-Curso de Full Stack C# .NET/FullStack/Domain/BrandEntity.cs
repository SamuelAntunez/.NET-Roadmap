using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BrandEntity
    {
        private string _name;
        public int? Id { get; private set; }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace.", nameof(value));
                }
                _name = value;
            }
        }

        public BrandEntity()
        {

        }
        public BrandEntity(string name)
        {
            Name = name;
        }

        public BrandEntity(int id, string name)
        {
            if (id<= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }

            Id = id;
            Name = name;
        }
    }
}
