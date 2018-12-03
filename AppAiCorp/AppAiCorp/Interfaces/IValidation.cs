using System;
namespace AppAiCorp.Interfaces
{
    /// <summary>
    /// IV alidation. - interface segregation principle
    /// </summary>
    public interface IValidation
    {
        bool IsValid { get; } // True when valid
        void Validate(); // Throws an exception when not valid
        string Message { get; } // The message when object is not valid
    }

    public abstract class ValidationBase<T> : IValidation where T : class
    {
        protected T Context { get; private set; }

        protected ValidationBase(T context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
        }

        public void Validate()
        {
            if (!IsValid)
            {
                throw new ValidationException(Message);
            }
        }

        public abstract bool IsValid { get; }
        public abstract string Message { get; }
    }
}
