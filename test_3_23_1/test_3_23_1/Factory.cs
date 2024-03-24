using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_3_23_1
{

    public class Factory
    {
        public Product PizzaMake()
        {
            Product pizza = new Product();
            pizza.Name = "pizza";
            pizza.Price = 60;
            return pizza;
        }
        public Product ToyCarMake()
        {
            Product toyCar = new Product();
            toyCar.Name = "toyCar";
            toyCar.Price = 100;
            return toyCar;
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class Box
    { public Product Product { get; set; } }
    public class WrapFactory
    {
        public Box WrapProduct(Func<Product> getProduct,Action<Product> action)
        {
            Box box = new Box();
            box.Product = getProduct();
            action(box.Product);
            return box;
        }
    }
    public class Logger
    {
        public void Log(Product product)
        {
            Console.WriteLine(  "Product '{0}' created at {1}.Price is {2}",product.Name,DateTime.Now,product.Price);
        }
    }

}
