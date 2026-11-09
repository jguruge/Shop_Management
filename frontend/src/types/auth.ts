export interface User {
  id: number
  username: string
  email: string
  fullName: string
  role: string
}

export interface LoginRequest {
  usernameOrEmail: string
  password: string
}

export interface LoginResponse {
  accessToken: string
  expiresAt: string
  user: User
}
