# Shop Management System — Software Requirements Specification (SRS)

A shop management system for a **vehicle spare parts and Caltex lubricant store**. It covers everything from product setup to customer credit, QR codes on the shelf, invoice OCR, and analytics dashboards.

## Documents

| # | Document | What it covers |
|---|----------|----------------|
| 01 | [Introduction](01-introduction.md) | Purpose, scope, business context, glossary |
| 02 | [System Overview](02-system-overview.md) | Architecture, modules, tech stack |
| 03 | [User Roles & Permissions](03-user-roles-and-permissions.md) | Admin, Manager, Seller; permission matrix |
| 04 | [Product Configuration](04-product-configuration.md) | Categories, product types, attributes, brands, units |
| 05 | [Product Register](05-product-register.md) | Registering products, pricing and price range, stock settings |
| 06 | [QR Codes](06-qr-codes.md) | QR generation, labels, scan to view price and details |
| 07 | [Inventory & Purchasing](07-inventory-and-purchasing.md) | Suppliers, purchase invoices (GRN), stock movements |
| 08 | [Invoice OCR](08-invoice-ocr.md) | Upload invoice photo, OCR auto-fill, manual fallback |
| 09 | [Sales & POS](09-sales-and-pos.md) | Selling, payments, receipts, returns |
| 10 | [Customers](10-customers.md) | Customer register, vehicles, credit limits |
| 11 | [Credit Sales & Receivables](11-credit-sales-and-receivables.md) | Goods given without payment, repayments, aging |
| 12 | [Notifications & Alerts](12-notifications-and-alerts.md) | Weekly unpaid-customer alert, low stock, expiry |
| 13 | [Dashboard & Analytics](13-dashboard-and-analytics.md) | Seller/accounts side and customer side analytics |
| 14 | [Reports](14-reports.md) | Printable/exportable reports |
| 15 | [Expenses & Cash Management](15-expenses-and-cash.md) | Expenses, cash drawer, day-end closing |
| 16 | [Users, Security & Audit](16-users-security-audit.md) | Login, passwords, audit log |
| 17 | [Settings](17-settings.md) | Shop profile, tax, numbering, alert schedule |
| 18 | [Data Model](18-data-model.md) | Entities, fields, relationships |
| 19 | [API Endpoints](19-api-endpoints.md) | REST API per feature |
| 20 | [UI Screens](20-ui-screens.md) | Screen list and navigation (IBM Carbon) |
| 21 | [Non-Functional Requirements](21-non-functional-requirements.md) | Performance, security, backup, usability |
| 22 | [Roadmap](22-roadmap.md) | Delivery phases and current status |

## Requirement IDs

Every requirement has an ID so it can be traced to code, tests and tickets.

| Prefix | Area | Prefix | Area |
|--------|------|--------|------|
| `FR-PC` | Product configuration | `FR-CR` | Credit & receivables |
| `FR-PR` | Product register | `FR-NT` | Notifications |
| `FR-QR` | QR codes | `FR-DB` | Dashboard |
| `FR-INV` | Inventory & purchasing | `FR-RP` | Reports |
| `FR-OCR` | Invoice OCR | `FR-EX` | Expenses & cash |
| `FR-SL` | Sales & POS | `FR-SEC` | Users & security |
| `FR-CU` | Customers | `FR-ST` | Settings |
| `NFR` | Non-functional | | |

Priority: **Must** (needed for first release), **Should** (important, can follow shortly after), **Could** (nice to have).
