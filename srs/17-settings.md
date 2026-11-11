# 17 — Settings

Admin only. Stored in a `Settings` table (key/value) or typed settings tables; cached in memory.

| Group | Setting | Default |
|-------|---------|---------|
| **Shop profile** | Name, logo, address, phones, email, VAT/TIN no, business reg. no | — |
| | Receipt footer text | "Thank you! Goods sold are not returnable without receipt." |
| **Localisation** | Currency | LKR |
| | Time zone | Asia/Colombo |
| | Languages for SMS/receipts | English, Sinhala |
| **Numbering** | Sale, credit, payment, purchase, customer, product SKU prefixes and next numbers | `INV-`, `PAY-`, `GRN-`, `CUS-`, `LUB-`/`SPR-` |
| **Tax** | VAT enabled, VAT rate, prices include VAT | Off |
| **Sales** | Allow negative stock | No |
| | Require approval below minimum price | Yes |
| | Max bill discount % for Sellers | 5% |
| **Credit** | Default credit period (days) | 30 |
| | Block credit when overdue more than (days) | 30 |
| | Block credit when over limit | Yes |
| **Weekly unpaid alert** | Day and time | Saturday 18:00 |
| | Include not-yet-due credit older than (days) | 7 |
| | Channels to staff | In-app (+ email/SMS optional) |
| | Auto-remind customers | Off |
| **Stock** | Costing method | Last cost |
| | Expiry warning (days) | 60 |
| | FEFO for batches | On |
| **QR** | Base URL for QR codes | `https://<host>/p/` |
| | Public QR page | Off |
| | Show price on label | Yes |
| | Default label size | 50×30 mm |
| **OCR** | Provider | Vision LLM |
| | Monthly page limit | 500 |
| **Messaging** | SMS gateway (e.g. Dialog, Mobitel, Notify.lk, Twilio), sender ID, API key (in `.env`) | — |
| | Email SMTP (in `.env`) | — |
| | Reminder templates (EN/SI/TA) | See [12](12-notifications-and-alerts.md) |
| **Printing** | Receipt printer type (80 mm thermal / A4 / A5) | 80 mm |
| **Backup** | Daily database backup time and retention | 02:00, 30 days |

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-ST-01 | Admin can view and change the settings above; changes are audited. | Must |
| FR-ST-02 | Secrets (API keys, SMTP password) are **not** stored in the database; they come from `backend/.env` / environment variables. | Must |
