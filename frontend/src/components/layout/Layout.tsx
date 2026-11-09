import {
  Header,
  HeaderContainer,
  HeaderGlobalAction,
  HeaderGlobalBar,
  HeaderMenuButton,
  HeaderName,
  SideNav,
  SideNavItems,
  SideNavLink,
  SkipToContent,
  Theme,
} from '@carbon/react'
import { Dashboard, Logout, Product, ShoppingCart, UserMultiple } from '@carbon/icons-react'
import { Link, Outlet, useLocation, useNavigate } from 'react-router-dom'
import { useAuth } from '../../hooks/useAuth'

const navItems = [
  { to: '/', label: 'Dashboard', icon: Dashboard },
  { to: '/products', label: 'Products', icon: Product },
  { to: '/sales', label: 'Sales', icon: ShoppingCart },
  { to: '/customers', label: 'Customers', icon: UserMultiple },
]

export default function Layout() {
  const { user, logout } = useAuth()
  const { pathname } = useLocation()
  const navigate = useNavigate()

  const handleLogout = () => {
    logout()
    navigate('/login', { replace: true })
  }

  return (
    <>
      <Theme theme="g100">
        <HeaderContainer
          render={({ isSideNavExpanded, onClickSideNavExpand }) => (
            <Header aria-label="Shop Management">
              <SkipToContent />
              <HeaderMenuButton
                aria-label={isSideNavExpanded ? 'Close menu' : 'Open menu'}
                onClick={onClickSideNavExpand}
                isActive={isSideNavExpanded}
                aria-expanded={isSideNavExpanded}
              />
              <HeaderName as={Link} to="/" prefix="Shop">
                Management
              </HeaderName>
              <HeaderGlobalBar>
                <span className="cds--header__name header-user">{user?.fullName}</span>
                <HeaderGlobalAction aria-label="Log out" tooltipAlignment="end" onClick={handleLogout}>
                  <Logout size={20} />
                </HeaderGlobalAction>
              </HeaderGlobalBar>
              <SideNav aria-label="Side navigation" expanded={isSideNavExpanded} onSideNavBlur={onClickSideNavExpand}>
                <SideNavItems>
                  {navItems.map(({ to, label, icon }) => (
                    <SideNavLink key={to} as={Link} to={to} renderIcon={icon} isActive={pathname === to}>
                      {label}
                    </SideNavLink>
                  ))}
                </SideNavItems>
              </SideNav>
            </Header>
          )}
        />
      </Theme>
      <main id="main-content" className="app-content">
        <Outlet />
      </main>
    </>
  )
}
