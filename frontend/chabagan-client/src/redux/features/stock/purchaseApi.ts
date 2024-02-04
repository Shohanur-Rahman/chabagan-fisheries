import { apiSlice } from "../api/apiSlice";
const purchaseApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        addDemoPurchase: builder.mutation({
            query: (data) => ({
                url: `purchases/save-demo`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["purchase-list"]
        }),
    })
})

export const {
    useAddDemoPurchaseMutation
} = purchaseApi;