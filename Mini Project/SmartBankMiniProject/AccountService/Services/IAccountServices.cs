using AccountService.DTO;

namespace AccountService.Services
{
    public interface IAccountServices
    {
        Task<AccountDTO> CreateAccountAsync(CreateAccountDTO dto);
        Task<List<AccountDTO>> GetAllAsync();
        Task<AccountDTO> GetByIdAsync(int id);
        Task DepositAsync(TransactionDTO dto);
        Task WithdrawAsync(TransactionDTO dto);
    }
}
