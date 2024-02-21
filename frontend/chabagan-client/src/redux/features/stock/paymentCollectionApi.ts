import { apiSlice } from "../api/apiSlice";
const paymentCollectionApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getPaymets: builder.query({
            query: () => ({
                url: `paymentcollections/payments`
            }),
            providesTags: ["paymentcollections-list"]
        }),
        getCollections: builder.query({
            query: () => ({
                url: `paymentcollections/collections`
            }),
            providesTags: ["paymentcollections-list"]
        }),
        getPaymentCollection: builder.mutation({
            query: (id) => ({
                url: `paymentcollections/${id}`
            }),
            invalidatesTags: ["paymentcollections-list"]
        }),
        addPaymentCollection: builder.mutation({
            query: (data) => ({
                url: `paymentcollections`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["paymentcollections-list"]
        }),
        updatePaymentCollection: builder.mutation({
            query: (data) =>({
                url: `paymentcollections`,
                method: "PUT",
                body: data
            }),
            invalidatesTags: ["paymentcollections-list"]
        }),
        deletePaymentCollection: builder.mutation({
            query: (id) =>({
                url: `paymentcollections/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["paymentcollections-list"],
        })
    })
})
 
export const {
    useGetPaymetsQuery,
    useGetCollectionsQuery,
    useGetPaymentCollectionMutation,
    useAddPaymentCollectionMutation,
    useUpdatePaymentCollectionMutation,
    useDeletePaymentCollectionMutation
} = paymentCollectionApi;