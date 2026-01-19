using Authentication_Api.Data.Interfaces;

namespace Authentication_Api.Core.Services.UserKeys
{
    public class GenerateUserKeyService
    {
        private readonly IUserRepository _userRepo;
        public GenerateUserKeyService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        private string GenerateRandomUserKey()
        {
            var random = new Random();
            return $"#{random.Next(10000, 99999)}";
        }

        public async Task<string> GenerateUniqueUserKeyAsync()
        {
            string key;
            do
            {
                key = GenerateRandomUserKey();
            } while (await _userRepo.UserKeyExistsAsync(key));
            return key;
        }
    }
}