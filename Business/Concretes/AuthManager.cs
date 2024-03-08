using Business.Abstracts;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IUserRepository _userRepository;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _userOperationClaimRepository = userOperationClaimRepository;
        _userRepository = userRepository;
    }

    public async Task<DataResult<AccessToken>> CreateAccessToken(User user)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(x => x.UserId == user.Id).Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken, "Created Token");

    }

    public async Task<DataResult<AccessToken>> Login(UserForLoginDto userForLoginDto)
    {
        var user = await _userService.GetByMail(userForLoginDto.Email);
        await UserShouldBeExists(user.Data);
        await UserEmailShouldBeExists(userForLoginDto.Email);
        await UserPasswordShouldBeMatch(user.Data.Id,userForLoginDto.Password);
        var createAccessToken = await CreateAccessToken(user.Data);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Login Success");
    }

    public async Task<DataResult<AccessToken>> Register(UserForRegisterDto userForRegisterDto)
    {
        await UserEmailShouldBeNotExists(userForRegisterDto.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        await _userRepository.Add(user);
        var createAccessToken = await CreateAccessToken(user);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }


    private async Task UserEmailShouldBeNotExists(string email)
    {
        User? user = await _userRepository.Get(u => u.Email == email);
        if (user is not null) throw new BusinessException("User mail already exists");
    }

    private async Task UserEmailShouldBeExists(string email)
    {
        User? user = await _userRepository.Get(u => u.Email == email);
        if (user is null) throw new BusinessException("Email or Password don't match");
    }

    private Task UserShouldBeExists(User? user)
    {
        if (user is null) throw new BusinessException("Email or Password don't match");
        return Task.CompletedTask;
    }

    private async Task UserPasswordShouldBeMatch(Guid id, string password)
    {
        User? user = await _userRepository.Get(u => u.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException("Email or Password don't match");
    }
}
