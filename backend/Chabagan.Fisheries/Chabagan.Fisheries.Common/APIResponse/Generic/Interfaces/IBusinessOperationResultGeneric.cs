using Chabagan.Fisheries.Common.APIResponse.Interfaces;

namespace Chabagan.Fisheries.Common.APIResponse.Generic.Interfaces
{
    public interface IBusinessOperationResultGeneric<out T> : IBusinessOperationResult
    {
        /// <summary>
        /// Gets the result returned by the operation.
        /// </summary>
        T Result { get; }
    }
}
