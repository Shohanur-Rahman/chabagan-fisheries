import { apiSlice } from "../api/apiSlice";

const rolesApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getRoles: builder.query({
            query: () => ({
                url: `roles`
            }),
            providesTags: ["role-list"]
        }),
        getRole: builder.mutation({
            query: (id) => ({
                url: `roles/${id}`
            }),
            invalidatesTags: ["role-list"]
        }),
        addRole: builder.mutation({
            query: (data) => ({
                url: `/roles`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["role-list"]
        }),
        updateRole: builder.mutation({
            query: (data) => ({
                url: `/roles`,
                method: "PUT",
                body: data
            }),
            invalidatesTags: ["role-list"]
        }),
        deleteRole: builder.mutation({
            query: (id) => ({
                url: `roles/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["role-list"],
        })
    })
});

export const { useAddRoleMutation, useGetRolesQuery, useDeleteRoleMutation, useGetRoleMutation, useUpdateRoleMutation } = rolesApi;
