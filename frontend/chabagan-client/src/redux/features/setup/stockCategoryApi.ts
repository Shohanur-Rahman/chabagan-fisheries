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
            query: (data) => ({
                url: `stockcategories`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["stockcategory-list"]
        }),
        updateStockCategory: builder.mutation({
            query: (data) => ({
                url: `stockcategories`,
                method: "PUT",
                body: data
            }),
            invalidatesTags: ["stockcategory-list"]
        }),
        deleteStockCategory: builder.mutation({
            query: (id) => ({
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