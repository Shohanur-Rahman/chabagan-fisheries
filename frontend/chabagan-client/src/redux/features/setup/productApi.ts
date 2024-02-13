import { apiSlice } from "../api/apiSlice";
const productApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getProducts: builder.query({
            query: () => ({
                url: `products`
            }),
            providesTags: ["products-list"]
        }),
        getAllProductStocks: builder.query({
            query: () => ({
                url: `products/stocks`
            }),
            providesTags: ["products-list"]
        }),
        getProductStocks: builder.mutation({
            query: (id?: number, brandId?: number) => ({
                url: `products/stocks?productId=${id}&brandId=${brandId}`
            }),
            invalidatesTags: ["products-list"]
        }),
        getProductStockById: builder.mutation({
            query: ({ id, brandId }) => ({
                url: `products/stock/${id}${brandId ? `?brandId=${brandId}` : ''}`
            }),
            invalidatesTags: ["products-list"]
        }),
        getProductAutocomplete: builder.query({
            query: () => ({
                url: `products/autocomplete`
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
                url: `products`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["products-list"]
        }),
        updateProduct: builder.mutation({
            query: (data) => ({
                url: `products`,
                method: "PUT",
                body: data
            }),
            invalidatesTags: ["products-list"]
        }),
        deleteProduct: builder.mutation({
            query: (id) => ({
                url: `products/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["products-list"],
        })
    })
});

export const {
    useGetProductsQuery,
    useGetAllProductStocksQuery,
    useGetProductStocksMutation,
    useGetProductStockByIdMutation,
    useGetProductAutocompleteQuery,
    useGetProductMutation,
    useAddProductMutation,
    useUpdateProductMutation,
    useDeleteProductMutation
} = productApi;