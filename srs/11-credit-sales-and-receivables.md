# 11 — Credit Sales & Receivables

When the seller gives products **without (full) payment**, the system records it against the customer and tracks it until it is paid. At the **end of every week** the seller is alerted about customers who have not paid ([12](12-notifications-and-alerts.md)).

## 11.1 Credit sale

A credit sale is a normal sale ([09](09-sales-and-pos.md)) where some or all of the amount is unpaid.

| Field | Notes |
|-------|-------|
| Sale / invoice | Link to the sale with its products |
| Customer | Required |
| Credit amount | Unpaid amount at time of sale |
| Due date | Sale date + customer credit period (editable by Manager) |
| Paid so far | Sum of allocated payments |
| Balance | Credit amount − paid |
| Status | **Unpaid**, **Partially paid**, **Paid**, **Overdue**, **Written off** |
| Promise-to-pay date | Optional, when customer promises a date |
| Notes | |

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-CR-01 | Completing a sale with an unpaid balance creates a credit record for the customer with due date. | Must |
| FR-CR-02 | **Give goods first, bill later**: record items taken by a customer (e.g. a garage picks up parts during the day) as a credit sale immediately; no payment needed. | Must |
| FR-CR-03 | Status becomes **Overdue** automatically after the due date when balance > 0. | Must |
| FR-CR-04 | Seller must confirm the customer, items and amount; customer signature capture on the device (optional) as proof of goods taken. | Should |

## 11.2 Receiving payments

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-CR-10 | Record a payment from a customer: date, amount, method (cash/card/transfer/cheque), reference, received by. | Must |
| FR-CR-11 | Allocate a payment automatically to the **oldest** unpaid credit first, or manually to chosen invoices. | Must |
| FR-CR-12 | Over-payment stays as customer **advance/credit balance**, used automatically on the next credit. | Should |
| FR-CR-13 | Print/share a payment receipt showing amount paid and remaining balance. | Must |
| FR-CR-14 | Reverse a payment (Manager/Admin, with reason) e.g. bounced cheque. | Must |

## 11.3 Account statement & aging

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-CR-20 | Customer statement for a date range: opening balance, credit sales, payments, returns, closing balance. PDF and share by WhatsApp/email. | Must |
| FR-CR-21 | Receivables aging report by customer: Current (not due), 1–7, 8–30, 31–60, 61–90, 90+ days overdue. | Must |
| FR-CR-22 | Collection list: customers with overdue balance, sorted by amount or days, with last payment date and phone (tap to call/WhatsApp). | Must |
| FR-CR-23 | Record follow-up notes on a customer ("called, will pay Friday") with promise-to-pay date. | Should |
| FR-CR-24 | Write off bad debt (Admin only, with reason); appears in reports separately. | Should |

## 11.4 Credit limits

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-CR-30 | Available credit = credit limit − outstanding balance. Shown at POS when the customer is selected. | Must |
| FR-CR-31 | Exceeding credit limit or having overdue > X days (setting) blocks new credit unless Manager overrides with reason. | Must |
