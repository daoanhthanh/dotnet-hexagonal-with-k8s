## Chạy migration 

### Lần chạy đầu tiên (khi mới clone project về)
```bash
dotnet build ./CLI.Migration/CLI.Migration.csproj

dotnet run --project ./CLI.Migration/CLI.Migration.csproj -- create_database
```

### Tạo migration

1. Tạo file migration
    ```bash
    # với linux:
    ./CLI.Migration/create_migration.sh <tên_migration>
    # với windows:
    CLI.Migration/create_migration.bat <tên_migration>
    ```
   Và điền nội dung cần thay đổi vào file migration vừa tạo.


2. Chạy migration
    ```bash
    dotnet run --project ./CLI.Migration/CLI.Migration.csproj -- run_migration
    ```