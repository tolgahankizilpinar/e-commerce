using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleEcommerce.MvcWeb.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Category> kategoriler = new List<Category>()
            {
                new Category(){Name="Televizyon", Description="Televizyon Ürünleri"},
                new Category(){Name="Bilgisayar", Description="Bilgisayar Ürünleri"},
                new Category(){Name="Elektronik", Description="Elektronik Ürünleri"},
                new Category(){Name="Telefon", Description="Telefon Ürünleri"},
                new Category(){Name="Beyaz Eşya", Description="Beyaz Eşya Ürünleri"}
            };

            foreach (var item in kategoriler)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();


            List<Product> urunler = new List<Product>()
            {
                new Product(){ Name="Vestel 32H9500 HD 32Inc 82 Ekran Uydu Alıcılı Smart LED TV",Description="Pixellence ile Kusursuz Görüntüleme,Yüksek Çözünürlük ve Ekran Paylaşımı,LED görüntü teknolojisini kullanan ve gerçeğe en yakın görüntüyü sunmayı amaçlayan akıllı televizyon",Price=2500,Stock=300,IsApproved=true,CategoryId=1, IsHome=true,Image="vest1.jpg"},
                new Product(){ Name="Toshiba 32LL3A63DT 32Inc 80 Ekran Uydu Alıcılı Full HD Smart LED TV",Description="Ekran Ebatı32 inç / 81 cm,Dahili Uydu Alıcı Var,Çözünürlük (Piksel)1920 x 1080,Ekran Formatı 16:9,Çözünürlük	Full HD",Price=5000,Stock=200,IsApproved=true,CategoryId=1, IsHome=true,Image="toshibaTv.jpg"},
                new Product(){ Name="LG 43UM7100PLB 43 Inc Uydu Alıcılı 4K Ultra HD Smart LED TV",Description="Çözünürlük (Piksel)	3840 x 2160,Dahili Uydu Alıcı	Var,Giriş / Çıkış Portları	Component, Djital Ses (Optik), USB,HDMI Girişleri	3, İşletim Sistemi	webOS,Ekran Ebatı	43 inç / 109 cm",Price=7000,Stock=150,IsApproved=false,CategoryId=1, IsHome=true,Image="lgTv.jpg"},
                 new Product(){ Name="Dijitsu DJTV43F 43 Inc 109 Ekran Uydu Alıcılı Full HD LED TV",Description="Çözünürlük: 1920 x 1080 (Full HD), Ekran Ebadı: 43 inç / 109 cm, Girişler: 3 Adet HDMI Girişi x 2 Adet USB Girişi,Garanti Tipi	Resmi Distribütör Garantili, Renk	Siyah",Price=4000,Stock=0,IsApproved=false,CategoryId=1, IsHome=true,Image="dijitsuTv.jpg"},
                 new Product(){ Name="Toshiba 24WL2A63DT 24 Inc 61 Ekran Uydu Alıcılı Smart LED TV",Description="Çözünürlük (Piksel)	1366 x 768,HDMI Girişleri	2, Ekran Ebatı	24 inç / 61 cm, Wi-Fi	Var, Scart	Yok",Price=4500,Stock=250,IsApproved=true,IsHome=true,CategoryId=1,Image="toshibaTv2.jpg"},



                 new Product(){ Name="Asus X509JB-BR015 Intel Core i5 1035G1 8GB 512GB SSD",Description="İşlemci:Intel® Core™ i5-1035G1 İşlemci İşletim Sistemi: Without OS Bellek: 4GB DDR4 on board +4GB DDR4 SO - DIMM Grafik: NVIDIA GeForce MX110 Depolama:512GB M.2 NVMe™ PCIe® 3.0  SSD Ekran:15.6' Narrow border//200nits//HD (1366 x 768) 16:9//Anti Glare//NTSC: 45% Video Kamera: VGA Web Camera(Fixed type) Network: Wi - Fi 5(802.11ac) + Bluetooth 4.1(Dual band) 1 * 1 Kart okuyucu:Micro SD kart okuyucu",Price=5000,Stock=400,IsApproved=true,CategoryId=2, IsHome=true,Image="asus1.jpg"},
                 new Product(){ Name="HP Pavilion 15-CS3007NT Intel Core i5 1035G1 8GB 512GB SSD MX250 Windows 10 Home ",Description="Bellek Hızı:2666 MHz,Ekran Kartı İşlemcisi:Nvidia GeForce GTX,İşlemci Tipi:Intel Core i5,Max Ekran Çözünürlüğü	1920 x 1080,USB 3.1	1 Adet,Ram Tipi	DDR4,İşletim Sistemi	Windows 10 Home",Price=6000,Stock=0,IsApproved=true,CategoryId=2, IsHome=true,Image="hp2.jpg"},
                 new Product(){ Name="MSI GF63 Thin 9SCXR-618XTR Intel Core i5 9300H 8GB 256GB SSD GTX1650 ",Description="İşlemci: Intel® Core™ i5-9300H (8M Cache, 2.40 GHz, up to 4.10 GHz),Ekran Kartı: GTX1650, GDDR6 4GB,HDD: 256GB NVMe PCIe SSD,Maksimum Hafıza: Max 64GB,İşletim Sistemi: FreeDOS",Price=8000,Stock=200,IsApproved=true,IsHome=true,CategoryId=2,Image="msi2.jpg"},
                 new Product(){ Name="Lenovo V15-ADA AMD Ryzen 3 3250U 8GB 256GB SSD Freedos ",Description="Bellek Hızı	2400 MHz,Ekran Boyutu	15,6 inç,Ekran Kartı İşlemcisi	AMD Radeon,Ekran Özelliği Full HD,İşlemci Cache	4 MB L3 Cache,İşlemci Tipi	AMD Ryzen 3,Maksimum İşlemci Hızı	3,5 GHz,SSD Kapasitesi	256 GB",Price=4000,Stock=150,IsApproved=true,IsHome=true,CategoryId=2,Image="lenovo1.jpg"},
                 new Product(){ Name="MSI P65 Creator 9SE-409TR i7-9750H 2.60GHz 16GB 512GB SSD 6GB GeForce RTX 2060 15,6Inc Full HD Win10 Home Notebook ",Description="İşlemci: Intel® Core™ i7-9750H,İşletim Sistemi: Windows 10 Home Advanced,Chipset: Intel HM370,HDD 512GB NVMe PCIe SSD,Pil: 4cells , Li-Polymer, 82Whr,Hafıza: DDR IV 8GB*2 (2666MHz),Ağırlık: 1.88kg",Price=10000,Stock=100,IsApproved=true,CategoryId=2,Image="laptop_msi.jpg"},



                 new Product(){ Name="Yamaha Mcr N 670D Bluetooth Wifi Musiccast Müzik Seti Black",Description="Subwoofer Gücü (W)	100 W,Renk	Siyah,Toplam Güç (W)	260 W, Çoklu Bağlantı8, Bağlantı TipiKablosuz, Bluetooth Bağlantı Var",Price=9000,Stock=0,IsApproved=false,CategoryId=3,Image="elek1.jpg"},
                 new Product(){ Name="Nikon D90 18-55mm Lens Dijital SLR Fotoğraf Makinesi",Description="12,3 megapiksel DX biçimli CMOS görüntü sensörü,EXPEED görüntü işleme sistemi, High ISO (200-3200) ışık duyarlılığı,Yüz Tanıma Sistemli Sahne Tanıma Sistemi,  Multi-CAM100 11 noktalı AF sistemi,3 inç 920k noktalı ve yüksek çözünürlüklü LCD ekranın 170 derecelik resim açısı",Price=4000,Stock=200,IsApproved=true,CategoryId=3, IsHome=true,Image="elek2.jpg"},
                 new Product(){ Name="Xiaomi Mijia M365 Elektrikli Scooter - Siyah",Description="Ağırlık 12.5 kg,Maksimum yük	100kg,Optimum yükseklik	120 ~ 200cm,Fren mesafesi	4 metre,Şarj süresi	Yaklaşık 5 saat,Akünün şarj sınırlama gerilimi	42V,Enerji yapısı	18650 yüksek güçlü lityum pil  30",Price=4000,Stock=250,IsApproved=true,CategoryId=3, IsHome=true,Image="elek3.jpg"},
                 new Product(){ Name="Xerox B205V_NI Wi-Fi Çok Fonksiyonlu Laser Yazıcı",Description="Baskı Kalitesi (Siyah)	1200 x 1200 DPI,Dahili Bellek	256 MB,Kağıt Çıkış Kapasitesi	120 Sayfa,Wi-Fi	Var,İşletim Sistemi	Linux, Mac OS, Windows,Ethernet Bağlantısı	Var,Fotoğraf Baskısı	Var,Dakikadaki Siyah/Beyaz Baskı Hızı(Max)	30 Sayfa",Price=2000,Stock=300,IsApproved=true,IsHome=true,CategoryId=3,Image="elek4.jpg"},
                 new Product(){ Name="Dji Mavic 2 Pro ve Akıllı Kumanda 16GB + Extra Çift Bataryalı Combo",Description="Sensör	1 CMOS, Etkin Pikseller	20 milyon,Foto Formatı	JPEG / DNG (RAW),MAVIC 2 ZOOM KAMERA,Maksimum Alçalış Hızı	3 m/s (S-mode),Batarya	3950 mAh,Algılama Sistemi	Çok Yönlü Engel Algılama",Price=22000,Stock=100,IsApproved=true,IsHome=true,CategoryId=3,Image="elek5.jpg"},



                  new Product(){ Name="iPhone 11 Pro Max 64 GB",Description="Bağlantı Hızı	42.2 Mbps,Dahili Hafıza	64 GB,Ekran Boyutu	6,5 inç,Ekran Tipi	OLED Multi-Touch,İşletim Sistemi	iOS 13,Kamera Çözünürlüğü Aralığı	8 - 12,9 MP,Kamera Zoom (Yakınlaştırma)	3x, Var,Mobil Bağlantı Hızı	4.5G,Pil Türü	Li-Ion,Ön (Selfie) Kamera	12 MP,Pil Gücü Aralığı	3500 - 3999 mAh,RAM Kapasitesi	4 GB RAM",Price=13000,Stock=200,IsApproved=true,CategoryId=4, IsHome=true,Image="tel1.jpg"},
                  new Product(){ Name="Oppo Reno2 Z 128 GB",Description="Bağlantı Hızı	42.2 Mbps,Arttırılabilir Hafıza	256 GB'a kadar,Ekran Boyutu	6,53 inç,Ekran Çözünürlüğü 1080 x 2340,İşlemci Kapasitesi	2,2 GHz Dual Core + 2,0 GHz Hexa Core,Kamera Çözünürlüğü	48 MP + 8 MP + 2 MP + 2 MP,Mobil Bağlantı Hızı	4.5G,NFC (Yakın Alan İletişimi)	Var,Ön (Selfie) Kamera	16 MP,RAM Kapasitesi	8 GB RAM",Price=4000,Stock=300,IsApproved=true,CategoryId=4, IsHome=true,Image="tel2.jpg"},
                  new Product(){ Name="Samsung Galaxy Note 10 256 GB",Description="Bağlantı Hızı	42.2 Mbps,Dahili Hafıza	256 GB,Ekran Boyutu	6,3 inç,Ekran Tipi	OLED Dynamic AMOLED,NFC (Yakın Alan İletişimi)	Var,Ön (Selfie) Kamera	10 MP,Pil Gücü	3500 mAh,RAM Kapasitesi	8 GB RAM,Kamera Zoom (Yakınlaştırma)	3x, Var",Price=7000,Stock=500,IsApproved=true,IsHome=true,CategoryId=4,Image="tel3.jpg"},
                  new Product(){ Name="Huawei Y7 2019 Dual Sim 32 GB ",Description="Arttırılabilir Hafıza	512 GB'a kadar,Bağlantı Hızı	42.2 Mbps,Ekran Boyutu	6,26 inç,Ekran Çözünürlüğü	720 x 1520,İşlemci Kapasitesi	1,8 GHz Octa Core,Kamera Çözünürlüğü	13 MP + 2 MP,Ön (Selfie) Kamera	8,0 MP,RAM Kapasitesi	3 GB RAM,Şarj Girişi	Micro USB",Price=2000,Stock=150,IsApproved=true,CategoryId=4,Image="tel4.jpg"},
                  new Product(){ Name="Xiaomi Redmi 8 64 GB ",Description="Arttırılabilir Hafıza	1 TB’a kadar,Bağlantı Hızı	42.2 Mbps,Dahili Hafıza	64 GB,Ekran Boyutu	6,26 inç,Ekran Çözünürlüğü	720 x 1520,İşlemci Kapasitesi	2,0 GHz Dual Core + 1,45 GHz Hexa Core,Kamera Çözünürlüğü	12 MP + 2 MP,Kamera Zoom (Yakınlaştırma)	3x, Var,Pil Gücü	5000 mAh,RAM Kapasitesi	4 GB RAM",Price=3000,Stock=250,IsApproved=true,IsHome=true,CategoryId=4,Image="tel5.jpg"}
            };

            foreach (var item in urunler)
            {
                context.Products.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}