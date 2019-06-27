using System;

namespace TestWarrior.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged;

        //void functions are by definition command functions
        public void Log(string error)
        {
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            LastError = error;

            // Write an error to the log
            // ...

            ErrorLogged?.Invoke(this, Guid.NewGuid());
            //OnErrorLogged(Guid.NewGuid());
        }

        //Don't test private or protected methods.
        //They represent implementation details.

        //protected virtual void OnErrorLogged(Guid errorId)
        //{
        //    ErrorLogged?.Invoke(this, errorId);
        //}
    }
}
