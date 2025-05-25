using GSCollect_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GSCollect_MVC.Services
{
    public interface IAuthenticationService
    {
        Task<User?> AuthenticateAsync(string userName, string password);
        bool ValidateInput(string input);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly GscollectContext _context;

        public AuthenticationService(GscollectContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateAsync(string userName, string password)
        {
            // Validate input to prevent SQL injection (similar to old app)
            if (!ValidateInput(userName) || !ValidateInput(password))
            {
                return null;
            }

            // Trim inputs (consistent with old app behavior)
            userName = userName.Trim();
            password = password.Trim();

            // Query user from database
            var user = await _context.Users
                .Where(u => u.UserName.Trim() == userName && u.Password.Trim() == password)
                .FirstOrDefaultAsync();

            return user;
        }

        public bool ValidateInput(string input)
        {
            // Same validation as the old application
            if (string.IsNullOrEmpty(input))
                return false;

            var invalidChars = new[] { "%", "'", "(", ")", "*" };
            return !invalidChars.Any(input.Contains);
        }
    }
}
