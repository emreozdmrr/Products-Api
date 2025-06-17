
# <p align="center"> PROJELER HAKKINDA </p>
<br>
<p>Merhaba, bu repoda JWT tabanlı bir ASP.NET Core Web API ve bu API'yı tüketmek için Bootstrap ile hazırlanmış arayüze sahip ASP.NET Core Web uygulaması oluşturduk.</p>

<p>API'ya ait endpoint'leri Postman ve hazırladığımız Web App ile test ettik.</p>





## <p align="center">KULLANILAN KÜTÜPHANELER VE TASARIM KALIPLARI</p>
<p>Web API projesi Onion mimarisi ile geliştirilmiştir. Kullanılan katmanlar şunlardır:

- Core
- Infrastructure
- Prensentation(API)
</p>

<p>
    Ayrıca projede veritabanı sorguları ve komutlarının yönetiminin kolaylaştırılması için <b>CQRS</b> tasarım deseni ve <b>MediatR</b> kütüphanesi kullanılmıştır.
</p>
<p>JWT tabanlı authentication için <b>JwtBearer</b> kütüphanesinden yararlanılmıştır.</p>

<p>Entity-Dto dönüşümleri için <b>AutoMapper</b> kütüphanesinden faydalanılmıştır.</p>


## <p align="center"> UYGULAMA DETAYLARI </p>


- <p>Web API projesinde Products ve Categories olmak üzere 2 adet entity bulunmaktadır.<br> Bu entityler için API'da rol bazlı GET-POST-PUT-DELETE metodları bulunmaktadır.<br> Kullanıcılar oluşturduğumuz Web App ile uygulamaya giriş yaparak backend tarafında içerisinde ExpireDate ve Role gibi bilgilerin bulunduğu bir Jwt oluşturmaktadır. Admin rolüne sahip kullanıcılar Login olarak oluşturdukları Jwt ile Categories ve Products için CRUD işlemlerini yapabilmekte, Member rolüne sahip kullanıcılar oluşturdukları Jwt ile yalnızca Products için CRUD işlemleri yapabilmektedir.</p>

## <p align="center">ENDPOINTS </p>




- http://localhost:5222/api/Auth/Login

<br>

 <p>Username ve Password bilgileri ile Login endpoint'ine başarılı bir POST isteği gerçekleştirdiğimizde kullanıcı bilgilerine göre Admin yada Member rolüne sahip bir JWT oluşturmaktadır.</p>



- http://localhost:5222/api/categories
<br>

<p>Admin rolüne sahip ve geçerlilik süresi dolmamış bir JWT'ı header'a ekleyerek categories endpoint'ine GET isteği gerçekleştirdiğimizde bize Kategori listesini dönecektir.</p>

- http://localhost:5222/api/categories/id
<br>
<p>Yine Admin rolüne sahip bir JWT ile id bilgisi ile categories/id endpoint'ine GET isteği gerçekleştirdiğimizde ilgili entity mevcut ise 200 kodu ile bize Kategori bilgilerini dönecektir.</p>


- http://localhost:5222/api/categories
<br>
<p>Admin rolüne sahip JWT ile categories endpoint'ine Definition bilgisi ile POST isteği gerçekleştirdiğimizde yeni Kategori oluşturulacaktır.</p>


- http://localhost:5222/api/categories
<br>
<p>Admin rolüne sahip JWT ile categories endpoint'ine Id ve Definition bilgileri ile PUT isteği gerçekleştirdiğimizde Id bilgisi gönderilen Kategori'nin Definition bilgisi güncellenecektir.</p>


- http://localhost:5222/api/categories/id
<br>
<p>Admin rolüne sahip JWT ile categories/id endpoint'ine geçerli bir id bilgisi ile DELETE isteği gerçekleştirdiğimizde id bilgisi gönderilen Kategori silinecektir.</p>


- http://localhost:5222/api/products
<br>
<p>Admin yada Member rolüne sahip bir JWT ile products endpoint'ine GET isteği gönderdiğimizde bize Ürün listesini dönecektir.</p>


- http://localhost:5222/api/products/id
<br>
<p>Admin yada Member rolüne sahip bir JWT ile products/id endpoint'ine geçerli bir id bilgisi ile GET isteği gönderdiğimizde bize ilgili id'ye ait Ürün bilgisini döndürecektir.</p>


- http://localhost:5222/api/products
<br>
<p>Admin yada Member rolüne sahip JWT ile isteğin Body'sine geçerli Name, Stock, Price ve CategoryId bilgileri eklenerek products endpoint'ine POST isteği gönderdiğimizde Body'ye eklenen bilgiler ile yeni Ürün oluşturulacaktır.</p>


- http://localhost:5222/api/products
<br>
<p>Admin yada Member rolüne sahip JWT ile Id, Name, Stock, Price ve CategoryId bilgileri ile products endpoint'ine PUT isteği gönderdiğimizde ilgili Id'ye ait Ürün'ün bilgileri güncellenecektir.</p>


- http://localhost:5222/api/products/id
<br>
<p>Admin yada Member rolüne sahip bir JWT ile products/id endpoint'ine geçerli bir id bilgisi ile DELETE isteği gönderdiğimizde ilgili id'ye ait Ürün silinecektir.</p>


<br>

<p>Projeler için eğitimlerinden faydalandığım Eğitmen: Yavuz Selim KAHRAMAN - Udemy</p>








