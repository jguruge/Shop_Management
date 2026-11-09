import { Column, Grid, Tile } from '@carbon/react'
import { useAuth } from '../../hooks/useAuth'

export default function DashboardPage() {
  const { user } = useAuth()

  return (
    <>
      <div className="page-header">
        <h1>Dashboard</h1>
        <p>Welcome back, {user?.fullName}. You are signed in as {user?.role}.</p>
      </div>
      <Grid condensed>
        {['Today’s sales', 'Products', 'Customers', 'Low stock'].map((label) => (
          <Column key={label} sm={4} md={4} lg={4}>
            <Tile>
              <p>{label}</p>
              <h2>—</h2>
            </Tile>
          </Column>
        ))}
      </Grid>
    </>
  )
}
