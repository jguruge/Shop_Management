# 05 — Product Register

The product register is the master list of everything the shop sells. **Products** already exist in the database (`Products` table) with name, SKU, price, stock and category; this document extends them.

## 5.1 Product fields

| Group | Field | Notes |
|-------|-------|-------|
| **Identity** | SKU | Auto-generated (`LUB-000123`, `SPR-000456`) or entered. Unique. |
| | Name | e.g. "Havoline ProDS 5W-30 4L" |
| | Product type | Drives the attribute form (see [04](04-product-configuration.md)) |
| | Category | Defaults from product type, can be changed |
| | Brand | |
| | Barcode / EAN | Optional; manufacturer barcode for scanning |
| | OEM part numbers | Multiple; searchable |
| | Alternative part numbers | Cross-references from other brands |
| | Description | Free text |
| | Photos | Up to 5 |
| **Attributes** | Values for each attribute of the product type | e.g. Viscosity `5W-30`, Pack size `4 L` |
| **Pricing** | Cost price | Last purchase cost; hidden from Sellers |
| | Selling price (standard / max) | The normal shelf price |
| | Minimum selling price | Lowest price a Seller may charge without approval |
| | Wholesale / garage price | Optional price for customers of type *Garage* |
| | Tax applicable | Yes/No |
| **Stock** | Unit of measure | Sell unit |
| | Purchase unit & conversion | Optional |
| | Current stock | Calculated from stock movements; not typed in |
| | Reorder level | Low-stock alert threshold |
| | Reorder quantity | Suggested order quantity |
| | Shelf / bin location | e.g. "Rack B-3" |
| | Track batches / expiry | From product type |
| | Warranty (months) | From product type, overridable |
| **Compatibility** | Vehicles | For spare parts |
| **Status** | Active / Inactive | Inactive products cannot be sold |

## 5.2 Price range

The **price range** is what a Seller sees after scanning a QR code: the band they are allowed to sell within.

```
Minimum selling price  ≤  agreed price  ≤  Selling price (max)
        LKR 4,800                              LKR 5,200
```

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-PR-01 | Minimum selling price must be ≤ selling price. | Must |
| FR-PR-02 | Warn (not block) when minimum selling price is below cost price; only Admin can save it. | Must |
| FR-PR-03 | If minimum price is empty, the price range is a single fixed price. | Must |
| FR-PR-04 | Optional *range by customer type*: Walk-in uses selling price; Garage/Wholesale uses garage price as its maximum. | Should |
| FR-PR-05 | Every price change is stored in price history (old price, new price, who, when). | Must |
| FR-PR-06 | Bulk price update by category/brand by percentage or fixed amount (e.g. Caltex price increase of 8%). | Should |

## 5.3 Registering a product

1. Choose **product type** → form shows that type's attributes.
2. Fill identity, attributes, pricing, stock settings.
3. Optionally upload photos and link compatible vehicles.
4. Save → system generates **SKU** (if empty) and a **QR code** ([06](06-qr-codes.md)).
5. Offer to **print QR label** and **enter opening stock**.

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-PR-10 | Register a product with the fields in 5.1; required attributes enforced. | Must |
| FR-PR-11 | SKU unique; barcode unique when present; OEM part numbers searchable. | Must |
| FR-PR-12 | Duplicate warning when a product with the same brand + OEM part number or same name exists. | Should |
| FR-PR-13 | Opening stock entry creates an *Opening Balance* stock movement, not a direct stock edit. | Must |
| FR-PR-14 | Edit product; changing product type is only allowed when no attribute values would be lost, or after confirmation. | Must |
| FR-PR-15 | Deactivate instead of delete when the product has any sales, purchases or stock movements. | Must |
| FR-PR-16 | Clone a product (e.g. same oil in 1 L and 4 L). | Should |
| FR-PR-17 | Import products from Excel/CSV with a template per product type; show row-level errors before saving. | Should |
| FR-PR-18 | Products created from an OCR'd supplier invoice start as *Draft* until reviewed ([08](08-invoice-ocr.md)). | Should |

## 5.4 Product list & search

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-PR-20 | Search by name, SKU, barcode, OEM/alternative part number, brand. | Must |
| FR-PR-21 | Filter by category, product type, brand, stock status (in stock / low / out), active status, searchable attributes, compatible vehicle. | Must |
| FR-PR-22 | Columns: photo, SKU, name, brand, stock, selling price, price range, location; cost/margin for Admin/Manager only. | Must |
| FR-PR-23 | Export list to Excel/CSV. | Should |

## 5.5 Product detail page

Shows everything about one product: identity, attributes, price range, current stock (and per batch for lubricants), shelf location, compatible vehicles, QR code, price history, stock movement history, last 10 sales, last purchase (supplier, cost, date).
