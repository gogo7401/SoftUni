using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        private readonly List<Shoe> Shoes;

        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }

        //public List<Shoe> Shoes { get; set; }

        public int Count => Shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (StorageCapacity == Shoes.Count)
            {
                return "No more space in the storage room.";
            }
            Shoes.Add(shoe);    
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int count = 0;

            while (Shoes.Any(x => x.Material == material))
            {
                count++;
                Shoes.Remove(Shoes.First(x => x.Material == material));
            }

            return count;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            return Shoes.FindAll(x => x.Type.ToLower() == type.ToLower());
        }

        public Shoe GetShoeBySize(double size)
        {
            return Shoes.FirstOrDefault(x => x.Size == size);
        }

        public string StockList(double size, string type)
        {
            var list = Shoes.FindAll(x => x.Type == type && x.Size == size);
            
            if (list.Count == 0)
            {
                return "No matches found!";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Stock list for size {size} - {type} shoes:");
            foreach (var item in list)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();

        }

    }
}
