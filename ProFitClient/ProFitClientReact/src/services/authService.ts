import axios, { AxiosError } from 'axios';
import Swal from 'sweetalert2'
import User from '../models/userType'
import { LoginRequest, RegisterRequest, AuthResponse } from '../models/authTypes';

const API_URL = 'https://localhost:7131/api/auth'; // שנה לכתובת ה-API שלך

export const login = async (credentials: LoginRequest): Promise<User> => {
    try {
        const response = await axios.post<AuthResponse>(`${API_URL}/login`, credentials);
        if (!response.data) {
            throw "Invalid response data";
        }
        const { token, user } = response.data;
        localStorage.setItem('token', token);
        return user;
    }
    catch (error: unknown) {
        console.log("error registration", login);
        if (axios.isAxiosError(error) && error.response && error.response.status === 400) {
            Swal.fire({
                title: "Login failed.",
                text: "Please check your email and password.",
                icon: "error",
            });
        }
        throw error;
    }
};

export const register = async (userData: RegisterRequest): Promise<AuthResponse | undefined> => {
    try {
        const response = await axios.post<AuthResponse>(`${API_URL}/register`, userData);
        if (!response.data) {
            throw "Invalid response data";
        }
        const { token, user } = response.data;

        localStorage.setItem('token', token);
        Swal.fire({
            title: "Registration completed successfully.",
            icon: "success",
            timer: 3000,
            showConfirmButton: false
        });
        return { user, token };
    } catch (error) {
        if (axios.isAxiosError(error) && error.response) {
            console.log("error registration", error);
            Swal.fire({
                title: "Registration failed.",
                text: error.response.data["message"],
                icon: "error",
            });
        }
        throw error;
    }
};

export const logout = async () => {
    localStorage.removeItem('token');
    return Promise.resolve();
};
