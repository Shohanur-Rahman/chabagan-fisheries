import { apiSlice } from "../api/apiSlice";
const supplierApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getSuppliers: builder.query({
            query: () => ({
                url: `suppliers`
            }),
            providesTags: ["supplier-list"]
        }),
        getSupplerTransections: builder.query({
            query: () => ({
                url: `suppliers/transections`
            }),
            providesTags: ["supplier-list"]
        }),
        getSupplierDropdown: builder.query({
            query: () => ({
                url: `suppliers/dropdown`
            }),
            providesTags: ["supplier-list"]
        }),
        getSupplierAutocomplete: builder.query({
            query: () => ({
                url: `suppliers/autocomplete`
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
                url: `suppliers`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["supplier-list"]
        }),
        updateSupplier: builder.mutation({
            query: (data) => ({
                url: `suppliers`,
                method: "PUT",
                body: data
            }),
            invalidatesTags: ["supplier-list"]
        }),
        deleteSupplier: builder.mutation({
            query: (id) => ({
                url: `suppliers/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["supplier-list"],
        })
    })
});

export const {
    useGetSuppliersQuery,
    useGetSupplerTransectionsQuery,
    useGetSupplierDropdownQuery,
    useGetSupplierAutocompleteQuery,
    useGetSupplierMutation,
    useAddSupplierMutation,
    useUpdateSupplierMutation,
    useDeleteSupplierMutation
} = supplierApi;