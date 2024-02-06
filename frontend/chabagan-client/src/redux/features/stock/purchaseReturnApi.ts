import { apiSlice } from "../api/apiSlice";
const purchaseReturnApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getPurchaseReturns: builder.query({
            query: () => ({
                url: `purchasereturns`
            }),
            providesTags: ["purchases-list"]
        }),
        getPurchaseReturn: builder.mutation({
            query: (id) => ({
                url: `purchasereturns/${id}`
            }),
            invalidatesTags: ["purchases-list"]
        }),
        addPurchaseReturn: builder.mutation({
            query: (data) => ({
                url: `purchasereturns`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["purchases-list"]
        }),
        updatePurchaseReturn: builder.mutation({
            query: (data) =>({
                url: `purchasereturns`,
                method: "PUT",
                body: data
            }),
            invalidatesTags: ["purchases-list"]
        }),
        deletePurchaseReturn: builder.mutation({
            query: (id) =>({
                url: `purchasereturns/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["purchases-list"],
        })
    })
})
 
export const {
    useGetPurchaseReturnsQuery,
    useAddPurchaseReturnMutation,
    useGetPurchaseReturnMutation,
    useUpdatePurchaseReturnMutation,
    useDeletePurchaseReturnMutation
} = purchaseReturnApi;