namespace Challenge.Service.Interfaces
{
    using Challenge.Shared.DBModels;
    using Challenge.Shared.DTOs;
    public interface IUserService
    {
        public Task<UserRiskValidationResponse> UserRiskValidation(Guid id);
        public Task<IList<User>> Get();
        public Task<User> GetDetails(Guid id);
        public Task<User> Post(User user);
        public Task<User> Put(User user);
        public Task Delete(User user);
    }
}
