import { apiSlice } from "../api/apiSlice";
const salesReturnsApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getSalesReturns: builder.query({
            query: () => ({
                url: `salesreturns`
            }),
            providesTags: ["salesreturns-list"]
        }),
        getSalesReturn: builder.mutation({
            query: (id) => ({
                url: `salesreturns/${id}`
            }),
            invalidatesTags: ["salesreturns-list"]
        }),
        addSalesReturn: builder.mutation({
            query: (data) => ({
                url: `salesreturns`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["salesreturns-list"]
        }),
        updateSalesReturn: builder.mutation({
            query: (data) =>({
                url: `salesreturns`,
                method: "PUT",
                body: data
            }),
            invalidatesTags: ["salesreturns-list"]
        }),
        deleteSalesReturn: builder.mutation({
            query: (id) =>({
                url: `salesreturns/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["salesreturns-list"],
        })
    })
})
 
export const {
    useGetSalesReturnsQuery,
    useAddSalesReturnMutation,
    useGetSalesReturnMutation,
    useUpdateSalesReturnMutation,
    useDeleteSalesReturnMutation
} = salesReturnsApi;