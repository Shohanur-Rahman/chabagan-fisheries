using AutoMapper;
using Chabagan.Chabagan.Fisheries.Models.Area;
using Chabagan.Chabagan.Fisheries.Models.Category;
using Chabagan.Chabagan.Fisheries.Models.Expense;
using Chabagan.Chabagan.Fisheries.Models.Feed;
using Chabagan.Chabagan.Fisheries.Models.Fish;
using Chabagan.Chabagan.Fisheries.Models.Project;
using Chabagan.Chabagan.Fisheries.Models.Seller;
using Chabagan.Chabagan.Fisheries.Models.User;
using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Mapping.User;
using Chabagan.Fisheries.Entities.Models.Stock;
using Chabagan.Fisheries.Mapping;
using Chabagan.Fisheries.Mapping.Area;
using Chabagan.Fisheries.Mapping.Fish;
using Chabagan.Fisheries.Mapping.User;
using Chabagan.Fisheries.Models.Area;
using Chabagan.Fisheries.Models.Category;
using Chabagan.Fisheries.Models.Expense;
using Chabagan.Fisheries.Models.Feed;
using Chabagan.Fisheries.Models.Project;
using Chabagan.Fisheries.Models.Seller;

namespace Chabagan.Fisheries.Data.Utilities
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DbUser, VwUser>().ReverseMap();
            CreateMap<DbUser, VwUserResponse>().ReverseMap();
            CreateMap<DbFish, VwFish>().ReverseMap();
            CreateMap<DbFeed, VwFeed>().ReverseMap();
            CreateMap<DbCategory, VwCategory>().ReverseMap();
            CreateMap<DbArea, VwArea>().ReverseMap();
            CreateMap<DbSeller, VwSeller>().ReverseMap();
            CreateMap<DbProject, VwProject>().ReverseMap();
            CreateMap<DbExpense, VwExpense>().ReverseMap();
            CreateMap<DbSell, VwSell>().ReverseMap();
            CreateMap<DbSellItem, VwSellItem>().ReverseMap();


            #region Stock

            CreateMap<DbBrand, VwBrand>().ReverseMap();
            CreateMap<DbStockCategory, VwStockCategory>().ReverseMap();
            CreateMap<DbProduct, VwProduct>().ReverseMap();
            CreateMap<DbPurchase, VwPurchase>().ReverseMap();
            CreateMap<DbPurchaseItem, VwPurchaseItem>().ReverseMap();
            CreateMap<DbSupplier, VwSupplier>().ReverseMap();


            CreateMap<DbProduct, DropdownModel>().ReverseMap();
            CreateMap<DbSupplier, DropdownModel>().ReverseMap();
            #endregion
        }
    }
}
