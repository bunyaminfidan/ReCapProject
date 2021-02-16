﻿using System;
using System.Collections.Generic;
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
        public static string GetCarsByBrandIdListed = "Arabaların fiyatları listelendi";
        public static string GetCarsByColorIdListed = "Arabaların renkleri listelendi";

    }
}
