using PharmaMVC.Models;

namespace PharmaMVC.Interfaces;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetTransactions();
    Task<IEnumerable<DataSalesPerMonthViewModel>> GetTransactionsByTimePeriod(DateTime startDate, DateTime endDate);
    Task<Transaction?> GetTransactionById(int transactionId);
    void CreateTransaction(Transaction transaction);
    void AddTransactionItem(TransactionItem transactionItem);
    Task SaveChangesAsync();
}

