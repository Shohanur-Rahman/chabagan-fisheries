import { apiSlice } from "../api/apiSlice";

const userApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getUsers: builder.query({
            query: () => ({
                url: `/users`
            }),
            providesTags: ["user-list"],
        }),
        getUser: builder.query({
            query: (id) => ({
                url: `users/${id}`
            }),
            providesTags: ["user-list"]
        }),
        addUser: builder.mutation({
            query: (userData) => ({
                url: `/users`,
                method: "POST",
                body: userData,
            }),
            invalidatesTags: ["user-list"],
        }),
        deleteUser: builder.mutation({
            query: (id) => ({
                url: `users/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["user-list"]
        })
    })
});

export const { useGetUsersQuery, useAddUserMutation, useDeleteUserMutation, useGetUserQuery } = userApi;