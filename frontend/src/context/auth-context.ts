import { createContext } from 'react'
import type { LoginRequest, User } from '../types/auth'

export interface AuthContextValue {
  user: User | null
  initializing: boolean
  login: (data: LoginRequest) => Promise<void>
  logout: () => void
}

export const AuthContext = createContext<AuthContextValue | null>(null)
