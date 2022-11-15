namespace LegacyApp
{
    public class UserCreditService : IUserCreditService
    {
        public int GetCreditLimit(User user)
        {
            int creditLimit = 0;
            if (user.HasCreditLimit)
            {
                using (var userCreditService = new UserCreditServiceClient())
                {
                    creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                }

            }
            return creditLimit;

        }
    }
}
