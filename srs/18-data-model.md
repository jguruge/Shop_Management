# 18 — Data Model

PostgreSQL, managed by EF Core migrations. All tables have `Id` (int, identity), `CreatedAt`, `UpdatedAt`; audited tables also `CreatedById`, `UpdatedById`. Money is `numeric(18,2)`; quantities `numeric(18,3)` (litres can be fractional).

## 18.1 Existing tables (from `InitialCreate`)

| Table | Current columns | Change needed |
|-------|----------------|---------------|
| `Roles` | Name, Description | None (Cashier shown as "Seller") |
| `Users` | Username, Email, FullName, PasswordHash, IsActive, LastLoginAt, RoleId | Add Mobile, MustChangePassword, FailedLoginCount, LockoutEnd, ApprovalPinHash |
| `Categories` | Name | Add ParentId, Description, DisplayOrder, ImageUrl, IsActive |
| `Products` | Name, Sku, Price, StockQuantity, CategoryId | Rename Price → SellingPrice; add fields in 18.3; StockQuantity becomes a cached value maintained from StockMovements |
| `Customers` | Name, Phone, Email | Add fields in [10](10-customers.md) |
| `Sales` | CustomerId, PaymentMethod, TotalAmount | Add SaleNo, SellerId, Subtotal, Discount, Tax, PaidAmount, BalanceAmount, Status, VehicleNo; move payment method to `SalePayments` |
| `SaleItems` | SaleId, ProductId, Quantity, UnitPrice | Add Discount, LineTotal, UnitCost (snapshot for profit), BatchId, ApprovedById (below-min) |

## 18.2 Entity relationship diagram

```mermaid
erDiagram
    Category ||--o{ Category : "parent of"
    Category ||--o{ ProductType : has
    ProductType ||--o{ AttributeDefinition : defines
    AttributeDefinition ||--o{ AttributeOption : "options"
    ProductType ||--o{ Product : "template for"
    Category ||--o{ Product : contains
    Brand ||--o{ Product : makes
    Unit ||--o{ Product : "sold in"
    Product ||--o{ ProductAttributeValue : has
    AttributeDefinition ||--o{ ProductAttributeValue : "value of"
    Product ||--o{ ProductPartNumber : "OEM/alt numbers"
    Product ||--o{ ProductVehicle : "fits"
    Vehicle ||--o{ ProductVehicle : ""
    Product ||--o{ ProductPhoto : has
    Product ||--o{ PriceHistory : logs
    Product ||--o{ StockBatch : "batches"
    Product ||--o{ StockMovement : moves

    Supplier ||--o{ PurchaseInvoice : issues
    PurchaseInvoice ||--o{ PurchaseInvoiceLine : has
    PurchaseInvoiceLine }o--|| Product : for
    PurchaseInvoice ||--o{ InvoiceDocument : "images"
    InvoiceDocument ||--o| OcrResult : "read as"
    Supplier ||--o{ SupplierItemMapping : remembers
    SupplierItemMapping }o--|| Product : maps
    Supplier ||--o{ SupplierPayment : "paid by shop"

    Customer ||--o{ CustomerVehicle : owns
    Customer ||--o{ Sale : buys
    User ||--o{ Sale : sells
    Sale ||--o{ SaleItem : has
    SaleItem }o--|| Product : of
    Sale ||--o{ SalePayment : "paid by"
    Sale ||--o| CreditSale : "unpaid part"
    Customer ||--o{ CreditSale : owes
    Customer ||--o{ CustomerPayment : pays
    CustomerPayment ||--o{ PaymentAllocation : allocates
    PaymentAllocation }o--|| CreditSale : to
    Customer ||--o{ FollowUpNote : has
    Customer ||--o{ ReminderLog : receives

    WeeklyUnpaidAlert ||--o{ WeeklyUnpaidAlertLine : lists
    WeeklyUnpaidAlertLine }o--|| Customer : about
    User ||--o{ Notification : receives
    ExpenseType ||--o{ Expense : groups
    User ||--o{ CashSession : opens
    User ||--o{ AuditLogEntry : did
```

