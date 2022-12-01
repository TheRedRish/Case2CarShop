using Case2CarShop.Menues;

Customer customer = new Customer();
Vehicle vehicle = new Vehicle();
do
{
    Console.Clear();
    Console.WriteLine("Please choose an option:");
    Console.WriteLine("1. AddCustomer");
    Console.WriteLine("2. SearchForPerson");
    Console.WriteLine("9. Exit");
    string? searchUserInput = Console.ReadLine() ?? "";

    bool isExitNumber = int.TryParse(searchUserInput, out int searchUserInputInt);
    if (searchUserInput?.ToLower() == "exit" || (isExitNumber && searchUserInputInt == 9))
    {
        break;
    }
    bool isAnOption = CheckUserInput.CheckIfUserInputMatchesCriteria(searchUserInput);

    if (!isAnOption || searchUserInput == null)
    {
        Console.Write("You have entered something wrong, try again");
        Console.ReadKey();
        continue;
    }

    // Add customer and vehicle
    if (searchUserInput == ((int)EnumCriteria.AddCustomer).ToString() || searchUserInput.ToLower() == EnumCriteria.AddCustomer.ToString().ToLower())
    {
        try
        {
            AddCustomer.Run(customer, vehicle);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }

    // Search for person, finds either customer or mechanic
    if (searchUserInput == ((int)EnumCriteria.SearchForPerson).ToString() || searchUserInput.ToLower() == EnumCriteria.SearchForPerson.ToString().ToLower())
    {
        try
        {
            SearchForPerson.Run(customer);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }

} while (true);