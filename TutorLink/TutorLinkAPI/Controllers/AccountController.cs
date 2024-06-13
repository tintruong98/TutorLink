using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using TutorLinkAPI.BusinessLogics.IServices;

namespace TutorLinkAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    public AccountController(IAccountService accountService)
    {
    _accountService = accountService; 
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    #region Add new account
    [HttpPost("add")]
    public IActionResult AddNewAccount([FromBody] AccountRequestModel model)
    {
        try
        {
            _accountService.AddNewAccount(
                model.Username,
                model.Password,
                model.Fullname,
                model.Email,
                model.Phone,
                model.Address,
                model.Gender
            );
            return Ok("Account created successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to create account: {ex.Message}");
        }
    }
    #endregion

    #region Get list
    [HttpGet("list")]
    public IActionResult ShowAccountList()
    {
        var accounts = _accountService.GetAllAccounts();
        return Ok(accounts);
    }
    #endregion

    #region View account with Id
    [HttpGet("get/{id}")]
    public IActionResult GetAccountById(Guid id)
    {
        var account = _accountService.GetAccountById(id);
        if (account == null)
            return NotFound("Account not found.");

        return Ok(account);
    }
    #endregion

    #region Update Account
    [HttpPut("update/{id}")]
    public IActionResult UpdateAccount(Guid id, [FromBody] AccountUpdateModel model)
    {
        try
        {
            _accountService.UpdateAccount(
                id,
                model.Fullname,
                model.Email,
                model.Phone,
                model.Address,
                model.Gender
            );
            return Ok("Account updated successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to update account: {ex.Message}");
        }
    }
    #endregion

    #region Delete account
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteAccount(Guid id)
    {
        try
        {
            _accountService.DeleteAccount(id);
            return Ok("Account deleted successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to delete account: {ex.Message}");
        }
    }
    #endregion

}
#region Account model
public class AccountRequestModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public UserGenders Gender { get; set; }
}

public class AccountUpdateModel
{
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public UserGenders Gender { get; set; }
}
#endregion