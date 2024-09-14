namespace PetFamily.Backend.Domain.Models.Pet;

/// <summary>
/// https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/builtin-types/enum#enumeration-types-as-bit-flags
/// https://learn.microsoft.com/ru-ru/dotnet/api/system.enum.hasflag?view=net-8.0
/// Статус помощи - Нуждается в помощи/Ищет дом/Нашел дом
/// Ищет дом/Нашел дом обьеденены в флаг IsHomeLess
/// 
///  Проверка например на нуждается в помощи будет производится
///		так			petInfo.HasFlag(PetHelpStatusEnum.IsNeedHelp)
///			или		petInfo & PetHelpStatusEnum.IsNeedHelp == PetHelpStatusEnum.IsNeedHelp
/// </summary>
[Flags]
public enum PetHelpStatusEnum
{
	None       = 0b_0000_0000,  // нуждается ни в какой в помощи
	IsNeedHelp = 0b_0000_0001, //если нуждается в помощи то устанавливаем в true
	IsHomeLess = 0b_0000_0010, //если бездомный то флаг устанавливаем в true
}

