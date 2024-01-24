import { apiSlice } from "../api/apiSlice";
const productApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getProducts: builder.query({
            query: () => ({
                url: `products`
            }),
            providesTags: ["products-list"]
        }),
        getProduct: builder.mutation({
            query: (id) => ({
                url: `products/${id}`
            }),
            invalidatesTags: ["products-list"]
        }),
        addProduct: builder.mutation({
            query: (data) => ({
                url: `/products`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["products-list"]
        }),
        updateProduct: builder.mutation({
            query: (data) => ({
                url: `/products`,
                method: "PUT",
                body: data
            }),
            invalidatesTags: ["products-list"]
        }),
        deleteProduct: builder.mutation({
            query: (id) => ({
                url: `/products/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["products-list"],
        })
    })
});

export const {
    useGetProductsQuery,
    useGetProductMutation,
    useAddProductMutation,
    useUpdateProductMutation,
    useDeleteProductMutation
} = productApi;