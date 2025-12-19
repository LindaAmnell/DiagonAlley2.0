
# 🧙‍♂️ Diagon Alley – Blazor Store Application (MongoDB)
![Diagon Alley Landing Page](wwwroot/images/DiagonAlley.jpg)

## 📖 About the Project
This project was developed as part of **Lab 3 – Application with MongoDB (Code First)**.

**Diagon Alley** is a Blazor Server application inspired by the magical wizarding world.
Users (wizards) can sign in, browse magical products, and shop in an online store.
An administrator wizard can manage the product assortment.

All data is stored in **MongoDB Atlas**, and the application uses a **Code First** approach.

---

## ✨ Features
- 🧙 Wizard login system (admin & regular user)
- 🛍️ Browse magical products (wands, potions, broomsticks)
- 🛒 Shopping cart functionality
- 👑 Admin-only product management
- 💾 MongoDB Atlas database
- 🌱 Automatic database seeding

---

## 🛠️ Technologies Used
- C# (.NET / Blazor Server)
- MongoDB Atlas
- MongoDB.Driver
- Dependency Injection
- Code First database design

---

## 📦 Database Structure
The application uses two MongoDB collections:

- **Products** – all store products
- **Wizards** – users and administrators

Administrators and regular users are represented by the same `Wizard` model.
Administrative privileges are handled using an `IsAdmin` flag.

---

## ▶️ How to Run the Application

### 1️⃣ Clone the repository
```bash
git clone <repository-url>
```

---

### 2️⃣ Configure MongoDB connection
The MongoDB connection string is **not included in the repository** for security reasons.

Open the file:

```
appsettings.json
```

Add your own MongoDB Atlas connection string:

```json
{
  "MongoDB": {
    "ConnectionString": "YOUR_CONNECTION_STRING_HERE",
    "DatabaseName": "DiagonAlleyDB"
  }
}
```

---

### 3️⃣ Run the application
```bash
dotnet run
```

---

## 🌱 Automatic Database Seeding
On first run (in **Development mode**), the application automatically:

- Seeds products into the database (if the collection is empty)
- Creates wizard accounts (if no wizards exist)

### Default Wizards (Auto Created)

**Admin Wizard**
- Name: `Albus Dumbledore`
- Password: `elderwand`
- Role: Admin

**Regular Wizard**
- Name: `Harry Potter`
- Password: `expelliarmus`
- Role: User

---

## 🔐 Security Notes
- No database credentials are stored in GitHub
- MongoDB connection strings are configured locally
- Admin access is controlled via application logic

---
