# 16 — Users, Security & Audit

## 16.1 Already implemented

- `Users` and `Roles` tables (Admin, Manager, Cashier), seeded admin account.
- `POST /api/auth/login` (username or email + password) → JWT access token (60 min).
- `GET /api/auth/me`; protected endpoints with `[Authorize]`.
- Passwords hashed with ASP.NET Core Identity `PasswordHasher` (PBKDF2).
- Secrets in `backend/.env` (git-ignored).

## 16.2 User management

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-SEC-10 | Admin creates users: username, full name, email, mobile, role, active flag, initial password. | Must |
| FR-SEC-11 | Admin can reset a user's password; user must change it at next login. | Must |
| FR-SEC-12 | Users change their own password (current + new). | Must |
| FR-SEC-13 | Deactivate users instead of deleting; their past records keep their name. | Must |
| FR-SEC-14 | Manager approval PIN (4–6 digits, hashed) per Manager/Admin for below-minimum prices and overrides. | Must |

## 16.3 Security

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-SEC-20 | Password policy: min 8 characters, letters and numbers; not same as username. | Must |
| FR-SEC-21 | Lock account for 15 minutes after 5 failed logins; log failed attempts. | Must |
| FR-SEC-22 | Refresh tokens (stored hashed, rotated) so users stay signed in on the shop PC up to 7 days; logout revokes. | Should |
| FR-SEC-23 | Change the seeded `admin` password on first login (force change). | Must |
| FR-SEC-24 | Role-based authorization policies on the server (see [03](03-user-roles-and-permissions.md)). | Must |
| FR-SEC-25 | HTTPS in production; HSTS; secure headers; CORS limited to the shop's web origin. | Must |
| FR-SEC-26 | Rate-limit login and public QR endpoints. | Must |

## 16.4 Audit log

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-SEC-30 | Record who/when/what for create, update, delete of products, prices, customers, credit limits, sales voids/returns, payments, stock adjustments, purchase invoices, users and settings. | Must |
| FR-SEC-31 | Store before/after values for changed fields (JSON). | Must |
| FR-SEC-32 | Implemented once via an EF Core `SaveChanges` interceptor, not per feature. | Must |
| FR-SEC-33 | Audit log is read-only and viewable/filterable by Admin. | Must |
| FR-SEC-34 | Every entity has `CreatedAt`, `CreatedBy`, `UpdatedAt`, `UpdatedBy`. | Must |
