# 22 — Roadmap

## Current status (Nov 2026)

| Done | Item |
|:----:|------|
| ✅ | .NET 10 API (single project, `Features/`), PostgreSQL, EF Core migrations |
| ✅ | Tables: Roles, Users, Categories, Products, Customers, Sales, SaleItems |
| ✅ | JWT login, `/auth/me`, seeded admin, `.env` configuration, Dockerfile |
| ✅ | React + IBM Carbon frontend: login, app shell, protected routes, basic product list |

## Phases

### Phase 1 — Catalog & QR (foundation)
- Categories tree, product types, attribute definitions, brands, units ([04](04-product-configuration.md))
- Full product register with price range and stock settings ([05](05-product-register.md))
- Stock movements + opening stock ([07](07-inventory-and-purchasing.md) §7.1)
- QR code generation, label PDF, scan screen ([06](06-qr-codes.md))
- User management, change password, force change of seeded admin password, audit log ([16](16-users-security-audit.md))

### Phase 2 — Selling & credit (core business)
- Customers with vehicles and credit settings ([10](10-customers.md))
- POS with price-range enforcement, approvals, split payments, receipts ([09](09-sales-and-pos.md))
- Credit sales, payments, allocation, statements, aging ([11](11-credit-sales-and-receivables.md))
- **Weekly unpaid-customer alert** + notification centre ([12](12-notifications-and-alerts.md))
- Seller dashboard and first KPI tiles

### Phase 3 — Purchasing & OCR
- Suppliers, purchase invoices (manual), posting, cost update, supplier item mapping ([07](07-inventory-and-purchasing.md))
- **Invoice OCR** upload → review → post, HEIC support, manual fallback ([08](08-invoice-ocr.md))
- Supplier payments & payables

### Phase 4 — Analytics & operations
- Full seller/accounts and customer dashboards ([13](13-dashboard-and-analytics.md))
- Reports with PDF/Excel export ([14](14-reports.md))
- Expenses, cash drawer, day-end closing, cheques ([15](15-expenses-and-cash.md))
- SMS/WhatsApp reminders, settings screen ([17](17-settings.md))

### Phase 5 — Extras
- Vehicle compatibility search, batches/expiry with FEFO
- Stock count, purchase orders, quotations, warranty claims
- Loyalty points, oil-change service reminders
- Sinhala UI, offline POS queue, multi-branch

## Definition of done (per feature)
1. Requirements in this SRS met (Must items).
2. EF migration added; `db/` SQL exports regenerated.
3. Server-side authorization per [03](03-user-roles-and-permissions.md).
4. Unit tests for business rules; manual test on phone and PC.
5. Audit entries recorded for changes.
