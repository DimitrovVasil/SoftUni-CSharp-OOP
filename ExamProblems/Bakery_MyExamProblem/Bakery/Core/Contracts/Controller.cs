using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        List<IBakedFood> bakedFoods;
        List<IDrink> drinks;
        List<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }

            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            drinks.Add(drink);

            return $"Added {drink.Name} ({drink.Brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == "Bread")
            {
                food = new Bread(name, price);
            }

            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }

            bakedFoods.Add(food);

            return $"Added {food.Name} ({food.GetType().Name}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }

            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);

            return $"Added table number {table.TableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = tables.Where(t => t.IsReserved == false).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public string GetTotalIncome()
        {


            foreach (Table table in tables)
            {    
                totalIncome += table.GetBill();
            }

           // string incomesAsString = totalIncome.ToString("00");

            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            totalIncome += bill;
            table.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            string result = sb.ToString().TrimEnd();
           // tables.Remove(table);
            return result;
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable targetTable = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (targetTable == null)
            {
                return $"Could not find table {tableNumber}";
            }

            IDrink targetDrink = drinks
                .Where(d => d.Name == drinkName)
                .Where(d => d.Brand == drinkBrand)
                .FirstOrDefault();

            if (targetDrink == null)
            {   
                return $"There is no {drinkName} {drinkBrand} available";
            }

            targetTable.OrderDrink(targetDrink);

            //TODO: MUST USE VARIABLES INSTEAD OF PROPERTIES OF TARGETOBJECTS?
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable targetTable = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (targetTable == null)
            {
                return $"Could not find table {tableNumber}";
            }

            IBakedFood targetFood = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (targetFood == null)
            {
                return $"No {foodName} in the menu";
            }

            targetTable.OrderFood(targetFood);

            //TODO: MUST USE VARIABLES INSTEAD OF PROPERTIES OF TARGETOBJECTS?
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable targetTable = tables
                .Where(t => t.IsReserved == false)
                .Where(t => t.Capacity >= numberOfPeople)
                .FirstOrDefault();

            if (targetTable == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            else
            {
                targetTable.Reserve(numberOfPeople);
                return $"Table {targetTable.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }
}
