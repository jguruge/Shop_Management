import {
  DataTableSkeleton,
  InlineNotification,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableHeader,
  TableRow,
} from '@carbon/react'
import { useProducts } from '../../hooks/useProducts'
import { formatCurrency } from '../../utils/format'

const headers = ['Name', 'SKU', 'Price', 'Stock']

export default function ProductsPage() {
  const { products, loading, error } = useProducts()

  if (loading) return <DataTableSkeleton headers={headers.map((h) => ({ header: h, key: h }))} />
  if (error) return <InlineNotification kind="error" title="Could not load products" subtitle={error} hideCloseButton />

  return (
    <TableContainer title="Products" description="All products in the shop">
      <Table>
        <TableHead>
          <TableRow>
            {headers.map((h) => (
              <TableHeader key={h}>{h}</TableHeader>
            ))}
          </TableRow>
        </TableHead>
        <TableBody>
          {products.length === 0 ? (
            <TableRow>
              <TableCell colSpan={headers.length}>No products yet.</TableCell>
            </TableRow>
          ) : (
            products.map((p) => (
              <TableRow key={p.id}>
                <TableCell>{p.name}</TableCell>
                <TableCell>{p.sku ?? '—'}</TableCell>
                <TableCell>{formatCurrency(p.price)}</TableCell>
                <TableCell>{p.stockQuantity}</TableCell>
              </TableRow>
            ))
          )}
        </TableBody>
      </Table>
    </TableContainer>
  )
}
