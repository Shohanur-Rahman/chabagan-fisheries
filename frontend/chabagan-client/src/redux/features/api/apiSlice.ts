import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://localhost:7195/api/",
    credentials: "include",
    prepareHeaders: (headers) => {
      let tokenString = localStorage.getItem("result");
      // debugger;
      if (tokenString !== null) {
        let token = JSON.parse(tokenString).result;
        headers.set("Authorization", `Bearer ${token}`);
      }

      return headers;
    },
  }),
  tagTypes: [
    "user-list",
    "role-list",
    "brand-list",
    "stockcategory-list",
    "products-list",
  ],
  endpoints: (builder) => ({
    getRoles: builder.query({
      query: () => ({
        url: `test`
      }),
      providesTags: ["role-list"]
    })
  }),
});
