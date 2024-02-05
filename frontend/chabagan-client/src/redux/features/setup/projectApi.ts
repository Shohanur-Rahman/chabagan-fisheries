import { apiSlice } from "../api/apiSlice";
const projectApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getProjects: builder.query({
            query: () => ({
                url: `projects`
            }),
            providesTags: ["projects-list"]
        }),
        getProjectAutoComplete: builder.query({
            query: () => ({
                url: `projects/autocomplete`
            }),
            providesTags: ["projects-list"]
        }),
        getProject: builder.mutation({
            query: (id) => ({
                url: `projects/${id}`
            }),
            invalidatesTags: ["projects-list"]
        }),
        addProject: builder.mutation({
            query: (data) => ({
                url: `projects`,
                method: "POST",
                body: data
            }),
            invalidatesTags: ["projects-list"]
        }),
        updateProject: builder.mutation({
            query: (data) => ({
                url: `projects`,
                method: "PUT",
                body: data
            }),
            invalidatesTags: ["projects-list"]
        }),
        deleteProject: builder.mutation({
            query: (id) => ({
                url: `projects/${id}`,
                method: "DELETE"
            }),
            invalidatesTags: ["projects-list"],
        })
    })
});

export const {
    useGetProjectsQuery,
    useGetProjectAutoCompleteQuery,
    useGetProjectMutation,
    useAddProjectMutation,
    useUpdateProjectMutation,
    useDeleteProjectMutation
} = projectApi;