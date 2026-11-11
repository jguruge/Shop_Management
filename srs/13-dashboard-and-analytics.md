# 13 — Dashboard & Analytics

Two views of the business: the **seller / accounts side** (money, stock, profit, what the shop owes) and the **customer side** (who buys, who owes, how they behave). All widgets have a date filter (Today, This week, This month, Custom) and update when data changes.

Cost, profit and margin widgets are visible to **Admin/Manager** only. Sellers see a personal dashboard (13.4).

## 13.1 Top KPI tiles (Admin/Manager)

| Tile | Calculation |
|------|-------------|
| Sales today | Σ sale totals today (and vs. same day last week) |
| Cash collected today | Cash + card + transfer received today (sales + credit repayments) |
| Gross profit (period) | Σ (sale price − cost) for items sold |
| Gross margin % | Gross profit ÷ net sales |
| **Outstanding receivables** | Σ customer balances |
| **Overdue receivables** | Σ balances past due date |
| Payables due | Σ supplier balances due within 7 days |
| Stock value | Σ stock × cost |
| Low-stock items | Count ≤ reorder level |
| Expenses (period) | Σ expenses |
| Net profit (period) | Gross profit − expenses |

## 13.2 Seller / accounts side

| Widget | Chart | Purpose |
|--------|-------|---------|
| Sales trend | Line (daily, last 30 days; weekly/monthly toggle) | Is business growing? |
| Sales by payment method | Stacked bar per day | How much is cash vs credit |
| **Cash vs credit sales** | Donut + trend | Credit dependence |
| Sales by category | Bar (Lubricants vs Spare parts, then sub-categories) | What sells |
| Top 10 products | Table: qty, revenue, profit | Best sellers |
| Slow / dead stock | Table: no sale in 60/90 days, stock value tied up | What to clear |
| Lubricants (Caltex) performance | Bar by product line & pack size; litres sold | Supplier targets / rebates |
| Profit by category / brand | Bar | Where margin comes from |
| Stock value by category | Bar | Where money is tied up |
| Purchases by supplier | Bar | Supplier spend |
| Payables aging | Stacked bar | What the shop owes and when |
| Cash flow | Bar: money in (sales + repayments) vs money out (supplier payments + expenses) per week | Liquidity |
| Expenses by type | Donut | Cost control |
| Seller performance | Table per seller: sales, # bills, avg bill, discounts given, below-min approvals | Staff view |
| Discounts given | Line | Margin leakage |

## 13.3 Customer side

| Widget | Chart | Purpose |
|--------|-------|---------|
| **Receivables aging** | Stacked bar: Current / 1–7 / 8–30 / 31–60 / 61–90 / 90+ | Collection risk |
| **Top debtors** | Table: customer, balance, overdue days, last payment, phone | Who to call |
| Collections trend | Line: amount collected per week vs new credit given per week | Is debt growing? |
| Weekly unpaid alert history | Line: outstanding & overdue at each week end | Trend of the weekly alert |
| Top customers by sales | Table: revenue, profit, # visits | Best customers |
| Customers by type | Donut: Walk-in / Regular / Garage / Fleet — share of sales | Customer mix |
| New vs returning customers | Bar per month | Growth |
| Average days to pay | Number + trend, per customer type | Payment behaviour |
| Credit limit utilisation | Table: customers > 80% of limit | Risk |
| Customer purchase frequency | Histogram | Loyalty |
| Vehicles served | Bar by make/model | What vehicles to stock for |
| Payment promises due | List: promises due today/this week | Follow-up |

## 13.4 Seller's own dashboard

- My sales today / this week, number of bills
- My credit sales and how much of it is collected
- My customers with overdue balance (from the weekly alert)
- Low-stock items (no cost data)
- Quick actions: **Scan QR**, **New sale**, **Receive payment**, **Add customer**

## 13.5 Requirements

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-DB-01 | Dashboards as described above, filtered by role. | Must |
| FR-DB-02 | Every widget has a date filter and drills down to the underlying list/report. | Must |
| FR-DB-03 | Dashboard loads in < 3 s with 2 years of data (use summary tables / materialised views if needed). | Must |
| FR-DB-04 | Charts use IBM Carbon Charts (`@carbon/charts-react`) to match the UI. | Should |
| FR-DB-05 | Export any widget's data to CSV. | Could |
| FR-DB-06 | Comparison to previous period (▲/▼ %) on KPI tiles. | Should |
