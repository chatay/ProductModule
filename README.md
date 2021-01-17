## **Projenin Kurulumu**
1. Projeyi indirdikten sonra `DigitArc.ProductModule.DataAccess\appsettings.json` dosya yolundan veritabanı ayarlarınızı yapınız. 
2. DigitArc.ProductModule.DataAccess Package Manager Console'u açıp `dotnet ef migrations add firstMigration` komutunu çalıştırın.
3. Sonrasında ise `dotnet ef database update` komutunu çalıştırarak veritabanınızı oluşturmuş olacaksınız.
4. **Swagger** 📝 ile test edebilirsiniz. Örn:  `localhost:(port)/swagger`  

## **Projede kullanıdığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız?**

Repository pattern kullandım. İleride eklenecek tablolar ve class için tekrar tekrar kod yazımı yerine, bir tane class üzerine generic olarak yapıp diğer
class'lara aynı operasyonların sağlanması. 

## Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek yazabilir misiniz?

1. Net Core
2. Mssql
3. Codefirst

**.Net Core:** .net core ile tecrübem, daha öncesinde kullandığımız wcf servislerini .net core taşıma aşamasında oldu. .Net core yavaş yavaş firmada etkinlik kazanmaya başladı.
.Net core ile middleware yapısını, bir diğer deyişle Configure alt yapısını kullanarak request'lerin ilk orada düzenlenebileceğini,
inprocess ve outof process kullanarak Kestrel server kullanılacağını, statik dosyaların kullanımı için middleware useStaticFiles() gibi eklemelerinin yapılması gerektiğini öğrendim.

**.Mssql:** .mssql ile 3 senedir tecrübem var. Transaction tablosu yönetimi, index, trigger, join, store proc gibi tecrübelerim oldu.

**.Codefirst:** bu zamana kadar projelerimizde databasefirst çoğunlukla kullandığımız halde, code first tecrübemde oldu.

## Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz?

* Daha doğru ve düzenli bir şekilde test edebilmek adına swagger eklerdim.
* Identity kütüphanesi ile authorization yapısı
* fluentvalidation eklerdim. Data Annotationlar kullanımı güzel fakat bazen tek sorumluluk kurallarını bozuyorlar.
* automapper kullanarak model entity ler ile viewmodel entity ler arasında entegrasyon sağlardım.

- Eklemek istediğiniz bir yorumunuz var mı?
Geliştirmeleri 3 tane branch e yaydım. Ardından development ve master ile merge ledim.
