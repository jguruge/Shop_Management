# 10 — Customers

Sellers can add customers with full details. A customer is needed for credit sales and is useful for loyalty, history and statements.

## 10.1 Customer fields

| Field | Required | Notes |
|-------|:--------:|-------|
| Customer code | auto | `CUS-000123` |
| Name | ✅ | Person or business name |
| Customer type | ✅ | Walk-in, Regular, **Garage/Mechanic**, Fleet/Company, Three-wheeler driver |
| Mobile number | ✅ | Primary; used for SMS/WhatsApp reminders; unique |
| Other phone | | |
| NIC / Business reg. no. | ✅ for credit customers | Identity for credit |
| Address | | Street, city |
| Email | | |
| Vehicles | | Vehicle number, make, model, year (many) |
| Credit allowed | | Yes/No (default No) |
| Credit limit (LKR) | when credit allowed | Max outstanding |
| Credit period (days) | when credit allowed | Default 30; drives due dates |
| Price level | | Retail / Garage |
| Guarantor name & phone | | Optional, for large credit |
| Photo / NIC copy | | Optional attachments |
| Notes | | |
| Status | | Active / Blocked |

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-CU-01 | Sellers can add and edit customers (except credit limit, credit period and status — Manager/Admin). | Must |
| FR-CU-02 | Quick-add from POS with just name + mobile; complete details later. Credit requires NIC and credit settings. | Must |
| FR-CU-03 | Mobile number unique; warn on similar names. | Must |
| FR-CU-04 | Search by name, mobile, NIC, customer code, **vehicle number**. | Must |
| FR-CU-05 | Blocked customers cannot buy on credit. | Must |
| FR-CU-06 | Merge duplicate customers (Admin). | Could |

## 10.2 Customer profile page

- Contact details and vehicles
- **Account summary:** total purchases, total paid, **outstanding balance**, overdue amount, credit limit and available credit, oldest unpaid date
- Credit sales list with status (Unpaid / Partially paid / Paid / Overdue)
- Payment history
- Purchase history (what, when, which vehicle)
- Reminders sent (date, channel, delivered)
- Actions: **New sale**, **Receive payment**, **Statement (PDF)**, **Send reminder**

## 10.3 Loyalty (optional)

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-CU-20 | Points per LKR spent (e.g. 1 point per LKR 100) on paid amounts; redeem as discount. | Could |
| FR-CU-21 | Service reminders: "oil change due" based on last engine-oil purchase date + interval (e.g. 3 months) per vehicle; SMS reminder. | Could |
