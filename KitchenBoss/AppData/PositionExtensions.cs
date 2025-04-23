using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace KitchenBoss.AppData
{
    public enum Positions
    {
        [Display(Name = "Менеджер")]
        Manager,
        [Display(Name = "Шеф-повар")]
        ChefCook,
        [Display(Name = "Официант")]
        Waitor,
        [Display(Name = "Повар")]
        Cook,
        [Display(Name = "Повар-стажер")]
        CookTrainee
    }

    public static class PositionExtensions
    {
        public static string GetPositionDisplayName(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var displayAttribute = fieldInfo?.GetCustomAttributes(typeof(DisplayAttribute), false)
                .OfType<DisplayAttribute>()
                .FirstOrDefault();
            return displayAttribute?.Name ?? enumValue.ToString();
        }
    }
}