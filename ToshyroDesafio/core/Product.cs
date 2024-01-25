namespace ToshyroDesafio.core;

public class Product
{
    public string Name { get; }
    public double Price { get; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public string Buy(double sum, bool change)
    {

        if (sum > Price)
        {
            return $"{Name} ={sum - Price}";
        } else if (sum == Price)
        {
            return $"{Name} ={sum - Price} NO_CHANGE";            
        }
        else
        {
            return "error in class Product.cs";
        }
    }
}