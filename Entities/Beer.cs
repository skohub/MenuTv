using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MenuTv
{
    public class Beer
    {
        public int Id {get; set;}

        [Required(ErrorMessage = "Название должно быть заполнено")]
        [DisplayName("Название")]
        public string Name {get; set;}

        [DisplayName("Описание")]
        public string Comment {get; set;}

        [DisplayName("Цена")]
        public int Price {get; set;}

        [DisplayName("В наличии")]
        public bool Available {get; set;} = true;
    }
}