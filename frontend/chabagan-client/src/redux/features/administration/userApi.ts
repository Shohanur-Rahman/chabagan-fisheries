import { apiSlice } from "../api/apiSlice";

const userApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getUsers: builder.query({
            query: () => ({
                url: `/users`
            })
        }),
        addUser: builder.mutation({
            query: (userData) =>({
                url: `/users`,
                method: "POST",
                body: userData
            })
        })
    })
});

export const {useGetUsersQuery, useAddUserMutation} = userApi;