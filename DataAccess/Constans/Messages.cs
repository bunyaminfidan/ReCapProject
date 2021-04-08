using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DataAccess.Constans
{
    public class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";

        public static string CarNameInValid = "Araç ismi geçersiz, en Az 3 karakter olmalıdır.";
        public static string CarPriceInValid = "Araç kiralama fiyatı 0'dan büyük olmalıdır.";

        public static string CarListed = "Arabalar listelendi";
        public static string CarByIdDetailListed = "Seçili araba detayları listelendi";
        public static string GetCarByIdListed = "Seçili araba listelendi";
        public static string GetCarDetailsListed = "Araba detayları listelendi";
        public static string GetCarsByBrandIdListed = "Arabaların markaları listelendi";
        public static string GetCarsByColorIdListed = "Arabaların renkleri listelendi";
        public static string CarByBrandIdDetailListed = "Seçili marka araba detayları listelendi";
        public static string CarByColorIdDetailListed = "Seçili renk araba detayları listelendi";
        public static string GetByFilterCar = "Arabalar filtrelendi.";
        public static string CarFindekScoreInValid = "Arabanın findeks skoru 0-1900 arasında olmalıdır.";
    






        public static string BrandAdded = "Araba markası eklendi";
        public static string BrandUpdated = "Araba markası güncellendi";
        public static string BrandDeleted = "Araba markası silindi";
        public static string GetAllBrand = "Araba markaları listelendi";
        public static string GetByBrandId = "Seçili araba markası listelendi";

        public static string ColorAdded = "Araba rengi eklendi";
        public static string ColorUpdated = "Araba rengi güncellendi";
        public static string ColorDeleted = "Araba rengi silindi";
        public static string GetAllColorListed = "Araba renkleri listelendi";
        public static string GetByColorIdListed = "Seçili Araba rengi listelendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silinidi";
        public static string GetAllUserListed = "Kullanıcılar listelendi";
        public static string GetByUserIdListed = "Seçili kullanıcı listelendi";
        public static string UserFindekScoreInValid = "Kullanıcının Findeks Scoru 0-1900 arasında olmalıdır.";

        public static string RentalAdded = "Yeni araba kiralama eklendi";
        public static string RentalUpdated = "Araba kiralama güncellendi";
        public static string RentalDeleted = "Araba kiralama silinidi";
        public static string GetRentalDetail = "Kiralamalar listelendi";
        public static string GetByCarIdRentalDetail = "Seçili kiralık araba detayları listelendi";
        public static string GetByCustomerIdRentalDetail = "Seçili müşterinin kiralama detayları listelendi";
        public static string GetByRentalId = "Seçili kiralama listelendi";
        public static string RentalReturnDateInValid = "Araç teslim tarihi boş olamaz. Araç teslim alma tarihinden küçük olamaz";
        public static string CarNotReceived = "Araç teslim alınmadığı için şuan kiralanamaz";
        public static string GetByRentDateRentalDetail = "Araç müşteriye teslim edilme tarihine göre listelendi";
        public static string GetByReturnDateRentalDetail = "Araç müşteriden teslim alınma tarihine göre listelendi";
        public static string RentalFindeksInValid = "Araçı kiralabilmek için yeterli Findeks puanınız bulunmuyor";




        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silinidi";
        public static string GetAllCustomerListed = "Müşteriler listelendi";
        public static string GetByCustomerIdListed = "Seçili müşteri listelendi";
        public static string GetCustomerByUserIdListed = "Seçili müşteri listelendi";
        public static string GetCustomerDetail = "Müşteri detayları getirildi";


        public static string FailedCarImageLimiit = "Araç maximum resim ekleme limitine ulaştı";
        public static string CarImageAdded = "Araç resim bilgileri yüklendi";
        public static string CarImageUpdated = "Araç resim bilgileri güncellendi";
        public static string CarImageDeleted = "Araç resim bilgileri silindi";
        public static string GetAllCarImage = "Araç resim bilgileri listelendi";
        public static string GetByIdCarImage = "Seçili araç resim bilgileri listelendi";
        public static string GetByCarIdCarImage = "Seçili aracın tüm resim resim bilgileri listelendi";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";


        public static string FakeCardAdded = "Demo kart eklendi";
        public static string FakeCardUpdated = "DEmo kart günncellendi";
        public static string FakeCardDeleted = "Demo kart silindi";
        public static string FakeCardGetAll = "Demo kartlar listelendi";
        public static string FakeCardGetById = "Seçili demo kart listelendi";
        public static string GetByCardNumber = "Kart numarasına göre kart getirildi.";




        public static string RegisteredCreditCardAdded = "Kredi kartı eklendi";
        public static string RegisteredCreditCardUpdated = "Kredi kartı güncellendi";
        public static string RegisteredCreditCardDeleted = "Kredi kartı silindi";
        public static string GetAllRegisteredCreditCard = "Kredi kartları listelendi";
        public static string GetByRegisteredCreditCard = "Seçili kredi kartı listelendi";
        public static string GetByUserIdRegisteredCreditCard = "Seçili kullanıcının kredi kartları listelendi";
    }
}
