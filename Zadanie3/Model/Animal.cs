using System.ComponentModel.DataAnnotations;

namespace Zadanie3.Model
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Area {  get; set; }
    }
}
