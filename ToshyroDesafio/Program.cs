using ToshyroDesafio.core;

class Program
{
    static void Main()
    {
        // coins dict: value-quantity
        Dictionary<string, int> coins = new Dictionary<string, int>
        {
            { "1.00", 10 },
            { "0.50", 10 },
            { "0.25", 10 },
            { "0.10", 10},
            { "0.05", 10 },
            { "0.01", 10 }
        };

        // product definition
        Product cocaCola = new Product("Coca-Cola", 1.5);
        Product pastelina = new Product("Pastelina", 0.30);
        Product agua = new Product("Agua", 1.0);

        // main loop
        var isRunning = true;
        while (isRunning)
        {
            Console.Write(">> ");
            var line = Console.ReadLine();

            var tokens = line.Split(" ");

            var sum = 0.0; // sum of all coins

            var change = false;

            string productChosen = "";
            
            foreach (var token in tokens)
            {
                // check if it's a number, if it is, then assign it to the 'value' variable
                // https://stackoverflow.com/questions/22794356/isnumeric-function-in-c-sharp
                if (double.TryParse(token, out double value))
                {
                    if (coins.ContainsKey(token) && coins[token] > 0)
                    {
                        sum += value;
                        coins[token]--;
                    }
                    else
                    {
                        Console.WriteLine("Moeda inválida ou sem estoque");
                    }
                }

                if (token.ToLower() == cocaCola.Name.ToLower() ||
                    token.ToLower() == pastelina.Name.ToLower() ||
                    token.ToLower() == agua.Name.ToLower()
                   )
                {
                    productChosen = token.ToLower();
                }
                
                if (token == "CHANGE")
                {
                    change = true;
                }

                if (token == "exit")
                {
                    return;
                }
            }
            
            ProcessPurchase(sum, cocaCola, pastelina, agua, change, productChosen);
        }
    }

    // this method will not work without the static keyword
   static void ProcessPurchase(double sum, Product cocaCola, Product pastelina, Product agua, bool change, string productChosen)
    {
        if (sum > 0)
        {
            if (sum >= cocaCola.Price && productChosen == cocaCola.Name.ToLower())
            {
                Console.WriteLine(cocaCola.Buy(sum, change));
            }
            else if (sum >= pastelina.Price && productChosen == pastelina.Name.ToLower())
            {
                Console.WriteLine(pastelina.Buy(sum, change));
            }
            else if (sum >= agua.Price && productChosen == agua.Name.ToLower())
            {
                Console.WriteLine(agua.Buy(sum, change));
            }
            else
            {
                Console.WriteLine("UNSPECIFIED ERROR");
            }
        }
    }
}