## 18.3 Main entities and fields

### Catalog

| Entity | Fields |
|--------|--------|
| **Category** | Name, ParentId?, Description, DisplayOrder, ImageUrl, IsActive |
| **ProductType** | Name, CategoryId, Description, TracksExpiry, HasWarranty, HasVehicleCompatibility, IsActive |
| **AttributeDefinition** | ProductTypeId, Name, Code, DataType (enum), Unit, IsRequired, IsSearchable, ShowOnQr, ShowOnLabel, DisplayOrder, MinValue?, MaxValue?, Regex?, IsActive |
| **AttributeOption** | AttributeDefinitionId, Value, DisplayOrder, IsActive |
| **Brand** | Name, Kind (Genuine/Aftermarket/Lubricant), Country, LogoUrl, IsActive |
| **Unit** | Name, Symbol, AllowsDecimal |
| **Vehicle** | Make, Model, YearFrom, YearTo, EngineCode, FuelType |

### Products

| Entity | Fields |
|--------|--------|
| **Product** | Sku (unique), Name, ProductTypeId, CategoryId, BrandId?, Barcode? (unique), Description, UnitId, PurchaseUnitId?, PurchaseUnitFactor?, CostPrice, SellingPrice, MinSellingPrice?, GaragePrice?, IsTaxable, StockQuantity (cached), ReorderLevel, ReorderQuantity, ShelfLocation, WarrantyMonths?, **QrCode (unique, 8 chars)**, Status (Draft/Active/Inactive) |
| **ProductAttributeValue** | ProductId, AttributeDefinitionId, ValueText?, ValueNumber?, ValueBool?, ValueDate?, (multi-select as rows or JSON) |
| **ProductPartNumber** | ProductId, PartNumber, Kind (OEM/Alternative/Supplier), BrandId? |
| **ProductVehicle** | ProductId, VehicleId, Note |
| **ProductPhoto** | ProductId, StorageKey, IsPrimary, DisplayOrder |
| **PriceHistory** | ProductId, Field (Cost/Selling/Min/Garage), OldValue, NewValue, ChangedById, ChangedAt, Reason |

### Inventory & purchasing

| Entity | Fields |
|--------|--------|
| **StockBatch** | ProductId, BatchNo, ExpiryDate?, Quantity |
| **StockMovement** | ProductId, BatchId?, Type (enum), Quantity (±), UnitCost, ReferenceType, ReferenceId, Reason, Note, OccurredAt, CreatedById |
| **Supplier** | Name, ContactPerson, Phone, Phone2, Email, Address, VatNo, PaymentTermsDays, BankDetails, OurCustomerCode, InvoiceDateFormat, ChequePayeeName, OcrTemplateJson, Notes, IsActive |
| **PurchaseInvoice** | SupplierId, SupplierInvoiceNo (unique per supplier), InvoiceDate, SupplyDate, DueDate, SupplierOrderNo, PlaceOfSupply, DeliveryMode, PaymentType, Subtotal, TotalLitres, Discount, Tax, OtherCharges, GrandTotal, PaidAmount, Status (Draft/Posted/Cancelled), Source (Manual/OCR), Notes |
| **PurchaseInvoiceLine** | PurchaseInvoiceId, ProductId, SupplierItemCode, SupplierDescription, PackQty, PackUnitCode (DR/CN/BT…), Litres?, StockQty (in sell unit), RatePerPack, UnitCost (per sell unit), Discount, LineTotal, BatchNo?, ExpiryDate? |
| **InvoiceDocument** | PurchaseInvoiceId?, StorageKey, OriginalFileName, ContentType, FileHash (unique), PageNo, UploadedById |
| **OcrResult** | InvoiceDocumentId, Provider, Status (Pending/Done/Failed), RawJson, FieldConfidenceJson, ProcessingMs, Error, CreatedAt |
| **SupplierItemMapping** | SupplierId, SupplierItemCode? (e.g. `504300DBE_03`), SupplierDescriptionNormalized, PackUnitCode, ProductId, UnitFactor (sell units per pack, e.g. 210 L per drum) |
| **SupplierPayment** | SupplierId, Date, Amount, Method, ChequeNo?, ChequeDate?, Reference |

