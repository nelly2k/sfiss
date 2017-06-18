using System.Collections.Generic;
using ExerciseAPIService.Constant;

namespace ExerciseAPIService.Model
{
    public class Exercise: Entity
    {
       
        public string[] OtherTitles { get; set; }
        public Complexity? Complexity { get; set; }
        public ICollection<Muscle> Muscles { get; set; }
        public ICollection<Equipment> Equipments { get; set; }
        public string Notes { get; set; }
    }
}