# 14 — Reports

All reports have filters (date range, category, brand, customer, supplier, seller as relevant), show on screen, and export to **PDF** and **Excel/CSV**. Reports with cost/profit are Admin/Manager only.

| # | Report | Key columns | Roles |
|---|--------|-------------|-------|
| R-01 | Daily sales summary | Bills, gross sales, discounts, returns, net sales, by payment method | All (Seller: own) |
| R-02 | Sales detail | Sale no, date, customer, seller, items, amount, paid, balance | Admin/Manager |
| R-03 | Sales by product | Qty, revenue, cost, profit, margin % | Admin/Manager |
| R-04 | Sales by category / brand | Same, grouped | Admin/Manager |
| R-05 | Sales by seller | Bills, revenue, discounts, below-min approvals | Admin/Manager |
| R-06 | Profit & loss (simple) | Sales, cost of goods sold, gross profit, expenses by type, net profit | Admin |
| R-07 | Stock on hand | Product, location, qty, cost, value, selling value | Admin/Manager (Seller: qty only) |
| R-08 | Stock movement | Product, date, type, in, out, balance, reference | Admin/Manager |
| R-09 | Low stock / reorder | Product, stock, reorder level, suggested qty, last supplier, last cost | Admin/Manager |
| R-10 | Dead / slow stock | Last sold date, qty, value | Admin/Manager |
| R-11 | Expiry report | Batch, expiry date, qty (lubricants) | Admin/Manager |
| R-12 | Stock valuation | By category/brand, at cost and at selling price | Admin |
| R-13 | Purchases by supplier | Invoices, totals, paid, balance | Admin/Manager |
| R-14 | Supplier payables aging | Current, 1–30, 31–60, 60+ | Admin/Manager |
| R-15 | **Customer statement** | Opening, credits, payments, closing | All |
| R-16 | **Receivables aging** | Customer, Current, 1–7, 8–30, 31–60, 61–90, 90+ | Admin/Manager |
| R-17 | **Weekly unpaid customers** | The weekly alert as a report for any week | All (Seller: own) |
| R-18 | Collections | Payments received by date/customer/method/collector | Admin/Manager |
| R-19 | Credit given vs collected | Per week/month | Admin/Manager |
| R-20 | Price change history | Product, old/new price, who, when | Admin/Manager |
| R-21 | Discounts & below-minimum sales | Sale, product, min price, sold price, approved by | Admin |
| R-22 | Expenses | By type, date, paid by | Admin/Manager |
| R-23 | Day-end / cash drawer | Opening cash, cash in, cash out, expected, counted, difference | Admin/Manager |
| R-24 | Caltex lubricant sales | Litres and value by product line, pack size, month | Admin/Manager |
| R-25 | Audit log | User, action, record, before/after, time | Admin |

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-RP-01 | Reports R-01, R-07, R-09, R-15, R-16, R-17, R-23 in first release. | Must |
| FR-RP-02 | Remaining reports. | Should |
| FR-RP-03 | Scheduled email of daily sales summary and weekly unpaid report to the owner. | Could |
