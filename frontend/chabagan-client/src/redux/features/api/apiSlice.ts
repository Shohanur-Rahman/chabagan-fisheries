import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({
    baseUrl: "http://gewilen510-001-site1.ctempurl.com/api/",
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
    "role-list"
  ],
  endpoints: (builder) => ({}),
});
