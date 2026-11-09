import { apiRequest } from './client'
import type { LoginRequest, LoginResponse, User } from '../types/auth'

export const authApi = {
  login: (data: LoginRequest) =>
    apiRequest<LoginResponse>('/auth/login', { method: 'POST', body: JSON.stringify(data) }),
  me: () => apiRequest<User>('/auth/me'),
}
