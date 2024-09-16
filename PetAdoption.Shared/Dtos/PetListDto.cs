using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Shared.Dtos
{
    public class PetListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image {  get; set; }

        public double Price { get; set; }

        public string Breed { get; set; }
    }
}
