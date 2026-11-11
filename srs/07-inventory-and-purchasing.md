# 07 — Inventory & Purchasing

## 7.1 Principle

Stock is **never edited directly**. Every change is a **stock movement**, and current stock = sum of movements. This gives a full history and makes stock auditable.

| Movement type | Effect | Created by |
|---------------|--------|-----------|
| Opening balance | + | Product registration / data import |
| Purchase (GRN) | + | Posting a purchase invoice |
| Sale | − | Completing a sale |
| Sales return | + | Customer return |
| Purchase return | − | Returning goods to supplier |
| Adjustment (+/−) | ± | Stock count, damage, loss, found |
| Transfer | ± | Between locations (future, multi-branch) |

## 7.2 Suppliers

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-INV-01 | Maintain suppliers: name, contact person, phone(s), email, address, VAT/TIN number, payment terms (days), bank details, notes, **our customer code at the supplier** (e.g. `PAN0000000027` at S.B.D. Enterprises), **invoice date format** (e.g. `MM/dd/yyyy`), cheque payee name (e.g. "SBD ENTERPRISES"). | Must |
| FR-INV-02 | Supplier page shows invoices, total purchased, amount owed (payables), and last purchase date. | Must |
| FR-INV-03 | Record payments to suppliers (cash, cheque with cheque no/date, bank transfer) against one or more invoices. | Should |
| FR-INV-04 | Supplier payables aging and "due this week" list. | Should |

## 7.3 Purchase invoices (GRN)

A purchase invoice records goods received from a supplier. It can be entered **by OCR** from a photo ([08](08-invoice-ocr.md)) or **manually**.

**Header:** supplier, supplier invoice number, invoice date, date of supply (received date), supplier order number, due date, place of supply, mode of delivery, payment type/status, attached image(s), notes.

**Lines:** product, supplier's item code/description (as printed), pack quantity and pack unit (e.g. `1 DR`), litres (lubricants, e.g. `210.00`), stock quantity received in the product's sell unit (after conversion), unit cost per pack and per sell unit, discount (% or amount), line total, batch number and expiry (if product tracks expiry).

**Totals:** subtotal, total litres (lubricants), discount, tax (VAT), other charges (transport), grand total.

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-INV-10 | Create purchase invoice as **Draft**, edit freely, then **Post**. Posting creates purchase stock movements and updates product cost price. | Must |
| FR-INV-11 | Supplier + supplier invoice number must be unique (prevents double entry of the same invoice). | Must |
| FR-INV-12 | Line totals and invoice totals are recalculated by the server; a mismatch with the printed total is shown as a warning. | Must |
| FR-INV-13 | Cost price update method setting: **last cost** (default) or **weighted average cost**. | Should |
| FR-INV-14 | If new cost makes current selling/min price below cost or below target margin, show a "price review" list after posting. | Should |
| FR-INV-15 | Posted invoices cannot be edited; corrections via purchase return or adjustment. Admin can *unpost* if no stock from it has been sold. | Must |
| FR-INV-16 | After posting, offer to print QR labels for the received quantities. | Should |
| FR-INV-17 | The original invoice image is stored and viewable from the purchase invoice. | Must |
| FR-INV-18 | Supplier item mapping: remember which supplier code/description maps to which product, so the next invoice matches automatically. | Must |

## 7.4 Stock control

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-INV-20 | Stock adjustment with reason (Count correction, Damaged, Expired, Lost, Found, Internal use) and note. | Must |
| FR-INV-21 | Stock count (stock-take): print count sheet by location/category, enter counted quantities, system posts differences as adjustments. | Should |
| FR-INV-22 | Batches & expiry for lubricants; sales use **FEFO** (first-expiry-first-out) by default. | Should |
| FR-INV-23 | Negative stock is blocked by default; setting can allow it with a warning. | Must |
| FR-INV-24 | Stock movement history per product with running balance. | Must |
| FR-INV-25 | Stock valuation (quantity × cost) by category/brand. | Must |
| FR-INV-26 | Reorder suggestions: products at or below reorder level, with suggested quantity and last supplier. | Should |
| FR-INV-27 | Create a purchase order to a supplier from reorder suggestions; print/send as PDF; convert to purchase invoice on receipt. | Could |
| FR-INV-28 | Purchase returns to supplier (reduce stock, reduce payable). | Should |
