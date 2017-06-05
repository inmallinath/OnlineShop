using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop
{
    public class InMemoryTourRepository : ITourRepository
    {
        private ICategoryRepository _categoryRepository;

        public InMemoryTourRepository(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Tour> Tours => new List<Tour>{
            new Tour{ TourId = 1, Name = "Canadian F1 Grand Prix", ShortDescription = "F1 Event at Montreal", 
                        LongDescription = "Occurs once in a Calendar Year and held at the vibrant city of Montreal. This Canadian event will bring all canadian and north american motor sports enthusiasts together. The tour price includes event tickets for all three days - Warm Up, Qualification and Race Day", 
                        Price = 1250.65M, Category = _categoryRepository.Categories.ToList()[0],
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e2/Canadian_GP_start_2008.jpg/1024px-Canadian_GP_start_2008.jpg", 
                        SeatsAvailable = false, IsTourOfTheWeek = false,
                        ImageThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/58/2012_Canadian_Grand_Prix_Fernando_Alonso_Ferrari_F2012-02.jpg/1280px-2012_Canadian_Grand_Prix_Fernando_Alonso_Ferrari_F2012-02.jpg"},
            new Tour{TourId = 2, Name = "Alaskan Wilderness", ShortDescription = "Get Adventurous at Alaska",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer finibus luctus turpis, nec fermentum ante. Sed iaculis tempus mauris, et varius ante molestie vitae. Aliquam lobortis quam eu risus venenatis, vitae vehicula dolor varius. Suspendisse potenti.",
                        Price = 2230.15M, Category = _categoryRepository.Categories.ToList()[1],
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/AK_koppen.svg/931px-AK_koppen.svg.png",
                        SeatsAvailable = true, IsTourOfTheWeek = true,
                        ImageThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/AK_koppen.svg/931px-AK_koppen.svg.png"},
            new Tour{TourId = 3, Name = "NickelBack Canadian Tour", ShortDescription = "Follow your favorite rock band with this tour package",
                        LongDescription = "Ut magna nunc, rutrum et leo non, commodo scelerisque neque. Nulla et purus eu tellus iaculis placerat. Nulla eleifend gravida nisi non aliquet. Morbi sit amet quam egestas, efficitur erat eget, bibendum turpis. Aliquam erat volutpat.",
                        Price = 3275.80M, Category = _categoryRepository.Categories.ToList()[2],
                        ImageUrl="https://upload.wikimedia.org/wikipedia/commons/c/ca/Nickelback_%40_Perth_Arena_%2817_11_2012%29_%288261243464%29.jpg",
                        SeatsAvailable = true, IsTourOfTheWeek = false,
                        ImageThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/c/ca/Nickelback_%40_Perth_Arena_%2817_11_2012%29_%288261243464%29.jpg"},
            new Tour{TourId = 4, Name = "Hare Rama Hare Krishna", ShortDescription = "Seek spirituality with a visit to the societies of Hare Rama and Hare Krishna in North America",
                        LongDescription = "Ut magna nunc, rutrum et leo non, commodo scelerisque neque. Nulla et purus eu tellus iaculis placerat. Nulla eleifend gravida nisi non aliquet. Morbi sit amet quam egestas, efficitur erat eget, bibendum turpis. Aliquam erat volutpat.",
                        Price = 1875.35M, Category = _categoryRepository.Categories.ToList()[3],
                        ImageUrl="https://upload.wikimedia.org/wikipedia/commons/4/44/Hare_Krishna_in_Helsinki_C_IMG_8105.JPG",
                        SeatsAvailable = true, IsTourOfTheWeek = false,
                        ImageThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/4/44/Hare_Krishna_in_Helsinki_C_IMG_8105.JPG"}
        };

        public IEnumerable<Tour> TourOfTheWeek => throw new NotImplementedException();

        public Tour GetTourById(int tourId)
        {
            throw new NotImplementedException();
        }
    }
}