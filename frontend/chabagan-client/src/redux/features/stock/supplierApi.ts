import { apiSlice } from "../api/apiSlice";
const supplierApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getSuppliers: builder.query({
            query: () => ({
                url: `/suppliers`
            }),
            providesTags: ["supplier-list"]
        }),
        getSupplier: builder.mutation({
            query: (id) => ({
                url: `suppliers/${id}`
            }),
            invalidatesTags: ["supplier-list"]
        }),
        addSupplier: builder.mutation({
            query: (data) => ({
                url: `/suppliers`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["supplier-list"]
        }),
        updateSupplier: builder.mutation({
            query: (data) => ({
                url: `/suppliers`,
                method: "PUT",
                body: data
            }),
            invalidatesTags: ["supplier-list"]
        }),
        deleteSupplier: builder.mutation({
            query: (id) => ({
                url: `/suppliers/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["supplier-list"],
        })
    })
});

export const {
    useGetSuppliersQuery,
    useGetSupplierMutation,
    useAddSupplierMutation,
    useUpdateSupplierMutation,
    useDeleteSupplierMutation
} = supplierApi;