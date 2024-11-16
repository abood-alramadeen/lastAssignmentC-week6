// See https://aka.ms/new-console-template for more information
/*
 Create a CarsStore class to represent the store name, the location and
the owner.
Create a Car class which represent the car name and the price.
Create a CarOnSale class to represent the sale of a car. The class should
represent the discount in percent, and the final price (calculated from
the price after the discount is applied).
 Make a few instances and print them out in organized way.
 Make sure that all data must be filled in from user.
 You must use inheritance.
 Take care of naming convention
 */
///Define the CarsStore Class
using System;

public class CarsStore
{
	public string StoreName { get; set; }
	public string Location { get; set; }
	public string Owner { get; set; }

	public CarsStore(string storeName, string location, string owner)
	{
		StoreName = storeName;
		Location = location;
		Owner = owner;
	}

	public override string ToString()
	{
		return $"Store Name: {StoreName}\nLocation: {Location}\nOwner: {Owner}\n";
	}
}


/////////////////////////////////////
///// Define the Car Class

public class Car
{
	public string CarName { get; set; }
	public decimal Price { get; set; }

	public Car(string carName, decimal price)
	{
		CarName = carName;
		Price = price;
	}

	public override string ToString()
	{
		return $"Car Name: {CarName}\nPrice: {Price:C}\n";
	}
}

///////////////////////////////
///Define the CarOnSale Class
/// <summary>
/// Define the CarOnSale Class
/// 


public class CarOnSale : Car
{
	public decimal DiscountPercentage { get; set; }
	public decimal FinalPrice => Price - (Price * DiscountPercentage / 100);

	public CarOnSale(string carName, decimal price, decimal discountPercentage)
		: base(carName, price)
	{
		DiscountPercentage = discountPercentage;
	}

	public override string ToString()
	{
		return base.ToString() +
			   $"Discount: {DiscountPercentage}%\nFinal Price: {FinalPrice:C}\n";
	}
}


//////////////////////////////////
///Create and Print Instances
///

class Program
{
	static void Main(string[] args)
	{
		Console.Write("Enter store name: ");
		string storeName = Console.ReadLine();

		Console.Write("Enter store location: ");
		string location = Console.ReadLine();

		Console.Write("Enter store owner: ");
		string owner = Console.ReadLine();

		CarsStore store = new CarsStore(storeName, location, owner);

		Console.WriteLine("\nStore Details:");
		Console.WriteLine(store);

		Console.Write("\nEnter car name: ");
		string carName = Console.ReadLine();

		Console.Write("Enter car price: ");
		decimal price = Convert.ToDecimal(Console.ReadLine());

		Console.Write("Enter discount percentage: ");
		decimal discountPercentage = Convert.ToDecimal(Console.ReadLine());

		CarOnSale carOnSale = new CarOnSale(carName, price, discountPercentage);

		Console.WriteLine("\nCar on Sale Details:");
		Console.WriteLine(carOnSale);

		Console.WriteLine("\nPress any key to exit...");
		Console.ReadKey();
	}
}










///////////////////////////////////////////////////////////////////////////////////////////////
///
/*
 Exercise 2
Create one method to represent mathematical operations (+ - * / ^
square root ) to be applied on two numbers and be careful that no
exceptions must appear regardless if they have values or nulls
 */


class Programm
{
	// Method for mathematical operations
	public static double PerformOperation(double? num1, double? num2, string operation)
	{
		// Default values if null
		double value1 = num1 ?? 0;
		double value2 = num2 ?? 0;

		try
		{
			switch (operation)
			{
				case "+":
					return value1 + value2;
				case "-":
					return value1 - value2;
				case "*":
					return value1 * value2;
				case "/":
					if (value2 == 0)
						throw new DivideByZeroException("Division by zero is not allowed.");
					return value1 / value2;
				case "^":
					return Math.Pow(value1, value2);
				case "sqrt":
					if (value1 < 0)
						throw new ArgumentException("Cannot calculate the square root of a negative number.");
					return Math.Sqrt(value1);
				default:
					throw new InvalidOperationException("Invalid operation.");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
			return double.NaN; // Return NaN for invalid operations
		}
	}

	static void Main(string[] args)
	{
		// Get input from the user
		Console.Write("Enter first number (or leave blank for null): ");
		string input1 = Console.ReadLine();
		double? num1 = string.IsNullOrWhiteSpace(input1) ? (double?)null : Convert.ToDouble(input1);

		Console.Write("Enter second number (or leave blank for null): ");
		string input2 = Console.ReadLine();
		double? num2 = string.IsNullOrWhiteSpace(input2) ? (double?)null : Convert.ToDouble(input2);

		Console.Write("Enter the operation (+, -, *, /, ^, sqrt): ");
		string operation = Console.ReadLine();

		// Perform the operation
		double result = PerformOperation(num1, num2, operation);

		// Display the result
		Console.WriteLine($"\nResult: {result}");
	}
}
