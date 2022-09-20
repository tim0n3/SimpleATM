using System;

public class CardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
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

    public void SetPin(int newPin)
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
            Console.WriteLine("Please, choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for you $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawl = Double.Parse(Console.ReadLine());
            // Check if the user has enough $$$ 
            if (currentUser.getBalance() < withdrawl)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawl);
                Console.WriteLine("You're good to go! Thank you :)");
            }
        }

        void balance(CardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<CardHolder> CardHolders = new List<CardHolder>();
        CardHolders.Add(new CardHolder("123456789876544321", 1234, "John", "Doe", 13579.00));
        CardHolders.Add(new CardHolder("198765443212345678", 1987, "Jane", "Doe", 3579.00));
        CardHolders.Add(new CardHolder("123444321567898765", 3215, "Son", "Doe", 1357.00));
        CardHolders.Add(new CardHolder("898123456776544321", 8981, "Dun", "Doe", 1579.00));

        // Promt the user
        Console.WriteLine("Welcome to SimpleATM!");
        Console.WriteLine("Please, insert your Debit card: ");
        String debitCardNum = "";
        CardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our DB
                currentUser = CardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card is not recognized. Please, try again");
                }
            }
            
            catch
            {
                Console.WriteLine("Card is not recognized. Please, try again");
            }
        }


        Console.WriteLine("Please, enter your Pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin. Please, try again");
                }
            }

            catch
            {
                Console.WriteLine("Incorrect pin. Please, try again");
            }
        }
        

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                if (option == 1)
                {
                    deposit(currentUser);
                }
                else if (option == 2)
                {
                    object depositCardNum = null;
                    withdraw(currentUser);
                }
                else if (option == 3)
                {
                    balance(currentUser);
                }
                else if (option == 4)
                {
                    break;
                }
                else
                {
                    option = 0;
                }
            }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice Day :)");
    }
}