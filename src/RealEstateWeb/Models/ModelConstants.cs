using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWeb.Models
{
    public static class ModelConstants
    {
        public const int NamesLength = 25;
        public const int AddressLength = 40;
        public const int PhoneLength = 10;
        public const int SubjectLength = 25;
        public const int MessageLength = 2500;
        public const int TitleMaxLength = 25;
        public const double DistanceMinValue = 0.01;
        public const double PriceMinValue = 0.01;
        public const double PriceMaxValue = double.MaxValue;
        public const double AreaMinValue = 0.01;
        public const double AreaMaxValue = double.MaxValue;


        public const string PhoneErrorMessage = "Телефония номер трябва да бъде 10 цифри!";
        public const string TitleErrorMessage = "Заглавието може да бъде до 25 символа!";
        public const string NameErrorMessage = "Името и Фамилията могат да бъдат максимум по 25 символа!";
        public const string AddressErrorMessage = "Всеки елемент на адреса може да бъде максимум по 25 символа!";
        public const string SubjectErrorMessage = "Темата може да бъде максимум 25 символа!";
        public const string RequiredField = "Задължително поле";
    }
}
