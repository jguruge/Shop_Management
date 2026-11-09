export interface Product {
  id: number
  name: string
  sku: string | null
  price: number
  stockQuantity: number
  categoryId: number | null
}

export type CreateProductRequest = Omit<Product, 'id'>
