import { NavLink } from 'react-router-dom'

const links = [
  { to: '/', label: 'Dashboard' },
  { to: '/products', label: 'Products' },
  { to: '/sales', label: 'Sales' },
  { to: '/customers', label: 'Customers' },
]

export default function Sidebar() {
  return (
    <aside className="sidebar">
      <h2>Shop Management</h2>
      <nav>
        {links.map((link) => (
          <NavLink key={link.to} to={link.to} end>
            {link.label}
          </NavLink>
        ))}
      </nav>
    </aside>
  )
}
