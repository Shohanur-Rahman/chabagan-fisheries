import { createSlice } from "@reduxjs/toolkit";
import { IUserResponse } from "../../../interfaces/IUserResponse"; 
import {jwtDecode} from "jwt-decode";

const userString = localStorage.getItem("result");
const user = userString ? JSON.parse(userString) : (null as any);

const verifyToken = () => {
	if (user?.result) {
		const decodeToken: any = jwtDecode(user?.result);
		const expiresTime = new Date(decodeToken.exp * 1000);
		if (expiresTime < new Date()) {
			localStorage.removeItem("user");
			return null;
		} else {
			return {
				token: user?.result,
				user: decodeToken
			};
		}
	} else {
		return null;
	}
};

export const authSlice = createSlice({
	name: "auth",
	initialState: {
		token: verifyToken()?.token,
		user: verifyToken()?.user,
	},
	reducers: {
		setUser: (state, { payload }) => {
			state.user = payload;
		},
		setToken: (state, { payload }) => {
			state.token = payload;
		},
		logout: (state) => {
			state.token = null;
			state.user = null;
		},
	},
});

export const { setUser, setToken, logout } = authSlice.actions;
export default authSlice.reducer;

// selectors
export const selectToken = (state: { auth: { token: string; }; }) => state.auth.token;
export const selectUser = (state: { auth: { user: IUserResponse; }; }) => state.auth.user;
