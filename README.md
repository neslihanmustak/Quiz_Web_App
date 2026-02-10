# QuizWebApp

ASP.NET MVC 5 ile geliştirilmiş basit bir “memory/quiz kartları” uygulaması.

## Özellikler

- Kullanıcı kayıt ve giriş akışı
- Kategori seçimi
- Kart ekleme, güncelleme, silme
- Kartları sırayla gösterme (doğru/yanlış akışı)

## Teknoloji

- ASP.NET MVC 5
- .NET Framework 4.7.2
- Entity Framework 6 (Database-First, EDMX)
- SQL Server / LocalDB

## Kurulum

Bu proje **.NET Framework** kullandığı için Windows gerektirir.

Gereksinimler:
- Windows
- Visual Studio (2019/2022)
- .NET Framework 4.7.2
- SQL Server veya LocalDB

Adımlar:
1. `MvcQuizSonDeneme/MvcQuizSonDeneme.sln` dosyasını Visual Studio ile aç.
2. NuGet paketlerini restore et.
3. `MvcQuizSonDeneme/MvcQuizSonDeneme/Web.config.example` dosyasını referans al.
4. `MvcQuizSonDeneme/MvcQuizSonDeneme/Web.config` içinde bağlantı cümlesini kendi DB bilgilerinle güncelle.
5. IIS Express ile çalıştır.

## Veritabanı

Bu proje Database-First model (EDMX) kullanır. Aşağıdaki tablolar beklenir:
- `kullaniciBilgileri`
- `soruKategori`
- `SoruKarti`

Alanlar (temel):
- `SoruKarti`: `id`, `soru`, `cevap`, `kullaniciId`, `kategori`

Not: Şema mevcut değilse, kendi DB’ni oluşturup EDMX’i güncellemen gerekir.

## Güvenlik ve Yapılandırma

`Web.config` içinde gerçek bağlantı bilgisini **commit etme**.
Repo’da yalnızca güvenli varsayılanlar vardır. Kendi makinen için:
1. `MvcQuizSonDeneme/MvcQuizSonDeneme/Web.config.example` dosyasını örnek al.
2. `MvcQuizSonDeneme/MvcQuizSonDeneme/Web.config` içinde gerçek DB bilgilerini kullan.

## Klasör Yapısı

- `MvcQuizSonDeneme/MvcQuizSonDeneme/Controllers`
- `MvcQuizSonDeneme/MvcQuizSonDeneme/Models`
- `MvcQuizSonDeneme/MvcQuizSonDeneme/Views`