### Sales, customers & receivables

| Entity | Fields |
|--------|--------|
| **Customer** | Code, Name, Type (enum), Mobile (unique), Phone2, NicOrBrn, Address, City, Email, CreditAllowed, CreditLimit, CreditPeriodDays, PriceLevel, GuarantorName, GuarantorPhone, Notes, Status (Active/Blocked), LoyaltyPoints |
| **CustomerVehicle** | CustomerId, VehicleNo, Make, Model, Year |
| **Sale** | SaleNo (unique), SaleDate, CustomerId?, SellerId, VehicleNo?, Subtotal, Discount, Tax, Total, PaidAmount, BalanceAmount, Status (Completed/Voided/Returned/PartReturned), Notes |
| **SaleItem** | SaleId, ProductId, BatchId?, Quantity, UnitPrice, UnitCost, Discount, LineTotal, BelowMinApprovedById? |
| **SalePayment** | SaleId, Method (Cash/Card/BankTransfer/Cheque), Amount, Reference, ChequeNo?, ChequeDate? |
| **CreditSale** | SaleId (unique), CustomerId, CreditAmount, PaidAmount, Balance, DueDate, Status (Unpaid/PartiallyPaid/Paid/Overdue/WrittenOff), PromiseToPayDate?, SignatureStorageKey? |
| **CustomerPayment** | ReceiptNo, CustomerId, Date, Amount, Method, Reference, ChequeNo?, ChequeDate?, ReceivedById, Status (Active/Reversed), ReverseReason? |
| **PaymentAllocation** | CustomerPaymentId, CreditSaleId, Amount |
| **FollowUpNote** | CustomerId, Note, PromiseDate?, CreatedById |
| **ReminderLog** | CustomerId, Channel (SMS/WhatsApp/Email), Message, Status, SentAt, SentById? |
| **SalesReturn / SalesReturnItem** | SaleId, Date, Reason, RefundMethod, Amount / ProductId, Qty, Restock |

### Notifications, expenses, system

| Entity | Fields |
|--------|--------|
| **WeeklyUnpaidAlert** | WeekEnding (unique), CustomerCount, TotalOutstanding, TotalOverdue, GeneratedAt |
| **WeeklyUnpaidAlertLine** | AlertId, CustomerId, SellerId?, Outstanding, Overdue, OldestUnpaidDate, LastPaymentDate? |
| **Notification** | UserId, Type, Title, Body, Link, IsRead, CreatedAt |
| **ExpenseType / Expense** | Name / Date, ExpenseTypeId, Amount, Method, PaidTo, Note, ReceiptStorageKey, CreatedById, ApprovedById? |
| **CashSession** | UserId, OpenedAt, OpeningCash, ClosedAt?, ExpectedCash, CountedCash, Difference, Notes |
| **CashMovement** | CashSessionId, Type (In/Out), Amount, Reason |
| **Setting** | Key (unique), Value (JSON) |
| **AuditLogEntry** | UserId, Action, EntityType, EntityId, ChangesJson, IpAddress, OccurredAt |
| **RefreshToken** | UserId, TokenHash, ExpiresAt, RevokedAt |
| **NumberSequence** | Name (unique), Prefix, Year, NextValue (row-locked when used) |

## 18.4 Key rules in the database

- Unique: `Products.Sku`, `Products.Barcode` (where not null), `Products.QrCode`, `Customers.Mobile`, `(PurchaseInvoices.SupplierId, SupplierInvoiceNo)`, `Sales.SaleNo`, `CreditSales.SaleId`, `WeeklyUnpaidAlerts.WeekEnding`, `InvoiceDocuments.FileHash`.
- Indexes for search: `Products.Name` (trigram, `pg_trgm`), `ProductPartNumbers.PartNumber`, `CustomerVehicles.VehicleNo`, `Customers.Name`.
- Restrict deletes on anything referenced by sales, purchases or stock movements (deactivate instead).
