using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            //Pesho=11;Gosho=4
            
            List<Person> people = new List<Person>();

            string[] inputPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputPeople.Length; i++)
            {
                string[] personInfo = inputPeople[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }        
            }

            List<Product> products = new List<Product>();

            string[] productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productsInput.Length; i++)
            {
                string[] currentProduct = productsInput[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = currentProduct[0];
                decimal price = decimal.Parse(currentProduct[1]);

                try
                {
                    Product product = new Product(name, price);
                    products.Add(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                } 
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] productInfo = input.Split();
                string personName = productInfo[0];
                string productName = productInfo[1];

                if (people.Any(x => x.Name == personName) && products.Any(x=> x.Name == productName))
                {
                    var currentPerson = people.FirstOrDefault(x => x.Name == personName);
                    var currentProduct = products.FirstOrDefault(x => x.Name == productName);

                    if (currentPerson.Money >= currentProduct.Cost)
                    {
                        currentPerson.Money -= currentProduct.Cost;
                        currentPerson.AddProduct(currentProduct);
                        Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                    }

                    else
                    {
                        Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }

                else
                {

                    StringBuilder sb = new StringBuilder($"{person.Name} - ");

                    foreach (var product in person.Products)
                    {
                        sb.Append(product.Name + ", ");
                    }

                    sb.ToString();
                    sb[sb.Length - 2] = ' ';
                    Console.WriteLine(sb.ToString().TrimEnd());
                }
            }
            

          

        }
    }
}
