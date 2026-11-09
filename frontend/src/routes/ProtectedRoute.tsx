import { Loading } from '@carbon/react'
import { Navigate, Outlet, useLocation } from 'react-router-dom'
import { useAuth } from '../hooks/useAuth'

export default function ProtectedRoute() {
  const { user, initializing } = useAuth()
  const location = useLocation()

  if (initializing) return <Loading withOverlay description="Loading session" />
  if (!user) return <Navigate to="/login" replace state={{ from: location }} />

  return <Outlet />
}
