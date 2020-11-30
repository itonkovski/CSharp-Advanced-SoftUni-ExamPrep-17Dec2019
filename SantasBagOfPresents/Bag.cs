using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Christmas
{
    public class Bag
    {
        List<Present> data;

        public Bag()
        {
            this.data = new List<Present>();
        }

        public Bag(string color, int capacity)
            :this()
        {
            this.Color = color;
            this.Capacity = capacity;
        }

        public string Color { get; set; }
        public int Capacity{ get; set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Present present)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(present);
            } 
        }

        public bool Remove(string name)
        {
            Present present = this.data
                .FirstOrDefault(p => p.Name == name);

            if (present != null)
            {
                this.data.Remove(present);
                return true;
            }
            return false;
        }

        public Present GetHeaviestPresent()
        {
            Present heaviestPresent = this.data
                .OrderByDescending(p => p.Weight)
                .FirstOrDefault();
            return heaviestPresent;
        }

        public Present GetPresent(string name)
        {
            Present present = this.data
                .FirstOrDefault(p => p.Name == name);

            return present;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.Color} bag contains:");

            foreach (var present in this.data)
            {
                sb
                    .AppendLine($"{present}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
