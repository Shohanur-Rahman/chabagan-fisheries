using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chabagan.Fisheries.Data.Repositories.Stock.Interfaces
{
    public interface IPaymentCollectionRepo
    {
        #region Public Methods
        /// <summary>
        /// Get all payment data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PaymentCollectionGrid>> GetAllPaymentCollectionsAsync(int typeId);

        /// <summary>
        /// Get a single payment data from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DbPaymentCollection?> GetPaymentCollectionByIdAsync(long id);

        /// <summary>
        /// Save payment information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DbPaymentCollection?> SavePaymentCollectionAsync(ProcessPaymentCollection model);

        /// <summary>
        /// Update Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DbPaymentCollection?> UpdatePaymentCollectionAsync(ProcessPaymentCollection model);

        /// <summary>
        /// Delete a payment data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DbPaymentCollection?> DeletePaymentCollectionByIdAsync(long id);
        #endregion
    }
}
