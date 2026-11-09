import { Navigate, Route, Routes } from 'react-router-dom'
import Layout from '../components/layout/Layout'
import ProtectedRoute from './ProtectedRoute'
import LoginPage from '../pages/Login/LoginPage'
import DashboardPage from '../pages/Dashboard/DashboardPage'
import ProductsPage from '../pages/Products/ProductsPage'
import SalesPage from '../pages/Sales/SalesPage'
import CustomersPage from '../pages/Customers/CustomersPage'

export default function AppRoutes() {
  return (
    <Routes>
      <Route path="/login" element={<LoginPage />} />
      <Route element={<ProtectedRoute />}>
        <Route element={<Layout />}>
          <Route path="/" element={<DashboardPage />} />
          <Route path="/products" element={<ProductsPage />} />
          <Route path="/sales" element={<SalesPage />} />
          <Route path="/customers" element={<CustomersPage />} />
        </Route>
      </Route>
      <Route path="*" element={<Navigate to="/" replace />} />
    </Routes>
  )
}
