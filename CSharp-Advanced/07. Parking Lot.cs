namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();    
            
            string line;

            while ((line = Console.ReadLine()) != "END")
            {
                string[] tokens = line.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string licenseplate = tokens[1];

                if (command == "IN")
                {
                    parkingLot.Add(licenseplate);
                }
                else if (command == "OUT")
                {
                    parkingLot.Remove(licenseplate);
                }
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {

            Console.WriteLine(string.Join(Environment.NewLine, parkingLot));
            }
        }
    }
}