# Database Artifacts

The schema is managed **exclusively by EF Core migrations** (`backend/Migrations/`, C#) — that's the source of truth, and `dotnet ef database update` is the only supported way to apply schema changes.

The files in this folder are **generated exports** for readability/review, not a second migration mechanism:

- `db/migrations/NNNN_description.sql` — one numbered, idempotent SQL script per EF Core migration.
- `db/schema.sql` — the full current schema, start to finish.

Regenerate them after adding a migration; don't hand-edit them:

```bash
cd backend
dotnet ef migrations add <Name>
dotnet ef database update
dotnet ef migrations script <previous-migration> <Name> --idempotent -o db/migrations/000N_description.sql
dotnet ef migrations script -o db/schema.sql
```

Current tables: `Roles`, `Users` (login), `Categories`, `Products`, `Customers`, `Sales`, `SaleItems`.
