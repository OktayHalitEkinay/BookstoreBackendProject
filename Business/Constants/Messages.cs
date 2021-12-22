using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime ="Sistem bakımda";
        public static string ProductsListed ="Ürünler listelendi";
        public static string ProductCountOfCategoryError="Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="Yetkiniz yok.";

        internal static string AuthorUpdated="Author updated.";
        internal static string AuthorDeleted="Author deleted.";
        internal static string AuthorAdded="Author added.";
        internal static string LanguageAdded;
        internal static string LanguageUpdated;
        internal static string PublisherAdded;
        internal static string PublisherDeleted;
        internal static string PublisherUpdated;
        internal static string BookAdded;
        internal static string BookDeleted;
        internal static string BookUpdated;
        internal static string BookAuthorUpdated;
        internal static string BookAuthorDeleted;
        internal static string BookAuthorAdded;

        public static string LanguageDeleted { get; internal set; }
    }
}
