import { useCallback, useEffect, useState, type ReactNode } from 'react'
import { authApi } from '../api/auth'
import { UNAUTHORIZED_EVENT } from '../api/client'
import { tokenStorage } from '../api/tokenStorage'
import type { LoginRequest, User } from '../types/auth'
import { AuthContext } from './auth-context'

export function AuthProvider({ children }: { children: ReactNode }) {
  const [user, setUser] = useState<User | null>(null)
  const [initializing, setInitializing] = useState(() => tokenStorage.get() !== null)

  const logout = useCallback(() => {
    tokenStorage.clear()
    setUser(null)
  }, [])

  const login = useCallback(async (data: LoginRequest) => {
    const response = await authApi.login(data)
    tokenStorage.set(response.accessToken)
    setUser(response.user)
  }, [])

  // Restore the session from a stored token
  useEffect(() => {
    if (!tokenStorage.get()) return
    authApi
      .me()
      .then(setUser)
      .catch(logout)
      .finally(() => setInitializing(false))
  }, [logout])

  useEffect(() => {
    window.addEventListener(UNAUTHORIZED_EVENT, logout)
    return () => window.removeEventListener(UNAUTHORIZED_EVENT, logout)
  }, [logout])

  return (
    <AuthContext.Provider value={{ user, initializing, login, logout }}>
      {children}
    </AuthContext.Provider>
  )
}
