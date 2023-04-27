using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choice from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to depoist? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you. The new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw?: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            // Check if user has enough money to withdraw
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Not enough funds");
            }
            else
            {
               currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you. All set.");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current Balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        // Example 1
        cardHolders.Add(new cardHolder("243624563478", 2456, "Liam", "Johnson", 100.00));

        // Example 2
        cardHolders.Add(new cardHolder("987654321012", 9999, "Emma", "Garcia", 1500.50));

        // Example 3
        cardHolders.Add(new cardHolder("777777777777", 1234, "Noah", "Hernandez", 500.75));

        // Example 4
        cardHolders.Add(new cardHolder("999999999999", 6789, "Ava", "Lopez", 300.25));

        // Example 5
        cardHolders.Add(new cardHolder("555555555555", 4321, "Oliver", "Martinez", 1000.00));

        // Prompt User
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Validate
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Try again."); }
            } catch { Console.WriteLine("Card not recognized. Try again."); }
        }

        Console.WriteLine("Enter PIN");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // Validate        
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect PIN. Try again."); }
            }
            catch { Console.WriteLine("Incorrect PIN. Try again."); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you. Have a nice day");
    }
}
