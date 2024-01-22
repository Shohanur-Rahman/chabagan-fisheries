import { apiSlice } from "../api/apiSlice";
const brandsApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getBrands: builder.query({
            query: () => ({
                url: `brands`
            }),
            providesTags: ["brand-list"]
        }),
        getBrand: builder.mutation({
            query: (id) => ({
                url: `brands/${id}`
            }),
            invalidatesTags: ["brand-list"]
        }),
        addBrand: builder.mutation({
            query: (roleData) => ({
                url: `/brands`,
                method: "POST",
                body: roleData
            }),
            invalidatesTags: ["brand-list"]
        }),
        updateBrand: builder.mutation({
            query: (roledata) =>({
                url: `/brands`,
                method: "PUT",
                body: roledata
            }),
            invalidatesTags: ["brand-list"]
        }),
        deleteBrand: builder.mutation({
            query: (id) =>({
                url: `brands/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["brand-list"],
        })
    })
});

export const { useGetBrandsQuery, useGetBrandMutation , useDeleteBrandMutation, useAddBrandMutation, useUpdateBrandMutation} = brandsApi;