# Covid-19
## Proje Hakkında
- Korona salgınının farkındalığına katkıda bulunmak için **DotNet Core3.1** - **Python3.8.1** - **jquery3.4.1** - **MSSQL (SQL Server 2014)** - **JavaScript** - **Html** - **CSS** 
Teknolojilerini ve Ülkelerin Covid19 Vaka, İyileşen Sayısı, Ölüm verilerini kullanarak hazırladığım projedir.
- **Johns Hopkins School of Public Health** tarafından günlük **CSV** olarak yayınlanan dataları ve bazı siyasetçilerin tweetlerini çekerek python ile MSSQL'e aktardım.
Anlık dataları ise **rapidapi** ve **collectapi** üzerinden çektim. 
- Projenin çalıştırılabilmesi için öncelikle proje dosyaları içerisindeki csv dosyalarını python kodlarını çalıştırarak MSSQL'e aktarmalısnız.
## Database Yapısı
1. ConfirmTable
   - id (Identity - Is Identity yes) 
   - Province (nvarchar(150) Allow Nulls)
   - Country (nvarchar(150))
   - Date (datetime Allow Nulls)
   - TotalCase (float Allow Nulls)

2. RecoveredTable
   - id (Identity - Is Identity yes) 
   - Province (nvarchar(150) Allow Nulls)
   - Country (nvarchar(150))
   - Date (datetime Allow Nulls)
   - Recovered (float Allow Nulls)
 
3. DeathTable
   - id (Identity - Is Identity yes) 
   - Province (nvarchar(150) Allow Nulls)
   - Country (nvarchar(150))
   - Date (datetime Allow Nulls)
   - Death (float Allow Nulls)
   
4. TweetDataTable
   - id (Identity - Is Identity yes) 
   - Country (nvarchar(150))
   - Lat (float)
   - Long (float)
