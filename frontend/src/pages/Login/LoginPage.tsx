import { useState, type FormEvent } from 'react'
import { Button, Form, InlineLoading, InlineNotification, PasswordInput, Stack, TextInput } from '@carbon/react'
import { ArrowRight } from '@carbon/icons-react'
import { Navigate, useLocation, useNavigate } from 'react-router-dom'
import { useAuth } from '../../hooks/useAuth'
import './LoginPage.scss'

export default function LoginPage() {
  const { user, login } = useAuth()
  const navigate = useNavigate()
  const location = useLocation()
  const from = (location.state as { from?: Location } | null)?.from?.pathname ?? '/'

  const [usernameOrEmail, setUsernameOrEmail] = useState('')
  const [password, setPassword] = useState('')
  const [error, setError] = useState<string | null>(null)
  const [submitting, setSubmitting] = useState(false)

  if (user) return <Navigate to={from} replace />

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault()
    setError(null)
    setSubmitting(true)
    try {
      await login({ usernameOrEmail, password })
      navigate(from, { replace: true })
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Login failed')
      setSubmitting(false)
    }
  }

  return (
    <div className="login-page">
      <div className="login-panel">
        <Form onSubmit={handleSubmit} aria-label="Log in">
          <Stack gap={7}>
            <div>
              <h1 className="login-title">Log in</h1>
              <p className="login-subtitle">Shop Management System</p>
            </div>

            {error && (
              <InlineNotification
                kind="error"
                title="Login failed"
                subtitle={error}
                lowContrast
                onClose={() => setError(null)}
              />
            )}

            <TextInput
              id="usernameOrEmail"
              labelText="Username or email"
              autoComplete="username"
              value={usernameOrEmail}
              onChange={(e) => setUsernameOrEmail(e.target.value)}
              required
              autoFocus
            />
            <PasswordInput
              id="password"
              labelText="Password"
              autoComplete="current-password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />

            {submitting ? (
              <InlineLoading description="Logging in..." />
            ) : (
              <Button type="submit" renderIcon={ArrowRight} className="login-button">
                Continue
              </Button>
            )}
          </Stack>
        </Form>
      </div>
    </div>
  )
}
