using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineShop.Models
{
    public static class DbInitializer
    {
        public static void seed(IApplicationBuilder appBuilder)
        {
            AppDbContext context = appBuilder.ApplicationServices
                                   .GetRequiredService<AppDbContext>();

            
            
            if(!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c=>c.Value));
            }

            if(!context.Tours.Any())
            {
                context.AddRange
                (
                    new Tour{ TourId = 1, Name = "Canadian F1 GP", ShortDescription = "F1 Event at Montreal", 
                        LongDescription = "Occurs once in a Calendar Year and held at the vibrant city of Montreal. This Canadian event will bring all canadian and north american motor sports enthusiasts together. The tour price includes event tickets for all three days - Warm Up, Qualification and Race Day", 
                        Price = 1250.65M, Category = Categories["Sports"], 
                        ImageUrl="http://i65.tinypic.com/2ajtg8y.jpg",
                        SeatsAvailable = false, IsTourOfTheWeek = false,
                        ImageThumbnailUrl="http://i67.tinypic.com/flvjwn.jpg"},
                    new Tour{TourId = 2, Name = "Alaskan Wilderness", ShortDescription = "Get Adventurous at Alaska",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer finibus luctus turpis, nec fermentum ante. Sed iaculis tempus mauris, et varius ante molestie vitae. Aliquam lobortis quam eu risus venenatis, vitae vehicula dolor varius. Suspendisse potenti.",
                        Price = 2230.15M, Category = Categories["Adventure"],
                        ImageUrl="http://i65.tinypic.com/25jb7sm.png",
                        SeatsAvailable = true, IsTourOfTheWeek = true,
                        ImageThumbnailUrl="http://i66.tinypic.com/sphzx4.png"},
                    new Tour{TourId = 3, Name = "NickelBack Tour", ShortDescription = "Follow your favorite rock band with this tour package",
                        LongDescription = "Ut magna nunc, rutrum et leo non, commodo scelerisque neque. Nulla et purus eu tellus iaculis placerat. Nulla eleifend gravida nisi non aliquet. Morbi sit amet quam egestas, efficitur erat eget, bibendum turpis. Aliquam erat volutpat.",
                        Price = 3275.80M, Category = Categories["Musical"],
                        ImageUrl="http://i66.tinypic.com/33dzia9.jpg",
                        SeatsAvailable = true, IsTourOfTheWeek = false,
                        ImageThumbnailUrl="http://i68.tinypic.com/2cdtjmf.jpg"},
                    new Tour{TourId = 4, Name = "Seeking God", ShortDescription = "Seeking God - Spirituality",
                        LongDescription = "Ut magna nunc, rutrum et leo non, commodo scelerisque neque. Nulla et purus eu tellus iaculis placerat. Nulla eleifend gravida nisi non aliquet. Morbi sit amet quam egestas, efficitur erat eget, bibendum turpis. Aliquam erat volutpat.",
                        Price = 1875.35M, Category = Categories["Spiritual"],
                        ImageUrl="http://i67.tinypic.com/10rtjrp.jpg",
                        SeatsAvailable = true, IsTourOfTheWeek = false,
                        ImageThumbnailUrl="http://i68.tinypic.com/o8yr92.jpg"}
                );
            }
            context.SaveChanges();
        }
        private static Dictionary<string, Category> categories;
            public static Dictionary<string, Category> Categories
            {
                get
                {
                    if (categories == null)
                    {
                        var  categoryList = new Category[]
                        {
                            new Category{ CategoryId = 1, CategoryName = "Sports", Description = "All Sports related tours"},
                            new Category{ CategoryId = 2, CategoryName = "Adventure", Description = "All tours related to adventure"},
                            new Category{ CategoryId = 3, CategoryName = "Musical", Description = "Music to the core"},
                            new Category{ CategoryId = 4, CategoryName = "Spiritual", Description = "Seeking God"}
                        };

                        categories = new Dictionary<string, Category>();

                        foreach(var category in categoryList)
                        {
                            categories.Add(category.CategoryName, category);
                        }
                    }
                
                    return categories;
                }
            }
        }
    }