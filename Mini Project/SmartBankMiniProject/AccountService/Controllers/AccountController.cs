using AccountService.DTO;
using AccountService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers
{
    [ApiController]
    [Route("WebServices/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _service;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger, IAccountServices service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountDTO dto)
        {
            var result = await _service.CreateAccountAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(TransactionDTO dto)
        {
            await _service.DepositAsync(dto);
            return Ok();
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDTO dto)
        {
            await _service.WithdrawAsync(dto);
            return Ok();
        }
    }
}
