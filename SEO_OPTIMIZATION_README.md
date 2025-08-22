# SEO Optimizasyonu - Cephe Modelleme

Bu dosya, Cephe Modelleme web sitesi için yapılan SEO optimizasyonlarını açıklamaktadır.

## Yapılan SEO İyileştirmeleri

### 1. Sitemap.xml
- Dinamik sitemap.xml oluşturuldu
- Tüm önemli sayfalar dahil edildi
- Her sayfa için uygun priority ve changefreq değerleri ayarlandı
- URL: `https://www.cephemodelleme.com/sitemap.xml`

### 2. Robots.txt
- Arama motorları için robots.txt dosyası oluşturuldu
- Admin alanları engellendi
- Sitemap referansı eklendi
- Crawl delay ayarlandı

### 3. Meta Tags ve Structured Data
- Her sayfa için özel meta tag'ler eklendi
- Open Graph ve Twitter Card meta tag'leri
- JSON-LD structured data eklendi
- Canonical URL'ler tanımlandı

### 4. Sayfa Bazlı SEO Optimizasyonları

#### Ana Sayfa (Home)
- Title: "Cephe Modelleme | 3D 2D Mimari Modelleme, Render ve Görselleştirme"
- WebSite structured data eklendi
- SearchAction potential action eklendi

#### Hizmetler Sayfası
- Title: "Hizmetlerimiz | Cephe Modelleme - 3D 2D Mimari Modelleme"
- Service structured data eklendi

#### İletişim Sayfası
- Title: "İletişim | Cephe Modelleme - Bize Ulaşın"
- ContactPage structured data eklendi

#### Galeri Sayfası
- Title: "Galeri | Cephe Modelleme - Projelerimiz ve Çalışmalarımız"
- ImageGallery structured data eklendi

#### Hakkımızda Sayfası
- Title: "Hakkımızda | Cephe Modelleme - Profesyonel Mimari Modelleme"
- AboutPage structured data eklendi

#### Fiyatlandırma Sayfası
- Title: "Fiyatlandırma | Cephe Modelleme - Uygun Fiyatlı 3D Modelleme"
- PriceSpecification structured data eklendi

#### Belgeler Sayfası
- Title: "Belgeler | Cephe Modelleme - Sertifikalar ve Belgelerimiz"
- WebPage structured data eklendi

### 5. Teknik SEO İyileştirmeleri

#### Middleware
- SeoMiddleware eklendi
- Güvenlik header'ları eklendi
- Cache control header'ları eklendi

#### Web.config (IIS)
- URL rewrite kuralları eklendi
- HTTPS yönlendirmesi
- www kaldırma
- Trailing slash kaldırma
- Sıkıştırma ayarları

#### .htaccess (Apache)
- URL rewrite kuralları
- Cache control
- Sıkıştırma
- Güvenlik header'ları

### 6. PWA Desteği
- manifest.json dosyası oluşturuldu
- PWA meta tag'leri eklendi
- Apple mobile web app desteği

### 7. Performans İyileştirmeleri
- Static dosyalar için cache header'ları
- Gzip sıkıştırma
- Image optimization için cache
- CSS/JS dosyaları için uzun süreli cache

## Google Search Console'a Eklenecekler

1. Sitemap.xml URL'sini ekleyin: `https://www.cephemodelleme.com/sitemap.xml`
2. robots.txt URL'sini ekleyin: `https://www.cephemodelleme.com/robots.txt`
3. Google Analytics kodunu ekleyin
4. Google Search Console doğrulama kodunu ekleyin

## Yapılması Gerekenler

### 1. Google Analytics
```html
<!-- Google Analytics kodu eklenecek -->
<script async src="https://www.googletagmanager.com/gtag/js?id=GA_MEASUREMENT_ID"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
  gtag('config', 'GA_MEASUREMENT_ID');
</script>
```

### 2. Google Search Console
- Google Search Console'a site ekleyin
- Doğrulama kodunu meta tag olarak ekleyin
- Sitemap.xml'i submit edin

### 3. Bing Webmaster Tools
- Bing Webmaster Tools'a site ekleyin
- Doğrulama kodunu meta tag olarak ekleyin

### 4. Sosyal Medya
- Facebook, Instagram, LinkedIn linklerini güncelleyin
- Sosyal medya meta tag'lerini güncelleyin

### 5. İçerik Optimizasyonu
- Her sayfa için unique ve kaliteli içerik ekleyin
- Anahtar kelime yoğunluğunu optimize edin
- İç linkleme yapısını iyileştirin

## SEO Skorunu Artırmak İçin Ek Öneriler

1. **Sayfa Hızı**: Resimleri optimize edin, CDN kullanın
2. **Mobile Friendly**: Responsive tasarımı test edin
3. **Core Web Vitals**: LCP, FID, CLS metriklerini iyileştirin
4. **İçerik**: Düzenli olarak yeni içerik ekleyin
5. **Backlink**: Kaliteli backlink'ler oluşturun
6. **Local SEO**: Google My Business hesabı oluşturun
7. **Schema Markup**: Daha fazla structured data ekleyin

## Test Araçları

- Google PageSpeed Insights
- Google Search Console
- GTmetrix
- Pingdom
- WebPageTest
- Schema.org Validator

Bu optimizasyonlar ile SEO skorunuzun 85'ten daha yüksek seviyelere çıkması beklenmektedir.
