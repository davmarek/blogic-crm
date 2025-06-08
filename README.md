# BlogicCMR (alias Contracter)

CRUD aplikace vytvořená v .NET s použitím Razor pro frontend a databází SQLite.  
Autorem projektu je **David Marek**.

## 🔧 Spuštění projektu a migrací

### Požadavky
- .NET SDK 9.0 nebo vyšší
- `dotnet-ef` nástroj:  
```bash
  dotnet tool install --global dotnet-ef
```

### Krok 1: Spuštění migrací
Před spuštěním aplikace je třeba provést migrace databáze

```bash
dotnet ef database update
```

> SQLite databáze bude vytvořena v root adresáři projektu v souboru `database.db`.

### Krok 2: Spuštění aplikace

Spustíme aplikaci pomocí:
```bash
dotnet run
```

---

## 📦 Funkcionalita aplikace

Aplikace obsahuje **CRUD operace** pro správu kontraktů a jejich vztahů s klienty, konzultanty a institucemi.
Dále umožňuje **vyhledávání smlouv, klientů a konzultantů**; **export dat do CSV** a je **responzivní** díky Bootstrap.

### Entity

- `Client`
  - reprezentuje zákazníka
  - obsahuje informace jako FirmName, LastName, Email, Phone, BirthDate, BirthNumber, Address
- `Consultant`
  - reprezentuje konzultanta
  - obsahuje informace stejné informace jako Client
- `Institution`
  - reprezentuje instituci
  - obsahuje pouze Name (pro jednoduchost)
- `Contract`
  - reprezentuje smlouvu
  - obsahuje datumy Created, Effective, Closed
  - obsahuje vztahy na `Client`, `Admin`, `Consultants` a `Institution`

> `Admin` u Contract je `Consultant`, který slouží jako správce smlouvy a je povinný. `Consultants` jsou účastníci smlouvy, kterých může být více.


### 🔍 Funkce: Search
Umožňuje vyhledávání textu v kontraktech, klientech a konzultantech.

### 🗄️ Funkce: Uložení do CSV
Umožňuje export dat vybrané entity.

---

## 📁 Struktura projektu

```
BlogicCMR/
│
├── Models/             # Definice entit (Contract, Client, Consultant, Institution) a view modelů
├── Database/           # Obsahuje AppDbContext a jednoduchý Faker pro seedování dat
├── Migrations/         # Generované migrace
├── Controllers/        # Controllery pro CRUD operace
├── Views/              # Razor Views pro zobrazení dat
└── Repositories/       # Odělení logiky pro přístup k datům
```

---

# David Marek – 2025
- Osobní portfolio: [https://davmarek.cz](https://davmarek.cz)
- Ukázková Weather aplikace v React:
  - repo: [https://github.com/davmarek/ap4tw-weather](https://github.com/davmarek/ap4tw-weather)
  - deployment: [https://ap4tw-weather.vercel.app](https://ap4tw-weather.vercel.app)



