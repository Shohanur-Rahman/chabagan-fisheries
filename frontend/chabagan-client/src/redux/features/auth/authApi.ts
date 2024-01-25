import { apiSlice } from "../api/apiSlice";
import { setToken, setUser } from "./authSlice";
import {jwtDecode} from "jwt-decode";

const authApi = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        signin: builder.mutation({
            query: (signinData) => ({
                url: `account/signin`,
                method: "POST",
                body: signinData,
            }),
            async onQueryStarted(_, { dispatch, queryFulfilled }) {
                try {
                    const { data } = await queryFulfilled;
                    // `onSuccess` side-effect
                    localStorage.setItem("result", JSON.stringify(data));
                    const user = data?.result && jwtDecode(data.result)
                    localStorage.setItem("user", JSON.stringify(user));
                    dispatch(setUser(user));
                    dispatch(setToken(data?.result));

                } catch (err) {
                    // `onError` side-effect
                    console.log("error", err);
                }
            },
        }),

        signup: builder.mutation({
            query: (signupData) => ({
                url: `account/signup`,
                method: "POST",
                body: signupData,
            }),
            async onQueryStarted(_, { dispatch, queryFulfilled }) {
                try {
                    const { data } = await queryFulfilled;
                    // `onSuccess` side-effect
                    localStorage.setItem("result", JSON.stringify(data));
                    const user = data?.result && jwtDecode(data.result)
                    localStorage.setItem("user", JSON.stringify(user));
                    dispatch(setUser(user));
                    dispatch(setToken(data?.result));
                } catch (err) {
                    // `onError` side-effect
                    console.log("error", err);
                }
            },
        }),

        forgetPasswordRequest: builder.mutation({
            query: (forgetPasswordData) => ({
                url: `account/password-request?email=${forgetPasswordData.email}`,
                method: "POST",
            })
        }),

        validatePasswordToken: builder.mutation({
            query: (tokenObject) => ({
                url: `account/validate-password-request?token=${tokenObject.token}`,
                method: "POST",
            })
        }),

        resetPassword: builder.mutation({
            query: (requestData) => ({
                url: `account/complete-password-request`,
                method: "POST",
                body: requestData,
            })
        })
    }),
});

export const { 
    useSigninMutation, 
    useSignupMutation, 
    useForgetPasswordRequestMutation, 
    useValidatePasswordTokenMutation,
    useResetPasswordMutation
 } = authApi;
