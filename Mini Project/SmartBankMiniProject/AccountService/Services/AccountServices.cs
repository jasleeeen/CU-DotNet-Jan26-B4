using AccountService.DTO;
using AccountService.Exceptions;
using AccountService.Helpers;
using AccountService.Models;
using AccountService.Repositories;

namespace AccountService.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepository _repo;

        public AccountServices(IAccountRepository repo)
        {
            _repo = repo;
        }

        public async Task<AccountDTO> CreateAccountAsync(CreateAccountDTO dto)
        {
            if (dto.InitialDeposit < 1000)
                throw new BadRequestException("Minimum deposit must be ₹1000");

            var account = new Account
            {
                Name = dto.Name,
                Balance = dto.InitialDeposit,
                CreatedAt = DateTime.UtcNow
            };

            account = await _repo.AddAsync(account);

            account.AccountNumber = AccountNumberGenerator.Generate(account.Id);

            await _repo.UpdateAsync(account);

            return new AccountDTO
            {
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                Name = account.Name,
                Balance = account.Balance
            };
        }

        public async Task<List<AccountDTO>> GetAllAsync()
        {
            var accounts = await _repo.GetAllAsync();

            return accounts.Select(a => new AccountDTO
            {
                Id = a.Id,
                AccountNumber = a.AccountNumber,
                Name = a.Name,
                Balance = a.Balance
            }).ToList();
        }

        public async Task<AccountDTO> GetByIdAsync(int id)
        {
            var account = await _repo.GetByIdAsync(id);

            if (account == null)
                throw new NotFoundException($"Account with ID {id} not found");

            return new AccountDTO
            {
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                Name = account.Name,
                Balance = account.Balance
            };
        }

        public async Task DepositAsync(TransactionDTO dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Deposit amount must be greater than 0");

            var account = await _repo.GetByIdAsync(dto.AccountId);

            if (account == null)
                throw new NotFoundException("Account not found");

            account.Balance += dto.Amount;

            await _repo.UpdateAsync(account);
        }

        public async Task WithdrawAsync(TransactionDTO dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Withdrawal amount must be greater than 0");

            var account = await _repo.GetByIdAsync(dto.AccountId);

            if (account == null)
                throw new NotFoundException("Account not found");

            if (account.Balance - dto.Amount < 1000)
                throw new BadRequestException("Minimum balance of ₹1000 must be maintained");

            account.Balance -= dto.Amount;

            await _repo.UpdateAsync(account);
        }
    }
}