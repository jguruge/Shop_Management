# 20 — UI Screens

React + **IBM Carbon Design System** (already used: UI Shell header + side nav, login page, data tables). Must work on desktop (shop PC) and phone (QR scanning, invoice photos).

## 20.1 Navigation (side nav)

```
Dashboard
Sales
  ├─ New sale (POS)
  ├─ Sales history
  ├─ Returns
  └─ Quotations
Scan QR                      ← also a floating button on mobile
Customers
  ├─ Customer list
  ├─ Receivables / collection list
  └─ Weekly unpaid alerts
Products
  ├─ Product list
  ├─ Register product
  ├─ Print QR labels
  └─ Import
Inventory
  ├─ Stock on hand
  ├─ Adjustments
  ├─ Stock count
  └─ Reorder suggestions
Purchasing
  ├─ Purchase invoices
  ├─ Upload invoice (OCR)
  └─ Suppliers
Expenses & Cash
Reports
Configuration                ← Admin/Manager
  ├─ Categories
  ├─ Product types & attributes
  ├─ Brands
  ├─ Units
  └─ Vehicles
Administration               ← Admin
  ├─ Users
  ├─ Settings
  └─ Audit log
```

Header: shop name, global search (products/customers/sales), **Scan** button, notification bell, user menu (change password, logout).

## 20.2 Screens

| Screen | Carbon components | Notes |
|--------|------------------|-------|
| Login | Form, TextInput, PasswordInput, Button | ✅ exists |
| Dashboard | Tiles, `@carbon/charts-react`, DataTable, DatePicker | Role-based (see [13](13-dashboard-and-analytics.md)) |
| POS | Search, DataTable (cart), NumberInput, ComboBox (customer), Modal (payment, approval PIN) | Keyboard-first on PC; big buttons on tablet |
| Scan QR | Camera view, price card (Tile), StructuredList (details), Buttons | Mobile-first |
| Product list | DataTable with toolbar search, filters (FilterableMultiSelect), batch actions (print labels, export) | ✅ basic version exists |
| Register/Edit product | ProgressIndicator (Type → Details → Pricing → Stock → Photos), dynamic form from attributes, FileUploader | |
| Product detail | Tabs: Overview, Stock, Price history, Sales, Purchases; QR preview | |
| Category tree | TreeView | |
| Product type editor | DataTable of attributes with drag reorder, Modal for attribute | |
| Upload invoice (OCR) | FileUploaderDropContainer / camera capture, InlineLoading, then split view: image viewer + form | Amber/red field highlights |
| Purchase invoice | Header form + editable line DataTable | Manual entry mode with required fields only |
| Customer list | DataTable, Tag for status/overdue | |
| Customer profile | Tabs: Account, Credit sales, Payments, Purchases, Vehicles, Notes & reminders | Call/WhatsApp buttons |
| Receive payment | Modal: amount, method, allocation table | |
| Collection list / weekly alert | DataTable sorted by overdue; batch action "Send reminders" | |
| Reports | List → report page with filters + export (PDF/Excel) | |
| Settings | Tabs per group | |
| Users | DataTable + Modal | |
| Audit log | DataTable with filters, expandable row for changes | |

## 20.3 UX rules

- Amounts formatted `LKR 12,500.00`; dates `14 Nov 2026`.
- Destructive actions use Carbon danger modals.
- Every list has empty, loading (skeleton) and error states.
- Forms validate inline; server errors shown with InlineNotification.
- Sinhala UI translation is a later phase; all UI text goes through an i18n layer from the start.
