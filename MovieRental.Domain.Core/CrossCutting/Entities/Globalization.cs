using System;

namespace MovieRental.Domain.Core.CrossCutting.Entities
{
    public static class Globalization
    {
        public static string NameIsEmpty() => "O nome não pode ser vazio";
        public static string NameNeedHave20() => "O nome precisa ter 20 caracteres";
        public static string DescriptionIsEmpty() => "A descrição não pode ser vazia";

        public static string CategoryInvalid() => "A categoria está inválida";

        public static string DescriptionNeedHave30() => "A categoria precisa ter 30 caracteres";
        public static string IdFilmIsInvalid() => "O Id do film está inválido";
    }
}
