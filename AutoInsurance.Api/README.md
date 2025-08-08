# Auto Insurance Policy System

## Overview
Sistem manajemen polis asuransi mobil sederhana menggunakan Clean Architecture dengan 4 layer utama:
- **AutoInsurance.Api**: Minimal API backend (.NET 9)
- **AutoInsurance.Application**: Business logic dan use cases
- **AutoInsurance.Domain**: Entities dan aturan domain
- **AutoInsurance.Infrastructure**: Database dan repository (EF Core + SQLite)

## Fitur Utama
- CRUD polis asuransi (Create, Read, Update, Delete)
- Nomor polis otomatis dibuat unik
- Kalkulasi premi otomatis (Premium = TSI × Rate / 100)
- Pencarian polis berdasarkan nama pemilik dan merk mobil
- Menggunakan database SQLite ringan
- Dokumentasi API dengan Swagger UI

## Persyaratan
- .NET 9 SDK
- SQLite (opsional untuk inspeksi database)
- Node.js & npm (jika ada frontend React)

## Setup dan Jalankan

1. Clone repository dan masuk ke folder project  
   `git clone https://github.com/enrilefadhli/AutoInsuranceApp.git`  
   `cd autoinsurance`

2. Restore dependencies dan build project  
   `dotnet restore`  
   `dotnet build`

3. Buat migration dan update database  
   `dotnet ef migrations add InitialCreate --project AutoInsurance.Infrastructure --startup-project AutoInsurance.Api`  
   `dotnet ef database update --project AutoInsurance.Infrastructure --startup-project AutoInsurance.Api`

4. Jalankan API  
   `dotnet run --project AutoInsurance.Api`

5. Akses Swagger UI untuk testing API di  
   `https://localhost:5001/swagger`

## Penjelasan Entitas Policy (Domain)

- **Id**: int, primary key  
- **PolicyNumber**: string, nomor unik polis  
- **BeneficiaryName**: string, nama pemilik polis  
- **CarBrand**: string, merek mobil  
- **CarType**: string, tipe mobil  
- **TSI**: decimal, Total Sum Insured (dalam Rupiah)  
- **PremiumRate**: decimal, persentase rate premi  
- **PremiumAmount**: decimal, hasil kalkulasi premi (TSI × Rate)  
- **StartDate** dan **EndDate**: tanggal mulai dan akhir polis  
- **CreatedAt**, **CreatedBy**, **UpdatedAt**, **UpdatedBy**: informasi audit

## Arsitektur dan Alur

- Layer **Api** menerima request, expose endpoint Minimal API  
- Layer **Application** meng-handle business logic dan validasi  
- Layer **Domain** menyimpan entitas dan aturan domain  
- Layer **Infrastructure** bertanggung jawab akses data menggunakan EF Core dan repository pattern

## Kalkulasi Premi

Formula untuk menghitung premi:  
**PremiumAmount = TSI × (PremiumRate / 100)**

Contoh:  
Jika TSI = Rp120.000.000 dan PremiumRate = 2.0%,  
maka premi adalah Rp2.400.000

## Lisensi

MIT License
