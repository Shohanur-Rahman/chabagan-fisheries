import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { ApiBaseURL } from "../../../data/Config";

export const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({
    baseUrl: ApiBaseURL,
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
    "supplier-list",
    "projects-list",
    "purchase-list",
    "purchases-list",
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
