const TOKEN_KEY = 'shop.accessToken'

export const tokenStorage = {
  get(): string | null {
    try {
      return localStorage.getItem(TOKEN_KEY)
    } catch {
      return null
    }
  },
  set(token: string) {
    try {
      localStorage.setItem(TOKEN_KEY, token)
    } catch {
      // storage unavailable; session lasts until reload
    }
  },
  clear() {
    try {
      localStorage.removeItem(TOKEN_KEY)
    } catch {
      // ignore
    }
  },
}
