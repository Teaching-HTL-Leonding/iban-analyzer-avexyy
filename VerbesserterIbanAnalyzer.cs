if (args.Length == 0)
{
    System.Console.WriteLine("Too few arguments");
}
else if (args.Length > 3)
{
    System.Console.WriteLine("Too many arguments");
}
else if (args[0] == "build")
{
    if (IsValidBankCode(args[1]) && IsValidAccountNumber(args[2]))
    {
        System.Console.WriteLine(BuildIban());
    }
    bool CharIsDigit(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (!Char.IsDigit(input[i]))
            {
                return false;
            }
        }
        return true;
    }

    bool IsValidBankCode(string bankCode)
    {
        if (!CharIsDigit(bankCode))
        {
            System.Console.WriteLine("Bank code must not contain letters");
        }
        else if (bankCode.Length > 4 || bankCode.Length <= 0)
        {
            System.Console.WriteLine("Bank code has wrong length, must contain 4 digits");
        }
        else
        {
            return true;
        }
        return false;
    }

    bool IsValidAccountNumber(string accountNumber)
    {
        if (!CharIsDigit(accountNumber))
        {
            System.Console.WriteLine("Account number must not contain letters");
        }
        else if (accountNumber.Length > 6 || accountNumber.Length <= 0)
        {
            System.Console.WriteLine("Account number has wrong length, must contain 6 digits");
        }
        else
        {
            return true;
        }
        return false;
    }

    string BuildIban()
    {
        return $"NO00{args[1]}{args[2]}7";
    }
}
else if (args[0] == "analyze")
{
    System.Console.WriteLine(AnalyzeIban(args[1]));
    string AnalyzeIban(string iban)
    {
        if (iban.Length == 0 || iban.Length > 15 || iban.Length <= 15)
        {
            return "Wrong length of IBAN";
        }
        else if (!iban.StartsWith("NO"))
        {
            return "Wrong country code, we currently only support 'NO'";
        }
        else if (!iban.EndsWith("7"))
        {
            return "Wrong national check digit, we currently only support '7'";
        }
        else
        {
            return $"Bank code is: {iban.Substring(4, 4)} |  Account Number is: {iban.Substring(8, 6)}";
        }
    }
}
else
{
    System.Console.WriteLine("Invalid command, must be 'build' or 'analyze' ");
}