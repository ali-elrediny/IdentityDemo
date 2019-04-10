using Framework.Core.Contracts;
using Framework.Core.Validator.Base.Enums;

namespace Framework.Core.Validator.Base.Contracts
{
    public interface IValidator<T> where T : class
    {
        T Model { get; set; }
        ReturnResult<T> Result { get; }
        ValidationModes Mode { get; set; }
        IRepositoryFactory RepositoryFactory { get; set; }
        ReturnResult<T> Validate();
    }
}