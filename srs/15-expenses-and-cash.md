# 15 — Expenses & Cash Management

## 15.1 Expenses

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-EX-01 | Record expenses: date, type, amount, payment method, paid to, note, receipt photo. | Must |
| FR-EX-02 | Expense types (configurable): Rent, Electricity, Water, Telephone/Internet, Salaries, Transport, Repairs, Stationery, Tea/Meals, Bank charges, Other. | Must |
| FR-EX-03 | Sellers can record petty-cash expenses up to a limit (setting); larger ones need Manager approval. | Should |
| FR-EX-04 | Recurring expenses (e.g. monthly rent) create a reminder each period. | Could |

## 15.2 Cash drawer & day-end

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-EX-10 | Open the day with opening cash float per drawer/seller. | Should |
| FR-EX-11 | Cash in/out entries during the day (owner withdrawal, change top-up, bank deposit). | Should |
| FR-EX-12 | Day-end closing: system shows expected cash (opening + cash sales + cash repayments − cash expenses − cash out); seller enters counted cash (by note denomination optional); difference recorded. | Should |
| FR-EX-13 | After closing, that day's sales cannot be voided (returns only). | Should |
| FR-EX-14 | Day-end summary sent to the owner (in-app, optional SMS/email). | Could |

## 15.3 Bank & cheques

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-EX-20 | Track cheques received (from customers) and issued (to suppliers): number, bank, date, amount, status (Pending, Deposited, Cleared, Bounced). | Should |
| FR-EX-21 | Bounced customer cheque re-opens the receivable and notifies Manager. | Should |
