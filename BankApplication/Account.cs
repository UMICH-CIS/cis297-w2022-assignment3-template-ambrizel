using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Class that holds the base account
/// </summary>
public abstract class Account
{
    private decimal balance;

    /// <summary>
    /// Constructor that initializes Account's variables
    /// </summary>
    /// <param name="accountBalance"></param>
    public Account(decimal accountBalance)
    {
        AccountBalance = accountBalance; //validate balance
    }

    /// <summary>
    ///  property that gets and sets account balance
    /// </summary>
    public decimal AccountBalance
    {
        get
        {
            return balance;
        }
        set
        {
            if (value < 0) //validation
            {
                Console.WriteLine("Debit amount exceeded account balance.");
            }
            else
            {
                balance = value;
            }
        }
    }

    /// <summary>
    /// method that allows for deposit into the account
    /// </summary>
    /// <param name="amountDeposit"></param>
    public virtual void Credit(decimal amountDeposit)
    {
        AccountBalance = balance + amountDeposit;
    }

    /// <summary>
    /// method that allows for withdraw from account
    /// </summary>
    /// <param name="amountWithdraw"></param>
    public virtual void Debit(decimal amountWithdraw)
    {
        AccountBalance = balance - amountWithdraw;
    }
}

/// <summary>
/// Class that derives from the base account and adds savings functionalities
/// </summary>
public class SavingsAccount : Account
{
    private decimal interestRate;

    /// <summary>
    /// Constructor that initializes SavingsAccount's variables
    /// </summary>
    /// <param name="balanceValue"></param>
    /// <param name="interestRateValue"></param>
    public SavingsAccount(decimal balanceValue, decimal interestRateValue) : base(balanceValue)
    {
        interestRate = interestRateValue;
    }

    /// <summary>
    /// method that caluclates the interest earned on an account
    /// </summary>
    /// <returns></returns>
    public decimal CalculateInterest()
    {
        decimal interestEaned;
        interestEaned = (interestRate * AccountBalance);
        return interestEaned;
    }
}

/// <summary>
/// Class that derives from the base account and adds checking functionalities
/// </summary>
public class CheckingAccount : Account
{
    private decimal fee;

    /// <summary>
    /// Constructor that initializes CheckingAccount's variables
    /// </summary>
    /// <param name="balanceValue"></param>
    /// <param name="feeValue"></param>
    public CheckingAccount(decimal balanceValue, decimal feeValue) : base(balanceValue)
    {
        fee = feeValue;
    }

    /// <summary>
    /// method overrides credit method inherited from account
    /// </summary>
    /// <param name="amountDeposit"></param>
    public override void Credit(decimal amountDeposit)
    {
        //if something is deposited a fee is charged
        if (amountDeposit > 0)
        {
            decimal updatedBalance = AccountBalance + amountDeposit - fee;
            AccountBalance = updatedBalance;
        }
    }

    /// <summary>
    /// method overrides debit method inherited from account
    /// </summary>
    /// <param name="amountWithdraw"></param>
    public override void Debit(decimal amountWithdraw)
    {
        //if something is withdrawn a fee is charged
        if (amountWithdraw > 0)
        {
            decimal updateBalance = AccountBalance;
            updateBalance = AccountBalance - amountWithdraw - fee;

            AccountBalance = updateBalance;
        }
    }
}