# 21 — Non-Functional Requirements

| ID | Area | Requirement |
|----|------|-------------|
| NFR-01 | Performance | API responses < 500 ms for 95% of requests with 20 000 products, 5 000 customers, 200 000 sales. |
| NFR-02 | Performance | QR scan → price card visible in < 2 s on 4G phone. |
| NFR-03 | Performance | Dashboard < 3 s with 2 years of data. |
| NFR-04 | Performance | OCR result < 20 s per page (provider dependent); UI never blocks while waiting. |
| NFR-05 | Concurrency | Sale/receipt/invoice numbers never duplicate under concurrent sales (row-locked sequences). Stock and balances updated in the same DB transaction as the sale/payment. |
| NFR-06 | Correctness | Money uses `decimal` / `numeric(18,2)`, never floating point. Rounding: half-up to 2 decimals. |
| NFR-07 | Availability | Shop hours 07:00–21:00; planned maintenance outside them. |
| NFR-08 | Offline tolerance | If internet drops, the POS shows a clear offline banner; (Could) queue sales locally and sync later. |
| NFR-09 | Security | HTTPS, JWT, role policies, hashed passwords, rate limiting, secrets only in `.env`/environment; see [16](16-users-security-audit.md). |
| NFR-10 | Privacy | Customer NIC, phone and documents visible only to logged-in staff; invoice images and NIC copies stored privately with signed URLs. |
| NFR-11 | Backup | Automatic daily PostgreSQL backup (`pg_dump`) kept 30 days, plus weekly off-site copy; restore tested monthly. |
| NFR-12 | Audit | All financial and stock changes traceable to a user and time. |
| NFR-13 | Usability | Usable on 1366×768 shop PC and 360 px-wide phones; touch targets ≥ 44 px on mobile screens. |
| NFR-14 | Usability | A new seller can complete a sale and a credit sale after 15 minutes of training. |
| NFR-15 | Localisation | LKR currency, Asia/Colombo time zone; English UI first, Sinhala later; SMS templates in EN/SI. |
| NFR-16 | Accessibility | Follow Carbon's WCAG 2.1 AA components; keyboard-operable POS. |
| NFR-17 | Maintainability | Backend organised by `Features/`; each feature has services with unit tests for business rules (price range, credit limit, allocation, aging, weekly alert). |
| NFR-18 | Deployability | Backend Dockerfile (exists), frontend static build; config through environment variables. |
| NFR-19 | Observability | Structured logs; health endpoint `/health` (DB, storage, OCR provider). |
| NFR-20 | Data retention | Sales, payments and audit data kept at least 7 years. |
