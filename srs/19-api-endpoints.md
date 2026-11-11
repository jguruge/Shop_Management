# 19 — API Endpoints

Base URL: `/api`. JSON. All endpoints require `Authorization: Bearer <token>` unless marked 🌐 (public). Lists support `?page=&pageSize=&search=&sort=`. Errors return `{ "status", "detail" }`.

## Auth & users
| Method | Path | Notes |
|--------|------|-------|
| POST 🌐 | `/auth/login` | ✅ exists |
| GET | `/auth/me` | ✅ exists |
| POST | `/auth/refresh` · `/auth/logout` | Refresh tokens |
| POST | `/auth/change-password` | |
| GET/POST/PUT | `/users`, `/users/{id}` | Admin |
| POST | `/users/{id}/reset-password` · `/users/{id}/deactivate` | Admin |
| POST | `/approvals/verify-pin` | Manager PIN for overrides |

## Catalog
| Method | Path |
|--------|------|
| GET/POST/PUT/DELETE | `/categories`, `/categories/{id}`, `GET /categories/tree` |
| GET/POST/PUT/DELETE | `/product-types`, `/product-types/{id}` |
| GET/POST/PUT/DELETE | `/product-types/{id}/attributes`, `/attributes/{id}`; `PUT /product-types/{id}/attributes/order` |
| GET/POST/PUT/DELETE | `/brands`, `/units`, `/vehicles` |

## Products & QR
| Method | Path | Notes |
|--------|------|-------|
| GET/POST | `/products` | ✅ exists (basic) — extend with filters & attributes |
| GET/PUT/DELETE | `/products/{id}` | ✅ exists (GET/DELETE) |
| POST | `/products/{id}/clone` · `/products/{id}/deactivate` | |
| POST | `/products/import` · GET `/products/export` | Excel/CSV |
| POST | `/products/bulk-price-update` | |
| GET | `/products/{id}/price-history` · `/products/{id}/stock-movements` | |
| POST/DELETE | `/products/{id}/photos` | |
| GET | `/products/{id}/qr.png` · `/products/{id}/qr.svg` | QR image |
| POST | `/products/{id}/qr/regenerate` | Admin/Manager |
| POST | `/labels` | Body: product IDs + quantities + size → PDF |
| GET | `/qr/{code}` | Scan result (role-filtered) |
| GET 🌐 | `/public/qr/{code}` | Only if public QR page enabled; rate-limited |
| GET | `/products/lookup?code=` | QR, barcode, SKU or part number |

## Inventory & purchasing
| Method | Path |
|--------|------|
| GET/POST/PUT | `/suppliers`, `/suppliers/{id}`; GET `/suppliers/{id}/statement` |
| POST | `/suppliers/{id}/payments` |
| GET/POST/PUT | `/purchase-invoices`, `/purchase-invoices/{id}` |
| POST | `/purchase-invoices/{id}/post` · `/purchase-invoices/{id}/unpost` |
| POST | `/purchase-invoices/ocr` (multipart image/PDF → creates draft + OCR job) |
| GET | `/ocr-jobs/{id}` (status + extracted result) |
| GET | `/invoice-documents/{id}/file` (signed URL) |
| POST | `/stock-adjustments` |
| GET/POST | `/stock-counts`, POST `/stock-counts/{id}/post` |
| GET | `/inventory/reorder-suggestions` · `/inventory/valuation` |

## Sales
| Method | Path |
|--------|------|
| GET/POST | `/sales`, GET `/sales/{id}` |
| POST | `/sales/{id}/void` · `/sales/{id}/returns` |
| GET | `/sales/{id}/receipt.pdf` · POST `/sales/{id}/share` |
| GET/POST/DELETE | `/held-sales` |
| GET/POST | `/quotations`, POST `/quotations/{id}/convert` |

## Customers & receivables
| Method | Path |
|--------|------|
| GET/POST/PUT | `/customers`, `/customers/{id}` |
| GET | `/customers/{id}/account` (balance, overdue, available credit) |
| GET | `/customers/{id}/statement?from=&to=` (JSON or `.pdf`) |
| GET/POST | `/customers/{id}/payments` · POST `/customer-payments/{id}/reverse` |
| GET/POST | `/customers/{id}/notes` · `/customers/{id}/reminders` |
| GET | `/receivables` (credit sales list, filter by status) |
| GET | `/receivables/aging` · `/receivables/collection-list` |
| POST | `/receivables/{id}/write-off` (Admin) |
| GET | `/weekly-alerts`, `/weekly-alerts/latest`, `/weekly-alerts/{id}` |
| POST | `/weekly-alerts/{id}/send-reminders` |

## Notifications, dashboard, reports
| Method | Path |
|--------|------|
| GET | `/notifications`, POST `/notifications/{id}/read`, `/notifications/read-all` |
| GET | `/dashboard/kpis?from=&to=` |
| GET | `/dashboard/sales-trend` · `/dashboard/sales-by-category` · `/dashboard/top-products` · `/dashboard/cash-vs-credit` · `/dashboard/stock-summary` · `/dashboard/payables` |
| GET | `/dashboard/customers/aging` · `/dashboard/customers/top-debtors` · `/dashboard/customers/collections-trend` · `/dashboard/customers/top-customers` · `/dashboard/customers/mix` |
| GET | `/dashboard/me` (seller's own) |
| GET | `/reports/{reportCode}?…&format=json|pdf|xlsx` |

## Expenses, cash, settings, audit
| Method | Path |
|--------|------|
| GET/POST/PUT | `/expenses`, `/expense-types` |
| POST | `/cash-sessions/open` · `/cash-sessions/{id}/movements` · `/cash-sessions/{id}/close` |
| GET/PUT | `/settings` (Admin) |
| GET | `/audit-log` (Admin) |
