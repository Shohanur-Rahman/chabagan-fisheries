import { apiSlice } from "../api/apiSlice";
const purchaseApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getPurchases: builder.query({
            query: () => ({
                url: `purchases`
            }),
            providesTags: ["purchase-list"]
        }),
        getPurchase: builder.mutation({
            query: (id) => ({
                url: `purchases/${id}`
            }),
            invalidatesTags: ["purchase-list"]
        }),
        addPurchase: builder.mutation({
            query: (data) => ({
                url: `purchases`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["purchase-list"]
        }),
        updatePurchase: builder.mutation({
            query: (data) =>({
                url: `purchases`,
                method: "PUT",
                body: data
            }),
            invalidatesTags: ["purchase-list"]
        }),
        deletePurchase: builder.mutation({
            query: (id) =>({
                url: `purchases/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["purchase-list"],
        })
    })
})

export const {
    useGetPurchasesQuery,
    useAddPurchaseMutation,
    useGetPurchaseMutation,
    useUpdatePurchaseMutation,
    useDeletePurchaseMutation
} = purchaseApi;