using System;
using System.Collections.Generic;


namespace Domain
{
    public class OperationResult
    {
        /// <summary>
        /// Set to <b>True</b> if request was executed without unexpected errors like:
        /// - Uncaught Exceptions (defaut service try/catch, Global Exception Handler)
        /// - Client version mismatch
        /// - Other fatal errors...
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Optional response message.
        /// </summary>
        public List<string> Messages { get; set; } = new List<string>();

        /// <summary>
        /// Exception stack trace if any.
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// Code represents detailed result of operation:
        /// - Error classification when Success == False (Unhandled Exception, Client Version Mismatch etc.)
        /// - Status classification when Success == True (i.e. removing file did not throw exceptions but file was not found which is OK)
        /// </summary>
        public OperationCode Code { get; set; }

        public OperationResult()
        {
            Success = true;
            Code = OperationCode.Ok;
        }

        public static OperationResult<T> FromUpsert<T>(T savedEntity)
        {
            return new OperationResult<T> {Code = OperationCode.Ok, Object = savedEntity};
        }

        public static OperationResult<T> FromError<T, U>(OperationResult<U> errorResult)
        {
            if (errorResult.Success)
            {
                throw new ArgumentException(nameof(errorResult));
            }
            return new OperationResult<T>
            {
                Messages = errorResult.Messages,
                Code = errorResult.Code,
                Success = errorResult.Success,
                StackTrace = errorResult.StackTrace
            };
        }

        public static OperationResult<T> FromException<T>(Exception e, OperationCode errorCode)
        {
            return new OperationResult<T>
            {
                Messages = new List<string> {e.Message},
                Success = false,
                StackTrace = e.StackTrace,
                Code = errorCode
            };
        }

        public static OperationResult FromException(Exception e, OperationCode errorCode)
        {
            return new OperationResult
            {
                Messages = new List<string> {e.Message},
                Success = false,
                StackTrace = e.StackTrace,
                Code = errorCode
            };
        }
    }

    public class OperationResult<TResult> : OperationResult
    {
        public OperationResult() : base() { } 

        public OperationResult(TResult res)
        {
            Success = true;
            Object = res;
        }
        public TResult Object { get; set; }
    }

    public class UpsertResult<TResult> : OperationResult<TResult> where TResult : DomainBase
    {
        public List<string> Warnings { get; set; } = new List<string>();

    }
}