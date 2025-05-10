# 📄 PDF Birleştirme Aracı (WinForms - iText7)

Bu Windows Forms projesi, seçilen bir klasördeki `.pdf` dosyalarını alfabetik sırayla **birleştirip** tek bir PDF dosyası olarak kaydeden bir masaüstü uygulamasıdır. Uygulama, [iText7](https://itextpdf.com/) kütüphanesini kullanarak PDF işlemlerini gerçekleştirir.

## 🛠 Özellikler

- Seçilen klasördeki tüm `.pdf` dosyalarını listeler.
- `Birleştirilmiş Pdf.pdf` dosyasını hariç tutar.
- Alfabetik sıralama ile birleştirme yapar.
- İşlem sırasında progress bar ile ilerleme gösterir.
- İşlem sonunda klasörü otomatik olarak açar.
- Dosya başka bir uygulama tarafından kullanılıyorsa kullanıcıyı uyarır.

## 🧰 Kullanılan Teknolojiler

- **.NET Framework / WinForms**
- **iText7** – PDF okuma ve birleştirme işlemleri için
- **C#** – Uygulama dili

## 📦 Kurulum
### 🔹 1. Hazır Kurulum (Tavsiye Edilen)

- En güncel sürüm için GitHub'daki [**Releases**](https://github.com/Burak-Ozlece/PdfBirlestirici/releases) sayfasına gidin.
- `Releases.zip` dosyasını indirin.
- İndirdiğiniz dosyayı çalıştırarak kurulumu tamamlayın.
- Uygulama masaüstüne veya başlat menüsüne otomatik olarak kısayol oluşturacaktır.

---

### 🔹 2. Kaynak Koddan Derlemek (Geliştiriciler İçin)

1. Depoyu klonlayın veya ZIP olarak indirin:
   ```bash
   git clone https://github.com/Burak-Ozlece/PdfBirlestirici.git

2. Visual Studio ile aç.

3. Projeyi derle ve çalıştır (`F5`)

## 🚀 Kullanım

1. Uygulamayı başlat.
2. `Klasör Seç` butonuna tıkla ve PDF dosyalarının bulunduğu klasörü seç.
3. Listelenen dosyaları kontrol et.
4. `PDF'leri Birleştir` butonuna tıkla.
5. Seçilen dosyalar `Birleştirilmiş Pdf.pdf` adıyla klasöre kaydedilir.

## ⚠️ Uyarılar

- Birleştirme işlemi sırasında herhangi bir PDF dosyası açık ise işlem başarısız olur.
- Aynı klasördeki `Birleştirilmiş Pdf.pdf` dosyası varsa, işlem öncesinde otomatik olarak silinir.
- Sadece `.pdf` uzantılı dosyalar listelenir ve işlenir.

## 📸 Ekran Görüntüsü
> Arayüzün ekran görüntüsü

![arayüzün ekran görüntüsü](https://github.com/user-attachments/assets/e8172a82-bcad-4a0e-9c74-713088d81f7f)

## 📄 Lisans

Bu proje açık kaynaklıdır ve [MIT Lisansı](https://github.com/Burak-Ozlece/PdfBirlestirici/blob/master/LICENSE.txt) ile lisanslanmıştır.

---

