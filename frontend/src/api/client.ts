import { tokenStorage } from './tokenStorage'

const BASE_URL = import.meta.env.VITE_API_BASE_URL

export const UNAUTHORIZED_EVENT = 'auth:unauthorized'

export async function apiRequest<T>(path: string, init?: RequestInit): Promise<T> {
  const token = tokenStorage.get()

  const response = await fetch(`${BASE_URL}${path}`, {
    ...init,
    headers: {
      'Content-Type': 'application/json',
      ...(token ? { Authorization: `Bearer ${token}` } : {}),
      ...init?.headers,
    },
  })

  if (!response.ok) {
    if (response.status === 401 && token) {
      window.dispatchEvent(new Event(UNAUTHORIZED_EVENT))
    }
    const problem = await response.json().catch(() => null)
    throw new Error(problem?.detail ?? `Request failed with status ${response.status}`)
  }

  return response.status === 204 ? (undefined as T) : response.json()
}
