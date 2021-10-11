using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models.ViewModels
{
    public class ProductCategoriesViewModel
    {
        public List<string> genre = new List<string>() { "RPG", "Simulation", "Strategy","Shooter" };
        public List<string> features = new List<string>() { "Single Player", "VR", "Multiplayer", "Controller Support" };
        public List<string> platform = new List<string>() { "Windows", "MacOS" };       
    }
}