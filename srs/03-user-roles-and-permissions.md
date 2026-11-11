# 03 — User Roles & Permissions

The `Roles` table already holds **Admin**, **Manager** and **Cashier**. In the UI, *Cashier* is shown as **Seller**.

## 3.1 Roles

| Role | Summary |
|------|---------|
| **Admin (Owner)** | Full access, including cost prices, profit, user management, settings and deleting records. |
| **Manager** | Manages products, stock, suppliers, purchases, customers and credit. Sees cost prices. Cannot manage users or settings. |
| **Seller (Cashier)** | Sells, scans QR codes, adds customers, records credit sales and repayments. Cannot see cost price or profit. Cannot sell below the minimum price without approval. |

## 3.2 Permission matrix

| Function | Admin | Manager | Seller |
|----------|:-----:|:-------:|:------:|
| Configure categories, types, attributes, brands, units | ✅ | ✅ | ❌ |
| Register / edit products | ✅ | ✅ | ❌ |
| Deactivate products | ✅ | ✅ | ❌ |
| View selling price & price range | ✅ | ✅ | ✅ |
| View cost price & margin | ✅ | ✅ | ❌ |
| Print QR labels | ✅ | ✅ | ✅ |
| Scan QR and view product details | ✅ | ✅ | ✅ |
| Suppliers & purchase invoices (incl. OCR) | ✅ | ✅ | ❌ |
| Stock adjustments | ✅ | ✅ | ❌ |
| Make sales (cash/card/transfer) | ✅ | ✅ | ✅ |
| Make credit sales | ✅ | ✅ | ✅ (within customer credit limit) |
| Sell below minimum price | ✅ | ✅ | ❌ (needs Manager/Admin PIN) |
| Void a sale / process returns | ✅ | ✅ | ❌ (request only) |
| Add / edit customers | ✅ | ✅ | ✅ |
| Change customer credit limit | ✅ | ✅ | ❌ |
| Record customer repayments | ✅ | ✅ | ✅ |
| Write off bad debt | ✅ | ❌ | ❌ |
| Record expenses | ✅ | ✅ | ✅ (petty cash only) |
| Day-end cash closing | ✅ | ✅ | ✅ (own drawer) |
| Seller dashboard (own sales) | ✅ | ✅ | ✅ |
| Full business dashboard (profit, stock value) | ✅ | ✅ | ❌ |
| Reports | ✅ | ✅ | Limited (own sales, customer statements) |
| Manage users | ✅ | ❌ | ❌ |
| Settings | ✅ | ❌ | ❌ |
| View audit log | ✅ | ❌ | ❌ |

## 3.3 Rules

- **FR-SEC-01 (Must)** Every API endpoint requires login unless explicitly marked public (only the public QR product page, if enabled, and `POST /api/auth/login`).
- **FR-SEC-02 (Must)** Permissions are enforced on the **server**; the UI only hides what the user cannot use.
- **FR-SEC-03 (Must)** Cost price, margin and profit fields are **removed from API responses** for Sellers, not just hidden in the UI.
