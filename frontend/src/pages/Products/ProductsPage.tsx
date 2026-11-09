import { useProducts } from '../../hooks/useProducts'
import { formatCurrency } from '../../utils/format'

export default function ProductsPage() {
  const { products, loading, error } = useProducts()

  if (loading) return <p>Loading...</p>
  if (error) return <p className="error">{error}</p>

  return (
    <>
      <h1>Products</h1>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>SKU</th>
            <th>Price</th>
            <th>Stock</th>
          </tr>
        </thead>
        <tbody>
          {products.map((p) => (
            <tr key={p.id}>
              <td>{p.name}</td>
              <td>{p.sku ?? '-'}</td>
              <td>{formatCurrency(p.price)}</td>
              <td>{p.stockQuantity}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  )
}
