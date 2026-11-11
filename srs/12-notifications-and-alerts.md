# 12 — Notifications & Alerts

## 12.1 Weekly unpaid-customer alert (key feature)

At the **end of every week** the seller receives an alert listing every customer who has taken products on credit and **has not paid yet**.

| Setting | Default |
|---------|---------|
| Day & time | **Saturday 18:00** (Asia/Colombo) — configurable |
| Include | Customers with balance > 0 whose credit is **overdue**, plus (setting) all unpaid credit older than 7 days |
| Recipients | All Admins and Managers; each Seller gets their own customers (sales they made) |
| Channels | In-app notification + dashboard banner (always); email and SMS to staff (optional) |

**Alert content**

```
Weekly unpaid customers — week ending Sat 14 Nov 2026
12 customers · LKR 486,300 outstanding · LKR 312,800 overdue

Customer            Phone         Outstanding   Overdue   Oldest unpaid   Last payment
Saman Motors        077 123 4567  LKR 85,000    85,000    12 Oct (33 d)   20 Sep
Nimal (3-wheel)     071 555 1234  LKR 12,400     8,000    28 Oct (17 d)   —
...
[Open collection list]  [Send reminders to all]
```

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-NT-01 | A background job runs at the configured weekly time and creates the alert above. | Must |
| FR-NT-02 | Each line shows customer, phone, outstanding, overdue, oldest unpaid date & days, last payment, and the products taken (expandable). | Must |
| FR-NT-03 | From the alert: call, WhatsApp, send SMS reminder, record payment, add follow-up note. | Must |
| FR-NT-04 | The job is safe to re-run (one alert per week; no duplicates if the server restarts). | Must |
| FR-NT-05 | If the server was off at the scheduled time, the job runs at next start-up. | Must |
| FR-NT-06 | Alert history is kept (what was outstanding each week) for trend reporting. | Should |

## 12.2 Customer payment reminders

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-NT-10 | Send reminder SMS/WhatsApp to a customer (manually or in bulk from the weekly alert) using a template: *"Dear {name}, your balance at {shop} is LKR {balance}, due since {date}. Please settle at your earliest. Thank you."* | Should |
| FR-NT-11 | Optional automatic reminders N days after due date (setting), max one per week per customer. | Could |
| FR-NT-12 | Templates editable in Settings, in **English and Sinhala** (and Tamil optional). | Should |
| FR-NT-13 | Every reminder is logged on the customer (date, channel, status). | Must |

## 12.3 Other alerts

| Alert | When | Priority |
|-------|------|----------|
| Low stock | Stock ≤ reorder level (daily digest + live badge) | Must |
| Out of stock | Stock reaches 0 | Must |
| Expiring lubricants | Batch expires within 60 days (setting) | Should |
| Credit limit exceeded / override used | On event | Must |
| Sale below minimum price approved | On event (to Admin) | Must |
| Supplier payment due | Due within 7 days | Should |
| Post-dated cheque due | Cheque date reached | Should |
| Day not closed | Cash drawer not closed by 22:00 | Should |
| OCR finished / failed | On event (to uploader) | Must |

## 12.4 Notification centre

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-NT-20 | Bell icon in the header with unread count; list of notifications with link to the related record. | Must |
| FR-NT-21 | Mark read / mark all read. | Must |
| FR-NT-22 | Per-user preferences: which alerts, which channels. | Should |
