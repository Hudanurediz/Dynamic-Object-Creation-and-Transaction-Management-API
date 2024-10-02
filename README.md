# Dinamik Nesne Oluşturma API'si

## Genel Bakış

Bu proje, **.NET** ve **Entity Framework** kullanarak tasarlanmış bir **Dinamik Nesne Oluşturma API'si** uygulamasıdır. API, kullanıcıların çeşitli dinamik nesneleri (ürünler, siparişler, müşteriler vb.) oluşturmasına, yönetmesine ve manipüle etmesine olanak tanır. Her bir CRUD işlemi tek endpoint üzerinden gerçekleştirilmektedir ve bu işlem tüm türleri kapsamaktadır. Proje, **Onion Architecture** tasarım prensipleri kullanılarak geliştirilmiştir ve bu sayede esnek, ölçeklenebilir ve bakımı kolay bir yapı sağlanmıştır.

## Özellikler

1. **Dinamik Nesne Oluşturma**
   - Kullanıcılar, API talepleri göndererek yeni nesneler ve alanlar oluşturabilir.
   - Tüm nesneler, merkezi bir dinamik tabloda saklanır.
   - Nesne yapıları esnek olup, türlerine göre değişiklik göstermektedir.

2. **Tek Endpoint ile CRUD İşlemleri**
   - Tüm CRUD işlemleri (Create, Read, Update, Delete) tek bir API endpoint üzerinden yönetilmektedir.
   - API, dinamik alanları kabul ederek kullanıcıların esnek bir şekilde nesne oluşturmasını sağlar.
   - İşlem türleri, istek türüne (GET, POST, PUT, DELETE) göre belirlenir.

3. **İşlem Yönetimi**
   - Ana nesne (örneğin, sipariş) ve ilgili alt nesnelerin (örneğin, sipariş ürünleri) oluşturulması atomik bir işlem olarak gerçekleştirilir.
   - Tüm işlemlerin başarılı bir şekilde tamamlanması için işlem yönetimi mantığı uygulanmakta; bu, ya tüm nesnelerin başarıyla oluşturulması ya da hata durumunda hiçbir nesnenin oluşturulmaması anlamına gelir.

4. **Hata Yönetimi**
   - Geçersiz nesne yapısı, eksik alanlar ve veritabanı bağlantı sorunları gibi durumlar için kapsamlı hata yönetimi sağlanır.
   - API, hata durumunda anlamlı mesajlar ile geri dönüş yapar.

5. **Veri Doğrulama**
   - API, her nesne türü için gerekli alanların varlığını dinamik olarak doğrular.
   - Doğrulama mantığı, nesne türüne bağlı olarak esneklik gösterir.

6. **Handler'lar**
   - Her işlem için ayrı handler'lar kullanılarak, kodun okunabilirliği ve test edilebilirliği artırılmıştır. Bu yapıyla, işlemler arasında ayrım yapılması ve yönetilmesi kolaylaştırılmıştır.
