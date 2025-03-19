import React from 'react';
import { useForm, SubmitHandler } from 'react-hook-form';
import { TextField, Button, Container, Typography, Box } from '@mui/material';
import { useDispatch } from 'react-redux';
import { AppDispatch } from '../../redux/store';
import { registerUser } from '../../redux/slices/userSlice';
import validationRules from '../../validations/RegisterValidations';

interface FormData {
    username: string;
    email: string;
    password: string;
    confirmPassword: string;
}

const Register: React.FC = () => {
    const dispatch = useDispatch<AppDispatch>();
    const { register, handleSubmit, formState: { errors }, watch } = useForm<FormData>({
        mode: 'onBlur'
    });

    const onSubmit: SubmitHandler<FormData> = async (data) => {
        const resultAction = await dispatch(registerUser(data));
        if (registerUser.fulfilled.match(resultAction)) {
            console.log('Registration successful:', resultAction.payload);
        } else {
            console.log('Registration failed:', resultAction.payload);
        }
    };

    return (
        <Container maxWidth="sm">
            <Box mt={5}>
                <Typography variant="h4" component="h1" gutterBottom>
                    Register
                </Typography>
                <form onSubmit={handleSubmit(onSubmit)} noValidate>
                    <TextField
                        label="Username"
                        {...register("username", validationRules.username)}
                        fullWidth
                        margin="normal"
                        error={!!errors.username}
                        helperText={errors.username ? errors.username.message : ''}
                    />
                    <TextField
                        label="Email"
                        type="email"
                        {...register("email", validationRules.email)}
                        fullWidth
                        margin="normal"
                        error={!!errors.email}
                        helperText={errors.email ? errors.email.message : ''}
                    />
                    <TextField
                        label="Password"
                        type="password"
                        {...register("password", validationRules.password)}
                        fullWidth
                        margin="normal"
                        error={!!errors.password}
                        helperText={errors.password ? errors.password.message : ''}
                    />
                    <TextField
                        label="Confirm Password"
                        type="password"
                        {...register("confirmPassword", { 
                            ...validationRules.confirmPassword,
                            validate: (value) => validationRules.confirmPassword.validate(value, watch("password"))
                        })}
                        fullWidth
                        margin="normal"
                        error={!!errors.confirmPassword}
                        helperText={errors.confirmPassword ? errors.confirmPassword.message : ''}
                    />
                    <Box mt={2}>
                        <Button type="submit" variant="contained" color="primary" fullWidth>
                            Register
                        </Button>
                    </Box>
                </form>
            </Box>
        </Container>
    );
};

export default Register;
