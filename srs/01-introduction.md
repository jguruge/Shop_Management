# 01 — Introduction

## 1.1 Purpose

This SRS describes what the Shop Management System must do for a retail store that sells **vehicle spare parts** and **Caltex lubricants** (engine oils, gear oils, ATF, greases, coolants, brake fluids). It is the reference for developers, testers and the shop owner when deciding what to build and checking that it works.

## 1.2 Business context

- The shop sells to **walk-in customers**, **regular customers**, **garages/mechanics** and **fleet owners** (three-wheelers, bikes, cars, vans, lorries).
- Many regular customers and garages **take goods on credit** and pay later. Tracking who owes what, and chasing late payers, is a major daily pain.
- Products come from many suppliers. Lubricants come mainly from **S.B.D. Enterprises (Caltex Regional Ware House, Panadura)**, delivered in drums (210 L), cans and bottles. Supplier invoices arrive on paper and are typed in by hand today, which is slow and error-prone.
- Spare parts are identified by **part numbers** (OEM and aftermarket) and **vehicle compatibility**. Lubricants are identified by **viscosity grade, specification, pack size**.
- Prices are often **negotiable within a range**. The seller needs to know the lowest price they may sell at without asking the owner.
- Currency is **Sri Lankan Rupees (LKR)**. Time zone is **Asia/Colombo**.

## 1.3 Scope

**In scope**

1. Product configuration: categories, product types, custom attributes, brands, units.
2. Product register with pricing, price ranges and stock settings.
3. QR code per product; scanning shows price/price range and full product details.
4. Suppliers, purchase invoices and stock movements.
5. Invoice photo upload with OCR auto-fill, plus manual entry.
6. Sales/POS with cash, card, bank transfer and **credit** payments.
7. Customer register, including vehicles and credit limits.
8. Credit sales tracking, repayments, aging, and a **weekly alert** for customers who have not paid.
9. Dashboards for the seller/accounts side and the customer side.
10. Reports, expenses, cash drawer and day-end closing.
11. Users, roles, security, audit log and settings.

**Out of scope (first release)**

- Full double-entry accounting / general ledger (the system tracks receivables, payables, cash and expenses; export to an accounting package is possible).
- Online store / e-commerce checkout.
- Payroll.
- Multi-branch stock transfer (data model allows it later; see [Roadmap](22-roadmap.md)).

## 1.4 Users

| User | Description |
|------|-------------|
| **Owner / Admin** | Owns the shop. Sees everything including cost and profit. Configures the system. |
| **Manager** | Runs the shop day to day. Manages products, stock, customers, purchases. |
| **Seller (Cashier)** | Serves customers, makes sales, records credit sales and repayments, scans QR codes. |
| **Customer** | Does not log in (first release). Receives receipts, statements and payment reminders. |

## 1.5 Glossary

| Term | Meaning |
|------|---------|
| **SKU** | Shop's own unique product code. |
| **OEM part number** | Manufacturer's part number (e.g. Toyota `90915-YZZE1`). |
| **Price range** | The minimum and maximum price a seller may charge for a product. |
| **Credit sale** | Goods handed to a customer without full payment; the balance becomes a receivable. |
| **Receivable** | Money a customer owes the shop. |
| **Payable** | Money the shop owes a supplier. |
| **GRN** | Goods Received Note — recording stock received against a supplier invoice. |
| **OCR** | Optical Character Recognition — reading text from an image. |
| **Aging** | Grouping unpaid amounts by how long they have been outstanding (0–7, 8–30, 31–60, 60+ days). |
| **Viscosity grade** | Oil grade such as `5W-30`, `15W-40`, `20W-50`. |
| **API / ACEA / JASO spec** | Lubricant performance standards (e.g. API `SN`, JASO `MA2`). |
