import { apiRequest } from './client'
import type { CreateProductRequest, Product } from '../types/product'

export const productsApi = {
  getAll: () => apiRequest<Product[]>('/products'),
  getById: (id: number) => apiRequest<Product>(`/products/${id}`),
  create: (data: CreateProductRequest) =>
    apiRequest<Product>('/products', { method: 'POST', body: JSON.stringify(data) }),
  remove: (id: number) => apiRequest<void>(`/products/${id}`, { method: 'DELETE' }),
}
