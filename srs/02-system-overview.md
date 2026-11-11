# 02 — System Overview

## 2.1 Architecture

```mermaid
flowchart LR
    subgraph Client
        WEB[React + IBM Carbon<br/>web app]
        PHONE[Phone camera<br/>QR scan / invoice photo]
    end
    subgraph Server[".NET 10 Web API (single project, feature folders)"]
        API[Controllers]
        SVC[Feature services]
        JOBS[Background jobs<br/>weekly alerts, low stock]
        OCR[OCR adapter]
    end
    DB[(PostgreSQL<br/>ShopManagement)]
    FILES[(File storage<br/>invoice images, product photos)]
    OCRP[OCR provider]
    MSG[SMS / Email provider]

    WEB -->|HTTPS + JWT| API
    PHONE --> WEB
    API --> SVC --> DB
    SVC --> FILES
    OCR --> OCRP
    SVC --> OCR
    JOBS --> DB
    JOBS --> MSG
```

## 2.2 Technology stack

| Layer | Technology | Notes |
|-------|-----------|-------|
| Frontend | React 19, TypeScript, Vite, **IBM Carbon Design System** | Responsive; works on phone for QR scanning and invoice photos |
| Backend | **.NET 10** ASP.NET Core Web API | Single project `backend/ShopManagement.Api.csproj`, organised by `Features/` |
| Database | **PostgreSQL** via EF Core + Npgsql | Schema managed only by EF Core migrations (`backend/Migrations/`) |
| Auth | JWT bearer tokens, ASP.NET Identity password hasher | Already implemented |
| Config | `backend/.env` (git-ignored), `.env.example` template | Already implemented |
| Background jobs | ASP.NET Core `BackgroundService` (or Quartz.NET / Hangfire) | Weekly unpaid alert, low-stock, expiry checks |
| OCR | Pluggable `IInvoiceOcrService` | See [08 — Invoice OCR](08-invoice-ocr.md) |
| QR | `QRCoder` (server) or `qrcode` (client) to generate; browser camera to scan | See [06 — QR Codes](06-qr-codes.md) |
| Files | Local disk in development; S3-compatible storage (e.g. Cloudflare R2) in production | Invoice images, product photos |
| PDF | QuestPDF | Receipts, statements, labels, reports |

## 2.3 Backend folder layout

```
backend/
├── Data/            AppDbContext, entity configurations, seeding
├── db/              Generated SQL exports of migrations (read-only)
├── Domain/          Entities grouped by area
├── Features/
│   ├── Auth/            (exists)
│   ├── Products/        (exists — to be extended)
│   ├── Catalog/         categories, product types, attributes, brands, units
│   ├── QrCodes/
│   ├── Inventory/       stock movements, adjustments
│   ├── Purchasing/      suppliers, purchase invoices, OCR
│   ├── Sales/           POS, receipts, returns
│   ├── Customers/
│   ├── Receivables/     credit sales, repayments, aging
│   ├── Notifications/
│   ├── Dashboard/
│   ├── Reports/
│   ├── Expenses/
│   ├── Users/
│   ├── Settings/
│   └── Shared/
├── Migrations/
└── Program.cs
```

Each feature contains `Controllers/`, `DTOs/`, `Services/` and a `<Feature>Module.cs` that registers its services.

## 2.4 Module map

```mermaid
flowchart TB
    CFG[Product Configuration] --> REG[Product Register]
    REG --> QR[QR Codes]
    REG --> INV[Inventory]
    SUP[Suppliers] --> PUR[Purchase Invoices]
    OCR[Invoice OCR] --> PUR
    PUR --> INV
    CUS[Customers] --> SALE[Sales / POS]
    REG --> SALE
    QR --> SALE
    SALE --> INV
    SALE --> AR[Credit & Receivables]
    AR --> NOTI[Notifications<br/>weekly unpaid alert]
    INV --> NOTI
    SALE --> DASH[Dashboard & Reports]
    AR --> DASH
    PUR --> DASH
    EXP[Expenses & Cash] --> DASH
```
