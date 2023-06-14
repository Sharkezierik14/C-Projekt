namespace Contracts
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Member
    {
        [Key]
        public int Id { get; set; }
        
        [RegularExpression(@"^[a-zA-ZáéíóöőúüűÁÉÍÓÖŐÚÜŰ ]+$", ErrorMessage = "Special characters are not allowed.")]
        public string Name { get; set; }
        public string Address { get; set; }
        public int YearOfBirth { get; set; }

    }
}
