import { apiSlice } from "../api/apiSlice";
const salesApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getSales: builder.query({
            query: () => ({
                url: `sales`
            }),
            providesTags: ["sales-list"]
        }),
        getSale: builder.mutation({
            query: (id) => ({
                url: `sales/${id}`
            }),
            invalidatesTags: ["sales-list"]
        }),
        addSale: builder.mutation({
            query: (data) => ({
                url: `sales`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["sales-list"]
        }),
        updateSale: builder.mutation({
            query: (data) =>({
                url: `sales`,
                method: "PUT",
                body: data
            }),
            invalidatesTags: ["sales-list"]
        }),
        deleteSale: builder.mutation({
            query: (id) =>({
                url: `sales/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["sales-list"],
        })
    })
})
 
export const {
    useGetSalesQuery,
    useGetSaleMutation,
    useAddSaleMutation,
    useDeleteSaleMutation,
    useUpdateSaleMutation
} = salesApi;