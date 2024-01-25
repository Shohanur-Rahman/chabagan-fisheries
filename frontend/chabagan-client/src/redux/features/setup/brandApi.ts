import { apiSlice } from "../api/apiSlice";
const brandsApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getBrands: builder.query({
            query: () => ({
                url: `brands`
            }),
            providesTags: ["brand-list"]
        }),
        getBrandAutocomplete: builder.query({
            query: () => ({
                url: `brands/autocomplete`
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
            query: (data) => ({
                url: `brands`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["brand-list"]
        }),
        updateBrand: builder.mutation({
            query: (data) =>({
                url: `brands`,
                method: "PUT",
                body: data
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

export const { 
    useGetBrandsQuery,
    useGetBrandAutocompleteQuery, 
    useGetBrandMutation , 
    useDeleteBrandMutation, 
    useAddBrandMutation, 
    useUpdateBrandMutation
} = brandsApi;