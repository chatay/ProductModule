## **Projenin Kurulumu**
1. Projeyi indirdikten sonra `DigitArc.ProductModule.DataAccess\appsettings.json` ve  `DigitArc.ProductModule.WebApiService\appsettings.json` dosya yolundan veritabanı ayarlarınızı yapınız. 
2. Eğer ef migrations tanımlı değilse, DigitArc.ProductModule.DataAccess Package Manager Console  açıp `dotnet tool install --global dotnet-ef` komutunu çalıştırın.
3. Yine DigitArc.ProductModule.DataAccess Package Manager Console'unda `dotnet ef migrations add firstMigration` komutunu çalıştırın.
4. Sonrasında ise `dotnet ef database update` komutunu çalıştırarak veritabanınızı oluşturmuş olacaksınız.
5. **Swagger** 📝 ile test edebilirsiniz. Örn:  `localhost:(port)/swagger`  
