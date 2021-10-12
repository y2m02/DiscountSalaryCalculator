using AutoMapper;
using SalaryDiscountCalculatorWeb.Models.Salary;

namespace SalaryDiscountCalculatorWeb.Helpers
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<SalaryResponse, SalaryViewModel>()
                .ForMember(
                    member => member.SalaryPerMonth,
                    option => option.MapFrom(mapping => mapping.SalaryPerMonth.ToString("N"))
                )
                .ForMember(
                    member => member.SalaryPerYear,
                    option => option.MapFrom(mapping => mapping.SalaryPerYear.ToString("N"))
                )
                .ForMember(
                    member => member.SalaryPerMonthAfterAfpAndSfsDiscounts,
                    option => option.MapFrom(mapping => mapping.SalaryPerMonthAfterAfpAndSfsDiscounts.ToString("N"))
                )
                .ForMember(
                    member => member.SalaryPerYearAfterAfpAndSfsDiscounts,
                    option => option.MapFrom(mapping => mapping.SalaryPerYearAfterAfpAndSfsDiscounts.ToString("N"))
                )
                .ForMember(
                    member => member.NetSalaryPerMonth,
                    option => option.MapFrom(mapping => mapping.NetSalaryPerMonth.ToString("N"))
                )
                .ForMember(
                    member => member.NetSalaryPerYear,
                    option => option.MapFrom(mapping => mapping.NetSalaryPerYear.ToString("N"))
                )
                .ForMember(
                    member => member.SfsPercent,
                    option => option.MapFrom(mapping => mapping.SfsPercent.ToString("N4"))
                )
                .ForMember(
                    member => member.SfsDiscountPerMonth,
                    option => option.MapFrom(mapping => mapping.SfsDiscountPerMonth.ToString("N"))
                )
                .ForMember(
                    member => member.SfsDiscountPerYear,
                    option => option.MapFrom(mapping => mapping.SfsDiscountPerYear.ToString("N"))
                )
                .ForMember(
                    member => member.AfpPercent,
                    option => option.MapFrom(mapping => mapping.AfpPercent.ToString("N4"))
                )
                .ForMember(
                    member => member.AfpDiscountPerMonth,
                    option => option.MapFrom(mapping => mapping.AfpDiscountPerMonth.ToString("N"))
                )
                .ForMember(
                    member => member.AfpDiscountPerYear,
                    option => option.MapFrom(mapping => mapping.AfpDiscountPerYear.ToString("N"))
                )
                .ForMember(
                    member => member.IsrDiscountPerMonth,
                    option => option.MapFrom(mapping => mapping.IsrDiscountPerMonth.ToString("N"))
                )
                .ForMember(
                    member => member.IsrDiscountPerYear,
                    option => option.MapFrom(mapping => mapping.IsrDiscountPerYear.ToString("N"))
                )
                .ForMember(
                    member => member.TotalDiscountPerMonth,
                    option => option.MapFrom(mapping => mapping.TotalDiscountPerMonth.ToString("N"))
                )
                .ForMember(
                    member => member.TotalDiscountPerYear,
                    option => option.MapFrom(mapping => mapping.TotalDiscountPerYear.ToString("N"))
                )
                .ForMember(
                    member => member.SalaryPerMonthInGfSystem,
                    option => option.MapFrom(mapping => mapping.SalaryPerMonthInGfSystem.ToString("N"))
                )
                .ForMember(
                    member => member.FortnightSalaryInGfSystem,
                    option => option.MapFrom(mapping => mapping.FortnightSalaryInGfSystem.ToString("N"))
                )
                .ForMember(
                    member => member.FortnightSalaryInGfSystem2,
                    option => option.MapFrom(mapping => mapping.FortnightSalaryInGfSystem2.ToString("N"))
                );
        }
    }
}
