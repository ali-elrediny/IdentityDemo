using Framework.Core.Contracts;
using Framework.Core.Validator.Base.Contracts;
using Framework.Core.Validator.Base.Enums;

namespace Framework.Core.Validator.Base
{
    public abstract class ValidatorBase<T> : IValidator<T> where T : class
    {
        #region cst

        protected ValidatorBase(T model, ValidationModes mode, IRepositoryFactory repositoryFactory)
        {
            this.Model = model;
            this.Result = new ReturnResult<T>();
            this.Mode = mode;
            this.RepositoryFactory = repositoryFactory;
        }

        #endregion

        #region IValidator

        #region props

        public T Model { get; set; }
        public ValidationModes Mode { get; set; }
        public ReturnResult<T> Result { get; }
        public IRepositoryFactory RepositoryFactory { get; set; }

        #endregion

        #region publics

        public ReturnResult<T> Validate()
        {
            RunValidations();

            Result.Value = this.Model;

            return Result;
        }

        protected virtual void RunValidations() { }

        #endregion 

        #endregion
    }
}
