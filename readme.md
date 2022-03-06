<img src="icon.png" align="right" />

# Synword

## Строки подключения
1. Для инициализации подключения к MS SQL Server необходимо включить пользовательские секреты. Данную команду необходимо прописать внутри PublicApi проекта

    ```
    dotnet user-secrets init
    ```

1. Определение строки подключения

    ```
    dotnet user-secrets set "UserDataConnection" "Server=(localdb)\\mssqllocaldb;Integrated Security=true;Initial Catalog=Synword.UserDataDb"
    ```

## Создание БД

1. Для начала создадим миграцию в окне Package Manager Console
с помощью команды:

    ```
    add-migration InitialMigration -Context UserDataContext -OutputDir "Data/Migrations"
    ```
1. Применение миграции:

    ```
    update-database -Context UserDataContext
    ```
1. IdentityDB:

    ```
    add-migration InitialMigration -Context AppIdentityDbContext -OutputDir "Identity/Migrations"
    ```
    
    ```
    update-database -Context AppIdentityDbContext
    ```
## JWT
1. Добавьте закрытый ключ для подписи JWT

    ```
    dotnet user-secrets set "JWT_SECRET_KEY" "test"
    ```
## Domain database model

![db_screen](docs/db_model.png)