import { apiSlice } from "../api/apiSlice";
const stockCategoryApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getStockCategory: builder.query({
            query: () => ({
                url: `stockcategories`
            }),
            providesTags: ["stockcategory-list"]
        }),
        getStockCategoryById: builder.mutation({
            query: (id) => ({
                url: `stockcategories/${id}`
            }),
            invalidatesTags: ["stockcategory-list"]
        }),
        addStockCategory: builder.mutation({
            query: (roleData) => ({
                url: `/stockcategories`,
                method: "POST",
                body: roleData
            }),
            invalidatesTags: ["stockcategory-list"]
        }),
        updateStockCategory: builder.mutation({
            query: (roledata) =>({
                url: `/stockcategories`,
                method: "PUT",
                body: roledata
            }),
            invalidatesTags: ["stockcategory-list"]
        }),
        deleteStockCategory: builder.mutation({
            query: (id) =>({
                url: `stockcategories/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["stockcategory-list"],
        })
    })
});

export const { 
    useGetStockCategoryQuery,
    useGetStockCategoryByIdMutation,
    useAddStockCategoryMutation,
    useUpdateStockCategoryMutation,
    useDeleteStockCategoryMutation
} = stockCategoryApi;