import { apiSlice } from "../api/apiSlice";
const productApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getProducts: builder.query({
            query: () => ({
                url: `products`
            }),
            providesTags: ["products-list"]
        })
    })
});

export const { 
    useGetProductsQuery
} = productApi;