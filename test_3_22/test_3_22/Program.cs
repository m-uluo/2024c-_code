using System.Xml.Linq;

namespace test_3_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //委托
            WrapFactory wrapFactory = new WrapFactory();
            ProductFactory productFactory = new ProductFactory();

            Func<Product> func1 = new Func<Product>(productFactory.MakePizza);
            Func<Product> func2 = new Func<Product>(productFactory.MakeToyCar);

            Logger logger = new Logger();
            Action<Product> action = new Action<Product>(logger.Log);

            Box boxPizza = wrapFactory.WrapProduct(func1,action);
            Box boxToyCar = wrapFactory.WrapProduct(func2, action);

            Console.WriteLine(boxPizza.Product.Name);
            Console.WriteLine(boxToyCar.Product.Name);

            //接口
            IProductFactory pizzaFactory=new PizzaFactory();
            IProductFactory toyCarFactory = new ToyCarFactory();
            WrapFactory1 wrapFactory1 = new WrapFactory1();
            Box boxPizza1 = wrapFactory1.WrapProduct1(pizzaFactory);
            Box boxToyCar1 = wrapFactory1.WrapProduct1(toyCarFactory);

            Console.WriteLine(boxPizza1.Product.Name);
            Console.WriteLine(boxToyCar1.Product.Name);
        }
    }

    public class Logger
    {
        public void Log(Product product)
        {
            Console.WriteLine( "Product '{0}' created at {1}.Price is {2}",
                                product.Name,DateTime.UtcNow,product.Price);
        }
    }
    public class Product
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                while (true)
                {
                    if (value != null)
                    {
                        name = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("出入错误"); return;
                    }
                }
            }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }


    }
    public class Box
    {
        private Product product;

        public Product Product
        {
            get { return product; }
            set
            {
                while (true)
                {
                    if (value != null)
                    {
                        product = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("出入错误"); return;
                    }
                }
            }
        }

    }
    public class WrapFactory        //封装工厂
    {
        public Box WrapProduct(Func<Product> getProduct,Action<Product> action)    //委托，封装输入的方法
        {
            Box box = new Box();
            Product product = getProduct();
            box.Product = product;
            action(box.Product);
            return box;
        }
    }
    public class ProductFactory     //生产工厂
    {
        public Product MakePizza()  //生产披萨
        {
            Product product = new Product();
            product.Name = "Pizza";
            return product;
        }
        public Product MakeToyCar() //生产玩具车
        {
            Product product = new Product();
            product.Name = "ToyCar";
            return product;
        }
    }

    //接口
    public interface IProductFactory
    {
        public Product Make();
    }
    class PizzaFactory : IProductFactory
    {
        public Product Make() 
        {
            Product product = new Product();
            product.Name = "Pizza";
            return product;
        }
    }
    class ToyCarFactory : IProductFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "ToyCar";
            return product;
        }
    }
    public class WrapFactory1        //封装工厂
    {
        public Box WrapProduct1(IProductFactory productFactory)    //委托，封装输入的方法
        {
            Box box = new Box();
            Product product = productFactory.Make();
            box.Product = product;
            return box;
        }
    }
}
