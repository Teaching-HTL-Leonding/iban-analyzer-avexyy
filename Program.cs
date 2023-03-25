if (args.Length > 0)
{
    string norway = "NO";
    string checkSum = "00";
    string bankCode = "";
    string accountNumber = "";
    string nationalCheckN = "7";


    if (args[0] == "build")
    {
        bankCode = args[1];
        accountNumber = args[2];

        if (args.Length > 3)
        {
            Console.WriteLine("Too many arguments");
            Environment.Exit(0);
        }
        else if (args.Length < 2)
        {
            System.Console.WriteLine("Too few arguments");
            Environment.Exit(0);
        }
        if (bankCode.Length != 4)
        {
            Console.WriteLine("Bank code has wrong length, must contain 4 digits"!);
            Environment.Exit(0);
        }
        if (accountNumber.Length != 6)
        {
            System.Console.WriteLine("Account number has wrong length, must contain 6 digits");
            Environment.Exit(0);
        }
        bool ErrorOutput(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (!Char.IsDigit(text[i]))
                {
                    return false;
                }
            }
            return true;
        }
        string BuildIban()
        {
            if (!ErrorOutput(bankCode))
            {
                return "Bank code must not contain letters";
            }
            if (!ErrorOutput(accountNumber))
            {
                return "Account number must not contain letters";
            }
            return $"{norway}{checkSum}{bankCode}{accountNumber}{nationalCheckN}";
        }

        Console.WriteLine(BuildIban());
    }
    else if (args[0] == "analyze")
    {
        System.Console.WriteLine(AnalyzeIban());
        string AnalyzeIban()
        {
            string iban = args[1];
            string countryCode = iban.Substring(0, 2);
            string nationalCheck = iban.Substring(14, 1);


            if (iban.Length != 15)
            {
                return "Wrong length of IBAN";
            }
            if (countryCode != "NO")
            {
                return "Wrong country code, we currently only support 'NO'";
            }
            if (nationalCheck != "7")
            {
                return "Wrong national check digit, we currently only support '7'";
            }

            string bankCode = iban.Substring(4, 4);
            string accountNumber = iban.Substring(8, 6);

            return $"Bank code is {bankCode} | Account number is {accountNumber}";
        }
    }
    else
    {
        System.Console.WriteLine("Invalid command, must be 'analyze' or 'build'");
    }
}