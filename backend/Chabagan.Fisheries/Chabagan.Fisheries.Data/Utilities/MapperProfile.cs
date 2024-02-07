using AutoMapper;
using Chabagan.Chabagan.Fisheries.Models.User;
using Chabagan.Fisheries.Entities.Mapping.Setup;
using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Mapping.User;
using Chabagan.Fisheries.Entities.Models.Setup;
using Chabagan.Fisheries.Entities.Models.Stock;
using Chabagan.Fisheries.Mapping;
using Chabagan.Fisheries.Mapping.User;

namespace Chabagan.Fisheries.Data.Utilities
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DbUser, VwUser>().ReverseMap();
            CreateMap<DbUser, VwUserResponse>().ReverseMap();
           

            #region  Setup

            CreateMap<DbBrand, VwBrand>().ReverseMap();
            CreateMap<DbStockCategory, VwStockCategory>().ReverseMap();
            CreateMap<DbProduct, VwProduct>().ReverseMap();
            CreateMap<DbSupplier, VwSupplier>().ReverseMap();
            CreateMap<DbProject, VwProject>().ReverseMap();
            CreateMap<DbPond, DbPond>().ReverseMap();
            /*
             * 
             * Dropdowns map
             */
            CreateMap<DbProduct, DropdownModel>().ReverseMap();
            CreateMap<DbSupplier, DropdownModel>().ReverseMap();
            CreateMap<DbProject, DropdownModel>().ReverseMap();
            CreateMap<DbPond, DropdownModel>().ReverseMap();

            #endregion


            #region Stock

            CreateMap<DbPurchase, ProcessPurchase>().ReverseMap();
            CreateMap<DbPurchaseReturn, ProcessPurchase>().ReverseMap();
            CreateMap<DbSales, ProcessPurchase>().ReverseMap();

            CreateMap<DbPurchase, PurchaaseInfo>().ReverseMap();
            CreateMap<DbPurchaseReturn, PurchaaseInfo>().ReverseMap();
            CreateMap<DbSales, PurchaaseInfo>().ReverseMap();

            CreateMap<DbPurchaseItem, ProcessPurchaseItem>().ReverseMap();
            CreateMap<DbPurchaseReturnItem, ProcessPurchaseItem>().ReverseMap();
            CreateMap<DbSalesItem, ProcessPurchaseItem>().ReverseMap();
            
            #endregion


        }
    }
}
