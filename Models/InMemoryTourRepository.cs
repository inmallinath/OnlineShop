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
            new Tour{ TourId = 1, Name = "Canadian F1 GP", ShortDescription = "F1 Event at Montreal", 
                        LongDescription = "Occurs once in a Calendar Year and held at the vibrant city of Montreal. This Canadian event will bring all canadian and north american motor sports enthusiasts together. The tour price includes event tickets for all three days - Warm Up, Qualification and Race Day", 
                        Price = 1250.65M, Category = _categoryRepository.Categories.ToList()[0], 
                        ImageUrl="http://i65.tinypic.com/2ajtg8y.jpg",
                        SeatsAvailable = false, IsTourOfTheWeek = false,
                        ImageThumbnailUrl="http://i67.tinypic.com/flvjwn.jpg"},
            new Tour{TourId = 2, Name = "Alaskan Wilderness", ShortDescription = "Get Adventurous at Alaska",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer finibus luctus turpis, nec fermentum ante. Sed iaculis tempus mauris, et varius ante molestie vitae. Aliquam lobortis quam eu risus venenatis, vitae vehicula dolor varius. Suspendisse potenti.",
                        Price = 2230.15M, Category = _categoryRepository.Categories.ToList()[1],
                        ImageUrl="http://i65.tinypic.com/25jb7sm.png",
                        SeatsAvailable = true, IsTourOfTheWeek = true,
                        ImageThumbnailUrl="http://i66.tinypic.com/sphzx4.png"},
            new Tour{TourId = 3, Name = "NickelBack Tour", ShortDescription = "Follow your favorite rock band with this tour package",
                        LongDescription = "Ut magna nunc, rutrum et leo non, commodo scelerisque neque. Nulla et purus eu tellus iaculis placerat. Nulla eleifend gravida nisi non aliquet. Morbi sit amet quam egestas, efficitur erat eget, bibendum turpis. Aliquam erat volutpat.",
                        Price = 3275.80M, Category = _categoryRepository.Categories.ToList()[2],
                        ImageUrl="http://i66.tinypic.com/33dzia9.jpg",
                        SeatsAvailable = true, IsTourOfTheWeek = false,
                        ImageThumbnailUrl="http://i68.tinypic.com/2cdtjmf.jpg"},
            new Tour{TourId = 4, Name = "Seeking God", ShortDescription = "Seeking God - Spirituality",
                        LongDescription = "Ut magna nunc, rutrum et leo non, commodo scelerisque neque. Nulla et purus eu tellus iaculis placerat. Nulla eleifend gravida nisi non aliquet. Morbi sit amet quam egestas, efficitur erat eget, bibendum turpis. Aliquam erat volutpat.",
                        Price = 1875.35M, Category = _categoryRepository.Categories.ToList()[3],
                        ImageUrl="http://i67.tinypic.com/10rtjrp.jpg",
                        SeatsAvailable = true, IsTourOfTheWeek = false,
                        ImageThumbnailUrl="http://i68.tinypic.com/o8yr92.jpg"}
        };

        public IEnumerable<Tour> TourOfTheWeek => throw new NotImplementedException();

        public Tour GetTourById(int tourId)
        {
            throw new NotImplementedException();
        }
    }
}